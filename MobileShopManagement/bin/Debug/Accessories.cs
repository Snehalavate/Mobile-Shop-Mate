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
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-7BRH95V4\SNEHAL;Initial Catalog=mobile;Integrated Security=True");
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            Con.Open();
            String query = "select *from accessories";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            accessoriesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (aidtb.Text == "" || abrandtb.Text == "" || amodeltb.Text == "" || apricetb.Text == "" || astocktb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into accessories values(" + aidtb.Text + ",'" + abrandtb.Text + "','" + amodeltb.Text + "'," + astocktb.Text + ",'" + apricetb.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aidtb.Text = "";
            abrandtb.Text = "";
            amodeltb.Text = "";
            apricetb.Text = "";
            astocktb.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (aidtb.Text == "")
            {
                MessageBox.Show("Enter accessories to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from accessories where Aid=" + aidtb.Text + " ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("accessories Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (aidtb.Text == "" || abrandtb.Text == "" || amodeltb.Text == "" || apricetb.Text == "" || astocktb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update  accessories set ABrand='" + abrandtb.Text + "',AModel ='" + amodeltb.Text + "',Aprice=" + apricetb.Text + ",AStock=" + astocktb.Text + " Where Aid=" + aidtb.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void accessoriesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.accessoriesDGV.Rows[e.RowIndex];
                aidtb.Text = row.Cells["Aid"].Value.ToString();
                abrandtb.Text = row.Cells["ABrand"].Value.ToString();
                amodeltb.Text = row.Cells["AModel"].Value.ToString();
                astocktb.Text = row.Cells["AStock"].Value.ToString();
                apricetb.Text = row.Cells["Aprice"].Value.ToString();
            }*/
    }
        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void accessoriesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = accessoriesDGV.Rows[e.RowIndex];
            aidtb.Text = row.Cells[0].Value.ToString();
            abrandtb.Text = row.Cells[1].Value.ToString();
            amodeltb.Text = row.Cells[2].Value.ToString();
            astocktb.Text = row.Cells[3].Value.ToString();
            apricetb.Text = row.Cells[4].Value.ToString();
           
        }

        private void accessoriesDGV_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = accessoriesDGV.Rows[e.RowIndex];
            aidtb.Text = row.Cells[0].Value.ToString();
            abrandtb.Text = row.Cells[1].Value.ToString();
            amodeltb.Text = row.Cells[2].Value.ToString();
            astocktb.Text = row.Cells[3].Value.ToString();
            apricetb.Text = row.Cells[4].Value.ToString();
        }
    }
}
   
