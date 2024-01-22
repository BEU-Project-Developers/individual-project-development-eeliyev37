using Guna.UI2.WinForms;
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
    public partial class Categories : Form
    {
        Functions Con;
        int Key = 0;

        // Constructor for the Categories form
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }

        // Method to display categories in the DataGridView
        private void ShowCategories()
        {
            try
            {
                string Query = "select * from CategoryTbl";
                CategoriesList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // Event handler for the "Add" button click
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before adding a new category
            if (NameTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Get data from the text box
                    string Name = NameTb.Text;

                    // Insert new category into the database
                    string Query = "insert into CategoryTbl values('{0}')";
                    Query = string.Format(Query, Name);
                    Con.SetData(Query);

                    // Refresh the categories list and display a message
                    ShowCategories();
                    MessageBox.Show("Category Added!!!");

                    // Clear the text box
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Event handler when a cell in the DataGridView is clicked
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate the text box with the selected category's name
            NameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();

            // Set Key to 0 if the NameTb is empty, else set it to the Category Code
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        // Event handler for the "Edit" button click
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before editing a category
            if (NameTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Get data from the text box
                    string Name = NameTb.Text;

                    // Update the category in the database
                    string Query = "update CategoryTbl set CatName = '{0}' where CatCode = {1}";
                    Query = string.Format(Query, Name, Key);
                    Con.SetData(Query);

                    // Refresh the categories list and display a message
                    ShowCategories();
                    MessageBox.Show("Category Edited!!!");

                    // Clear the text box
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Event handler for the "Delete" button click
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before deleting a category
            if (NameTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Delete the selected category from the database
                    string Query = "delete from CategoryTbl where CatCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);

                    // Refresh the categories list and display a message
                    ShowCategories();
                    MessageBox.Show("Category Deleted!!!");

                    // Clear the text box
                    NameTb.Text = "";
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

        // Event handler for the Customers button click
        private void CustT_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
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

        private void LogouT_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void XT_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
       
         
    }
}
