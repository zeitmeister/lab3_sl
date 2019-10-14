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
<<<<<<< HEAD
        private IBookService inMemory = SimpleDI.GetService(); // CsvBookService();
=======
        private IBookService inMemory = new CsvBookService();
>>>>>>> cf3899cf073e4cd2ae6a5d40ccc810f2f15c67aa

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
<<<<<<< HEAD
        }

        private void BookForm_Load(object sender, EventArgs e)
        {

=======
>>>>>>> cf3899cf073e4cd2ae6a5d40ccc810f2f15c67aa
        }
    }
}
