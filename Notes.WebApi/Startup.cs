using Notes.Application;
using Notes.Application.Common.Mappings;
using Notes.Persistence;
using System.Reflection;

namespace Notes.WebApi;

public class Startup(IConfiguration configuration)
{
    private const string namePolicy = "AllowAll";

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        });

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

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors(namePolicy);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}