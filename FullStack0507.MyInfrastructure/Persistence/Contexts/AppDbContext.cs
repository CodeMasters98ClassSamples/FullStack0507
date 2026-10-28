using FullStack0507.MyDomain.Entites;
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

}
