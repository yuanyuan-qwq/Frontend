using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SmartStock.Model;

namespace SmartStock.Controller
{
    internal class LoginController
    {
        private MySQLDatabase db;

        public LoginController()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM staff WHERE username = @username AND password = @password";

            using (var connection = db.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    return userCount > 0;
                }
            }
        }
    }
}
