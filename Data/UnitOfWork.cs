using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShelfContext context;

        public UnitOfWork(ShelfContext context)
        {
            this.context = context;
        }

        private IBookRepository? bookRepository;
        public IBookRepository BookRepository => bookRepository ??= new BookRepository(context);

        private IAuthorRepository? authorRepository;
        public IAuthorRepository AuthorRepository => authorRepository ??= new AuthorRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
