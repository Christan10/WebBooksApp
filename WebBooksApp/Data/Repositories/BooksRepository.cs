using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBooksApp.Data.Stores;
using WebBooksApp.Models;

namespace WebBooksApp.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICacheStore _booksCache;
        private readonly DbSet<Book> _dbSet;

        public BooksRepository(ApplicationDbContext dbContext, ICacheStore booksCache)
        {
            _dbContext = dbContext;
            _booksCache = booksCache;
            _dbSet = dbContext.Books;
        }

        public async Task<Book> FindAsync(int id)
        {
            _booksCache.Cache.TryGetValue(id, out var book);
            if (book != null) return book;

            book = await _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            _booksCache.Cache.Add(id, book);

            return book;
        }

        public async Task<Book> FindByNameAsync(string title)
        {
            var book = await _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Title == title);

            return book;
        }

        public async Task<Book> SaveAsync(Book book)
        {
            if (book.Id <= 0)
            {
                _dbSet.Add(book);
            }
            else
            {
                _dbContext.Entry(book).State = EntityState.Modified;
            }
            return await _dbContext.SaveChangesAsync() > 0 ? book : null;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _dbContext.Books.OrderBy(c => c.Title).ToListAsync();
        }
    }
}
