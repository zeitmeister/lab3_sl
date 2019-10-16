using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookService
{
    public partial class BookForm : Form
    {
        private IBookService inMemory = SimpleDI.GetService();
        private bool checker;
        private WriteToFileIntermediate intermediate = new WriteToFileIntermediate();

        public event EventHandler<EventArgs> Pressed;
        EventArgs args = new EventArgs();
        

        public BookForm()
        {
            InitializeComponent();
            domainUpDown1.Items.Add("Sub 4 rating");
            domainUpDown1.Items.Add("More than 2 million votes");

            foreach (var button in Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Pressed(this, args);
            listBox1.Items.Clear();
            var books = inMemory.AllBooks();
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }
            intermediate.BooksOrAuthors = books;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var books = inMemory.AllAuthors();
            foreach (var author in books)
            {
                listBox1.Items.Add(author);
            }
            intermediate.BooksOrAuthors = books;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var books = inMemory.BooksByAuthor(textBox1.Text);
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }
            intermediate.BooksOrAuthors = books;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var books = inMemory.BooksByYear(int.Parse(textBox1.Text));
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }
            intermediate.BooksOrAuthors = books;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var books = inMemory.BooksBetweenYears((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }
            intermediate.BooksOrAuthors = books;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            if (!checker)
            {
                var books = inMemory.AllBooksOrderedByRating();
                foreach (var book in books)
                {
                    listBox1.Items.Add(book);
                }
                button5.Text = "Order by top rating";
                intermediate.BooksOrAuthors = books;
            }
            if (checker)
            {
                var books = inMemory.AllBooksOrderedByRating();
                foreach (var book in books)
                {
                    listBox1.Items.Add(book);
                }
                button5.Text = "Order by lowest rating";
                intermediate.BooksOrAuthors = books;
            }
            
            checker = !checker;
        }


        private void Button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var books = inMemory.BooksWithMostNumberOfVotes((int)numericUpDown3.Value);
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<Book> bookList = new List<Book>();

            if (domainUpDown1.Text == "Sub 4 rating")
            {
                bookList = inMemory.FilterBooksBy(Sub4Rating).ToList();
                foreach (var book in bookList)
                {
                    listBox1.Items.Add(book);
                }
            }
            if (domainUpDown1.Text == "More than 2 million votes")
            {
                bookList = inMemory.FilterBooksBy(TwoMilVotes).ToList();
                foreach (var book in bookList)
                {
                    listBox1.Items.Add(book);
                }
            }
            
            button7.Text = "Write to File!";
            WriteToFile<Book>.WriteToTextFile(bookList);
            button7.Text = "Books sub 4 rating";
        }

        public Func<Book, bool> Sub4Rating = b => b.Rating < 4;
        public Func<Book, bool> TwoMilVotes = b => b.NumberOfUserVotes > 2000000;


        private void button8_Click(object sender, EventArgs e)
        {
           WriteToFile<object>.WriteToTextFile(intermediate.BooksOrAuthors);
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void BookForm_Load(object sender, EventArgs e)
        {

        }
    }
}
