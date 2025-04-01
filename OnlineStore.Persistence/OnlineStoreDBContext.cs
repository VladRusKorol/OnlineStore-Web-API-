using Microsoft.EntityFrameworkCore;
using OnlineStore.Entity;

namespace OnlineStore.Persistence;

public class OnlineStoreDBContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=OnlineStoreDB.db");
    }
}
