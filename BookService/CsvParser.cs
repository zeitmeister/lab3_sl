using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookService
{
    /// <summary>
    /// Parses books and authors from a csv-file with a specific format.
    /// </summary>
    class CsvParser
    {
        private List<Book> Books = new List<Book>();
        private Dictionary<string, Author> Authors =
            new Dictionary<string, Author>();

        /// <summary>
        /// Get all parsed books.
        /// Call ParseCsv before calling this method.
        /// </summary>
        /// <returns>A set of books.</returns>
        public IEnumerable<Book> GetBooks()
        {
            return Books;
        }

        /// <summary>
        /// Get all parsed authors.
        /// Call ParseCsv before calling this method.
        /// </summary>
        /// <returns>A set of authors.</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return Authors.Values;
        }

        /// <summary>
        /// Parses a csv-file at path:"/../../files/books.csv"
        /// containing books and their authors.
        /// </summary>
        public void ParseCsv()
        {
            var path = Application.StartupPath + "/../../Files/books.csv";
            var lines = File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));

            foreach (string line in lines)
            {
                var items = line.Split(new string[] { ";" }, StringSplitOptions.None);

                int year, votes;
                long isbn;
                int.TryParse(items[2], out year);
                int.TryParse(items[5], out votes);
                long.TryParse(items[0], out isbn);

                double rating;
                var style = NumberStyles.Number;
                var culture = CultureInfo.CreateSpecificCulture("en-US");
                double.TryParse(items[4], style, culture, out rating);


                Book book = new Book
                {
                    ISBN = isbn,
                    Title = items[3],
                    YearOfPublication = year,
                    Rating = rating,
                    NumberOfUserVotes = votes,
                    Authors = new List<Author>()
                };

                Books.Add(book);

                var authors = items[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in authors)
                {
                    Author author;

                    if (!Authors.ContainsKey(c))
                    {
                        author = new Author
                        {
                            Books = new List<Book>(),
                            Name = c
                        };

                        Authors.Add(c, author);
                    }
                    else
                        author = Authors[c];

                    author.Books.Add(book);
                    book.Authors.Add(author);
                }
            }
        }
    }
}
