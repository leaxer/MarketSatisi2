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
using System.Data.SqlClient;

namespace MarketSatis1
{
    public partial class KasiyerSayfa : Form
    {
        private readonly string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

        public KasiyerSayfa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void KasiyerSayfa_Load(object sender, EventArgs e)
        {
            UrunleriYukle();
            RaporOlustur();
            StokVeSatisBilgileriniYukle();
        }

        private void StokVeSatisBilgileriniYukle()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string stokQuery = "SELECT SUM(urun_adedi) FROM urunler";
                    MySqlCommand stokCmd = new MySqlCommand(stokQuery, conn);
                    object stokSonuc = stokCmd.ExecuteScalar();
                    guna2TextBox4.Text = stokSonuc != DBNull.Value ? stokSonuc.ToString() : "0";

                    string satisQuery = "SELECT COUNT(DISTINCT siparis_id) FROM siparisler";
                    MySqlCommand satisCmd = new MySqlCommand(satisQuery, conn);
                    object satisSonuc = satisCmd.ExecuteScalar();
                    guna2TextBox5.Text = satisSonuc != DBNull.Value ? satisSonuc.ToString() + " adet sipariş" : "0 adet sipariş";
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
                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi, urun_alis " +
                                 "FROM urunler ORDER BY CAST(urun_kodu AS SIGNED)";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    guna2DataGridView1.DataSource = dt;

                    // Sütun başlıklarını ayarla
                    string[] columnMappings = {
                        "urun_kodu", "Ürün Kodu",
                        "urun_adi", "Ürün Adı",
                        "urun_fiyati", "Satış Fiyatı (₺)",
                        "urun_adedi", "Stok",
                        "urun_tanimi", "Tanım",
                        "urun_alis", "Alış Fiyatı (₺)"
                    };

                    for (int i = 0; i < columnMappings.Length; i += 2)
                    {
                        guna2DataGridView1.Columns[columnMappings[i]].HeaderText = columnMappings[i + 1];
                    }

                    // Görünüm ayarları
                    DataGridViewGorunumAyarla(guna2DataGridView1);

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

        private void DataGridViewGorunumAyarla(Guna2DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 35;

            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!UrunEklemeValidasyonu()) return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    if (UrunKoduKontrol(connection)) return;

