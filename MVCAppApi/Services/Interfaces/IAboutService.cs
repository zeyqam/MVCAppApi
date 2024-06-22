using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Abouts;

namespace MVCAppApi.Services.Interfaces
{
    public interface IAboutService
    {
        Task CreateAsync(AboutCreateDto request);
        Task<List<AboutDto>> GetAllAsync();
        Task<AboutDto> GetById(int id);
        Task EditAsync(int id, AboutEditDto request);
    }
}
