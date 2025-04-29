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
using Guna.UI2.WinForms;

namespace MarketSatis1
{
    public partial class KasiyerSayfa : Form
    {
        public KasiyerSayfa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

        private void KasiyerSayfa_Load(object sender, EventArgs e)
        {
            UrunleriYukle();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokQuery = "SELECT SUM(urun_adedi) FROM urunler";
                    MySqlCommand stokCmd = new MySqlCommand(stokQuery, conn);
                    object stokSonuc = stokCmd.ExecuteScalar();
                    guna2TextBox4.Text = stokSonuc != DBNull.Value ? stokSonuc.ToString() : "0";

                    string satisQuery = "SELECT SUM(siparis_id) FROM siparis_detaylari";
                    MySqlCommand satisCmd = new MySqlCommand(satisQuery, conn);
                    object satisSonuc = satisCmd.ExecuteScalar();
                    guna2TextBox5.Text = satisSonuc != DBNull.Value ? satisSonuc.ToString() : "0";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void UrunleriYukle()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT urun_kodu, urun_adi, " +
                                 "urun_fiyati, urun_adedi, urun_tanimi " +
                                 "FROM urunler ORDER BY CAST(urun_kodu AS SIGNED)";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // DataGridView'e veri kaynağını ata
                    guna2DataGridView1.DataSource = dt;

                    // Sütun başlıklarını ayarla
                    guna2DataGridView1.Columns["urun_kodu"].HeaderText = "Ürün Kodu";
                    guna2DataGridView1.Columns["urun_adi"].HeaderText = "Ürün Adı";
                    guna2DataGridView1.Columns["urun_fiyati"].HeaderText = "Fiyat (₺)";
                    guna2DataGridView1.Columns["urun_adedi"].HeaderText = "Stok";
                    guna2DataGridView1.Columns["urun_tanimi"].HeaderText = "Tanım";

                    // Sütun genişliklerini ayarla
                    guna2DataGridView1.Columns["urun_kodu"].Width = 98;
                    guna2DataGridView1.Columns["urun_adi"].Width = 97;
                    guna2DataGridView1.Columns["urun_fiyati"].Width = 98;
                    guna2DataGridView1.Columns["urun_adedi"].Width = 97;
                    guna2DataGridView1.Columns["urun_tanimi"].Width = 98;

                    // Para formatını ayarla
                    guna2DataGridView1.Columns["urun_fiyati"].DefaultCellStyle.Format = "N2";

                    // Sıralama ayarları
                    foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Boş alan kontrolü
                if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox2.Text) ||
                    string.IsNullOrWhiteSpace(guna2TextBox3.Text) ||
                    string.IsNullOrWhiteSpace(guna2ComboBox1.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ürün kodu kontrolü
                int urunKodu;
                if (!int.TryParse(guna2TextBox1.Text.Trim(), out urunKodu))
                {
                    MessageBox.Show("Ürün kodu sayısal bir değer olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fiyat kontrolü
                decimal urunFiyati;
                if (!decimal.TryParse(guna2TextBox3.Text.Trim(), out urunFiyati) || urunFiyati <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir ürün fiyatı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Ürün kodu kontrolü
                    string checkQuery = "SELECT COUNT(*) FROM urunler WHERE urun_kodu = @UrunKodu";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);
                        int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (existingCount > 0)
                        {
                            MessageBox.Show("Bu ürün kodu zaten kullanılmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Ürün ekleme
                    string insertQuery = "INSERT INTO urunler (urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi) " +
                                      "VALUES (@UrunKodu, @UrunAdi, @UrunFiyati, @UrunAdedi, @UrunTanimi)";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UrunKodu", urunKodu);
                        command.Parameters.AddWithValue("@UrunAdi", guna2TextBox2.Text.Trim());
                        command.Parameters.AddWithValue("@UrunFiyati", urunFiyati);
                        command.Parameters.AddWithValue("@UrunAdedi", (int)guna2NumericUpDown3.Value);
                        command.Parameters.AddWithValue("@UrunTanimi", guna2ComboBox1.Text.Trim());

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UrunleriYukle();

                    // Form alanlarını temizle
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();
                    guna2NumericUpDown3.Value = 0;
                    guna2ComboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string kasiyerAdi = guna2TextBox6.Text.Trim();
            string kasiyerSoyadi = guna2TextBox7.Text.Trim();
            int kasiyerNo;

            if (!int.TryParse(guna2TextBox8.Text, out kasiyerNo))
            {
                MessageBox.Show("Kasiyer numarası sayısal olmalıdır.");
                return;
            }

            if (string.IsNullOrEmpty(kasiyerAdi) || string.IsNullOrEmpty(kasiyerSoyadi))
            {
                MessageBox.Show("Kasiyer adı ve soyadı boş bırakılamaz.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO kasiyerler (kasiyer_no, kasiyer_adi, kasiyer_soyadi) VALUES (@KasiyerNo, @KasiyerAdi, @KasiyerSoyadi)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@KasiyerNo", kasiyerNo);
                    command.Parameters.AddWithValue("@KasiyerAdi", kasiyerAdi);
                    command.Parameters.AddWithValue("@KasiyerSoyadi", kasiyerSoyadi);

                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Kasiyer başarıyla eklendi.");
                        guna2TextBox6.Clear();
                        guna2TextBox7.Clear();
                        guna2TextBox8.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Kasiyer eklenirken bir hata oluştu.");
                    }
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

        private void txtToplamSatis_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Boş event handler
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // Boş event handler
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int urunKodu = (int)guna2NumericUpDown1.Value;
                int eklenecekAdet = (int)guna2NumericUpDown2.Value;

                if (urunKodu <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir ürün kodu giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT urun_adedi FROM urunler WHERE urun_kodu = @UrunKodu";
                    using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);
                        object result = selectCommand.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Bu ürün koduna sahip bir ürün bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int mevcutStok = Convert.ToInt32(result);
                        int yeniStok = mevcutStok + eklenecekAdet;

                        if (yeniStok < 0)
                        {
                            MessageBox.Show("Stok miktarı 0'dan küçük olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string updateQuery = "UPDATE urunler SET urun_adedi = @YeniStok WHERE urun_kodu = @UrunKodu";
                        using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@YeniStok", yeniStok);
                            updateCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);

                            int affectedRows = updateCommand.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Stok başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UrunleriYukle();
                                guna2NumericUpDown1.Value = 0;
                                guna2NumericUpDown2.Value = 0;
                            }
                            else
                            {
                                MessageBox.Show("Stok güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            // Boş event handler
        }

        private void guna2NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
 
