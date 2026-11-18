using FullStack0507.MyDomain.Entities.ProductContext;
using Microsoft.EntityFrameworkCore;

namespace FullStack0507.MyInfrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    //Config
    //Bind
    //Table
    //Seed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(builder =>
        {
            //Value object -> owned type (same table, column named 'Price')
            builder.OwnsOne(product => product.Price, price =>
            {
                price.Property(p => p.Value)
                    .HasColumnName("Price")
                    .HasPrecision(18, 2)
                    .IsRequired();

                price.Property(p => p.Currency)
                    .HasColumnName("PriceCurrency")
                    .HasMaxLength(3)
                    .IsRequired();
            });
        });
    }
}
