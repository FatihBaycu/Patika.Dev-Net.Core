using AutoMapper;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;
using WebAPI.Operations.BookOperations.Commands.Create;

namespace WebAPI.Operations.BookOperations.Commands.Update;

public class UpdateBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public UpdateBookModel updateBookModel { get; set; }
    IMapper _mapper;


    public UpdateBookCommand(BookStoreDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    
    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(c => c.Id == updateBookModel.Id);
        if (book == null) throw new InvalidOperationException("Kitap mevcut değil!");
        Book mappedBook=_mapper.Map(updateBookModel, book);

        _dbContext.Books.Update(book);
        _dbContext.SaveChanges();
    }
}

public class UpdateBookModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int GenreId { get; set; }
    public int PageSize { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}