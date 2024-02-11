namespace Sa.Payment.Api.IoC;

public static class DependencyResolver
{
    public static IServiceCollection AddApiRepositores(this IServiceCollection services)    
    {
        services.AddScoped<ICardRepository, CardRepository>();

        services.AddScoped<IInstallmentsRepository, InstallmentsRepository>();

        services.AddScoped<IDateHelper, DateHelper>();

        return services;
    }
}