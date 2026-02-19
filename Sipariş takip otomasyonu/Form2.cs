using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sipariş_takip_otomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // Fixed the incorrect method name 'FormArgb' to 'FromArgb'  
            panel1.BackColor = Color.FromArgb(211, 211, 211);
            button1.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        
            SqlConnection baglan=null;
            try
            {
                 baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT ka,Şifre FROM giriş", baglan);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    if (oku["ka"].ToString()==textBox1.Text && oku["Şifre"].ToString() == textBox2.Text)
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Kullanıcı adı veya şifre hatalı.";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata var sql de " + ex.ToString());
            }
            finally {
                if(baglan != null)
                baglan.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
