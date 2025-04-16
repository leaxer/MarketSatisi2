using MySql.Data.MySqlClient;
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

namespace MarketSatis1
{
    public partial class DükkanSayfa : Form
    {

        private List<Urun> urunListesi = new List<Urun>();
        private List<SepetItem> sepetListesi = new List<SepetItem>();
        private decimal toplamTutar = 0;
        private bool krediKartiSecili = false;
        public DükkanSayfa()
        {
            InitializeComponent();
        }

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

        // Sepet öğesi sınıfı
        public class SepetItem
        {
            public Urun Urun { get; set; }
            public int Adet { get; set; }
            public decimal ToplamFiyat { get; set; }

            public override string ToString()
            {
                return $"{Urun.UrunAdi} - {Adet} adet - {ToplamFiyat:C2}";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DükkanSayfa_Load(object sender, EventArgs e)
        {
            UrunleriYukle();

            // Başlangıç ayarları
            numAdet.Value = 0;
            txtTutar.ReadOnly = true;
            txtToplamTutar.ReadOnly = true;
            txtIndirimliTutar.ReadOnly = true;
            rbNakit.Checked = true;
        }

        private void UrunleriYukle()
        {
            try
            {
                urunListesi.Clear();
                lstUrunler.Items.Clear();

                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT urun_kodu, urun_adi, urun_fiyati, urun_adedi FROM urunler WHERE urun_adedi > 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Urun urun = new Urun
                                {
                                    UrunKodu = reader["urun_kodu"].ToString(),
                                    UrunAdi = reader["urun_adi"].ToString(),
                                    Fiyat = Convert.ToDecimal(reader["urun_fiyati"]),
                                    Stok = Convert.ToInt32(reader["urun_adedi"])
                                };

                                urunListesi.Add(urun);
                                lstUrunler.Items.Add(urun);
                            }
                        }
                    }
                }
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

            txtToplamTutar.Text = toplam.ToString("C2");

            // Ödeme yöntemine göre indirimli tutarı hesapla
            if (krediKartiSecili)
            {
                decimal indirimliTutar = toplam * 1.03m; // %3 KDV ekle
                txtIndirimliTutar.Text = indirimliTutar.ToString("C2");
            }
            else
            {
                txtIndirimliTutar.Text = toplam.ToString("C2");
            }

            // Siparişi Onayla butonu ekle (eğer daha önce eklenmemişse)
            if (!Controls.ContainsKey("btnSiparisiOnayla"))
            {
                Button btnSiparisiOnayla = new Button();
                btnSiparisiOnayla.Name = "btnSiparisiOnayla";
                btnSiparisiOnayla.Text = "Siparişi Onayla";
                btnSiparisiOnayla.Location = new Point(742, 449);
                btnSiparisiOnayla.Size = new Size(120, 35);
                btnSiparisiOnayla.Click += btnSiparisiOnayla_Click_1;
                Controls.Add(btnSiparisiOnayla);
            }
        }

        private void btnSiparisiOnayla_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Sipariş kaydı ekle
                    string insertSiparisQuery = "INSERT INTO siparisler (siparis_tarihi, toplam_tutar, odeme_yontemi) VALUES (@siparisTarihi, @toplamTutar, @odemeYontemi)";
                    int siparisId = 0;

