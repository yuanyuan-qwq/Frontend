using MySql.Data.MySqlClient;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartStock.Controller
{
    internal class OrderingController
    {
        private MySQLDatabase db;

        public OrderingController()
        {
            db = new MySQLDatabase();
        }

        public bool AddOrdering(Ordering ordering)
        {
            try
            {
                string query = $"INSERT INTO Ordering (OrderDate, TotalAmount, Status) VALUES " +
                               $"('{ordering.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}', {ordering.TotalAmount}, '{ordering.Status}')";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Ordering: {ex.Message}");
                return false;
            }
        }

        public bool UpdateOrdering(Ordering ordering)
        {
            try
            {
                string query = $"UPDATE Ordering SET OrderDate = '{ordering.OrderDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                               $"TotalAmount = {ordering.TotalAmount}, Status = '{ordering.Status}' WHERE OrderID = {ordering.OrderID}";

                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Update successful
                }
                else
                {
                    MessageBox.Show("No rows were affected, update failed");
                    return false; // No rows were affected, update failed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Ordering: {ex.Message}");
                return false;
            }
        }

        public bool DeleteOrdering(int orderID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM Ordering WHERE OrderID = {orderID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting Ordering: OrderID {orderID} not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Ordering: {ex.Message}");
                return false;
            }
        }

        public List<Ordering> GetAllOrderings()
        {
            List<Ordering> orderingList = new List<Ordering>();

            // Construct SELECT query
            string query = "SELECT * FROM Ordering";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    Ordering ordering = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        OrderDate = reader.GetDateTime("OrderDate"),
                        TotalAmount = reader.GetDouble("TotalAmount"),
                        Status = reader.GetString("Status")
                    };

                    // Add the ordering object to the list
                    orderingList.Add(ordering);
                }
            }

            return orderingList;
        }

        public Ordering GetOrderingByID(int orderID)
        {
            Ordering ordering = null;

            // Construct the SQL query to select ordering by OrderID
            string query = $"SELECT * FROM Ordering WHERE OrderID = {orderID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Ordering object and populate it with data from the database
                    ordering = new Ordering
                    {
                        OrderID = reader.GetInt32("OrderID"),
                        OrderDate = reader.GetDateTime("OrderDate"),
                        TotalAmount = reader.GetDouble("TotalAmount"),
                        Status = reader.GetString("Status")
                    };
                }
            }

            // Return the ordering object (might be null if no ordering found with the given OrderID)
            return ordering;
        }
    }
}
