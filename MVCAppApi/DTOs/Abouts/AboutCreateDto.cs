using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace MVCAppApi.DTOs.Abouts
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }
    public class AboutCreateDtoValidator : AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is  required");
            RuleFor(x => x.Description).NotEmpty().NotNull();

        }
    }
}
