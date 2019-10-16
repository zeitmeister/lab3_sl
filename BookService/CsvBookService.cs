﻿using System;
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

        public IEnumerable<Book> BooksBetweenYears(int yearA, int yearB)
        {
            return _books.Where(b => b.YearOfPublication > yearA && b.YearOfPublication < yearB);
        }

        public IEnumerable<Book> AllBooksOrderedByRating()
        {
            return _books.OrderBy(b => b.Rating);
        }

        public IEnumerable<Book> BooksWithMostNumberOfVotes(int numberOfBooks)
        {
            return _books.OrderByDescending(b => b.NumberOfUserVotes).Take(numberOfBooks);
        }

        public IEnumerable<Book> FilterBooksBy(Func<Book, bool> expression)
        {
            return _books.Where(expression);
        }

        public IEnumerable<Book> AllBooksOrderedByRatingRev()
        {
            return _books.OrderByDescending(b => b.Rating);
        }

        public Func<Book, bool> Sub4Rating = b => b.Rating < 4;

        public Func<Book, bool> TwoMilVotes = b => b.NumberOfUserVotes > 2000000;
    }
}
