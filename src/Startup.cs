using Sa.Core.Extensions;

namespace Sa.Payment.Api;

public class Startup(IWebHostEnvironment env)
{
    private readonly StartupManager _startupManager = new(env);
    private AppSettings _appSettings;

    public virtual void ConfigureServices(IServiceCollection services)
    {
        _appSettings = _startupManager.GetSettings().Result;

        services.AddControllers()
            .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; 
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
        
        services.AddControllers().AddJsonOptions(x => x. JsonSerializerOptions. ReferenceHandler = ReferenceHandler. IgnoreCycles);

        services.AddApiRepositores();

        services.AddDbContext<CardContext>(opt => 
        {
            opt.UseSqlServer(_appSettings.sql.ConnectionString);
        });


        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddCustomAuthentication(_appSettings);

    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseWebSockets();
        app.UseRouting();
        _startupManager.Configure(app, _appSettings);
    }

}