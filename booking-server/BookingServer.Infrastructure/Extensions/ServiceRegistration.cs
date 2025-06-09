using BookingServer.Application.DTOs;
using BookingServer.Application.Interfaces;
using BookingServer.Application.Interfaces.AI;
using BookingServer.Application.Mapper;
using BookingServer.Application.Services;
using BookingServer.Application.Validation;
using BookingServer.Application.Validator;
using BookingServer.Infrastructure.Persistence;
using BookingServer.Infrastructure.Persistence.Repositories;
using BookingServer.Infrastructure.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BookingServer.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddRepositories(services);
            AddBackgroundServices(services);
            AddAutoMapper(services);
            AddMediatR(services);
            AddValidation(services);
            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("sqlConnection"));
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingValidationService, BookingValidationService>();
            services.AddScoped<ICoworkingRepository, CoworkingRepository>();
            services.AddScoped<IPromptReaderService, PromptReaderService>();

        }

        private static void AddBackgroundServices(IServiceCollection services)
        {
            services.AddHostedService<ExpiredBooking>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }

        private static void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }


        private static void AddValidation(IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateBookingDto>, CreateBookingDtoValidator>();
            services.AddTransient<IValidator<PatchBookingDto>, PatchBookingDtoValidator>();

        }
    }
}