namespace Sa.Payment.Api;

public class Startup(IWebHostEnvironment env)
{
    private readonly StartupManager _startupManager = new(env);
    private AppSettings _appSettings;

    public virtual void ConfigureServices(IServiceCollection services)
    {
        _appSettings = _startupManager.GetSettings().Result;
       
        services.AddDefaultServices(_appSettings); 
        services.AddDefaultDependencies(_appSettings);
        services.AddApiRepositores();
        services.AddContexts(_appSettings);

        services.AddCustomAuthentication(_appSettings);
    }

    public void Configure(IApplicationBuilder app)
    {
        _startupManager.Configure(app, _appSettings);
    }

}