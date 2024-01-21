using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Shop_Management_System
{
    public partial class Customers : Form
    {
        Functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCustomers();
        }
        
        private void ShowCustomers()
        {
            try
            {
                string Query = "select * from CustomerTbl";
                CustomersList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else { 
                try
                {
                    string CustName = NameTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Query = "insert into CustomerTbl values('{0}', '{1}', '{2}')";
                    Query = string.Format(Query, CustName, Gender, Phone);
                    Con.SetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Customer Added!!!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            GenderCb.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if(NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if(NameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CustName = NameTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Query = "update CustomerTbl set CustName = '{0}', Gender = '{1}', Phone = '{2}'";
                    Query = string.Format(Query, CustName, Gender, Phone);
                    Con.SetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Customer Updated!!!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CustName = NameTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;
                    string Query = "Delete from CustomerTbl where CustCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowCustomers();
                    MessageBox.Show("Customer Deleted!!!");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
