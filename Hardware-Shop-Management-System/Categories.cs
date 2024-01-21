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
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        
        private void ShowCategories()
        {
            try
            {
                string Query = "select * from CategoryTbl";
                CategoriesList.DataSource = Con.GetData(Query);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
            
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Query = "insert into CategoryTbl values('{0}')";
                    Query = string.Format(Query, Name);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Added!!!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Query = "Update CategoryTbl set CatName = '{0}' where CatCode = {1}";
                    Query = string.Format(Query, Name, Key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Edited!!!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Query = "Delete from CategoryTbl where CatCode = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Category Deleted!!!");
                    NameTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ItT_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
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