                    using (MySqlCommand cmd = new MySqlCommand(insertSiparisQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@siparisTarihi", DateTime.Now);
                        cmd.Parameters.AddWithValue("@toplamTutar", decimal.Parse(txtIndirimliTutar.Text, NumberStyles.Currency));
                        cmd.Parameters.AddWithValue("@odemeYontemi", krediKartiSecili ? "Kredi Kartı" : "Nakit");

                        cmd.ExecuteNonQuery();
                        siparisId = (int)cmd.LastInsertedId;
                    }

                    // Sipariş detayları ekle ve stok güncelle
                    foreach (SepetItem item in sepetListesi)
                    {
                        // Sipariş detayı ekle
                        string insertDetayQuery = "INSERT INTO siparis_detaylari (siparis_id, urun_kodu, adet, birim_fiyat) VALUES (@siparisId, @urunKodu, @adet, @birimFiyat)";

                        using (MySqlCommand cmd = new MySqlCommand(insertDetayQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@siparisId", siparisId);
                            cmd.Parameters.AddWithValue("@urunKodu", item.Urun.UrunKodu);
                            cmd.Parameters.AddWithValue("@adet", item.Adet);
                            cmd.Parameters.AddWithValue("@birimFiyat", item.Urun.Fiyat);

                            cmd.ExecuteNonQuery();
                        }

                        // Stok güncelle
                        string updateStokQuery = "UPDATE urunler SET urun_adedi = urun_adedi - @adet WHERE urun_kodu = @urunKodu";

                        using (MySqlCommand cmd = new MySqlCommand(updateStokQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@adet", item.Adet);
                            cmd.Parameters.AddWithValue("@urunKodu", item.Urun.UrunKodu);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Sipariş başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sepeti temizle
                sepetListesi.Clear();
                lstSepet.Items.Clear();
                txtToplamTutar.Clear();
                txtIndirimliTutar.Clear();

                // Siparişi Onayla butonunu kaldır
                if (Controls.ContainsKey("btnSiparisiOnayla"))
                {
                    Control btnSiparisiOnayla = Controls["btnSiparisiOnayla"];
                    Controls.Remove(btnSiparisiOnayla);
                    btnSiparisiOnayla.Dispose();
                }

                // Ürünleri tekrar yükle (stoklar güncellendi)
                UrunleriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş işlenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ürünler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;
            int adet = (int)numAdet.Value;

            if (adet <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir adet giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (adet > seciliUrun.Stok)
            {
                MessageBox.Show($"Stokta yeterli ürün yok. Mevcut stok: {seciliUrun.Stok}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tutar = seciliUrun.Fiyat * adet;
            txtTutar.Text = tutar.ToString("C2");
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTutar.Text))
            {
                MessageBox.Show("Önce hesapla butonuna basınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;
            int adet = (int)numAdet.Value;
            decimal tutar = seciliUrun.Fiyat * adet;

            // Sepete ekle
            SepetItem sepetItem = new SepetItem
            {
                Urun = seciliUrun,
                Adet = adet,
                ToplamFiyat = tutar
            };

            sepetListesi.Add(sepetItem);
            lstSepet.Items.Add(sepetItem);

            // Stoktan düş
            seciliUrun.Stok -= adet;

            // Formu temizle
            numAdet.Value = 0;
            txtTutar.Clear();

            MessageBox.Show("Ürün sepete eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        // Radio buttonlar değiştiğinde
        private void rbNakit_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbNakit.Checked)
            {
                krediKartiSecili = false;
                // Toplam tutar zaten hesaplanmışsa, indirimli tutarı güncelle
                if (!string.IsNullOrEmpty(txtToplamTutar.Text))
                {
                    HesaplaIndirimliTutar();
                }
            }
        }

        private void rbKrediKarti_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbKrediKarti.Checked)
            {
                krediKartiSecili = true;
                // Toplam tutar zaten hesaplanmışsa, indirimli tutarı güncelle
                if (!string.IsNullOrEmpty(txtToplamTutar.Text))
                {
                    HesaplaIndirimliTutar();
                }
            }
        }

        // Toplam tutarı hesaplayan yardımcı metod
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

            txtToplamTutar.Text = toplam.ToString("C2");

            // İndirimli tutarı hesapla
            HesaplaIndirimliTutar();


        }

        // İndirimli tutarı hesaplayan yardımcı metod
        private void HesaplaIndirimliTutar()
        {
            if (string.IsNullOrEmpty(txtToplamTutar.Text))
                return;

            decimal toplam = decimal.Parse(txtToplamTutar.Text.Replace("₺", "").Trim(), NumberStyles.Any);

            if (krediKartiSecili)
            {
                decimal indirimliTutar = toplam * 1.03m; // %3 KDV ekle
                txtIndirimliTutar.Text = indirimliTutar.ToString("C2");
            }
            else
            {
                txtIndirimliTutar.Text = toplam.ToString("C2");
            }
        }
    }
}
