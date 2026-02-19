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
    public partial class Form4: Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public void listele()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Satislar", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            listele();

            SqlConnection  baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
            BackColor = Color.FromArgb(47, 62, 70);
            panel1.BackColor = Color.FromArgb(74, 101, 117);
            try
            {
                SqlCommand komut = new SqlCommand("SELECT ID, urunadı FROM urunler", baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "urunadı";
                comboBox1.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata var sql de " + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
            try
            {

                SqlCommand komut = new SqlCommand("SELECT fiyat,miktar FROM urunler WHERE ID=@id", baglan);
                if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int secilenID))
                {
                    secilenID = Convert.ToInt32(comboBox1.SelectedValue);

                    komut.Parameters.AddWithValue("@id", secilenID);
                    baglan.Open();
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox1.Text = dr["fiyat"].ToString();
                        textBox2.Text = dr["miktar"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.ToString());
            }
            finally
            {

                baglan.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");

            int stokMiktari = Convert.ToInt32(textBox2.Text);
            int satisMiktari;

            if (!int.TryParse(textBox3.Text, out satisMiktari))
            {
                MessageBox.Show("Geçerli bir satış miktarı girin.");
                return;
            }

            if (satisMiktari > stokMiktari)
            {
                MessageBox.Show("Yeterli stok yok!");
                return;
            }
            else if (satisMiktari <= 0)
            {
                MessageBox.Show("Satış miktarı 0 veya daha az olamaz.");
                return;
            }
            else
            {

                int yeniStok = stokMiktari - satisMiktari;
                int secilenID = Convert.ToInt32(comboBox1.SelectedValue);

                SqlCommand stokGuncelle = new SqlCommand("UPDATE urunler SET miktar=@miktar WHERE ID=@id", baglan);
                stokGuncelle.Parameters.AddWithValue("@miktar", yeniStok);
                stokGuncelle.Parameters.AddWithValue("@id", secilenID);

                baglan.Open();
                stokGuncelle.ExecuteNonQuery();
                baglan.Close();

                SqlCommand satisEkle = new SqlCommand("INSERT INTO Satislar(UrunID, SatisMiktar, Tarih) VALUES(@id, @miktar, @tarih)", baglan);
                satisEkle.Parameters.AddWithValue("@id", secilenID);
                satisEkle.Parameters.AddWithValue("@miktar", satisMiktari);
                satisEkle.Parameters.AddWithValue("@tarih", DateTime.Now);

                baglan.Open();
                satisEkle.ExecuteNonQuery();
                baglan.Close();

                label6.Text="Satış başarıyla gerçekleşti.";
                textBox3.Clear();

            }



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
