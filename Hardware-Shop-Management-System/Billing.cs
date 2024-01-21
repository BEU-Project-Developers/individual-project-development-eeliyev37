using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;
using System.Windows.Input;

namespace Hardware_Shop_Management_System
{
    public partial class Billing : Form
    {
        Functions Con;
        public Billing()
        {
            Con = new Functions();
            InitializeComponent();
            ShowItems();
        }

        private void ShowItems()
        {
            try
            {
                string Query = "Select * from ItemTbl";
                ItemList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }


        }
        int Key = 0;
        int Stock;
        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //NameTb.Text = ItemList.SelectedRows[0].Cells[1].Value.ToString();
            //CatCb.Text = ItemList.SelectedRows[0].Cells[2].Value.ToString();
            //PriceTb.Text = ItemList.SelectedRows[0].Cells[3].Value.ToString();
            //Stock = Convert.ToInt32(ItemList.SelectedRows[0].Cells[4].Value.ToString());
            //ManufacturerTb.Text = ItemList.SelectedRows[0].Cells[5].Value.ToString();

            //if (NameTb.Text == "")
            //{
            //    Key = 0;
            //}
            //else
            //{
            //    Key = Convert.ToInt32(ItemList.SelectedRows[0].Cells[0].ToString());
            //}
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            //NameTb.Text = "";
            PriceTb.Text = "";
        }
        string PMethod = "";
        int n = 0;
        int GrdTotal;
        private void UpdateStock()
        {
            try
            {
                int NewStock = Stock - Convert.ToInt32(QuantityTb.Text);
                string Query = "insert into ItemTbl set ItStock = {0} where ItCode = {1}";
                Query = string.Format(Query, NewStock, Key);
                Con.SetData(Query);
                ShowItems();
                MessageBox.Show("Stock Updated!!!");

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //    if(PriceTb.Text == "" || QuantityTb.Text == "" || NameTb.Text == "")
            //    {
            //        MessageBox.Show("Missing Data!!!");
            //    }
            //    else if (Stock <   Convert.ToInt32(QuantityTb.Text))
            //    {
            //        MessageBox.Show("Not Enough Stock!!!");
            //    }
            //    else
            //    {
            //        int Qte = Convert.ToInt32(QuantityTb.Text);
            //        int total = Convert.ToInt32(PriceTb.Text) * Qte;
            //        DataGridViewRow newRow = new DataGridViewRow();
            //        newRow.CreateCells(ClientBill);
            //        newRow.Cells[0].Value = n + 1;
            //        newRow.Cells[1].Value = NameTb.Text;
            //        newRow.Cells[2].Value = PriceTb.Text;
            //        newRow.Cells[3].Value = QuantityTb.Text;
            //        newRow.Cells[4].Value = "Rs " + total;
            //        ClientBill.Rows.Add(newRow);
            //        n++;
            //        GrdTotal = GrdTotal + total;
            //        GrdTotalLbl.Text = "Rs " + GrdTotal;
            //        UpdateStock();
            //        ShowItems();
            //    }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            //        if (NameTb.Text == "" || CustTb.Text == "")
            //        {
            //            MessageBox.Show("Missing Data!!!");
            //        }
            //        else
            //        {
            //            try
            //            {
            //                if(MobileRadio.Checked == true)
            //                {
            //                    PMethod = "Mobile";
            //                }
            //                else if (CardRadio.Checked == true)
            //                {
            //                    PMethod = "Card";
            //                }
            //                else
            //                {
            //                    PMethod = "Cash";
            //                }
            //                string ItName = NameTb.Text;

            //                string Query = "insert into BillingTbl values('{0}', {1}, {2}, '{3}')";
            //                Query = string.Format(Query, DateTime.Today.Date, CustTb.Text, GrdTotal, PMethod);
            //                Con.SetData(Query);
            //                ShowItems();
            //                MessageBox.Show("Bill Added!!!");

            //            }
            //            catch (Exception Ex)
            //            {
            //                MessageBox.Show(Ex.Message);
            //            }
            //        }
                }
        }
    }
