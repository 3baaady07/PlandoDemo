using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlandoDemo.API.Models;
using System;
using System.Linq;

namespace PlandoDemo.API.Data
{
    public static class PersonMigration
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                PersonDbContext context = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

                try
                {
                    context.Database.Migrate();
                    SeedData(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return app;
        }

        private static void SeedData(PersonDbContext context)
        {
            if (!context.People.Any())
            {
                context.AddRange(
                    new Person() { Name = "Abdullah", Address = "Alghadeer" },
                    new Person() { Name = "Naif", Address = "Olya" }
                    );

                context.SaveChanges();
            }
        }
    }
}
