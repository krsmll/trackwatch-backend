using System;
using System.Linq;
using DAL.App.EF;
using Domain.App;
using Domain.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services
                    .SingleOrDefault(d =>
                        d.ServiceType == typeof(DbContextOptions<AppDbContext>)
                    );
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase(builder.GetSetting("test_database_name") ?? string.Empty);
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();

                if (db.Characters.Any()) return;
                
                db.Characters.Add(new Character
                {
                    FirstName = "Kristjan",
                    LastName = "Mill",
                    Description = "Epic and cool",
                    Age = 21,
                    Birthdate = new DateTime(1999, 12, 26)
                });
                
                db.Characters.Add(new Character
                {
                    FirstName = "Not Kristjan",
                    LastName = "Miller",
                    Description = "Cringe and uncool",
                    Age = 19,
                    Birthdate = new DateTime(2001, 12, 26)
                });
                
                db.SaveChanges();
            });
        }
    }
}