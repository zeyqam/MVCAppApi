using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVCAppApi.Data;
using MVCAppApi.DTOs;
using MVCAppApi.Helpers.Extensions;
using MVCAppApi.Models;
using MVCAppApi.Services.Interfaces;
using System.IO;

namespace MVCAppApi.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public SliderService(AppDbContext context, IWebHostEnvironment env, IMapper mapper)

        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }
        public async Task CreateAsync(SliderCreateDto request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
            string path = _env.GenerateFilePath( "images", fileName);
            await request.UploadImage.SaveFileToLocalAsync(path);
            request.Image = fileName;

            var mappedData = _mapper.Map<Slider>(request);
            await _context.Sliders.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Sliders.FindAsync(id);
            string path = _env.GenerateFilePath("images", existSlider.Image);
            path.DeleteFileFromLocal();

            _context.Sliders.Remove(existSlider);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, SliderEditDto request)
        {
            var existSlider = await _context.Sliders.FindAsync(id);
            if (request.UploadImage is not null)
            {
                string oldPath = _env.GenerateFilePath("images", existSlider.Image);
                if (!File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }
                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
                string newPath = _env.GenerateFilePath ("images", fileName);
                await request.UploadImage.SaveFileToLocalAsync(newPath);

                request.Image = fileName;
            }
            _mapper.Map(request, existSlider);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SliderDto>> GetAllAsync()
        {
            return _mapper.Map<List<SliderDto>>(await _context.Sliders.AsNoTracking().ToListAsync());
        }

        public async Task<SliderDto> GetById(int id)
        {
            return _mapper.Map<SliderDto>(await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
