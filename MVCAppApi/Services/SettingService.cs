using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVCAppApi.Data;
using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Settings;
using MVCAppApi.Models;
using MVCAppApi.Services.Interfaces;

namespace MVCAppApi.Services
{
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SettingService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAsync(SettingCreateDto request)
        {
            var mappedData = _mapper.Map<Setting>(request);
            await _context.Settings.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        

        public async Task EditAsync(int id, SettingEditDto request)
        {
            var existSetting = await _context.Settings.FindAsync(id);
            _mapper.Map(request, existSetting);

            await _context.SaveChangesAsync();
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }

        

        public async Task<SettingDto> GetById(int id)
        {
            return _mapper.Map<SettingDto>(await _context.Settings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
