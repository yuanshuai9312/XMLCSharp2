using OperationXML.BLL;
using OperationXML.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OperationXML.UI
{
    public partial class Form1 : Form
    {
       BookModel _bookmodel = new BookModel();
        BookBll _b = new BookBll();
   
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreatXML cx = new CreatXML();
            cx.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {    
            DataSet ds = _b.PersonLoad();
            dataGridView1.DataSource = ds.Tables[0];
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = 50;
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 200;
            }     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add _add = new Add();
            _add.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DataGridViewRow _Row = dataGridView1.CurrentRow;
            DataGridViewSelectedRowCollection drArray = dataGridView1.SelectedRows;
            if (_Row == null)
            {
                MessageBox.Show("没有数据行,操作无效!");
                return;        //要问的问题      
            }
            List<string> list = new List<string>();
            foreach (DataGridViewRow singleRow in drArray)
            {
                list.Add(singleRow.Cells["编号"].Value.ToString());
            }
            if (MessageBox.Show("确定删除此行数据?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (string s in list)
                {
                    _b.Delete(s);
                }
                MessageBox.Show("删除数据成功!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Query qe = new Query();
            qe.ShowDialog();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow _Row = dataGridView1.CurrentRow;
            if (_Row == null)
            {
                MessageBox.Show("没有数据行,当前操作无效!");
                return;
            }
           Modify md = new Modify();
            md.CurrentRow = _Row;
            md.ShowDialog();
        }
    }
}
