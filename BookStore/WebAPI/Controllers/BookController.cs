using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.BookOperations.Commands;
using WebAPI.BookOperations.Queries;
using WebAPI.DbOperations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    readonly IBookRepository _bookRepository;
    readonly BookStoreDbContext _context;

    public BookController(IBookRepository bookRepository, BookStoreDbContext context)
    {
        _bookRepository = bookRepository;
        _context = context;
    }

    [HttpGet("getList")]
    public List<Book> GetBookList()
    {
        var result = _bookRepository.GetBooks();
        return result;
    }

    
    [HttpGet("get-list-with-model-from-repo")]
    public IActionResult GetBookListWithModel()
    {

        var result = _bookRepository.GetBooksWithModel();
        return Ok(result);
    }

    [HttpGet("get-list-with-model")]
    public IActionResult GetBooksWithModel()
    {
        GetBooksQuery query = new GetBooksQuery(_context);
        var result = query.Handle();
        return Ok(result);

    }


    //[HttpGet("{id}")]
    //public Book GetById(int id)
    //{
    //    var result = _bookRepository.GetById(id);
    //    return result;
    //}
    

    [HttpGet]
    public Book GetByIdFromQuery([FromQuery] int id)
    {
        var result = _bookRepository.GetById(id);
        return result;
    } 
    
    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        _bookRepository.AddBook(book);
        
        return Ok();
    }


    [HttpPost("add-book-with-model")]
    public IActionResult AddBookWithModel([FromBody] CreateBookModel createBookModel)
    {

        CreateBookCommand createBookCommand = new CreateBookCommand(_context);
        createBookCommand.createBookModel = createBookModel;
        createBookCommand.Handle();
        return Ok();

    }

    [HttpDelete("delete-book")]
    public IActionResult DeleteBook(int id)
    {
        _bookRepository.DeleteBook(id);
        
        return Ok();
    }
    
    [HttpPut("update-book")]
    public IActionResult UpdateBook([FromBody] Book book)
    {
        _bookRepository.UpdateBook(book);
        
        return Ok();
    }

}