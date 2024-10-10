using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IShelfService
    {
        Task<IEnumerable<BookListItem>> GetBooks();
        Task<BookDetail> GetBook(int id);

        Task CreateBook(Book book);
        Task UpdateBook(int id, Book book);
        Task DeleteBook(int id);
    }
}
