
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Users;
using SeaBreeze.Service.DTOS.Account;
using SeaBreeze.Service.DTOS.Consumer;
using SeaBreeze.Service.DTOS.User;
using SeaBreeze.Service.Enums;
using SeaBreeze.Service.Helpers.TokenService;
using SeaBreeze.Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace SeaBreeze.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly ILocalizing _localizing;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, ITokenService tokenService, AppDbContext context, ILocalizing localizing)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _context = context;
            _localizing = localizing;
        }

        public async Task<string> RegisterConsumer(RegisterConsumerDto consumer)
        {
            var userExists = await _userManager.FindByNameAsync(consumer.PhoneNumber);
            var user = CreateUserFromDto(consumer);
            if (userExists != null)
            {
                var isUnconfirmedUser = await _userManager.IsInRoleAsync(userExists, DefinedUSerRoles.UnConfirmedUser.ToString());

                if (isUnconfirmedUser)
                {
                    // Send confirmation code to the user
                    await SendConfirmationCode(userExists);
                    var roles = await _userManager.GetRolesAsync(user);
                    return _tokenService.CreateToken(user, roles);
                }
                else
                {
                    throw new Exception("User already exists and is confirmed.");
                }
            }
            
            

            await CreateUserAndSendConfirmationCode(user, consumer.PassWord);

            var userRoles = await _userManager.GetRolesAsync(user);
            return _tokenService.CreateToken(user, userRoles);
        }

        public async Task<string> RegisterResident(RegisterResidentDto resident)
        {
            var residentInfo = await _context.ResidentInfos.Where(m => m.FIN == resident.FIN).FirstOrDefaultAsync();

            if (residentInfo is null) throw new Exception("Resident not found");

            var user = _mapper.Map<AppUser>(resident);

            var checkUser = await _userManager.FindByEmailAsync(resident.Email);

            if (checkUser is not null)
            {
                throw new Exception("User is already exist");
            }

            try
            {

                user.UserName = resident.PhoneNumber;
                user.IsResident = true;
                user.Lang = "en";
                var userCreateResult = await _userManager.CreateAsync(user, resident.PassWord);
                if (userCreateResult.Succeeded)
                {
                    await CheckRoleExist(DefinedUSerRoles.UnConfirmedUser.ToString());
                    await _userManager.AddToRoleAsync(user, DefinedUSerRoles.UnConfirmedUser.ToString());
                    await SendConfirmationCode(user);
                    var roles = await _userManager.GetRolesAsync(user);
                    return _tokenService.CreateToken(user, roles);
                }
                else
                {
                    throw new Exception("User already exists and is confirmed.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> Login(UserLoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) throw new Exception("User is not exist");
            
            
            if (user.IsDelete)
            {
                throw new Exception("User is not exist");
            }


            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) throw new Exception("Mail or password is wrong");

            var roles = await _userManager.GetRolesAsync(user);


            if (roles.Contains("Resident"))
            {
                throw new Exception("Please log in as resident");
            }

            if (roles.Contains("UnConfirmedUser"))
            {
                await SendConfirmationCode(user);
            }
            
            return _tokenService.CreateToken(user, roles);
        }

        public async Task<string> LoginResident(UserLoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) throw new Exception("User is not exist");


            if (user.IsDelete)
            {
                throw new Exception("User is not exist");
            }


            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) throw new Exception("Mail or password is wrong");

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains("Resident"))
            {
                throw new Exception("User is not resident");
            }
            
            if (roles.Contains("UnConfirmedUser"))
            {
                await SendConfirmationCode(user);
            }

            return _tokenService.CreateToken(user, roles);
        }

        public async Task<string> ChangeLanguage(string userId, string langCode)
        {
            var user = await _userManager.FindByIdAsync(userId);

            user.Lang = langCode;

            await _userManager.UpdateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            return _tokenService.CreateToken(user, roles);
        }

        public async Task<bool> DeleteAccount(string currentUserId)
        {
            var user = await _userManager.FindByIdAsync(currentUserId);

            user.IsDelete = true;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<GetUserInfoDto> GetUserInfo(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);


            GetUserInfoDto userInfoDto = new GetUserInfoDto()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsResident = user.IsResident,
                FullName = user.FullName
            };

            return userInfoDto;
        }

        public async Task<string> ChangeUserPass(string userId, ChangePasswordDto passwordDto)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.CheckPasswordAsync(user, passwordDto.CurrentPass);

            if (result)
            {
                var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                var passChangeResult = await _userManager.ResetPasswordAsync(user, resetPassToken, passwordDto.NewPass);

                var roles = await _userManager.GetRolesAsync(user);

                return _tokenService.CreateToken(user, roles);
            }
            else
            {
                throw new Exception(_localizing["changePassword"]);
            }
        }

        public async Task<string> ConfirmUSer(string userId, string phoneConfirmToken)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var isTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, phoneConfirmToken);

            if (!isTokenValid)
            {
                throw new Exception("Invalid phone confirmation token.");
            }
            else
            {
                await CheckRoleExist(DefinedUSerRoles.Consumer.ToString());
                await _userManager.AddToRoleAsync(user, DefinedUSerRoles.Consumer.ToString());
            }
            

            // User phone number is confirmed successfully
            // You can perform additional operations here if needed

            var roles = await _userManager.GetRolesAsync(user);
            return _tokenService.CreateToken(user, roles);
        }



        //Private Methods

        #region Private Methods

        private async Task CreateUserAndSendConfirmationCode(AppUser user, string pass)
        {
            var userCreateResult = await _userManager.CreateAsync(user, pass);

            if (userCreateResult.Succeeded)
            {
                await CheckRoleExist(DefinedUSerRoles.UnConfirmedUser.ToString());
                await _userManager.AddToRoleAsync(user, DefinedUSerRoles.UnConfirmedUser.ToString());

                await SendConfirmationCode(user);
            }
            else
            {
                throw new Exception("User registration failed.");
            }
        }
        
        
        private async Task SendConfirmationCode(AppUser user)
        {
            var token = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);
            string smsUrl = $"http://api.msm.az/sendsms?user=seabreeze_api&password=T3gEQBx1&gsm={user.PhoneNumber}&from=Sea Breeze&text={token}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(smsUrl);
                Console.WriteLine(response.ToString());
            }
        }
        
        private AppUser CreateUserFromDto(RegisterConsumerDto consumer)
        {
            var user = _mapper.Map<AppUser>(consumer);
            user.UserName = consumer.PhoneNumber;
            user.Lang = "en";
            user.NormalizedEmail = consumer.Email.ToUpper();
            return user;
        }

        private async Task<bool> CheckRoleExist(string roleName)
        {
            var isRoleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!isRoleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                return result.Succeeded;
            }

            return isRoleExist;
        }
        
        #endregion
        
    }

}
