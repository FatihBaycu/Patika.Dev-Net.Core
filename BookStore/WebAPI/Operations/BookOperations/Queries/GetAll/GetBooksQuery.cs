using AutoMapper;
using WebAPI.Common;
using WebAPI.DbOperations;

namespace WebAPI.Operations.BookOperations.Queries.GetAll;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public List<BooksViewModel> Handle()
    {
        var list = _dbContext.Books.ToList();
        List<BooksViewModel> booksViewModel = _mapper.Map<List<BooksViewModel>>(list);
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
