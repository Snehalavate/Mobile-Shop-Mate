using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShopManagement
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int startpoint = 15;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            
            progressBar2.Value = startpoint;
            if(progressBar2.Value == 100)
            {
               
                progressBar2.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
