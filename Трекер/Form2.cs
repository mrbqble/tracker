using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Трекер
{
    public partial class Form2 : Form
    {
        public static string cos = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = d://Users//bruce//Desktop//Grade 10//Трекер//base.mdb";
        private OleDbConnection con = new OleDbConnection(cos);
        private DataTable dt = new DataTable();
        public string user;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog afd = new OpenFileDialog();
            if (afd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation = afd.FileName;
            }
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "baseDataSet.История". При необходимости она может быть перемещена или удалена.
            this.историяTableAdapter.Fill(this.baseDataSet.История);
            con.Open();
            string query = "Select * FROM История WHERE Пользователь LIKE '%" + user + "%'";
            OleDbDataAdapter com = new OleDbDataAdapter(query, con);
            com.Fill(dt);
            историяBindingSource.DataSource = dt;
            con.Close();
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataRow nRow = baseDataSet.История.NewRow();
            int rc = dataGridView2.RowCount + 1;
            nRow[0] = rc;
            nRow[1] = user;
            nRow[2] = comboBox1.Text;
            nRow[3] = textBox2.Text;
            nRow[4] = textBox1.Text;
            nRow[5] = comboBox2.Text;
            nRow[6] = dateTimePicker1.Text;
            nRow[7] = converterDemo(pictureBox1.Image);
            baseDataSet.История.Rows.Add(nRow);
            историяTableAdapter.Update(baseDataSet.История);
            baseDataSet.История.AcceptChanges();
            dataGridView1.Refresh();
            con.Open();
            string query = "Select * FROM История WHERE Пользователь LIKE '%" + user + "%'";
            OleDbDataAdapter com = new OleDbDataAdapter(query, con);
            com.Fill(dt);
            историяBindingSource.DataSource = dt;
            con.Close();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            pictureBox1.Image = null;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
        private void tabPage5_Enter(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}