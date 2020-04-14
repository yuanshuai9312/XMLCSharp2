using OperationXML.BLL;
using OperationXML.Model;
using System;
using System.Windows.Forms;

namespace OperationXML.UI
{
    public partial class Modify : Form
    {
        BookBll _b = new BookBll();
        BookModel _book = new BookModel();


        private DataGridViewRow _CurrentRow;
        public DataGridViewRow CurrentRow
        {
            get { return _CurrentRow; }
            set { _CurrentRow = value; }
        }
        public Modify()
        {
            InitializeComponent();
        }

        private void Modify_Load(object sender, EventArgs e) //加载到页面
        {
            txtAuthor.Text = _CurrentRow.Cells["作者"].Value.ToString();
            txtID.Text = _CurrentRow.Cells["编号"].Value.ToString();
            txtName.Text = _CurrentRow.Cells["书名"].Value.ToString();
            txtPrice.Text = _CurrentRow.Cells["价格"].Value.ToString();
            comboBox1.Text = _CurrentRow.Cells["课程类型"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _book.BookAuthor = txtAuthor.Text;
            _book.BookID = Convert.ToInt32(txtID.Text);
            _book.BookName = txtName.Text;
            _book.BookPrice = txtPrice.Text;
            _book.BookType = comboBox1.Text;
            _b.Update(_book);

            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
