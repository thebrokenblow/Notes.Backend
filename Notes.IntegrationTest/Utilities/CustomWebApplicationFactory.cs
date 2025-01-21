using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence;

namespace Notes.IntegrationTests.Utilities;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private const string nameDatabase = "notes_db";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(serviceDescriptor =>
                serviceDescriptor.ServiceType == typeof(DbContextOptions<NotesDbContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameDatabase);
            });

            services.AddSingleton(serviceProvider =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<NotesDbContext>();
                optionsBuilder.UseInMemoryDatabase(nameDatabase);

                return optionsBuilder.Options;
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
            TestDataSeeder.Seed(db);
        });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            using var scope = Services.CreateScope();

            var notesDbContext = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
            TestDataSeeder.Seed(notesDbContext);
        }

        base.Dispose(disposing);
    }
}