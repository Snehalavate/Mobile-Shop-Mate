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
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-7BRH95V4\SNEHAL;Initial Catalog=mobile;Integrated Security=True");
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void populate()
        {
            Con.Open();
            String query = "select *from mobilemanage";
            SqlDataAdapter da = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        if(mobileidtb.Text == "" || brandtb.Text == "" || modeltb.Text=="" || pricetb.Text =="" || stocktb.Text=="" || cameratb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into mobilemanage values(" + mobileidtb.Text +",'"+brandtb.Text+"','"+modeltb.Text+"','"+pricetb.Text+ "','"+stocktb.Text+"','"+ramcb.SelectedItem.ToString()+"','"+romcb.SelectedItem.ToString()+ "','"+cameratb.Text+"')";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
                    Con.Close();
                    populate();
                
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Mobile_Load(object sender, EventArgs e)
        {
            populate();
        }
     

        private void mobileidTb_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
            
                                      
            //mobileidtb.Text = mobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            //brandtb.Text = mobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            //modeltb.Text = mobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            //pricetb.Text = mobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            //stocktb.Text = mobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            //ramcb.SelectedItem = mobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            //romcb.SelectedItem = mobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            //cameratb.Text = mobileDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mobileidtb.Text = "";
            brandtb.Text = "";
            modeltb.Text = "";
            pricetb.Text = "";
            stocktb.Text = "";
            cameratb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(mobileidtb.Text =="")
            {
                MessageBox.Show("Enter Mobile to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from mobilemanage where Mobid="+mobileidtb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
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
            if (mobileidtb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update mobilemanage set Mbrand='"+brandtb.Text+"',MModel ='"+modeltb.Text+"',Mprice="+pricetb.Text+",MStock="+stocktb.Text+",MRam="+ramcb.SelectedItem.ToString()+ ",MRom="+romcb.SelectedItem.ToString()+",Mcam="+cameratb.Text+" Where Mobid="+mobileidtb.Text+";";
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

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void mobileDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = mobileDGV.Rows[e.RowIndex];
            mobileidtb.Text = row.Cells[0].Value.ToString();
            brandtb.Text = row.Cells[1].Value.ToString();
            modeltb.Text = row.Cells[2].Value.ToString();
            pricetb.Text = row.Cells[3].Value.ToString();
            stocktb.Text = row.Cells[4].Value.ToString();
            ramcb.SelectedItem = row.Cells[5].Value.ToString();
            romcb.SelectedItem = row.Cells[6].Value.ToString();
            cameratb.Text = row.Cells[7].Value.ToString();
        }
    }
}
    