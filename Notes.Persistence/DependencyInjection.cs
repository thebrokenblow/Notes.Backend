using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Repositories;
using Notes.Persistence.Repositories;

namespace Notes.Persistence;

public static class DependencyInjection
{
    private const string nameConnectionString = "DbConnection";

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameConnectionString);

        services.AddDbContext<NotesDbContext>(
            options =>
            {
                options.UseNpgsql(connectionString);
            });

        services.AddScoped<INoteRepository, NoteRepository>();

        return services;
    }
}