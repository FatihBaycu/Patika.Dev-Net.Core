using AutoMapper;
using WebAPI.Common;
using WebAPI.Entities;
using WebAPI.Operations.BookOperations.Commands.Create;
using WebAPI.Operations.BookOperations.Commands.Update;
using WebAPI.Operations.BookOperations.Queries.GetAll;
using WebAPI.Operations.BookOperations.Queries.GetBy;

namespace WebAPI.Extensions.Mapper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<UpdateBookModel, Book>().ReverseMap();
            CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString())); 
            CreateMap<Book, BooksViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }  
    }
}
