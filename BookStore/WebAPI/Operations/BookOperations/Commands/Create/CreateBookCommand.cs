using AutoMapper;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Operations.BookOperations.Commands.Create;

public class CreateBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public CreateBookModel createBookModel { get; set; }
    IMapper _mapper;

    public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(c => c.Name == createBookModel.Name);
        if (book != null) { throw new InvalidOperationException("Kitap zaten mevcut"); }

        book = _mapper.Map<Book>(createBookModel);

        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }
}

public class CreateBookModel
{
    public string Name { get; set; }
    public string Author { get; set; }
    public int GenreId { get; set; }
    public int PageSize { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}