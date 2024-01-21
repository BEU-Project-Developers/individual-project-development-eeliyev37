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
        // Declare an instance of the Functions class for database interactions
        Functions Con;

        // Constructor for the Login form
        public Login()
        {
            InitializeComponent();

            // Initialize the Functions class instance
            Con = new Functions();
        }

        // Event handler for the login button click
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Check if the username or password is missing
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            // Check if the entered username and password match the hardcoded values
            else if (UNameTb.Text == "Ekber" || PasswordTb.Text == "1161i")
            {
                // If the credentials match, open the Items form and hide the current form
                Items Obj = new Items();
                Obj.Show();
                this.Hide();
            }
            else
            {
                // Display a message for wrong username or password
                MessageBox.Show("Wrong Username or Password");
            }
        }
    }
}
