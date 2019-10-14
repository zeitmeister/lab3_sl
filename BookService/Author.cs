using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class Author
    {
        public string Name { get; set; }
        public ICollection<Book> Books{ get; set; }

        public Author(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public Author()
        {

        }

        public override string ToString()
        {
            return this.Name; 
        }
    }
}
