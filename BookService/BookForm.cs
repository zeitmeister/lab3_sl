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
        private IBookService inMemory = SimpleDI.GetService(); //new CsvBookService();

        public BookForm()
        {
            InitializeComponent();

            
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
            var bookList = inMemory.BooksByYear(2013);

            foreach (var item in bookList)
            {
                label1.Text += item.Title;
            }
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

        private void BookForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in inMemory.BooksBetweenYears((int)numericUpDown2.Value, (int)numericUpDown1.Value))
            {
                listBox1.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var bookList = inMemory.AllBooksOrderedByRating();
            foreach (var item in inMemory.AllBooksOrderedByRating())
            {
                listBox1.Items.Add(item);
            }
            button7.Text = "add to text";
            WriteToFile<Book>.WriteToTextFile(bookList);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
