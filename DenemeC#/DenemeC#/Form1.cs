using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DenemeC_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Cikmak istediginize emin misiniz ?","çıkış işlemi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();            }
        }

        private void button1_Clck(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurunuz.", "Eksik Bilgi bulunmaktadır", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where Kullanici_Adi=@Kullanici_Adi and Parola=@Parola",baglanti);
            komut.Parameters.AddWithValue("@Kullanici_Adi",textBox1.Text);
            komut.Parameters.AddWithValue("@Parola",textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Close();
                icerik frm = new icerik();
                frm.Show();
                this.Visible = false;
            }
            else 
            {
                MessageBox.Show("Yanlış kullanıcı adı veya parola");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
