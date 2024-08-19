using Microsoft.EntityFrameworkCore;
using APIPB301.Data.Entities;
using System.Reflection;

namespace APIPB301.Data.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
