using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace MVCAppApi.DTOs
{
    public class SliderEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }
    public class SliderEditDtoValidator : AbstractValidator<SliderEditDto>
    {
        public SliderEditDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is  required:please add title");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");

        }
    }
}
