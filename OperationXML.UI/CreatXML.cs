using OperationXML.BLL;
using OperationXML.Model;
using System;
using System.Windows.Forms;

namespace OperationXML.UI
{
    public partial class CreatXML : Form
    {
        public CreatXML()
        {
            InitializeComponent();
        }

        BookModel _book = new BookModel();
        BookBll _b = new BookBll();
        private void button1_Click(object sender, EventArgs e)
        {
            _book.BookName = txtTitle.Text;
            _book.BookAuthor = txtauthor.Text;
            _book.BookPrice = txtPrice.Text;
            _book.BookID = Convert.ToInt32(txtID.Text);
            _book.BookType = comboBox1.Text;
            _b.Creat(_book);

            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
