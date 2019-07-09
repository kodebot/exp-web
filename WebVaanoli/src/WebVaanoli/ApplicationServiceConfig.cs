using Microsoft.Extensions.DependencyInjection;
using WebVaanoli.Data;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;
using WebVaanoli.Services;

namespace WebVaanoli
{
    public static class ApplicationServiceConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IRadioRepository, RadioRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IStreamQualityRepository, StreamQualityRepository>();
            services.AddTransient<IVaanoliDataContext, VaanoliDataContext>();
            services.AddTransient<IFirebaseRepository<Genre>>(provider => new FirebaseRepository<Genre>(provider.GetService<IVaanoliDataContext>().Genres));
            services.AddTransient<IFirebaseRepository<StreamQuality>>(provider => new FirebaseRepository<StreamQuality>(provider.GetService<IVaanoliDataContext>().StreamQualities));
            services.AddTransient<IFirebaseRepository<Radio>>(provider => new FirebaseRepository<Radio>(provider.GetService<IVaanoliDataContext>().Radios));

        }
    }
}
