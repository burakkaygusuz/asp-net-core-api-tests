using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.API.Models.Extensions;

namespace MovieDatabase.API.Tests
{
    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing").ConfigureTestServices(services =>
            {
                services.AddDbContext<MovieDatabaseContext>(options => options.UseInMemoryDatabase("InMemoryDbForTesting"));

                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieDatabaseContext>();
                dbContext.Database.EnsureCreated();
            });
        }
    }
}