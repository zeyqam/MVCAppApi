using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Abouts;
using MVCAppApi.Helpers.Extensions;
using MVCAppApi.Services;
using MVCAppApi.Services.Interfaces;

namespace MVCAppApi.Controllers
{
   
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AboutCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!request.UploadImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return BadRequest(ModelState);
            }

            if (!request.UploadImage.CheckFileSize(500))
            {
                ModelState.AddModelError("Image", "Image size must be max 200 KB");
                return BadRequest(ModelState);
            }
            await _aboutService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _aboutService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _aboutService.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] AboutEditDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (request.UploadImage != null)
            {
                if (!request.UploadImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Input can accept only image format");
                    return BadRequest(ModelState);
                }

                if (!request.UploadImage.CheckFileSize(500))
                {
                    ModelState.AddModelError("Image", "Image size must be max 200 KB");
                    return BadRequest(ModelState);
                }
            }
            await _aboutService.EditAsync(id, request);
            return Ok();
        }
    }
}
