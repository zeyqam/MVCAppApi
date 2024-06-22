using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVCAppApi.Data;
using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Abouts;
using MVCAppApi.Helpers.Extensions;
using MVCAppApi.Models;
using MVCAppApi.Services.Interfaces;

namespace MVCAppApi.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public AboutService ( AppDbContext context,
                              IMapper mapper,
                              IWebHostEnvironment env)
        {
            
           _context = context;
           _mapper = mapper;
            _env = env;
        }
        public async Task CreateAsync(AboutCreateDto request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
            string path = _env.GenerateFilePath("images", fileName);
            await request.UploadImage.SaveFileToLocalAsync(path);
            request.Image = fileName;

            var mappedData = _mapper.Map<About>(request);
            await _context.Abouts.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, AboutEditDto request)
        {
            var existAbout = await _context.Abouts.FindAsync(id);
            if (request.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", existAbout.Image);
                if (!File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }
                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
                string newPath = _env.GenerateFilePath("images", fileName);
                await request.UploadImage.SaveFileToLocalAsync(newPath);

                request.Image = fileName;
            }
            _mapper.Map(request, existAbout);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AboutDto>> GetAllAsync()
        {
            return _mapper.Map<List<AboutDto>>(await _context.Abouts.AsNoTracking().ToListAsync());
        }

        public async Task<AboutDto> GetById(int id)
        {
            return _mapper.Map<AboutDto>(await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
