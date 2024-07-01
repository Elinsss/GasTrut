using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasTrut
{
    public partial class Form3 : Form
    {
        db db = new db();

        public Form3()
        {
            InitializeComponent();
        }

        private void logins()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string query = $"select * from Users where Логин='{textBox1.Text}' and Пароль='{textBox2.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            adapter.SelectCommand = command;

            adapter.Fill(Table);

            if (Table.Rows.Count == 1)
            {
                acc.name = textBox1.Text;
                MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 p = new Form1();
                p.ShowDialog();

                db.con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                db.con.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                logins();
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
