using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using F1_App.Services;
using F1_App.Configuration;

namespace F1_App.Data
{
    public class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!await context.Drivers.AnyAsync())
                {
                    var apiSettings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
                    var dataFetcher = new DataFetcher();
                    var drivers = await dataFetcher.FetchDriversAsync(apiSettings.DriversApiUrl);

                    context.Drivers.AddRange(drivers);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
