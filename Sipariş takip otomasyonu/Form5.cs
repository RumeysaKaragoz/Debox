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

namespace Sipariş_takip_otomasyonu
{
    public partial class Form5: Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }

        public void listele()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID,urunadı,fiyat,miktar,kategori FROM urunler", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void Form5_Load(object sender, EventArgs e)
        {
                   listele();
        
            BackColor = Color.FromArgb(47, 62, 70);
            panel1.BackColor = Color.FromArgb(74, 101, 117);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3=new Form3();
            form3.Show();
            this.Hide();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan=null;
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text!="")
                {
                    baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO urunler(urunadı,fiyat,miktar,kategori)VALUES (@ad,@fyt,@mkt,@ktg)", baglan);
                    komut.Parameters.AddWithValue("@ad", textBox1.Text);
                    komut.Parameters.AddWithValue("@fyt", Convert.ToDecimal(textBox2.Text));
                    komut.Parameters.AddWithValue("@mkt", Convert.ToInt32(textBox3.Text));
                    komut.Parameters.AddWithValue("@ktg", comboBox1.Text);
                    komut.ExecuteNonQuery();
                    clear();
                    label6.Text = "Ürün Başarıyla eklendi.";
                    listele();
                }
                else {
                    label6.Text = "Lütfen Tüm Alanları Giriniz.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.ToString());
            }
            finally {
                if (baglan != null)
                    baglan.Close();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["urunadı"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["fiyat"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["miktar"].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["kategori"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");

            if (dataGridView1.CurrentRow != null)
            {
                int secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

                baglan.Open();
                SqlCommand komut = new SqlCommand("UPDATE urunler SET urunadı=@ad, fiyat=@fyt, miktar=@mkt WHERE ID=@id", baglan);
                komut.Parameters.AddWithValue("@ad", textBox4.Text);
                komut.Parameters.AddWithValue("@fyt", Convert.ToDecimal(textBox5.Text));
                komut.Parameters.AddWithValue("@mkt",Convert.ToInt32(textBox6.Text));
                komut.Parameters.AddWithValue("@id", secilenID);
                komut.ExecuteNonQuery();
                baglan.Close();

                label7.Text= "Ürün Başarıyla Güncellendi.";
                listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
                baglan.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM urunler WHERE ID=@id", baglan);
                komut.Parameters.AddWithValue("@id", secilenID);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Ürün Başarıyla Silindi.");
                listele();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }
    }
}
