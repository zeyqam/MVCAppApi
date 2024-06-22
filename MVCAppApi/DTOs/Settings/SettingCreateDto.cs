using FluentValidation;

namespace MVCAppApi.DTOs.Settings
{
    public class SettingCreateDto
    {
        
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class SettingCreateDtoValidator : AbstractValidator<SettingCreateDto>
    {
        public SettingCreateDtoValidator()
        {
            RuleFor(x => x.Value).NotNull().WithMessage("Title is  required");
            

        }
    }
}
