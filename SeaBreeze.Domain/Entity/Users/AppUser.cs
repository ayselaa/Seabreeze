using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SeaBreeze.Domain.Entity.Users
{
    public class AppUser : IdentityUser
    {
        [NotNull]
        public string FullName { get; set; }
        public string? FIN { get; set; }
        public string? Lang { get; set; } = "az";
        public bool IsResident { get; set; }
        public bool IsDelete { get; set; }

    }
}
