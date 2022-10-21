using AutoMapper;
using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.Operations.BookOperations.Queries.GetBy
{

    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }


        public GetBookByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(c => c.Id == BookId);
            if (book == null) { throw new InvalidOperationException("Böyle Bir Kitap Mevcut Deðildir!"); }

            BookViewModel bookViewModel = _mapper.Map<BookViewModel>(book);
            return bookViewModel;

        }
    }

    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PageSize { get; set; }
        public string PublishDate { get; set; }
        public decimal Price { get; set; }
    }

}