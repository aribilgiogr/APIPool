using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Summary { get; set; }
        public string CoverImage { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
