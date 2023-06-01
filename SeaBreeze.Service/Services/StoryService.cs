using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SeaBreeze.Domain;
using SeaBreeze.Service.DTOS.Story;
using SeaBreeze.Service.Interfaces;

namespace SeaBreeze.Service.Services
{
    public class StoryService : IStoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<GetAllStoriesDto>> GetAll()
        {
            var stories = await _context.Stories.Select(s => new GetAllStoriesDto
            {
                Id = s.Id,
                BannerImage = s.BannerImage
            }).ToListAsync();

            return stories;
        }

        public async Task<StoryDetailDto> GetDetail(string lang, int Id)
        {
            var story = await _context.Stories
                .Where(s => s.Id == Id)
                .Include(s => s.StoriesTranslates.Where(st => st.LangCode == lang))
                .FirstOrDefaultAsync();

            var storyDetail = _mapper.Map<StoryDetailDto>(story);

            return storyDetail;
        }
    }
}
