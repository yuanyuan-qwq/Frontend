using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartStock.Model;
using SmartStock.View;

namespace SmartStock
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MySQLDatabase mySQLDatabase = new MySQLDatabase();

            if (TestConnection(mySQLDatabase))
            {
                Console.WriteLine("Connection successful.");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            }
            else
            {
                MessageBox.Show("Failed to connect to the database. The application will now exit.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        static bool TestConnection(MySQLDatabase mySQLDatabase)
        {
            try
            {
                // Attempt to open a connection
                using (var connection = mySQLDatabase.GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
