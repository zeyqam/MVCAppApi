using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace MVCAppApi.DTOs
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is  required");
            RuleFor(x => x.Description).NotEmpty().NotNull();

        }
    }
}
