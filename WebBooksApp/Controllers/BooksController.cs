using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBooksApp.Data;
using WebBooksApp.Data.Repositories;
using WebBooksApp.Models;
using WebBooksApp.ViewModels.Books;

namespace WebBooksApp.Controllers
{
    [Route("api/[controller]"), AllowAnonymous]
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ApplicationDbContext _dbContext;

        public BooksController(IBooksRepository booksRepository, ApplicationDbContext dbContext)
        {
            _booksRepository = booksRepository;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _booksRepository.GetBooks();
            var results = Mapper.Map<BookViewModel[]>(books);
            return Ok(results);
        }

        [HttpGet("{id:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _booksRepository.FindAsync(id);
            if (book == null) return NotFound();

            return Ok(Mapper.Map<BookViewModel>(book));
        }

        [HttpGet("{name:length(1, 50)}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var book = await _booksRepository.FindByNameAsync(name);
            if (book == null) return NotFound();

            return Ok(Mapper.Map<BookViewModel>(book));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Author = new Author
                {
                    Name = model.AuthorName
                }
            };

            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return Ok(book);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookEditViewModel model)
        {
            var book = await _booksRepository.FindAsync(id);
            if (book == null) return NotFound();

            var bookToUpdate = Mapper.Map(model, book);

            await _booksRepository.SaveAsync(bookToUpdate);

            return Ok(Mapper.Map<BookViewModel>(bookToUpdate));
        }
    }
}
