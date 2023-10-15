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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            Accessories ac = new Accessories();
            ac.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mobile mob= new Mobile();
            mob.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selling se = new selling();
            se.Show();
            this.Hide();
        }
    }
}
