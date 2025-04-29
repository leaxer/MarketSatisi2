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
using System.IO;

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void KasiyerSayfa_Load(object sender, EventArgs e)
        {
            UrunleriYukle();

            // Varsayılan olarak resim butonunu ekle
            OlusturResimSecmeButonu();

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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT urun_kodu as urunId, urun_adi as urunAdi, urun_fiyati as urunFiyati, urun_adedi as urunAdedi FROM urunler";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    guna2DataGridView1.DataSource = dt;

                    guna2DataGridView1.Columns["urunId"].HeaderText = "ID";
                    guna2DataGridView1.Columns["urunAdi"].HeaderText = "Ürün";
                    guna2DataGridView1.Columns["urunFiyati"].HeaderText = "Fiyat (₺)";
                    guna2DataGridView1.Columns["urunAdedi"].HeaderText = "Stok";

                    guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    guna2DataGridView1.Columns["urunId"].Width = 60;
                    guna2DataGridView1.RowTemplate.Height = 30;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }


        //private void UrunleriListele()
        //{
        //    lstUrunler.Items.Clear();

        //    try
        //    {
        //        string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

        //        using (MySqlConnection connection = new MySqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi FROM urunler ORDER BY urun_kodu";

        //            using (MySqlCommand cmd = new MySqlCommand(query, connection))
        //            {
        //                using (MySqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        string urunKodu = reader["urun_kodu"].ToString();
        //                        string urunAdi = reader["urun_adi"].ToString();
        //                        decimal urunFiyati = Convert.ToDecimal(reader["urun_fiyati"]);
        //                        int urunStok = Convert.ToInt32(reader["urun_adedi"]);

        //                        string listItem = $"{urunKodu} - {urunAdi} - {urunFiyati:C2} - Stok: {urunStok}";
        //                        lstUrunler.Items.Add(listItem);
        //                    }
        //                }
        //            }

        //            connection.Close();
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
            int urunKodu = (int)guna2NumericUpDown1.Value;
            int eklenecekAdet = (int)guna2NumericUpDown2.Value;

            if (urunKodu <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir ürün kodu giriniz.");
                return;
            }

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

                    int affectedRows = updateCommand.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Stok başarıyla güncellendi.");
                        UrunleriYukle();
                    }
                    else
                    {
                        MessageBox.Show("Stok güncellenirken bir hata oluştu.");
                    }
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

        // Resim seçme alanlarını tanımla
        private Guna.UI2.WinForms.Guna2PictureBox urunResim;
        private Guna.UI2.WinForms.Guna2Button btnResimSec;
        private string secilenResimYolu = "";

        // Resim seçme alanını oluşturan metot
        private void OlusturResimSecmeButonu()
        {
            try
            {
                if (tabPage2.Controls.Find("urunResim", true).Length == 0)
                {
                    // PictureBox oluştur
                    urunResim = new Guna.UI2.WinForms.Guna2PictureBox();
                    urunResim.Name = "urunResim";
                    urunResim.Size = new Size(150, 150);
                    urunResim.Location = new Point(20, 120);
                    urunResim.BorderRadius = 10;
                    urunResim.SizeMode = PictureBoxSizeMode.Zoom;
                    urunResim.BorderStyle = BorderStyle.FixedSingle;
                    tabPage2.Controls.Add(urunResim);

                    // Varsayılan resim
                    try
                    {
                        if (Properties.Resources.ResourceManager.GetObject("default_product") != null)
                        {
                            urunResim.Image = (Image)Properties.Resources.ResourceManager.GetObject("default_product");
                        }
                    }
                    catch
                    {
                        // Varsayılan resim yoksa boş bırak
                    }

                    // Resim seç butonu
                    btnResimSec = new Guna.UI2.WinForms.Guna2Button();
                    btnResimSec.Name = "btnResimSec";
                    btnResimSec.Text = "Resim Seç";
                    btnResimSec.Size = new Size(150, 36);
                    btnResimSec.Location = new Point(20, 280);
                    btnResimSec.BorderRadius = 8;
                    btnResimSec.FillColor = Color.FromArgb(72, 72, 176);
                    btnResimSec.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    btnResimSec.ForeColor = Color.White;
                    btnResimSec.Click += BtnResimSec_Click;
                    tabPage2.Controls.Add(btnResimSec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim seçme alanı oluşturulurken hata: " + ex.Message);
            }
        }

        // Resim seçme butonu için olay işleyici
        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Ürün Resmi Seç";
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    secilenResimYolu = openFileDialog.FileName;
                    try
                    {
                        using (FileStream fs = new FileStream(secilenResimYolu, FileMode.Open, FileAccess.Read))
                        {
                            urunResim.Image = Image.FromStream(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            int urunKodu;
            if (!int.TryParse(guna2TextBox1.Text, out urunKodu))
            {
                MessageBox.Show("Ürün kodu sayısal olmalıdır.");
                return;
            }

            string urunAdi = guna2TextBox3.Text.Trim();
            if (string.IsNullOrEmpty(urunAdi))
            {
                MessageBox.Show("Ürün adı boş olamaz.");
                return;
            }

            decimal urunFiyati;
            if (!decimal.TryParse(guna2TextBox2.Text, out urunFiyati) || urunFiyati <= 0)
            {
                MessageBox.Show("Geçerli bir ürün fiyatı giriniz.");
                return;
            }

            int urunAdedi = (int)guna2NumericUpDown3.Value;
            string urunTanimi = guna2ComboBox1.Text;

            // Resmi base64'e çevir
            string resimBase64 = "";
            if (!string.IsNullOrEmpty(secilenResimYolu) && File.Exists(secilenResimYolu))
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(secilenResimYolu);
                    resimBase64 = Convert.ToBase64String(imageBytes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim dönüştürülürken hata: " + ex.Message);
                }
            }
            else if (urunResim != null && urunResim.Image != null)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        urunResim.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] imageBytes = ms.ToArray();
                        resimBase64 = Convert.ToBase64String(imageBytes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim dönüştürülürken hata: " + ex.Message);
                }
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM urunler WHERE urun_kodu = @UrunKodu";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);

                    int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (existingCount > 0)
                    {
                        MessageBox.Show("Bu ürün kodu zaten kullanılmaktadır.");
                        return;
                    }

                    // SQL sorgusuna resim alanını ekle
                    string insertQuery = "INSERT INTO urunler (urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi, urun_resim) VALUES (@UrunKodu, @UrunAdi, @UrunFiyati, @UrunAdedi, @UrunTanimi, @UrunResim)";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@UrunKodu", urunKodu);
                    insertCommand.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    insertCommand.Parameters.AddWithValue("@UrunFiyati", urunFiyati);
                    insertCommand.Parameters.AddWithValue("@UrunAdedi", urunAdedi);
                    insertCommand.Parameters.AddWithValue("@UrunTanimi", urunTanimi);
                    insertCommand.Parameters.AddWithValue("@UrunResim", resimBase64);

                    int affectedRows = insertCommand.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Ürün başarıyla eklendi.");
                        UrunleriYukle();

                        // Form alanlarını temizle
                        guna2TextBox1.Clear();
                        guna2TextBox3.Clear();
                        guna2TextBox2.Clear();
                        guna2NumericUpDown3.Value = 0;
                        guna2ComboBox1.SelectedIndex = -1;
                        secilenResimYolu = "";
                        
                        // Resmi varsayılana çevir
                        try
                        {
                            if (Properties.Resources.ResourceManager.GetObject("default_product") != null)
                            {
                                urunResim.Image = (Image)Properties.Resources.ResourceManager.GetObject("default_product");
                            }
                            else
                            {
                                urunResim.Image = null;
                            }
                        }
                        catch
                        {
                            urunResim.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ürün eklenirken bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
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
    }
}
 
