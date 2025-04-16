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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcının girdiği değerleri al
                string urunKodu = txtUrunKodu.Text.Trim();
                int eklenecekAdet = Convert.ToInt32(numEklenecekAdet.Value);

                // Girdileri kontrol et
                if (string.IsNullOrEmpty(urunKodu))
                {
                    MessageBox.Show("Lütfen bir ürün kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Veritabanı bağlantısı
                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Önce ürünün mevcut olup olmadığını kontrol et
                    string checkQuery = "SELECT urun_adedi FROM urunler WHERE urun_kodu = @urunKodu";
                    int mevcutAdet = 0;
                    bool urunBulundu = false;

                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@urunKodu", urunKodu);

                        using (MySqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mevcutAdet = Convert.ToInt32(reader["urun_adedi"]);
                                urunBulundu = true;
                            }
                        }
                    }

                    if (!urunBulundu)
                    {
                        MessageBox.Show("Girilen ürün kodu ile eşleşen ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Yeni adet değerini hesapla
                    int yeniAdet = mevcutAdet + eklenecekAdet;

                    // Eğer yeni adet negatifse uyarı ver
                    if (yeniAdet < 0)
                    {
                        MessageBox.Show("Stok miktarı negatif olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Güncelleme sorgusunu hazırla ve çalıştır
                    string updateQuery = "UPDATE urunler SET urun_adedi = @yeniAdet WHERE urun_kodu = @urunKodu";

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@yeniAdet", yeniAdet);
                        updateCmd.Parameters.AddWithValue("@urunKodu", urunKodu);

                        int affectedRows = updateCmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show($"Ürün stok adedi başarıyla güncellendi. Yeni stok: {yeniAdet}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Formu temizle
                            txtUrunKodu.Clear();
                            numEklenecekAdet.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
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
                txtUrunAdi.Clear();
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

        private void btnSatısIslemler(object sender, EventArgs e)
        {
            DükkanSayfa dükkanSayfa = new DükkanSayfa();
            dükkanSayfa.Show();
            this.Hide();
        }
    }
}
 