using MySql.Data.MySqlClient;

namespace MarketSatis1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {

                string connectionString = "Server=localhost; Database=marketsatis; Uid=root; Pwd=2007;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        MessageBox.Show("Baðlantý baþarýlý!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Baðlantý Hatasý: " + ex.Message);
                    }
                }

                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanýcý adý veya þifre hatalý!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
