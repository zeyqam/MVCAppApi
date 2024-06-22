using FluentValidation;

namespace MVCAppApi.DTOs.Settings
{
    public class SettingEditDto
    {
        public string Value { get; set; }
    }


    public class SettingEditDtoValidator : AbstractValidator<SettingEditDto>
    {
        public SettingEditDtoValidator()
        {
            RuleFor(x => x.Value).NotNull().WithMessage("Value is  required");


        }
    }
}
