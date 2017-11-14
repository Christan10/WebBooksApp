using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebBooksApp.Models;

namespace WebBooksApp.Data.Repositories
{
    public interface IUsersRepository
    {
        Task<int> CountAsync();
        Task<ApplicationUser> GetByEmail(string email);
        Task<IdentityResult> AddPolicyToUser(string email, string policy);
    }

    public interface IBooksRepository
    {
        Task<Book> FindAsync(int id);
        Task<Book> SaveAsync(Book book);
        Task<Book> FindByNameAsync(string name);
        Task<IEnumerable<Book>> GetBooks();
    }
}
