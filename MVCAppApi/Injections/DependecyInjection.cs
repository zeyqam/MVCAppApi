using FluentValidation.AspNetCore;
using FluentValidation;
using MVCAppApi.Helpers;
using MVCAppApi.DTOs;
using MVCAppApi.Services.Interfaces;
using MVCAppApi.Services;
using MVCAppApi.DTOs.Settings;
using MVCAppApi.DTOs.Abouts;

namespace MVCAppApi.Injections
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddScoped<IValidator<SliderCreateDto>, SliderCreateDtoValidator>();
            services.AddScoped<IValidator<SliderEditDto>, SliderEditDtoValidator>();
            services.AddScoped<IValidator<SettingCreateDto>, SettingCreateDtoValidator>();
            services.AddScoped<IValidator<SettingEditDto>, SettingEditDtoValidator>();
            services.AddScoped<IValidator<AboutCreateDto>, AboutCreateDtoValidator>();
            services.AddScoped<IValidator<AboutEditDto>, AboutEditDtoValidator>();
            

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IAboutService, AboutService>();

            return services;
        }
    }
}
