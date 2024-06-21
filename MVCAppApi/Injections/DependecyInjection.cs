using FluentValidation.AspNetCore;
using FluentValidation;
using MVCAppApi.Helpers;
using MVCAppApi.DTOs;
using MVCAppApi.Services.Interfaces;
using MVCAppApi.Services;

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
            services.AddScoped<ISliderService, SliderService>();

            return services;
        }
    }
}
