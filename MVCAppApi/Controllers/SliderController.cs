using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAppApi.DTOs;
using MVCAppApi.Helpers.Extensions;
using MVCAppApi.Services.Interfaces;

namespace MVCAppApi.Controllers
{

    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!request.UploadImage.CheckFileType("images"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return BadRequest(ModelState);
            }

            if (!request.UploadImage.CheckFileSize(500))
            {
                ModelState.AddModelError("Image", "Image size must be max 200 KB");
                return BadRequest(ModelState);
            }
            await _sliderService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sliderService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _sliderService.GetById(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SliderEditDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (request.UploadImage != null)
            {
                if (!request.UploadImage.CheckFileType("images"))
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
            await _sliderService.EditAsync(id, request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _sliderService.DeleteAsync(id);
            return Ok();

        }
    }
}
