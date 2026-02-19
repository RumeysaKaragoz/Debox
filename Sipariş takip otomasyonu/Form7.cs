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
    public partial class Form7: Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public  void listele()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=PRACYON\SQLEXPRESS01;Initial Catalog=OSTK.giriş;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM urunler", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void Form7_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(47, 62, 70);
            panel1.BackColor = Color.FromArgb(74, 101, 117);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            listele();

           
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
    }
}
