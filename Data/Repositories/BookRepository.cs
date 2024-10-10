using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utility.Generics;

namespace Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ShelfContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Book>> FindManyAsync(Expression<Func<Book, bool>>? expression = null)
        {
            var data = _set.Include(x => x.Author);
            return expression != null ? await data.Where(expression).ToListAsync() : await data.ToListAsync();
        }

        public override async Task<Book?> FindByKeyAsync(object entityKey)
        {
            var data = _set.Include(x => x.Author);
            return await data.FirstOrDefaultAsync(x => x.Id == (int)entityKey);
        }
    }
}
