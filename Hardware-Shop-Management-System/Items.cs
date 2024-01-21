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
using System.Windows.Input;

namespace Hardware_Shop_Management_System
{
    public partial class Items : Form
    {
        Functions Con;
        int Key = 0;

        // Constructor for the Items form
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
        }

        // Method to populate the categories in the ComboBox
        private void GetCategories()
        {
            string Query = "Select * from CategoryTbl";
            CatCb.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }

        // Method to display items in the DataGridView
        private void ShowItems()
        {
            try
            {
                string Query = "Select * from ItemTbl";
                ItemsList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // Event handler when a cell in the DataGridView is clicked
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate text boxes with selected item details
            NameTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            StockTb.Text = ItemsList.SelectedRows[0].Cells[4].Value.ToString();
            ManufacturerTb.Text = ItemsList.SelectedRows[0].Cells[5].Value.ToString();

            // Set Key to 0 if the NameTb is empty, else set it to the Item Code
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].ToString());
            }
        }

        // Event handler for the Edit button click
        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before updating
            if (NameTb.Text == "" || CatCb.SelectedIndex == -1 || PriceTb.Text == "" || StockTb.Text == "" || ManufacturerTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Get data from text boxes
                    string Name = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;

                    // Update item in the database
                    string Query = "update ItemTbl set ItName = '{0}', ItCategory = {1}, ItPrice = {2}, ItStock = {3}, Manufacturer = '{4}'";
                    Query = string.Format(Query, Name, Cat, Price, Stock, Man);
                    Con.SetData(Query);

                    // Refresh the items list and display a message
                    ShowItems();
                    MessageBox.Show("Item Updated!!!");

                    // Clear text boxes
                    NameTb.Text = "";
                    ManufacturerTb.Text = "";
                    CatCb.SelectedIndex = -1;
                    PriceTb.Text = "";
                    StockTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Event handler for the Add button click
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check for missing data before adding
            if (NameTb.Text == "" || CatCb.SelectedIndex == -1 || PriceTb.Text == "" || StockTb.Text == "" || ManufacturerTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    // Get data from text boxes
                    string ItName = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;

                    // Insert new item into the database
                    string Query = "insert into ItemTbl values('{0}', {1}, {2}, {3}, '{4}')";
                    Query = string.Format(Query, ItName, Cat, Price, Stock, Man);
                    Con.SetData(Query);

                    // Refresh the items list and display a message
                    ShowItems();
                    MessageBox.Show("Item Added!!!");

                    // Clear text boxes
                    NameTb.Text = "";
                    ManufacturerTb.Text = "";
                    CatCb.SelectedIndex = -1;
                    PriceTb.Text = "";
                    StockTb.Text = "";
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
            // Check if an item is selected
            if (Key == 0)
            {
                MessageBox.Show("Select an Item!!!");
            }
            else
            {
                try
                {
                    // Delete selected item from the database
                    string Query = "delete from ItemTbl where ItCode = {0})";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);

                    // Refresh the items list and display a message
                    ShowItems();
                    MessageBox.Show("Item Deleted!!!");

                    // Clear text boxes
                    NameTb.Text = "";
                    ManufacturerTb.Text = "";
                    CatCb.SelectedIndex = -1;
                    PriceTb.Text = "";
                    StockTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Event handler for the Category button click
        private void CatT_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        // Event handler for the Customer button click
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
    }
}
