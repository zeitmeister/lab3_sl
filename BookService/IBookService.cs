using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    interface IBookService
    {
        IEnumerable<Book> AllBooks();
        IEnumerable<Author> AllAuthors();
        IEnumerable<Book> BooksByAuthor(string name);
        IEnumerable<Book> BooksByYear(int year);
        IEnumerable<Book> BooksBetweenYears(int yearA, int yearB);
        IEnumerable<Book> LeastFavouriteBooks();
    }
}
