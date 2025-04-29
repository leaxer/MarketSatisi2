using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace MarketSatis1
{
    public partial class DükkanSayfa : Form
    {
        private List<Urun> urunListesi = new List<Urun>();
        private List<SepetItem> sepetListesi = new List<SepetItem>();
        private bool krediKartiSecili = false;
        private Label lblUrunSayisi;
        private Guna.UI2.WinForms.Guna2TextBox txtAra;

        // Ürün resmi, adı ve fiyatını gösterecek bileşenler
        private Guna.UI2.WinForms.Guna2PictureBox urunResim;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUrunAdi;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUrunFiyat;
        private Guna.UI2.WinForms.Guna2Panel urunDetayPanel;

        public DükkanSayfa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label ve TextBox bileşenlerini oluştur
            lblUrunSayisi = new Label();
            lblUrunSayisi.Location = new Point(20, 530);
            lblUrunSayisi.Size = new Size(200, 23);
            lblUrunSayisi.Font = new Font("Segoe UI", 9);
            tabPage1.Controls.Add(lblUrunSayisi);

            // Arama TextBox oluştur
            txtAra = new Guna.UI2.WinForms.Guna2TextBox();
            txtAra.PlaceholderText = "Ürün ara...";
            txtAra.Location = new Point(20, 540);
            txtAra.Size = new Size(200, 36);
            txtAra.BorderRadius = 5;
            tabPage1.Controls.Add(txtAra);

            // Form yüklendiğinde DataGridView'leri yapılandır ve doldur
            this.Load += DükkanSayfa_Load;
        }

        string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

        public class Urun
        {
            public string UrunKodu { get; set; }
            public string UrunAdi { get; set; }
            public decimal Fiyat { get; set; }
            public int Stok { get; set; }
            public string ResimBase64 { get; set; }

            public override string ToString()
            {
                return $"{UrunKodu} - {UrunAdi} - {Fiyat:C2}";
            }
        }

        public class SepetItem
        {
            public string UrunKodu { get; set; }
            public string UrunAdi { get; set; }
            public decimal BirimFiyat { get; set; }
            public int Adet { get; set; }
            public decimal ToplamFiyat { get; set; }

            public override string ToString()
            {
                return $"{UrunKodu} - {UrunAdi} - {BirimFiyat:C2} - {Adet} adet - {ToplamFiyat:C2}";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DükkanSayfa_Load(object sender, EventArgs e)
        {
            // Ürün detay panelini oluştur
            OlusturUrunDetayPaneli();
            
            KonfigureDataGridViews();
            
            // DataGridView görünümlerini iyileştir
            IyilestirDataGridViewGorunumu(guna2DataGridView1);
            IyilestirDataGridViewGorunumu(guna2DataGridView2);
            
            UrunleriYukle();
            SepetDurumunuGuncelle(); // Sepet durumunu güncelle
            
            // Event handler'ları ekle
            txtAra.TextChanged += txtAra_TextChanged;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
        }

        private void KonfigureDataGridViews()
        {
            try
            {
                // Ürün listesi DataGridView sütunlarını temizle ve yeniden yapılandır
                guna2DataGridView1.Columns.Clear();

                // Ürün listesi için sütunlar ekle
                guna2DataGridView1.Columns.Add("UrunKodu", "Ürün Kodu");
                guna2DataGridView1.Columns.Add("UrunAdi", "Ürün Adı");
                guna2DataGridView1.Columns.Add("Fiyat", "Fiyat");
                guna2DataGridView1.Columns.Add("Stok", "Stok");
                guna2DataGridView1.Columns.Add("Tanim", "Tanım");

                // Sütun genişlikleri ayarla
                guna2DataGridView1.Columns["UrunKodu"].Width = 90;
                guna2DataGridView1.Columns["UrunAdi"].Width = 170;
                guna2DataGridView1.Columns["Fiyat"].Width = 70;
                guna2DataGridView1.Columns["Stok"].Width = 60;
                guna2DataGridView1.Columns["Tanim"].Width = 180;

                // Sepet DataGridView sütunlarını temizle ve yeniden yapılandır
                guna2DataGridView2.Columns.Clear();

                // Sepet için sütunlar ekle
                guna2DataGridView2.Columns.Add("UrunKodu", "Ürün Kodu");
                guna2DataGridView2.Columns.Add("UrunAdi", "Ürün Adı");
                guna2DataGridView2.Columns.Add("BirimFiyat", "Birim Fiyat");
                guna2DataGridView2.Columns.Add("Adet", "Adet");
                guna2DataGridView2.Columns.Add("ToplamFiyat", "Toplam Fiyat");

                // Sepet sütun genişlikleri ayarla
                guna2DataGridView2.Columns["UrunKodu"].Width = 80;
                guna2DataGridView2.Columns["UrunAdi"].Width = 150;
                guna2DataGridView2.Columns["BirimFiyat"].Width = 90;
                guna2DataGridView2.Columns["Adet"].Width = 50;
                guna2DataGridView2.Columns["ToplamFiyat"].Width = 110;

                // DataGridView'lerin genel ayarları
                foreach (DataGridView dgv in new[] { guna2DataGridView1, guna2DataGridView2 })
                {
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToDeleteRows = false;
                    dgv.AllowUserToResizeRows = false;
                    dgv.ReadOnly = true;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.MultiSelect = false;
                    dgv.RowHeadersVisible = false;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGridView'ler yapılandırılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IyilestirDataGridViewGorunumu(Guna.UI2.WinForms.Guna2DataGridView dataGridView)
        {
            // DataGridView görünümünü iyileştir
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(72, 72, 176);
            dataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            
            // Satır renkleri
            dataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(240, 240, 240);
            
            // Seçili satır rengi
            dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(125, 124, 184);
            dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
        }

        private void UrunleriYukle()
        {
            try
            {
                // DataGridView'i temizle
                guna2DataGridView1.Rows.Clear();
                urunListesi.Clear();

                // Veritabanı bağlantısını oluştur
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Tüm ürünleri getiren sorgu - resim de dahil
                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi, urun_resim " +
                                   "FROM urunler " +
                                   "ORDER BY urun_adi";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Verileri oku
                                string urunKodu = reader["urun_kodu"].ToString();
                                string urunAd = reader["urun_adi"].ToString();
                                decimal fiyat = Convert.ToDecimal(reader["urun_fiyati"]);
                                int stok = Convert.ToInt32(reader["urun_adedi"]);
                                string tanim = reader["urun_tanimi"].ToString();
                                
                                // Resim verisini oku
                                string resimBase64 = string.Empty;
                                if (!reader.IsDBNull(reader.GetOrdinal("urun_resim")))
                                {
                                    resimBase64 = reader["urun_resim"].ToString();
                                }

                                // Urun nesnesi oluştur
                                Urun urun = new Urun
                                {
                                    UrunKodu = urunKodu,
                                    UrunAdi = urunAd,
                                    Fiyat = fiyat,
                                    Stok = stok,
                                    ResimBase64 = resimBase64
                                };

                                // Urun listesine ekle
                                urunListesi.Add(urun);

                                // DataGridView'e ekle
                                int rowIndex = guna2DataGridView1.Rows.Add(urunKodu, urunAd, fiyat.ToString("F2"), stok, tanim);
                                guna2DataGridView1.Rows[rowIndex].Tag = urun;
                            }
                        }
                    }
                }

                // Ürün sayısını göster
                lblUrunSayisi.Text = $"Toplam {guna2DataGridView1.Rows.Count} ürün listelendi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Sepet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnToplamTutarHesapla_Click(object sender, EventArgs e)
        {
            HesaplaToplam();
        }

        private void btnSiparisiOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                string fis = "      *** MAĞAZA FİŞİ ***\n";
                fis += "-----------------------------\n";

                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (row.Tag is SepetItem item)
                    {
                        fis += $"{item.UrunAdi} - {item.Adet} adet - {item.ToplamFiyat:C2}\n";
                    }
                }

                fis += "-----------------------------\n";

                fis += $"Toplam Tutar: {guna2TextBox3.Text}\n";
                fis += $"Ödenecek Tutar: {guna2TextBox4.Text}\n";

                if (guna2RadioButton1.Checked)
                    fis += "Ödeme Yöntemi: Nakit\n";
                else if (guna2RadioButton2.Checked)
                    fis += "Ödeme Yöntemi: Kredi Kartı\n";

                fis += "-----------------------------\n";
                fis += $"Tarih: {DateTime.Now}\n";
                fis += "        TEŞEKKÜRLER!\n";

                MessageBox.Show(fis, "Sipariş Fişi");

                // Sipariş oluştur
                SiparisOlustur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiş oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ürünler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                Urun seciliUrun = (Urun)selectedRow.Tag;

                guna2NumericUpDown1.Maximum = seciliUrun.Stok;
                guna2NumericUpDown1.Value = 1;
                decimal tutar = seciliUrun.Fiyat * 1;
                guna2TextBox1.Text = tutar.ToString("C2");
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
            Urun seciliUrun = (Urun)selectedRow.Tag;
            int adet = (int)guna2NumericUpDown1.Value;

            if (adet > seciliUrun.Stok)
            {
                MessageBox.Show($"Stokta yeterli ürün bulunmamaktadır. Mevcut stok: {seciliUrun.Stok}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2NumericUpDown1.Value = seciliUrun.Stok;
                return;
            }

            decimal tutar = seciliUrun.Fiyat * adet;
            guna2TextBox1.Text = tutar.ToString("C2");
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
            Urun seciliUrun = (Urun)selectedRow.Tag;
            int adet = (int)guna2NumericUpDown1.Value;
            
            if (adet <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SepeteUrunEkle(seciliUrun.UrunKodu, seciliUrun.UrunAdi, seciliUrun.Fiyat, adet);
            
            // Sepet sayfasına geç
            guna2TabControl1.SelectedIndex = 1;
        }

        private void btnSepetGit_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 1;
        }

        private void btnDukkanIslemleri_Click(object sender, EventArgs e)
        {
            KasiyerSayfa kasiyerSayfa = new KasiyerSayfa();
            kasiyerSayfa.Show();
            this.Hide();
        }

        private void rbNakit_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {
                krediKartiSecili = false;
                if (!string.IsNullOrEmpty(guna2TextBox3.Text))
                {
                    HesaplaOdenecekTutar();
                }
            }
        }

        private void rbKrediKarti_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton2.Checked)
            {
                krediKartiSecili = true;
                if (!string.IsNullOrEmpty(guna2TextBox3.Text))
                {
                    HesaplaOdenecekTutar();
                }
            }
        }

        private void HesaplaToplam()
        {
            if (sepetListesi.Count == 0)
            {
                MessageBox.Show("Sepette ürün bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal toplam = 0;
            foreach (SepetItem item in sepetListesi)
            {
                toplam += item.ToplamFiyat;
            }

            guna2TextBox3.Text = toplam.ToString("C2");

            HesaplaOdenecekTutar();
        }

        private void HesaplaOdenecekTutar()
        {
            if (string.IsNullOrEmpty(guna2TextBox3.Text))
                return;

            decimal toplam = decimal.Parse(guna2TextBox3.Text.Replace("₺", "").Trim(), NumberStyles.Any);

            if (krediKartiSecili)
            {
                decimal odenecekTutar = toplam * 1.03m;
                guna2TextBox4.Text = odenecekTutar.ToString("C2");
            }
            else
            {
                guna2TextBox4.Text = toplam.ToString("C2");
            }
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void btnUrunlereGit_Click(object sender, EventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
        }

        private void btnSepetiBosalt_Click(object sender, EventArgs e)
        {
            if (sepetListesi.Count == 0)
            {
                MessageBox.Show("Sepet zaten boş!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Sepeti boşaltmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                sepetListesi.Clear();
                guna2DataGridView2.Rows.Clear();
                guna2TextBox3.Clear();
                guna2TextBox4.Clear();
                guna2Button4.Visible = false;

                UrunleriYukle(); // Stokları yenile

                MessageBox.Show("Sepet boşaltıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSepettenCikar_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen sepetten çıkarılacak bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = guna2DataGridView2.SelectedRows[0];
            SepetItem seciliItem = (SepetItem)selectedRow.Tag;
            
            SepettenCikar(seciliItem);
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aramaMetni = txtAra.Text.ToLower().Trim();

            // Arama metni boşsa tüm ürünleri göster
            if (string.IsNullOrEmpty(aramaMetni))
            {
                UrunleriListele();
                return;
            }

            // Arama metnine göre ürünleri filtrele
            guna2DataGridView1.Rows.Clear();

            foreach (Urun urun in urunListesi)
            {
                if (urun.UrunKodu.ToLower().Contains(aramaMetni) ||
                    urun.UrunAdi.ToLower().Contains(aramaMetni))
                {
                    // Veritabanından ürün tanımını al
                    string urunTanimi = GetUrunTanimi(urun.UrunKodu);

                    int rowIndex = guna2DataGridView1.Rows.Add(
                        urun.UrunKodu,
                        urun.UrunAdi,
                        urun.Fiyat.ToString("C"),
                        urun.Stok.ToString(),
                        urunTanimi
                    );

                    guna2DataGridView1.Rows[rowIndex].Tag = urun;
                }
            }
        }

        private string GetUrunTanimi(string urunKodu)
        {
            string tanim = "Belirtilmemiş";
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT urun_tanimi FROM urunler WHERE urun_kodu = @urunKodu";
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@urunKodu", urunKodu);
                        var result = command.ExecuteScalar();
                        
                        if (result != null && result != DBNull.Value)
                        {
                            tanim = result.ToString();
                        }
                    }
                }
            }
            catch
            {
                // Hata durumunda varsayılan tanım döndür
            }
            
            return tanim;
        }
        
        private void UrunleriListele()
        {
            // DataGridView'i temizle
            guna2DataGridView1.Rows.Clear();

            // Ürünleri listele
            foreach (Urun urun in urunListesi)
            {
                // Veritabanından ürün tanımını al
                string urunTanimi = GetUrunTanimi(urun.UrunKodu);
                
                int rowIndex = guna2DataGridView1.Rows.Add(
                    urun.UrunKodu,
                    urun.UrunAdi,
                    urun.Fiyat.ToString("C2"),
                    urun.Stok.ToString(),
                    urunTanimi
                );

                guna2DataGridView1.Rows[rowIndex].Tag = urun;
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlık satırı veya geçersiz tıklama ise çık
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            try
            {
                // Tıklanan satırdan ürün bilgisini al
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                Urun seciliUrun = (Urun)row.Tag;

                if (seciliUrun == null)
                    return;
                
                // Ürün detaylarını panelde göster
                GosterUrunDetay(seciliUrun);

                // Stok kontrolü
                if (seciliUrun.Stok <= 0)
                {
                    MessageBox.Show("Bu ürün stokta kalmamıştır.", "Stok Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // NumericUpDown değerini güncelle
                guna2NumericUpDown1.Maximum = seciliUrun.Stok;
                guna2NumericUpDown1.Value = 1;
                decimal tutar = seciliUrun.Fiyat * 1;
                guna2TextBox1.Text = tutar.ToString("C2");

                // Ürünü sepette kontrol et
                SepetItem existingItem = sepetListesi.FirstOrDefault(item => item.UrunKodu == seciliUrun.UrunKodu);

                if (existingItem != null)
                {
                    // Sepetteki miktarı artır
                    existingItem.Adet++;
                    existingItem.ToplamFiyat = existingItem.BirimFiyat * existingItem.Adet;
                }
                else
                {
                    // Yeni sepet öğesi ekle
                    SepetItem yeniItem = new SepetItem
                    {
                        UrunKodu = seciliUrun.UrunKodu,
                        UrunAdi = seciliUrun.UrunAdi,
                        BirimFiyat = seciliUrun.Fiyat,
                        Adet = 1,
                        ToplamFiyat = seciliUrun.Fiyat * 1
                    };

                    sepetListesi.Add(yeniItem);
                }

                // Sepet DataGridView'ini güncelle
                SepetiGuncelle();

                // Toplam tutarı güncelle
                ToplamTutariGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SepetiGuncelle()
        {
            try
            {
                // Sepet DataGridView'ini temizle
                guna2DataGridView2.Rows.Clear();

                // Sepet öğelerini DataGridView'e ekle
                foreach (SepetItem item in sepetListesi)
                {
                    decimal toplamFiyat = item.BirimFiyat * item.Adet;

                    int rowIndex = guna2DataGridView2.Rows.Add(
                        item.UrunKodu,
                        item.UrunAdi,
                        item.BirimFiyat.ToString("C2"),
                        item.Adet.ToString(),
                        toplamFiyat.ToString("C2")
                    );

                    guna2DataGridView2.Rows[rowIndex].Tag = item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sepet güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToplamTutariGuncelle()
        {
            try
            {
                decimal toplamTutar = sepetListesi.Sum(item => item.ToplamFiyat);
                guna2TextBox3.Text = toplamTutar.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplam tutar hesaplanırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SepeteUrunEkle(string urunKodu, string urunAdi, decimal birimFiyat, int adet)
        {
            try
            {
                // Stok kontrolü
                Urun seciliUrun = urunListesi.FirstOrDefault(u => u.UrunKodu == urunKodu);
                if (seciliUrun == null)
                {
                    MessageBox.Show("Ürün bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (seciliUrun.Stok < adet)
                {
                    MessageBox.Show($"Yeterli stok yok! Mevcut stok: {seciliUrun.Stok}", "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sepette aynı ürün var mı kontrol et
                SepetItem mevcut = sepetListesi.FirstOrDefault(item => item.UrunKodu == urunKodu);
                
                if (mevcut != null)
                {
                    // Ürün zaten sepette, miktarı güncelle
                    if (seciliUrun.Stok < mevcut.Adet + adet)
                    {
                        MessageBox.Show($"Bu kadar stok yok! Mevcut stok: {seciliUrun.Stok}", "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    mevcut.Adet += adet;
                    mevcut.ToplamFiyat = mevcut.BirimFiyat * mevcut.Adet;
                }
                else
                {
                    // Sepete yeni ürün ekle
                    SepetItem yeniItem = new SepetItem
                    {
                        UrunKodu = urunKodu,
                        UrunAdi = urunAdi,
                        BirimFiyat = birimFiyat,
                        Adet = adet,
                        ToplamFiyat = birimFiyat * adet
                    };
                    
                    sepetListesi.Add(yeniItem);
                }

                // DataGridView'i güncelle
                SepetiGuncelle();
                
                // Stok miktarını güncelle
                seciliUrun.Stok -= adet;
                UrunleriListele(); // Güncel stok durumunu göster
                
                // Sepet durumunu güncelle
                SepetDurumunuGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sepete ürün eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SepettenCikar(SepetItem sepetItem)
        {
            try
            {
                if (sepetItem == null)
                {
                    MessageBox.Show("Geçersiz sepet öğesi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sepet listesinden çıkar
                sepetListesi.Remove(sepetItem);

                // DataGridView'den çıkar
                foreach (DataGridViewRow row in guna2DataGridView2.Rows)
                {
                    if (row.Tag is SepetItem item && item == sepetItem)
                    {
                        guna2DataGridView2.Rows.Remove(row);
                        break;
                    }
                }

                // Stok miktarını geri ekle
                Urun urun = urunListesi.FirstOrDefault(u => u.UrunKodu == sepetItem.UrunKodu);
                if (urun != null)
                {
                    urun.Stok += sepetItem.Adet;

                    // Ürünler DataGridView'inde stok değerini güncelle
                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.Tag is Urun rowUrun && rowUrun.UrunKodu == urun.UrunKodu)
                        {
                            row.Cells["Stok"].Value = urun.Stok;
                            break;
                        }
                    }
                }

                // Toplam tutarı güncelle
                if (sepetListesi.Count > 0)
                {
                    HesaplaToplam();
                }
                else
                {
                    guna2TextBox3.Clear();
                    guna2TextBox4.Clear();
                    guna2Button4.Visible = false;
                }

                MessageBox.Show($"{sepetItem.Adet} adet {sepetItem.UrunAdi} sepetten çıkarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün sepetten çıkarılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SiparisOlustur()
        {
            try
            {
                if (sepetListesi.Count == 0)
                {
                    MessageBox.Show("Sepette ürün bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string odemeYontemi = krediKartiSecili ? "Kredi Kartı" : "Nakit";
                decimal toplamTutar = decimal.Parse(guna2TextBox4.Text.Replace("₺", "").Trim(), NumberStyles.Any);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Sipariş ekle
                    string siparisQuery = "INSERT INTO siparisler (siparis_tarihi, toplam_tutar, odeme_yontemi) " +
                                         "VALUES (@siparisTarihi, @toplamTutar, @odemeYontemi); " +
                                         "SELECT LAST_INSERT_ID();";

                    int siparisId;
                    using (MySqlCommand command = new MySqlCommand(siparisQuery, connection))
                    {
                        command.Parameters.AddWithValue("@siparisTarihi", DateTime.Now);
                        command.Parameters.AddWithValue("@toplamTutar", toplamTutar);
                        command.Parameters.AddWithValue("@odemeYontemi", odemeYontemi);

                        // Son eklenen siparişin ID'sini al
                        siparisId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Sipariş detaylarını ekle
                    foreach (SepetItem item in sepetListesi)
                    {
                        string detayQuery = "INSERT INTO siparis_detaylari (siparis_id, urun_kodu, adet, birim_fiyat) " +
                                           "VALUES (@siparisId, @urunKodu, @adet, @birimFiyat)";

                        using (MySqlCommand command = new MySqlCommand(detayQuery, connection))
                        {
                            command.Parameters.AddWithValue("@siparisId", siparisId);
                            command.Parameters.AddWithValue("@urunKodu", item.UrunKodu);
                            command.Parameters.AddWithValue("@adet", item.Adet);
                            command.Parameters.AddWithValue("@birimFiyat", item.BirimFiyat);

                            command.ExecuteNonQuery();
                        }

                        // Stok güncelleme
                        string updateStokQuery = "UPDATE urunler SET urun_adedi = urun_adedi - @adet WHERE urun_kodu = @urunKodu";

                        using (MySqlCommand command = new MySqlCommand(updateStokQuery, connection))
                        {
                            command.Parameters.AddWithValue("@adet", item.Adet);
                            command.Parameters.AddWithValue("@urunKodu", item.UrunKodu);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Form durumunu sıfırla
                UrunleriYukle();
                sepetListesi.Clear();
                guna2DataGridView2.Rows.Clear();
                guna2TextBox3.Clear();
                guna2TextBox4.Clear();
                guna2Button4.Visible = false;

                MessageBox.Show("Siparişiniz başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sepet durumunu güncelleyen metot
        private void SepetDurumunuGuncelle()
        {
            // Siparişi Onayla butonunu, sepette ürün varsa görünür yap, yoksa gizle
            guna2Button4.Visible = sepetListesi.Count > 0;
            
            // Toplam tutarı güncelle
            decimal toplam = sepetListesi.Sum(item => item.ToplamFiyat);
            guna2TextBox3.Text = toplam.ToString("C2");
        }

        private void OlusturUrunDetayPaneli()
        {
            // Panel oluştur
            urunDetayPanel = new Guna.UI2.WinForms.Guna2Panel();
            urunDetayPanel.Size = new Size(400, 150);
            urunDetayPanel.Location = new Point(guna2GroupBox1.Location.X, guna2GroupBox1.Location.Y - 160);
            urunDetayPanel.BorderRadius = 10;
            urunDetayPanel.FillColor = Color.FromArgb(240, 240, 240);
            urunDetayPanel.ShadowDecoration.Enabled = true;
            urunDetayPanel.ShadowDecoration.Depth = 5;
            urunDetayPanel.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);
            tabPage1.Controls.Add(urunDetayPanel);
            
            // Ürün resmi için PictureBox
            urunResim = new Guna.UI2.WinForms.Guna2PictureBox();
            urunResim.Size = new Size(120, 120);
            urunResim.Location = new Point(20, 15);
            urunResim.BorderRadius = 10;
            urunResim.SizeMode = PictureBoxSizeMode.Zoom;
            urunResim.Image = Properties.Resources.default_product; // Varsayılan resim (eğer yoksa oluşturmanız gerekecek)
            urunDetayPanel.Controls.Add(urunResim);
            
            // Ürün adı etiketi
            lblUrunAdi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblUrunAdi.Size = new Size(240, 40);
            lblUrunAdi.Location = new Point(160, 20);
            lblUrunAdi.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblUrunAdi.Text = "Ürün seçilmedi";
            urunDetayPanel.Controls.Add(lblUrunAdi);
            
            // Ürün fiyatı etiketi
            lblUrunFiyat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblUrunFiyat.Size = new Size(240, 30);
            lblUrunFiyat.Location = new Point(160, 70);
            lblUrunFiyat.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblUrunFiyat.ForeColor = Color.FromArgb(72, 72, 176);
            lblUrunFiyat.Text = "";
            urunDetayPanel.Controls.Add(lblUrunFiyat);
            
            // Stok bilgisi etiketi
            Guna.UI2.WinForms.Guna2HtmlLabel lblStok = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblStok.Size = new Size(240, 30);
            lblStok.Location = new Point(160, 100);
            lblStok.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblStok.ForeColor = Color.DarkGray;
            lblStok.Text = "Stok: 0";
            urunDetayPanel.Controls.Add(lblStok);
        }

        private void GosterUrunDetay(Urun urun)
        {
            // Ürün adını ve fiyatını güncelle
            lblUrunAdi.Text = urun.UrunAdi;
            lblUrunFiyat.Text = urun.Fiyat.ToString("C2");
            
            // Stok bilgisini güncelle
            Guna.UI2.WinForms.Guna2HtmlLabel lblStok = (Guna.UI2.WinForms.Guna2HtmlLabel)urunDetayPanel.Controls[3]; // Stok etiketi
            lblStok.Text = $"Stok: {urun.Stok}";
            
            // Ürün resmini göster
            try
            {
                if (!string.IsNullOrEmpty(urun.ResimBase64))
                {
                    byte[] imageBytes = Convert.FromBase64String(urun.ResimBase64);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        urunResim.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    urunResim.Image = Properties.Resources.default_product;
                }
            }
            catch
            {
                urunResim.Image = Properties.Resources.default_product; 
            }
        }
    }
}