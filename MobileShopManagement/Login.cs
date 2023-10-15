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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-7BRH95V4\SNEHAL;Initial Catalog=mobile;Integrated Security=True");
        private void label4_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            PassTb.Text = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UidTb.Text;
            string password = PassTb.Text;
            if (UidTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter user name and password");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "SELECT COUNT(*) FROM registration WHERE Uid = @Username AND Pass = @Password";
                    using (SqlCommand command = new SqlCommand(query, Con))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int result = reader.GetInt32(0);

                                if (result > 0)
                                {
                                    
                                    Home home = new Home();
                                    home.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Wrong username or password");
                                    Register r = new Register();
                                    r.Show();
                                    this.Hide();
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                /* Home home =new Home();
                  home.Show();
                  this.Hide();
              }
              else
              {
                  MessageBox.Show("Wrong user name or password");
                  Register r = new Register();
                  r.Show();
                  this.Hide();
               }*/


            }
        }
        private void register_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Hide();

        }

        private void UidTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