                    UrunEkle(connection);
                    MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UrunleriYukle();
                    FormTemizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UrunEklemeValidasyonu()
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) ||
                string.IsNullOrWhiteSpace(guna2TextBox2.Text) ||
                string.IsNullOrWhiteSpace(guna2TextBox3.Text) ||
                string.IsNullOrWhiteSpace(guna2ComboBox1.Text) ||
                string.IsNullOrWhiteSpace(txtUrunAlis.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(guna2TextBox1.Text.Trim(), out int urunKodu))
            {
                MessageBox.Show("Ürün kodu sayısal bir değer olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(guna2TextBox3.Text.Trim(), out decimal urunFiyati) || urunFiyati <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir ürün fiyatı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtUrunAlis.Text.Trim(), out decimal urunAlisFiyati) || urunAlisFiyati <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir ürün alış fiyatı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool UrunKoduKontrol(MySqlConnection connection)
        {
            string checkQuery = "SELECT COUNT(*) FROM urunler WHERE urun_kodu = @UrunKodu";
            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
            {
                checkCommand.Parameters.AddWithValue("@UrunKodu", guna2TextBox1.Text.Trim());
                int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (existingCount > 0)
                {
                    MessageBox.Show("Bu ürün kodu zaten kullanılmaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private void UrunEkle(MySqlConnection connection)
        {
            string insertQuery = "INSERT INTO urunler (urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi, urun_alis) " +
                              "VALUES (@UrunKodu, @UrunAdi, @UrunFiyati, @UrunAdedi, @UrunTanimi, @UrunAlis)";

            using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@UrunKodu", guna2TextBox1.Text.Trim());
                command.Parameters.AddWithValue("@UrunAdi", guna2TextBox2.Text.Trim());
                command.Parameters.AddWithValue("@UrunFiyati", decimal.Parse(guna2TextBox3.Text.Trim()));
                command.Parameters.AddWithValue("@UrunAdedi", (int)guna2NumericUpDown3.Value);
                command.Parameters.AddWithValue("@UrunTanimi", guna2ComboBox1.Text.Trim());
                command.Parameters.AddWithValue("@UrunAlis", decimal.Parse(txtUrunAlis.Text.Trim()));

                command.ExecuteNonQuery();
            }
        }

        private void FormTemizle()
        {
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2NumericUpDown3.Value = 0;
            guna2ComboBox1.SelectedIndex = -1;
            txtUrunAlis.Clear();
        }

        private void btnSatısIslemleri_Click(object sender, EventArgs e)
        {
            DükkanSayfa dükkanSayfa = new DükkanSayfa();
            dükkanSayfa.Show();
            this.Hide();
        }

        private void btnKasiyerEkle_Click(object sender, EventArgs e)
        {
            if (!KasiyerEklemeValidasyonu()) return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    KasiyerEkle(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private bool KasiyerEklemeValidasyonu()
        {
            string kasiyerAdi = guna2TextBox6.Text.Trim();
            string kasiyerSoyadi = guna2TextBox7.Text.Trim();

            if (!int.TryParse(guna2TextBox8.Text, out int kasiyerNo))
            {
                MessageBox.Show("Kasiyer numarası sayısal olmalıdır.");
                return false;
            }

            if (string.IsNullOrEmpty(kasiyerAdi) || string.IsNullOrEmpty(kasiyerSoyadi))
            {
                MessageBox.Show("Kasiyer adı ve soyadı boş bırakılamaz.");
                return false;
            }

            return true;
        }

        private void KasiyerEkle(MySqlConnection connection)
        {
            string insertQuery = "INSERT INTO kasiyerler (kasiyer_no, kasiyer_adi, kasiyer_soyadi) VALUES (@KasiyerNo, @KasiyerAdi, @KasiyerSoyadi)";
            using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@KasiyerNo", int.Parse(guna2TextBox8.Text));
                command.Parameters.AddWithValue("@KasiyerAdi", guna2TextBox6.Text.Trim());
                command.Parameters.AddWithValue("@KasiyerSoyadi", guna2TextBox7.Text.Trim());

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
                    StokGuncelle(connection, urunKodu, eklenecekAdet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StokGuncelle(MySqlConnection connection, int urunKodu, int eklenecekAdet)
        {
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

        private void RaporOlustur()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            u.urun_kodu,
                            u.urun_adi,
                            u.urun_fiyati,
                            u.urun_adedi as urun_miktari,
                            u.urun_tanimi as urun_kategorisi,
                            u.urun_alis as urun_alis_fiyati,
                            (u.urun_fiyati - u.urun_alis) as kar,
                            COALESCE((
                                SELECT SUM(sd.adet * (u.urun_fiyati - u.urun_alis))
                                FROM siparis_detaylari sd
                                INNER JOIN siparisler s ON sd.siparis_id = s.siparis_id
                                WHERE sd.urun_kodu = u.urun_kodu
                                AND MONTH(s.siparis_tarihi) = MONTH(CURRENT_DATE())
                                AND YEAR(s.siparis_tarihi) = YEAR(CURRENT_DATE())
                            ), 0) as aylik_kar
                        FROM urunler u
                        ORDER BY u.urun_adi";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        string[] columnMappings = {
                            "urun_kodu", "Ürün Kodu",
                            "urun_adi", "Ürün Adı",
                            "urun_fiyati", "Satış Fiyatı",
                            "urun_miktari", "Stok Miktarı",
                            "urun_kategorisi", "Kategori",
                            "urun_alis_fiyati", "Alış Fiyatı",
                            "kar", "Birim Kar",
                            "aylik_kar", "Aylık Toplam Kar"
                        };

                        for (int i = 0; i < columnMappings.Length; i += 2)
                        {
                            dt.Columns[columnMappings[i]].ColumnName = columnMappings[i + 1];
                        }

                        guna2DataGridView2.DataSource = dt;

                        string[] currencyColumns = { "Satış Fiyatı", "Alış Fiyatı", "Birim Kar", "Aylık Toplam Kar" };
                        foreach (string column in currencyColumns)
                        {
                            guna2DataGridView2.Columns[column].DefaultCellStyle.Format = "N2";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void txtUrunKodu_TextChanged(object sender, EventArgs e) { }
        private void txtToplamStok_TextChanged(object sender, EventArgs e) { }
        private void txtUrunKod_TextChanged(object sender, EventArgs e) { }
        private void numUrunKodu_ValueChanged(object sender, EventArgs e) { }
        private void txtToplamSatis_TextChanged(object sender, EventArgs e) { }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
        private void guna2NumericUpDown3_ValueChanged(object sender, EventArgs e) { }
        private void guna2HtmlLabel3_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel4_Click(object sender, EventArgs e) { }
    }
}