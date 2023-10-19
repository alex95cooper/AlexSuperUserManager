using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.DAL.Repositories;
using AlexSuperUserManager.Domain;
using AlexSuperUserManager.Domain.Interfaces;

namespace AlexSuperUserManager.Extensions;

public static class ServiceExtensions
{
    public static void InitializeDataComponents(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUsersCreator, UsersCreator>();
        services.AddTransient<IUsersProvider, UsersProvider>();
        services.AddTransient<IUsersUpdater, UsersUpdater>();
        services.AddTransient<IUsersValidator, UsersValidator>();
    }
}