using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.Commands;

public class CreateBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public CreateBookModel createBookModel { get; set; }

    public CreateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book1=_dbContext.Books.SingleOrDefault(c=>c.Name==createBookModel.Name);
        if (book1 != null) throw new InvalidOperationException("Kitap zaten mevcut");
        Book book = new Book();
        book.Name = createBookModel.Name;
        book.Author = createBookModel.Author;
        book.GenreId = createBookModel.GenreId;
        book.PageSize = createBookModel.PageSize;
        book.PublishDate = createBookModel.PublishDate;
        book.Price = createBookModel.Price;

        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }
}

public class CreateBookModel{
    public string Name { get; set; }
    public string Author { get; set; }
    public int GenreId { get; set; }
    public int PageSize { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}