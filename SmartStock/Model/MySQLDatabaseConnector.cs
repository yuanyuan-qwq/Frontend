using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SmartStock.Model
{
    public class MySQLDatabase
    {
        private string connectionString;

        public MySQLDatabase()
        {
            // Create connection string
            connectionString = "Server=127.0.0.1;Database=fyp;user=root;password=;";
        }

        public MySqlConnection GetConnection()
        {
            // Create and return a new MySqlConnection object using the connection string
            return new MySqlConnection(connectionString);
        }

        public int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            // Create a MySqlConnection object
            using (var connection = GetConnection())
            {
                // Open the connection
                connection.Open();

                // Create a MySqlCommand object
                using (var command = new MySqlCommand(query, connection))
                {
                    // Execute the query and get the number of affected rows
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public object ExecuteScalar(string query)
        {
            // Create a MySqlConnection object
            using (var connection = GetConnection())
            {
                // Open the connection
                connection.Open();

                // Create a MySqlCommand object
                using (var command = new MySqlCommand(query, connection))
                {
                    // Execute the query and return the result
                    return command.ExecuteScalar();
                }
            }
        }

        public MySqlDataReader ExecuteQuery(string query)
        {
            // Create a MySqlConnection object
            var connection = GetConnection();

            // Open the connection
            connection.Open();

            // Create a MySqlCommand object
            var command = new MySqlCommand(query, connection);

            // Execute the query and return the MySqlDataReader
            return command.ExecuteReader();
        }

        internal MySqlDataReader ExecuteQuery(string query, int currentHour)
        {
            // Create a MySqlConnection object
            var connection = GetConnection();

            // Open the connection
            connection.Open();

            // Create a MySqlCommand object
            var command = new MySqlCommand(query, connection);

            // Add parameter for current hour
            command.Parameters.AddWithValue("?CurrentHour", currentHour);

            // Execute the query and return the MySqlDataReader
            return command.ExecuteReader();
        }

    }
}
