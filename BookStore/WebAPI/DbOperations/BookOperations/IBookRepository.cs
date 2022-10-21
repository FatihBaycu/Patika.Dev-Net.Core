using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Entities;
using WebAPI.Operations.BookOperations.Queries.GetAll;

namespace WebAPI.DbOperations.BookOperations
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public List<BooksViewModel> GetBooksWithModel();
        public Book GetById(int id);
        public string AddBook(Book book);
        public string DeleteBook(int id);
        public string UpdateBook(Book book);
    }

}



