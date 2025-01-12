using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:7241/";
                options.Audience = "NotesWebAPI";
                options.RequireHttpsMetadata = false;
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}