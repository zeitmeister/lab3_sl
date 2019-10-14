using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    class CsvBookService : IBookService
    {
        private List<Book> _books;
        private List<Author> _authors;
<<<<<<< HEAD

=======
>>>>>>> cf3899cf073e4cd2ae6a5d40ccc810f2f15c67aa
        public CsvBookService()
        {
            CsvParser parser = new CsvParser();
            parser.ParseCsv();
            _books = parser.GetBooks().ToList();
            _authors = parser.GetAuthors().ToList();
        }
        public IEnumerable<Author> AllAuthors()
        {
            return _authors.Select(a => a);
        }

        public IEnumerable<Book> AllBooks()
        {
            return _books.Select(b => b);
        }

        public IEnumerable<Book> BooksByAuthor(string name)
        {
            return _authors.Where(a => a.Name == name).SelectMany(a => a.Books);
        }

        public IEnumerable<Book> BooksByYear(int year)
        {
            return _books.Where(b => b.YearOfPublication == year);
        }
    }
}
