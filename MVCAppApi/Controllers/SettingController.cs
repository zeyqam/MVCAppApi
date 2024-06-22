using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Settings;
using MVCAppApi.Services;
using MVCAppApi.Services.Interfaces;

namespace MVCAppApi.Controllers
{
   
    public class SettingController : BaseController
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SettingCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _settingService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _settingService.GetAllAsync());
        }
        [HttpPut("{id}")]
        
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody]SettingEditDto request)
        {
           

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _settingService.EditAsync(id, request);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _settingService.GetById(id));
        }
    }
}
