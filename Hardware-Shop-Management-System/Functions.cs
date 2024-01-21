using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware_Shop_Management_System
{
    internal class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private string ConStr;
        private SqlDataAdapter Sda;

        // Constructor initializes the SqlConnection and SqlCommand objects
        public Functions()
        {
            // Connection string for the local Microsoft SQL Server database
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Unisoft\Documents\HardwareDb.mdf;Integrated Security=True;Connect Timeout=30;";

            // Initialize SqlConnection and SqlCommand
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        // Method to execute a SELECT query and return a DataTable
        public DataTable GetData(string Query)
        {
            // Create a new DataTable to store query results
            dt = new DataTable();

            // Use SqlDataAdapter to fill DataTable with data from the database
            Sda = new SqlDataAdapter(Query, ConStr);
            Sda.Fill(dt);

            // Return the populated DataTable
            return dt;
        }

        // Method to execute INSERT, UPDATE, or DELETE queries and return the number of affected rows
        public int SetData(string Query)
        {
            int Cnt;

            // Open the database connection if it is closed
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            // Set the command text to the provided query
            Cmd.CommandText = Query;

            // Execute the query and store the number of affected rows
            Cnt = Cmd.ExecuteNonQuery();

            // Close the database connection
            Con.Close();

            // Return the number of affected rows
            return Cnt;
        }
    }
}
