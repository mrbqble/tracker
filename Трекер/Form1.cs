using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Трекер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "baseDataSet.Аккаунты". При необходимости она может быть перемещена или удалена.
            this.аккаунтыTableAdapter.Fill(this.baseDataSet.Аккаунты);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a=0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox1.Text)
                    {
                        dataGridView1.Rows[i].Selected = true;
                        if (dataGridView1.Rows[i].Cells[2].Value.ToString() == textBox2.Text)
                        {
                            Form2 af = new Form2();
                            af.user = textBox1.Text;
                            af.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный пароль. Попробуйте еще раз!", "Ошибка!");
                        }
                        break;
                    }
                }
                a = i;
            }
            if (a == dataGridView1.RowCount - 1 && dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Неправильный логин. Попробуйте еще раз!", "Ошибка!");
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Show();
            tabControl1.SelectTab(1);
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabPage2.Hide();
            tabPage1.Show();
            tabControl1.SelectTab(0);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)
            {
                DataRow nRow = baseDataSet.Tables[0].NewRow();
                int rc = dataGridView1.RowCount;
                nRow[0] = rc;
                nRow[1] = textBox3.Text;
                nRow[2] = textBox4.Text;
                baseDataSet.Tables[0].Rows.Add(nRow);
                аккаунтыTableAdapter.Update(baseDataSet.Аккаунты);
                baseDataSet.Tables[0].AcceptChanges();
                dataGridView1.Refresh();
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}