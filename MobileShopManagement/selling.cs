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
using System.Drawing.Printing;

namespace MobileShopManagement
{
    public partial class selling : Form
    {
        public selling()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-7BRH95V4\SNEHAL;Initial Catalog=mobile;Integrated Security=True");

        private void populate()
        {
            Con.Open();
            String query = "select Mbrand,MModel,Mprice from mobilemanage";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populateAccess()
        {
            Con.Open();
            String query = "select Abrand,AModel,Aprice from accessories";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            accessoriesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void insertbill()
        {
            if (billidtb.Text == "" || cnametb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                int amount = Convert.ToInt32(amountlb.Text);
                try
                {
                    Con.Open();
                    String sql = "insert into billtable values(" + billidtb.Text + ",'" + cnametb.Text + "','" + amountlb.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added Successfully");
                    Con.Close();
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void selling_Load(object sender, EventArgs e)
        {
            populate();
            populateAccess();
           
        }
        private void sum()
        {
           Con.Open();
            string query = "select sum(Amt) from billtable";
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sellamountlb.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void mobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* producttb.Text = mobileDGV.SelectedRows[0].Cells[0].Value.ToString() + mobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            pricetb.Text = mobileDGV.SelectedRows[0].Cells[2].Value.ToString*/
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void accessoriesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /* producttb.Text = accessoriesDGV.SelectedRows[0].Cells[0].Value.ToString() + mobileDGV.SelectedRows[0].Cells[1].Value.ToString();
           pricetb.Text = accessoriesDGV.SelectedRows[0].Cells[2].Value.ToString(); */
        }

        int n = 0,grdtotal=0;
        private void bill_Click(object sender, EventArgs e)
        {
           
            if(quantitytb.Text == "" || pricetb.Text =="")
            {
                MessageBox.Show("Enter the Quantity");
            }
            else
            {
                int total = Convert.ToInt32(quantitytb.Text) * Convert.ToInt32(pricetb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(billDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = producttb.Text;
                newRow.Cells[2].Value = pricetb.Text;
                newRow.Cells[3].Value = quantitytb.Text;
                newRow.Cells[4].Value = total;
                billDGV.Rows.Add(newRow);
                n++;
                grdtotal = grdtotal + total;
                amountlb.Text =""+grdtotal;
            }
            insertbill();
            sum();
        }
        

        private void mobileDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = mobileDGV.Rows[e.RowIndex];
            producttb.Text = row.Cells[0].Value.ToString()+ row.Cells[1].Value.ToString();
            pricetb.Text = row.Cells[2].Value.ToString();
         }

        private void accessoriesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = accessoriesDGV.Rows[e.RowIndex];
            producttb.Text = row.Cells[0].Value.ToString() + row.Cells[1].Value.ToString();
            pricetb.Text = row.Cells[2].Value.ToString();

        }
        int prodid, prodprice, prodqty, total, pos = 60;
        string prodname;

        private void billDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("Mobile Shop Mate", new Font("century Gothic", 12, FontStyle.Bold),Brushes.Red,new Point(90,15));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26,40));
           
            foreach (DataGridViewRow row in billDGV.Rows)
            {
                if (!row.IsNewRow)
                {
                    prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                    prodname = " " + row.Cells["Column2"].Value;
                    prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                    prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                    total = Convert.ToInt32(row.Cells["Column5"].Value);

                    e.Graphics.DrawString("" + prodid, new Font("century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                    e.Graphics.DrawString("" + prodname, new Font("century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                    e.Graphics.DrawString("" + prodprice, new Font("century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                    e.Graphics.DrawString("" + prodqty, new Font("century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                    e.Graphics.DrawString("" + total, new Font("century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));

                    pos += 20;
                }
            }


            e.Graphics.DrawString("Grand Total:Rs"+grdtotal, new Font("century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50,pos+50));
            e.Graphics.DrawString("**********mobile shop mate**********" , new Font("century Gothic", 8, FontStyle.Bold), Brushes.Crimson, new Point(10,pos+85));
            billDGV.Rows.Clear();
            billDGV.Refresh();
            pos = 100;
            grdtotal = 0;
            n = 0;  
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if(printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void billidtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
