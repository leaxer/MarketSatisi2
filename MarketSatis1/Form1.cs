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
            // Test edilirken kullanýyoruz.
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

            //string kasiyerAd = txtKasiyerAdi.Text.Trim();
            //string kasiyerNo = txtKasiyerNo.Text.Trim();

            //if (kasiyerAd == "" || kasiyerNo == "")
            //{
            //    MessageBox.Show("Lütfen tüm alanlarý doldurun.");
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
            //            MessageBox.Show("Giriþ baþarýlý!");
            //            Form2 form2 = new Form2();
            //            form2.Show();
            //            this.Hide();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Kasiyer bilgileri hatalý.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Hata: " + ex.Message);
            //    }
            //}
        }


private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
