using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class Book
    {
        public long ISBN { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public double Rating { get; set; }
        public int NumberOfUserVotes { get; set; }
        public ICollection<Author> Authors { get; set; }

        public Book(long isbn, string title, int yearOfPublication, double rating, int numberOfUserVotes)
        {
            ISBN = isbn;
            Title = title;
            YearOfPublication = yearOfPublication;
            Rating = rating;
            NumberOfUserVotes = numberOfUserVotes;
            Authors = new List<Author>();
        }
        public Book()
        {

        }

        public override string ToString()
        {
            var authors = Authors.Select(a => a.Name);
            string result = "Title: " + this.Title + ". By : ";
            foreach (var author in authors)
            {
                result += author + ", ";
            }
            return result;
        }
    }
}
