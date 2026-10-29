using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace LAB5_MSSQL
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                using var db = new ProductDbContext();
                db.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to SQL Server or initialize the MagazinDB database. Check the connection string in App.config.\n\n" + ex.Message,
                    "Database connection failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form1());
        }
    }
}
