using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class InMemoryBookService : IBookService
    {
        private List<Book> inMemoryBooks = new List<Book>();

        private List<Author> inMemoryAuthors = new List<Author>();

        public InMemoryBookService()
        {
            Book book1 = new Book(132353, "Skepparkransen", 2014, 8, 294);
            Book book2 = new Book(210909, "Den Tomma Stolen", 2011, 7, 38);
            Book book3 = new Book(928838, "Ninjan", 2013, 4, 8472);

            Author author1 = new Author("Kenneth Rugstål");
            Author author2 = new Author("Selma Smagerost");
            Author author3 = new Author("Slagathor Persson");
            inMemoryAuthors.Add(author1);
            inMemoryAuthors.Add(author2);
            inMemoryAuthors.Add(author3);

            inMemoryBooks.Add(book1);
            inMemoryBooks.Add(book2);
            inMemoryBooks.Add(book3);

            ConnectBookAndAuthor(book1, author1);
            ConnectBookAndAuthor(book2, author2);
            ConnectBookAndAuthor(book2, author3);
            ConnectBookAndAuthor(book3, author1);
            ConnectBookAndAuthor(book3, author2);
            ConnectBookAndAuthor(book3, author3);
        }

        public void ConnectBookAndAuthor(Book _book, Author _author)
        {
            _book.Authors.Add(_author);


            _author.Books.Add(_book);

        }

        public IEnumerable<Book> AllBooks()
        {
            //return from b in inMemoryBooks select b;
            return inMemoryBooks.Select(b => b);
        }

        public IEnumerable<Author> AllAuthors()
        {
            return inMemoryAuthors.Select(a => a);
        }

        public IEnumerable<Book> BooksByAuthor(string name)
        {
            var books = inMemoryAuthors.Where(a => a.Name == name).SelectMany(a => a.Books);

            return books;
        }

        public IEnumerable<Book> BooksByYear(int year)
        {
            return inMemoryBooks.Select(b => b).Where(b => b.YearOfPublication == year);
        }

        public IEnumerable<Book> BooksBetweenYears(int yearA, int yearB)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> AllBooksOrderedByRating()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> BooksWithMostNumberOfVotes(int numberOfBooks)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FilterBooksBy(Func<Book, bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}
