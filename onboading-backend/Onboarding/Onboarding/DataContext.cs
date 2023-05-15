using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAppNamespace.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

public class DataContext : DbContext
{
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<LoginDto> Login { get; set; }
}
