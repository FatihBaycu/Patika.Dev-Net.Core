using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.Commands;

public class UpdateBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public UpdateBookModel updateBookModel { get; set; }

    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(c => c.Id == updateBookModel.Id);
        if (book == null) throw new InvalidOperationException("Kitap mevcut değil!");

        book.Id = updateBookModel.Id;
        book.Name = updateBookModel.Name;
        book.Author = updateBookModel.Author;
        book.GenreId = updateBookModel.GenreId;
        book.PageSize = updateBookModel.PageSize;
        book.PublishDate = updateBookModel.PublishDate;
        book.Price = updateBookModel.Price;

        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
    }
}

public class UpdateBookModel
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int GenreId { get; set; }
    public int PageSize { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}