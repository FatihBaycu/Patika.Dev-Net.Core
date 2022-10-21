using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.BookOperations.Queries
{

    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookViewModel Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(c=>c.Id==id);
            if(book==null) { throw new InvalidOperationException("Böyle Bir Kitap Mevcut Deðildir!"); }

            BookViewModel bookViewModel = new BookViewModel();

            bookViewModel.Name = book.Name;
            bookViewModel.Author = book.Author;
            bookViewModel.Genre = ((GenreEnum)book.GenreId).ToString();
            bookViewModel.PageSize = book.PageSize;
            bookViewModel.Price = book.Price;
            bookViewModel.PublishDate = book.PublishDate.Date.ToString("dd/M/yyyy");

            return bookViewModel;

        }
    }

    public class BookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PageSize { get; set; }
        public string PublishDate { get; set; }
        public decimal Price { get; set; }
    }

}