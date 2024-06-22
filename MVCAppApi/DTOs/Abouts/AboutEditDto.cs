using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace MVCAppApi.DTOs.Abouts
{
    public class AboutEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }
    public class AboutEditDtoValidator : AbstractValidator<AboutEditDto>
    {
        public AboutEditDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title is  required:please add title");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");

        }
    }
}
