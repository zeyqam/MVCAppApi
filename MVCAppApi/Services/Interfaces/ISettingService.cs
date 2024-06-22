using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Settings;
using MVCAppApi.Models;

namespace MVCAppApi.Services.Interfaces
{
    public interface ISettingService
    {
        Task CreateAsync(SettingCreateDto request);
        Task<Dictionary<string, string>> GetAllAsync();
        Task EditAsync(int id, SettingEditDto request);
        Task<SettingDto> GetById(int id);
    }
}
