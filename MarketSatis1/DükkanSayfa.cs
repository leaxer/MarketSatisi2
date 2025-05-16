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

        public DükkanSayfa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblUrunSayisi = new Label();
            lblUrunSayisi.Location = new Point(330, 5);
            lblUrunSayisi.Size = new Size(200, 23);
            lblUrunSayisi.Font = new Font("Segoe UI", 9);
            tabPage1.Controls.Add(lblUrunSayisi);

            txtAra = new Guna.UI2.WinForms.Guna2TextBox();
            txtAra.PlaceholderText = "Ürün ara...";
            txtAra.Location = new Point(330, 29);
            txtAra.Size = new Size(176, 32);
            txtAra.BorderRadius = 5;
            tabPage1.Controls.Add(txtAra);

            this.Load += DükkanSayfa_Load;
        }

        string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

        public class Urun
        {
            public string UrunKodu { get; set; }
            public string UrunAdi { get; set; }
            public decimal Fiyat { get; set; }
            public int Stok { get; set; }

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

            KonfigureDataGridViews();

            IyilestirDataGridViewGorunumu(guna2DataGridView1);
            IyilestirDataGridViewGorunumu(guna2DataGridView2);

            UrunleriYukle();
            SepetDurumunuGuncelle();

            txtAra.TextChanged += txtAra_TextChanged;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
        }

        private void KonfigureDataGridViews()
        {
            try
            {
                guna2DataGridView1.Columns.Clear();
                DataGridViewTextBoxColumn urunKoduColumn = new DataGridViewTextBoxColumn();
                urunKoduColumn.Name = "UrunKodu";
                urunKoduColumn.HeaderText = "Ürün Kodu";
                urunKoduColumn.Width = 98;

                DataGridViewTextBoxColumn urunAdiColumn = new DataGridViewTextBoxColumn();
                urunAdiColumn.Name = "UrunAdi";
                urunAdiColumn.HeaderText = "Ürün Adı";
                urunAdiColumn.Width = 97;

                DataGridViewTextBoxColumn fiyatColumn = new DataGridViewTextBoxColumn();
                fiyatColumn.Name = "Fiyat";
                fiyatColumn.HeaderText = "Fiyat";
                fiyatColumn.Width = 98;

                DataGridViewTextBoxColumn stokColumn = new DataGridViewTextBoxColumn();
                stokColumn.Name = "Stok";
                stokColumn.HeaderText = "Stok";
                stokColumn.Width = 97;

                DataGridViewTextBoxColumn tanimColumn = new DataGridViewTextBoxColumn();
                tanimColumn.Name = "Tanim";
                tanimColumn.HeaderText = "Tanım";
                tanimColumn.Width = 98;

                guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { 
                    urunKoduColumn, urunAdiColumn, fiyatColumn, stokColumn, tanimColumn 
                });

                guna2DataGridView2.Columns.Clear();

                DataGridViewTextBoxColumn sepetKoduColumn = new DataGridViewTextBoxColumn();
                sepetKoduColumn.Name = "UrunKodu";
                sepetKoduColumn.HeaderText = "Ürün Kodu";
                sepetKoduColumn.Width = 98;

                DataGridViewTextBoxColumn sepetAdiColumn = new DataGridViewTextBoxColumn();
                sepetAdiColumn.Name = "UrunAdi";
                sepetAdiColumn.HeaderText = "Ürün Adı";
                sepetAdiColumn.Width = 97;

                DataGridViewTextBoxColumn birimFiyatColumn = new DataGridViewTextBoxColumn();
                birimFiyatColumn.Name = "BirimFiyat";
                birimFiyatColumn.HeaderText = "Birim Fiyat";
                birimFiyatColumn.Width = 98;

                DataGridViewTextBoxColumn adetColumn = new DataGridViewTextBoxColumn();
                adetColumn.Name = "Adet";
                adetColumn.HeaderText = "Adet";
                adetColumn.Width = 97;

                DataGridViewTextBoxColumn toplamFiyatColumn = new DataGridViewTextBoxColumn();
                toplamFiyatColumn.Name = "ToplamFiyat";
                toplamFiyatColumn.HeaderText = "Toplam Fiyat";
                toplamFiyatColumn.Width = 98;

                guna2DataGridView2.Columns.AddRange(new DataGridViewColumn[] { 
                    sepetKoduColumn, sepetAdiColumn, birimFiyatColumn, adetColumn, toplamFiyatColumn 
                });

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
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(72, 72, 176);
            dataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView.ThemeStyle.RowsStyle.BackColor = Color.White;
            dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(125, 124, 184);
            dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
        }

        private void UrunleriYukle()
        {
            try
            {
                guna2DataGridView1.Rows.Clear();
                urunListesi.Clear();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi " +
                                 "FROM urunler " +
                                 "ORDER BY CAST(urun_kodu AS SIGNED)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string urunKodu = reader["urun_kodu"].ToString();
                                string urunAd = reader["urun_adi"].ToString();
                                decimal fiyat = Convert.ToDecimal(reader["urun_fiyati"]);
                                int stok = Convert.ToInt32(reader["urun_adedi"]);
                                string tanim = reader["urun_tanimi"].ToString();

                                Urun urun = new Urun
                                {
                                    UrunKodu = urunKodu,
                                    UrunAdi = urunAd,
                                    Fiyat = fiyat,
                                    Stok = stok
                                };

                                urunListesi.Add(urun);

                                int rowIndex = guna2DataGridView1.Rows.Add(urunKodu, urunAd, fiyat.ToString("F2"), stok, tanim);
                                guna2DataGridView1.Rows[rowIndex].Tag = urun;
                            }
                        }
                    }
                }

                foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                guna2DataGridView1.Sort(guna2DataGridView1.Columns["UrunKodu"], System.ComponentModel.ListSortDirection.Ascending);
                lblUrunSayisi.Text = $"Toplam {guna2DataGridView1.Rows.Count} ürün listelendi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                Urun seciliUrun = (Urun)selectedRow.Tag;
                int adet = (int)guna2NumericUpDown1.Value;

                if (adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (seciliUrun.Stok < adet)
                {
                    MessageBox.Show($"Stokta yeterli ürün bulunmamaktadır. Mevcut stok: {seciliUrun.Stok}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    guna2NumericUpDown1.Value = seciliUrun.Stok;
                    return;
                }

                SepetItem mevcut = sepetListesi.FirstOrDefault(item => item.UrunKodu == seciliUrun.UrunKodu);

                if (mevcut != null)
                {
                    if (seciliUrun.Stok < (mevcut.Adet + adet))
                    {
                        MessageBox.Show($"Bu kadar ürün eklenemez. Mevcut stok: {seciliUrun.Stok}, Sepetteki miktar: {mevcut.Adet}", 
                            "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    mevcut.Adet += adet;
                    mevcut.ToplamFiyat = mevcut.BirimFiyat * mevcut.Adet;
                }
                else
                {
                    SepetItem yeniItem = new SepetItem
                    {
                        UrunKodu = seciliUrun.UrunKodu,
                        UrunAdi = seciliUrun.UrunAdi,
                        BirimFiyat = seciliUrun.Fiyat,
                        Adet = adet,
                        ToplamFiyat = seciliUrun.Fiyat * adet
                    };

                    sepetListesi.Add(yeniItem);
                }

                seciliUrun.Stok -= adet;


                SepetiGuncelle();
                UrunleriListele();
                SepetDurumunuGuncelle();
                ToplamTutariGuncelle();

                MessageBox.Show("Ürün sepete eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                guna2TabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün sepete eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                UrunleriYukle();

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

            if (string.IsNullOrEmpty(aramaMetni))
            {
                UrunleriListele();
                return;
            }

            guna2DataGridView1.Rows.Clear();

            foreach (Urun urun in urunListesi)
            {
                if (urun.UrunKodu.ToLower().Contains(aramaMetni) ||
                    urun.UrunAdi.ToLower().Contains(aramaMetni))
                {
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
            guna2DataGridView1.Rows.Clear();

            foreach (Urun urun in urunListesi)
            {
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            try
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                Urun seciliUrun = (Urun)row.Tag;

                if (seciliUrun == null)
                    return;

                if (seciliUrun.Stok <= 0)
                {
                    MessageBox.Show("Bu ürün stokta kalmamıştır.", "Stok Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                guna2NumericUpDown1.Maximum = seciliUrun.Stok;
                guna2NumericUpDown1.Value = 1;
                
                decimal tutar = seciliUrun.Fiyat * guna2NumericUpDown1.Value;
                guna2TextBox1.Text = tutar.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün seçilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SepetiGuncelle()
        {
            try
            {
                guna2DataGridView2.Rows.Clear();


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

                SepetItem mevcut = sepetListesi.FirstOrDefault(item => item.UrunKodu == urunKodu);

                if (mevcut != null)
                {
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

                SepetiGuncelle();

                seciliUrun.Stok -= adet;
                UrunleriListele();

                SepetDurumunuGuncelle();

                ToplamTutariGuncelle();
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
                Urun seciliUrun = urunListesi.FirstOrDefault(u => u.UrunKodu == sepetItem.UrunKodu);
                if (seciliUrun != null)
                {
                    seciliUrun.Stok += sepetItem.Adet;
                }

                sepetListesi.Remove(sepetItem);

                SepetiGuncelle();

                UrunleriListele();

                SepetDurumunuGuncelle();

                ToplamTutariGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sepetten ürün çıkarılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string siparisQuery = "INSERT INTO siparisler (siparis_tarihi, toplam_tutar, odeme_yontemi) " +
                                         "VALUES (@siparisTarihi, @toplamTutar, @odemeYontemi); " +
                                         "SELECT LAST_INSERT_ID();";

                    int siparisId;
                    using (MySqlCommand command = new MySqlCommand(siparisQuery, connection))
                    {
                        command.Parameters.AddWithValue("@siparisTarihi", DateTime.Now);
                        command.Parameters.AddWithValue("@toplamTutar", toplamTutar);
                        command.Parameters.AddWithValue("@odemeYontemi", odemeYontemi);

                        siparisId = Convert.ToInt32(command.ExecuteScalar());
                    }

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

                        string updateStokQuery = "UPDATE urunler SET urun_adedi = urun_adedi - @adet WHERE urun_kodu = @urunKodu";

                        using (MySqlCommand command = new MySqlCommand(updateStokQuery, connection))
                        {
                            command.Parameters.AddWithValue("@adet", item.Adet);
                            command.Parameters.AddWithValue("@urunKodu", item.UrunKodu);

                            command.ExecuteNonQuery();
                        }
                    }
                }

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

        private void SepetDurumunuGuncelle()
        {
            guna2Button4.Visible = sepetListesi.Count > 0;

            decimal toplam = sepetListesi.Sum(item => item.ToplamFiyat);
            guna2TextBox3.Text = toplam.ToString("C2");
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}