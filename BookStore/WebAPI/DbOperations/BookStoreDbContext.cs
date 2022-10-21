using Microsoft.EntityFrameworkCore;

namespace WebAPI.DbOperations;
public class BookStoreDbContext:DbContext{

    public BookStoreDbContext(DbContextOptions options) : base(options){}

    public BookStoreDbContext(){}

    protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "BookStoreDb");
    }

    public DbSet<Book> Books { get; set; }

}