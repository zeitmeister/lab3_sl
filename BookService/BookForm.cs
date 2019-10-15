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

        public BookForm()
        {
            InitializeComponent();
            domainUpDown1.Items.Add("Sub 4 rating");
            domainUpDown1.Items.Add("More than 2 million votes");
            
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var book in inMemory.AllBooks())
            {
                listBox1.Items.Add(book);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var author in inMemory.AllAuthors())
            {
                listBox1.Items.Add(author);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Visible = true;
            foreach (var book in inMemory.BooksByAuthor(textBox1.Text))
            {
                listBox1.Items.Add(book);
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Visible = true;
            foreach (var book in inMemory.BooksByYear(Int32.Parse(textBox1.Text)))
            {
                listBox1.Items.Add(book);
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var book in inMemory.BooksBetweenYears((int)numericUpDown1.Value, (int)numericUpDown2.Value))
            {
                listBox1.Items.Add(book);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var book in inMemory.LeastFavouriteBooks())
            {
                listBox1.Items.Add(book);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var book in inMemory.MostFavouriteBooks((int)numericUpDown3.Value))
            {
                listBox1.Items.Add(book);
            }

        }

        /*private void CheckFilterOption()
        {
            if (domainUpDown1.Text ==)
        }*/

        private void Button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<Book> bookList = new List<Book>();
            /*var bookList = inMemory.FilterBooksBy(b => b.Rating < 4).ToList();

            foreach (var book in bookList)
            {
                listBox1.Items.Add(book);
            }*/
            if (domainUpDown1.Text == "Sub 4 rating")
            {
                bookList = inMemory.FilterBooksBy(b => b.Rating < 4).ToList();
                foreach (var book in bookList)
                {
                    listBox1.Items.Add(book);
                }
            }
            if (domainUpDown1.Text == "More than 2 million votes")
            {
                bookList = inMemory.FilterBooksBy(b => b.NumberOfUserVotes > 2000000).ToList();
                foreach (var book in bookList)
                {
                    listBox1.Items.Add(book);
                }
            }
            
            button7.Text = "Write to File!";
            WriteToFile<Book>.WriteToTextFile(bookList);
            button7.Text = "Books sub 4 rating";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WriteToFile<ListBox.ObjectCollection>.WriteToTextFile(listBox1.Items);
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
