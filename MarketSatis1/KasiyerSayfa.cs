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

            string ad = txtUrunFiyati.Text;
            string soyad = textBox4.Text;
            string email = txtUrunKodu.Text;
            string password = txtUrunAdi.Text;


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
            UrunleriListele();
        }


        private void UrunleriListele()
        {
            // ListBox'ı temizle
            lstUrunler.Items.Clear();

            try
            {
                // Veritabanı bağlantı bilgileri
                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // SQL sorgusu
                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi FROM urunler ORDER BY urun_kodu";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Verileri oku ve ListBox'a ekle
                            while (reader.Read())
                            {
                                string urunKodu = reader["urun_kodu"].ToString();
                                string urunAdi = reader["urun_adi"].ToString();
                                decimal urunFiyati = Convert.ToDecimal(reader["urun_fiyati"]);
                                int urunStok = Convert.ToInt32(reader["urun_adedi"]);

                                // İstenilen formatta ListBox'a ekle
                                string listItem = $"{urunKodu} - {urunAdi} - {urunFiyati:C2} - Stok: {urunStok}";
                                lstUrunler.Items.Add(listItem);
                            }
                        }
                    }

                    // Bağlantıyı kapat
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from form fields
                string urunKodu = txtUrunKodu.Text;
                string urunTanimi = cmbUrunTanimi.Text;
                string urunAdi = txtUrunAdi.Text;
                decimal urunFiyati = 0;

                // Parse price value with appropriate decimal separator
                if (!decimal.TryParse(txtUrunFiyati.Text.Replace('.', ','), out urunFiyati) &&
                    !decimal.TryParse(txtUrunFiyati.Text.Replace(',', '.'), out urunFiyati))
                {
                    MessageBox.Show("Lütfen geçerli bir ürün fiyatı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get product quantity
                int urunAdedi = Convert.ToInt32(numUrunAdedi.Value);

                // Validate inputs
                if (string.IsNullOrEmpty(urunKodu) || string.IsNullOrEmpty(urunTanimi) ||
                    string.IsNullOrEmpty(urunAdi))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create MySQL connection

                string connectionString = "Server=localhost; Database=marketsatis; Uid=root; Pwd=2007;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Open connection
                    connection.Open();

                    // Prepare SQL command
                    string query = "INSERT INTO urunler (urun_kodu, urun_tanimi, urun_adi, urun_fiyati, urun_adedi) " +
                                  "VALUES (@urunKodu, @urunTanimi, @urunAdi, @urunFiyati, @urunAdedi)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@urunKodu", urunKodu);
                        cmd.Parameters.AddWithValue("@urunTanimi", urunTanimi);
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                        cmd.Parameters.AddWithValue("@urunFiyati", urunFiyati);
                        cmd.Parameters.AddWithValue("@urunAdedi", urunAdedi);

                        // Execute command
                        cmd.ExecuteNonQuery();
                    }

                    // Close connection
                    connection.Close();
                }

                MessageBox.Show("Ürün başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form fields
                txtUrunKodu.Clear();
                cmbUrunTanimi.Text = "";
                txtUrunKodu.Clear();
                txtUrunFiyati.Clear();
                numUrunAdedi.Value = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
 