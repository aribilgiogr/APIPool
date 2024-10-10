using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ShelfService : IShelfService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShelfService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateBook(Book book)
        {
            await unitOfWork.BookRepository.InsertOneAsync(book);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteBook(int id)
        {
            await unitOfWork.BookRepository.DeleteByKeyAsync(id);
            await unitOfWork.CommitAsync();
        }

        public async Task<BookDetail> GetBook(int id)
        {
            var b = await unitOfWork.BookRepository.FindByKeyAsync(id);
            if (b != null)
            {
                return new BookDetail
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = b.Genre,
                    CoverImage = b.CoverImage,
                    AuthorId = b.AuthorId,
                    AuthorName = $"{b.Author.Firstname} {b.Author.Middlename} {b.Author.Lastname}",
                    AuthorPicture = b.Author.ProfilePicture,
                    PageCount = b.PageCount,
                    Summary = b.Summary
                };
            }
            return null;
        }

        public async Task<IEnumerable<BookListItem>> GetBooks()
        {
            return from b in await unitOfWork.BookRepository.FindManyAsync()
                   select new BookListItem
                   {
                       Id = b.Id,
                       Title = b.Title,
                       Genre = b.Genre,
                       CoverImage = b.CoverImage,
                       AuthorName = $"{b.Author.Firstname} {b.Author.Middlename} {b.Author.Lastname}"
                   };
        }

        public async Task UpdateBook(int id, Book book)
        {
            await unitOfWork.BookRepository.UpdateAsync(book);
            await unitOfWork.CommitAsync();
        }
    }
}
