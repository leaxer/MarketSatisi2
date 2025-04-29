using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MarketSatis1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
            //string kasiyerAd = txtKasiyerAdi.Text.Trim();
            //string kasiyerNo = txtKasiyerNo.Text.Trim();

            //if (string.IsNullOrEmpty(kasiyerAd) || string.IsNullOrEmpty(kasiyerNo))
            //{
            //    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //string connectionString = "Server=localhost;Database=marketsatis;Uid=root;Pwd=2007;";
            //using (MySqlConnection conn = new MySqlConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();
            //        string query = "SELECT * FROM kasiyerler WHERE kasiyer_no = @no AND kasiyer_adi = @ad";
            //        MySqlCommand cmd = new MySqlCommand(query, conn);
            //        cmd.Parameters.AddWithValue("@no", kasiyerNo);
            //        cmd.Parameters.AddWithValue("@ad", kasiyerAd);

            //        MySqlDataReader reader = cmd.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            Form2 form2 = new Form2();
            //            form2.Show();
            //            this.Hide();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Kasiyer bilgileri hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void txtKasiyerAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
