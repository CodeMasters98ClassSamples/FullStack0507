using FullStack0507.MyWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack0507.MyWebApi.Data
{
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
}
