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
            LoadUrunListesi();

            string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokQuery = "SELECT SUM(urun_adedi) FROM urunler";
                    MySqlCommand stokCmd = new MySqlCommand(stokQuery, conn);
                    object stokSonuc = stokCmd.ExecuteScalar();
                    txtToplamStok.Text = stokSonuc != DBNull.Value ? stokSonuc.ToString() : "0";


                    string satisQuery = "SELECT SUM(siparis_id) FROM siparis_detaylari";
                    MySqlCommand satisCmd = new MySqlCommand(satisQuery, conn);
                    object satisSonuc = satisCmd.ExecuteScalar();
                    txtToplamSatis.Text = satisSonuc != DBNull.Value ? satisSonuc.ToString() : "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void UrunleriListele()
        {
            lstUrunler.Items.Clear();

            try
            {
                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi FROM urunler ORDER BY urun_kodu";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string urunKodu = reader["urun_kodu"].ToString();
                                string urunAdi = reader["urun_adi"].ToString();
                                decimal urunFiyati = Convert.ToDecimal(reader["urun_fiyati"]);
                                int urunStok = Convert.ToInt32(reader["urun_adedi"]);

                                string listItem = $"{urunKodu} - {urunAdi} - {urunFiyati:C2} - Stok: {urunStok}";
                                lstUrunler.Items.Add(listItem);
                            }
                        }
                    }

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

        private void LoadUrunListesi()
        {
            lstUrunler.Items.Clear();

            string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi FROM urunler";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string urunKodu = reader["urun_kodu"].ToString();
                        string urunAdi = reader["urun_adi"].ToString();
                        decimal fiyat = Convert.ToDecimal(reader["urun_fiyati"]);
                        int stok = Convert.ToInt32(reader["urun_adedi"]);

                        lstUrunler.Items.Add($"{urunKodu} - {urunAdi} - ₺{fiyat:N2} - Stok: {stok}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün listesi yüklenirken hata oluştu: " + ex.Message);
                }
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
            int urunKodu = (int)numUrunKodu.Value;
            int eklenecekAdet = (int)numEklenecekAdet.Value;

            if (urunKodu <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir ürün kodu giriniz.");
                return;
            }

            string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT urun_adedi FROM urunler WHERE urun_kodu = @UrunKodu";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);

                    object result = selectCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Bu ürün koduna sahip bir ürün bulunamadı.");
                        return;
                    }

                    int mevcutStok = Convert.ToInt32(result);
                    int yeniStok = mevcutStok + eklenecekAdet;

                    string updateQuery = "UPDATE urunler SET urun_adedi = @YeniStok WHERE urun_kodu = @UrunKodu";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@YeniStok", yeniStok);
                    updateCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);

                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Stok başarıyla güncellendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string urunKodu = txtUrunKodu.Text;
                string urunTanimi = cmbUrunTanimi.Text;
                string urunAdi = txtUrunAdi.Text;
                decimal urunFiyati = 0;

                if (!decimal.TryParse(txtUrunFiyati.Text.Replace('.', ','), out urunFiyati) &&
                    !decimal.TryParse(txtUrunFiyati.Text.Replace(',', '.'), out urunFiyati))
                {
                    MessageBox.Show("Lütfen geçerli bir ürün fiyatı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int urunAdedi = Convert.ToInt32(numUrunAdedi.Value);

                if (string.IsNullOrEmpty(urunKodu) || string.IsNullOrEmpty(urunTanimi) ||
                    string.IsNullOrEmpty(urunAdi))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO urunler (urun_kodu, urun_tanimi, urun_adi, urun_fiyati, urun_adedi) " +
                                  "VALUES (@urunKodu, @urunTanimi, @urunAdi, @urunFiyati, @urunAdedi)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@urunKodu", urunKodu);
                        cmd.Parameters.AddWithValue("@urunTanimi", urunTanimi);
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                        cmd.Parameters.AddWithValue("@urunFiyati", urunFiyati);
                        cmd.Parameters.AddWithValue("@urunAdedi", urunAdedi);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("Ürün başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnSatısIslemleri_Click(object sender, EventArgs e)
        {
            DükkanSayfa dükkanSayfa = new DükkanSayfa();
            dükkanSayfa.Show();
            this.Hide();
        }

        private void txtUrunKodu_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnKasiyerEkle_Click(object sender, EventArgs e)
        {
            string kasiyerAd = txtKasiyerAdi.Text;
            string kasiyerSoyad = txtKasiyerSoyadi.Text;
            string kasiyerNo = txtKasiyerNo.Text;

            string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Kasiyerler (kasiyer_adi, kasiyer_soyadi, kasiyer_no) VALUES (@ad, @soyad, @kasiyerNo)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ad", kasiyerAd);
                    cmd.Parameters.AddWithValue("@soyad", kasiyerSoyad);
                    cmd.Parameters.AddWithValue("@kasiyerNo", kasiyerNo);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kasiyer başarıyla eklendi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void txtToplamStok_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUrunKod_TextChanged(object sender, EventArgs e)
        {

        }

        private void numUrunKodu_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
 