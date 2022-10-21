using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Operations.BookOperations.Commands.Delete
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookModel deleteBookModel { get; set; }

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null) throw new InvalidOperationException("Kitap mevcut değil!");
            
            _context.Books.Remove(book);
            _context.SaveChanges();
          
        }

    }

    public class DeleteBookModel
    {
        public int Id { get; set; }
    }

}
