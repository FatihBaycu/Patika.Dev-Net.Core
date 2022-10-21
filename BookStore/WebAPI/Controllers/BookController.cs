using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.DbOperations;
using WebAPI.DbOperations.BookOperations;
using WebAPI.Entities;
using WebAPI.Operations.BookOperations.Commands.Create;
using WebAPI.Operations.BookOperations.Commands.Delete;
using WebAPI.Operations.BookOperations.Commands.Update;
using WebAPI.Operations.BookOperations.Queries.GetAll;
using WebAPI.Operations.BookOperations.Queries.GetBy;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    readonly IBookRepository _bookRepository;
    readonly BookStoreDbContext _context;
    public IMapper _mapper { get; set; }

    public BookController(IBookRepository bookRepository, BookStoreDbContext context, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _context = context;
        _mapper = mapper;

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
        GetBooksQuery query = new GetBooksQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);

    }


    [HttpGet("get-by-id-with-model")]
    public IActionResult GetByIdWithModel(int id)
    {
        GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
        try
        {
            GetBookByIdCommandValidator validationRules = new GetBookByIdCommandValidator();
            query.BookId=id;
            validationRules.ValidateAndThrow(query);
        }
        catch (Exception)
        {

            throw;
        }
        var result = query.Handle();
        return Ok(result);
    }


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

        CreateBookCommand createBookCommand = new CreateBookCommand(_context, _mapper);

        try
        {
            createBookCommand.createBookModel = createBookModel;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(createBookCommand);
            createBookCommand.Handle();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


        //if (!result.IsValid)
        //{
        //    foreach (var item in result.Errors)
        //    {
        //        Console.WriteLine("Özellik "+item.PropertyName+" - Error Message: "+ item.ErrorMessage);
        //    }
        //}

        return Ok();

    }

    [HttpPut("update-book-with-model")]
    public IActionResult UpdateBookWithModel([FromBody] UpdateBookModel UpdateBookModel)
    {
        UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context, _mapper);
        try
        {
            updateBookCommand.updateBookModel = UpdateBookModel;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(updateBookCommand);
            updateBookCommand.Handle();
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
           
        }

        return Ok();


    }

    [HttpDelete("delete-book-with-model")]
    public IActionResult DeleteBookWithModel([FromBody] DeleteBookModel deleteBookModel)
    {
        DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);

        try
        {
            deleteBookCommand.deleteBookModel = deleteBookModel;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(deleteBookCommand);
            deleteBookCommand.Handle(deleteBookModel.Id);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

        return Ok("Baþarýyla Silindi");
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