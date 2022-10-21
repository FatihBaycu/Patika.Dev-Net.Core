using WebAPI.Common;
using WebAPI.Entities;
using WebAPI.Operations.BookOperations.Queries.GetAll;

namespace WebAPI.DbOperations.BookOperations
{
    public class BookRepository : IBookRepository
    {

        public BookRepository()
        {

            using (var context = new BookStoreDbContext())
            {

                if (context.Books.Any()) { return; }

                var books = new List<Book>
                {
                new Book
                {
                    //Id=1,
                    GenreId=1,
                    Name ="Joydip",
                    Author ="Kanjilal",
                    PageSize=200,
                    Price=200,
                    PublishDate=DateTime.Now

                },
                new Book
                {
                    //Id=2,
                    GenreId=1,
                    Name ="Joydip",
                    Author ="Kanjilal",
                    PageSize=200,
                    Price=200,
                    PublishDate=DateTime.Now

                }
                };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }

        public string AddBook(Book book)
        {
            using (var context = new BookStoreDbContext())
            {
                context.AddRange(book);
                context.SaveChanges();
            }
            return "Eklendi";
        }

        public string DeleteBook(int id)
        {
            using (var context = new BookStoreDbContext())
            {
                var bookIsExist = context.Books.SingleOrDefault(c => c.Id == id);
                if (bookIsExist != null)
                {
                    context.Books.Remove(bookIsExist);
                    context.SaveChanges();
                }
                else return "Bu Kitap bulunamadı";

            }
            return "Silindi.";
        }

        public List<Book> GetBooks()
        {
            using (var context = new BookStoreDbContext())
            {
                var list = context.Books.ToList();
                return list;
            }
        }


        public List<BooksViewModel> GetBooksWithModel()
        {
            using (var context = new BookStoreDbContext())
            {
                var list = context.Books.ToList();
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


        public Book GetById(int id)
        {
            using (var context = new BookStoreDbContext())
            {
                var singleBook = context.Books.Single(x => x.Id == id);
                return singleBook;
            }
        }

        public string UpdateBook(Book book)
        {
            using (var context = new BookStoreDbContext())
            {
                var bookIsExist = context.Books.Where(c => c.Id == book.Id);
                if (bookIsExist.Any())
                {
                    context.Update(book);
                    context.SaveChanges();
                }
                else return "Bu Kitap bulunamadı";

            }
            return "Güncellendi.";
        }
    }

}



