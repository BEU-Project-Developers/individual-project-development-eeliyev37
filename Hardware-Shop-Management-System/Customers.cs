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
        int Key = 0;

        // Constructor for the Customers form
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCustomers();
        }

        // Method to display customers in the DataGridView
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

        // Event handler for the "Add Item" button click
        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            // Check for missing data before adding a new customer
            if (NameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Get data from text boxes
                    string CustName = NameTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;

                    // Insert new customer into the database
                    string Query = "insert into CustomerTbl values('{0}', '{1}', '{2}')";
                    Query = string.Format(Query, CustName, Gender, Phone);
                    Con.SetData(Query);

                    // Refresh the customers list and display a message
                    ShowCustomers();
                    MessageBox.Show("Customer Added!!!");

                    // Clear text boxes
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

        // Event handler when a cell in the DataGridView is clicked
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate text boxes with selected customer details
            NameTb.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            GenderCb.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            // Set Key to 0 if the NameTb is empty, else set it to the Customer Code
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        // Event handler for the Edit button click
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before updating
            if (NameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Get data from text boxes
                    string CustName = NameTb.Text;
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Phone = PhoneTb.Text;

                    // Update customer in the database
                    string Query = "update CustomerTbl set CustName = '{0}', Gender = '{1}', Phone = '{2}'";
                    Query = string.Format(Query, CustName, Gender, Phone);
                    Con.SetData(Query);

                    // Refresh the customers list and display a message
                    ShowCustomers();
                    MessageBox.Show("Customer Updated!!!");

                    // Clear text boxes
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

        // Event handler for the Delete button click
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before deleting
            if (NameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Delete selected customer from the database
                    string Query = "Delete from CustomerTbl where CustCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);

                    // Refresh the customers list and display a message
                    ShowCustomers();
                    MessageBox.Show("Customer Deleted!!!");

                    // Clear text boxes
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

        // Event handler for the Items button click
        private void ItT_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        // Event handler for the Categories button click
        private void CatT_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        // Event handler for the Bill button click
        private void BillT_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }
    }
}
