using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasTrut
{
    public partial class Form2 : Form
    {
        db db = new db();
        public Form2()
        {
            InitializeComponent();
            Event(listBox1);
        }

        public void Event(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Equipment";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"id: {reader["EquipmentID"].ToString()} | Название: {reader["Название"].ToString()} | Тип: {reader["Тип"].ToString()} | Количество: {reader["Количество"].ToString()} | Состояние: {reader["Состояние"].ToString()} | Дата установки: {reader["Дата_установки"].ToString()} | Дата списания: {reader["Дата_списания"].ToString()}");
                    }
                }
            }
            db.con.Close();
        }

        public void P()
        {
            string query = $"INSERT INTO Equipment (Название, Тип, Количество, Состояние, Дата_установки, Дата_списания) VALUES  ('{textBox1.Text}','{textBox3.Text}','{numericUpDown1.Value}','{textBox2.Text}', '{dateTimePicker1.Text}', '{dateTimePicker2.Text}')";
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

        private void Delete()
        {

            string query = $"DELETE FROM Equipment WHERE EquipmentID = {textBox4.Text}";

            using (SqlCommand command = new SqlCommand(query, db.con))
            {
                db.con.Open();
                command.ExecuteNonQuery();
                db.con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Delete();
            Event(listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            string header = "Отчет";
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            graphics.DrawString(header, headerFont, Brushes.Black, 100, 100);

            int y = 150;
            foreach (string item in listBox1.Items)
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.LineAlignment = StringAlignment.Near;
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.Trimming = StringTrimming.Word;

                graphics.DrawString(item, new Font("Arial", 12), Brushes.Black, 100, y, stringFormat);

                y += 20;
            }
        }
    }
}
