using OperationXML.BLL;
using OperationXML.Model;
using System;
using System.Windows.Forms;

namespace OperationXML.UI
{
    public partial class Add : Form
    {
        BookBll _bbb = new BookBll();
        BookModel _book = new BookModel();
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _book.BookType = this.comboBox1.Text;
            _book.BookPrice = this.txtPrice.Text;
            _book.BookID = Convert.ToInt32(txtISBN.Text);
            _book.BookName = this.txtName.Text;
            _book.BookAuthor = this.txtAuthor.Text; 
            _bbb.Add(_book);

            Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
