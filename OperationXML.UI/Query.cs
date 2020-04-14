using OperationXML.BLL;
using OperationXML.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OperationXML.UI
{
    public partial class Query : Form
    {
        BookBll _b = new BookBll();                          //实例化(调用)B层
        BookModel _bookmodel = new BookModel();      //实例化(调用)Model层
        List<BookModel> list = null;


        public Query()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _str = comboBox1.Text;
            if (_str == "")
            {
                MessageBox.Show("请选择查询条件！");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入查询条件！");
                return;
            }


            switch (_str)
            {
                case "编号":
                    list = _b.Query(1, textBox1.Text);
                    break;

                case "书名":
                    list = _b.Query(2, textBox1.Text);
                    break;

                case "作者":
                    list = _b.Query(3, textBox1.Text);
                    break;
                default:
                    break;
            }

            dataGridView1.DataSource = list;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = 50;
            }  //设置行高

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 160;
            }  //设置列宽
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
