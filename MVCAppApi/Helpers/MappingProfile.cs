using AutoMapper;
using MVCAppApi.DTOs;
using MVCAppApi.DTOs.Abouts;
using MVCAppApi.DTOs.Settings;
using MVCAppApi.Models;

namespace MVCAppApi.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<SliderCreateDto, Slider>();
            CreateMap<Slider, SliderDto>();
            CreateMap<SliderEditDto, Slider>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)).
                                               ForMember(dest => dest.Description, opt => opt.Condition(src => src.Description is not null));

            CreateMap<SettingCreateDto, Setting>();
            CreateMap<SettingEditDto, Setting>();
            CreateMap<Setting, SettingDto>();
            CreateMap<AboutCreateDto, About>();
            CreateMap<About, AboutDto>();
            CreateMap<AboutEditDto, About>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)).
                                               ForMember(dest => dest.Description, opt => opt.Condition(src => src.Description is not null));

        }
    }
}
