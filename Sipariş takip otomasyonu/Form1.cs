using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sipariş_takip_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmAna_Resize(sender, e);

            BackColor = Color.DarkSlateBlue;
            StartPosition = FormStartPosition.CenterScreen; 
            FormBorderStyle = FormBorderStyle.FixedSingle;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAna_Resize(object sender, EventArgs e)
        {
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
           

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
