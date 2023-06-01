using SeaBreeze.Service.DTOS.Story;

namespace SeaBreeze.Service.Interfaces
{
    public interface IStoryService
    {
        Task<List<GetAllStoriesDto>> GetAll();
        Task<StoryDetailDto> GetDetail(string lang, int Id);
    }
}
