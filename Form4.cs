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
    public partial class Form4 : Form
    {
        db db = new db();
        public Form4()
        {
            InitializeComponent();
            Event(listBox1);
        }

        public void Event(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"id: {reader["UserID"].ToString()} | Логин: {reader["Логин"].ToString()} | Пароль: {reader["Пароль"].ToString()} | Роль: {reader["Роль"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        private void Delete()
        {

            string query = $"DELETE FROM Users WHERE UserID = {textBox4.Text}";

            using (SqlCommand command = new SqlCommand(query, db.con))
            {
                db.con.Open();
                command.ExecuteNonQuery();
                db.con.Close();
            }
        }

        public void P()
        {
            string query = $"INSERT INTO Users (Логин, Пароль, Роль) VALUES  ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}')";
            SqlCommand command = new SqlCommand(query, db.con);


            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Изменено", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Delete();
            Event(listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            P();
            Event(listBox1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var selectedItemText = selectedItem.ToString();

                var lines = selectedItemText.Split();

                textBox4.Text = lines[1];
            }
        }
    }
}
