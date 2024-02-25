namespace Sa.Payment.Api.IoC;

public static class DependencyResolver
{
    public static IServiceCollection AddApiRepositores(this IServiceCollection services)    
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IInstallmentsRepository, InstallmentsRepository>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<ISummaryRepository, SummaryRepository>();

        return services;
    }

    public static IServiceCollection AddContexts<T>(this IServiceCollection services, T appSettings) where T : AppSettings
    {
        services.AddDbContext<CardContext>(opt => 
        {
            opt.UseSqlServer(appSettings.SqlConfiguration.ConnectionString);
        });

        return services;
    }
}