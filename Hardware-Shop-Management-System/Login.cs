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
    public partial class Login : Form
    {
        Functions Con;

        public Login()
        {
            InitializeComponent();
            Con = new Functions();
            Con = new Functions();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else if (UNameTb.Text == "Ekber" || PasswordTb.Text == "1161i")
            {
                Items Obj = new Items();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
    }
}