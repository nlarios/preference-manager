using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PreferenceManager.Infrastructure.Configuration;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("PerformanceManagerDatabase"));
    }
}