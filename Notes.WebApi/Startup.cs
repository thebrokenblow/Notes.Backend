using Notes.Application;
using Notes.Persistence;
using Notes.WebApi.Middleware;

namespace Notes.WebApi;

public class Startup(IConfiguration configuration)
{
    private const string namePolicy = "AllowAll";

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();
        services.AddPersistence(configuration);

        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy(namePolicy, policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors(namePolicy);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}