using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MarketSatis1
{
    public partial class KasiyerSayfa : Form
    {
        public KasiyerSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Bağlantı dizesi
            string connectionString = "Server=localhost; Database=marketsatis; Uid=root; Pwd=2007;";

            string ad = textBox1.Text;
            string soyad = textBox4.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;


            string query = "INSERT INTO Kullanıcılar (Ad, Soyad, Email, Password) VALUES (@ad, @soyad, @email, @password);";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Database başarıyla oluştu.");
                    MessageBox.Show("Veri başarıyla eklendi!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void KasiyerSayfa_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
 