using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<DataItem> DataItems => Set<DataItem>();

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<ClientContacts> ClientContacts => Set<ClientContacts>();

    public DbSet<DateInterval> Dates => Set<DateInterval>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}