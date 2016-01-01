using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebVaanoli.Domain;

namespace WebVaanoli
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            // Radio mapping
            Mapper.CreateMap<Radio, ViewModels.Radio.DetailViewModel>();
            Mapper.CreateMap<ViewModels.Radio.EditorViewModel, Radio>();
            Mapper.CreateMap<Radio, ViewModels.Radio.EditorViewModel>()
                .ForMember(item => item.StreamQualities, options => options.Ignore())
                .ForMember(item => item.Genres, options => options.Ignore());

            // Genre mapping
            Mapper.CreateMap<Genre, ViewModels.Genre.EditorViewModel>();
            Mapper.CreateMap<ViewModels.Genre.EditorViewModel, Genre>();
            Mapper.CreateMap<Genre, ViewModels.Genre.DetailViewModel>();

            // StreamQuality mapping
            Mapper.CreateMap<StreamQuality, ViewModels.StreamQuality.EditorViewModel>();
            Mapper.CreateMap<ViewModels.StreamQuality.EditorViewModel, StreamQuality>();
            Mapper.CreateMap<StreamQuality, ViewModels.StreamQuality.DetailViewModel>();


            Mapper.AssertConfigurationIsValid();
            services.AddInstance<IMappingEngine>(Mapper.Engine);
        }
    }
}
