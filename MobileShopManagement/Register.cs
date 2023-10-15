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

namespace MobileShopManagement
{
    public partial class Register : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-7BRH95V4\SNEHAL;Initial Catalog=mobile;Integrated Security=True");
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nametb.Text == "" || UidTb.Text == "" || PassTb.Text == "" || mobilenotb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into registration values('"+ nametb.Text +"','" + UidTb.Text + "','" + PassTb.Text + "','" + mobilenotb.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
                    Con.Close();

                    Login l = new Login();
                    l.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
