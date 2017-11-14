using AutoMapper;
using WebBooksApp.Models;

namespace WebBooksApp.ViewModels.Books
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookEditViewModel, Book>();
        }
    }
}
