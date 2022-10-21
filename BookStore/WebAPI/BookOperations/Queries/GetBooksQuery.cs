using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.Queries;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;

    public GetBooksQuery(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public List<BooksViewModel> Handle()
    {

        var list = _dbContext.Books.ToList();
        List<BooksViewModel> booksViewModel = new List<BooksViewModel>();
        foreach (var book in list)
        {
            booksViewModel.Add(new BooksViewModel
            {
                Name = book.Name,
                Author = book.Author,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PageSize = book.PageSize,
                Price = book.Price,
                PublishDate = book.PublishDate.Date.ToString("dd//mm/yyyy/")
           }); ;
        }
        return booksViewModel;

    }
}

public class BooksViewModel
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PageSize { get; set; }
    public string PublishDate { get; set; }
    public decimal Price { get; set; }
}
