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
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
        }
        
        private void GetCategories()
        {
            string Query = "Select * from CategoryTbl";
            CatCb.ValueMember = Con.GetData(Query).Columns["CatCode"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["CatName"].ToString();
            CatCb.DataSource = Con.GetData(Query);
        }
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
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = ItemsList.SelectedRows[0].Cells[1].Value.ToString();
            CatCb.Text = ItemsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = ItemsList.SelectedRows[0].Cells[3].Value.ToString();
            StockTb.Text = ItemsList.SelectedRows[0].Cells[4].Value.ToString();
            ManufacturerTb.Text = ItemsList.SelectedRows[0].Cells[5].Value.ToString();

            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ItemsList.SelectedRows[0].Cells[0].ToString());
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || CatCb.SelectedIndex == -1 || PriceTb.Text == "" || StockTb.Text == "" || ManufacturerTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;
                    string Query = "update ItemTbl set ItName = '{0}', ItCategory = {1}, ItPrice = {2}, ItStock = {3}, Manufacturer = '{4}'";
                    Query = string.Format(Query, Name, Cat, Price, Stock, Man);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Updated!!!");
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || CatCb.SelectedIndex == -1 || PriceTb.Text == "" || StockTb.Text == "" || ManufacturerTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string ItName = NameTb.Text;
                    string Cat = CatCb.SelectedValue.ToString();
                    string Price = PriceTb.Text;
                    string Stock = StockTb.Text;
                    string Man = ManufacturerTb.Text;
                    string Query = "insert into ItemTbl values('{0}', {1}, {2}, {3}, '{4}')";
                    Query = string.Format(Query, ItName, Cat, Price, Stock, Man);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Added!!!");
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
        

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Select a Item!!!");
            }
            else
            {
                try
                {
                    string Query = "delete from  ItemTbl where ItCode = {0})";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowItems();
                    MessageBox.Show("Item Deleted!!!");
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

        private void CatT_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void CustT_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void BillT_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }
    }   
}

