using FluentValidation.AspNetCore;
using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.BUSINESS.ExternalServices.Implements;
using GTwitt.BUSINESS.ExternalServices.Interfaces;
using GTwitt.BUSINESS.Profiles;
using GTwitt.BUSINESS.Repositories.Implements;
using GTwitt.BUSINESS.Repositories.Interfaces;
using GTwitt.BUSINESS.Services.Implements;
using GTwitt.BUSINESS.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GTwitt.BUSINESS
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<ITopicServices, TopicServices>();
            services.AddScoped<IUserServices, UserServices>();
            return services;
        }

        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<TopicCreateDTOValidator>());
            services.AddAutoMapper(typeof(TopicMappingProfile).Assembly);
            return services;
        }
        public static IServiceCollection AddEmails(this IServiceCollection services)
        {
            services.AddScoped<IEmailServices, EmailServices>();
            return services;
        }
    }
}
