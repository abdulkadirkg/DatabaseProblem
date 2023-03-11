using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NpgsqlProblem;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("User ID=test;Password=test;Host=localhost;Port=5432;Database=testdb;Pooling=true;Connection Lifetime=0;")
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // TODO: 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<DummyDataClass> DummyDataClasses { get; set; }
}
