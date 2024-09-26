using MySql.Data.MySqlClient;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartStock.Controller
{
    internal class OrderItemController
    {
        private MySQLDatabase db;

        public OrderItemController()
        {
            db = new MySQLDatabase();
        }

        public bool AddOrderItem(OrderItem orderItem)
        {
            try
            {
                string query = $"INSERT INTO OrderItem (OrderID, ProductID, UnitPrice, Quantity) VALUES " +
                               $"({orderItem.OrderID}, {orderItem.ProductID}, {orderItem.UnitPrice}, {orderItem.Quantity})";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding OrderItem: {ex.Message}");
                return false;
            }
        }

        public bool UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                string query = $"UPDATE OrderItem SET OrderID = {orderItem.OrderID}, " +
                               $"ProductID = {orderItem.ProductID}, UnitPrice = {orderItem.UnitPrice}, Quantity = {orderItem.Quantity} " +
                               $"WHERE OrderItemID = {orderItem.OrderItemID}";

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
                MessageBox.Show($"Error updating OrderItem: {ex.Message}");
                return false;
            }
        }

        public bool DeleteOrderItem(int orderItemID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM OrderItem WHERE OrderItemID = {orderItemID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting OrderItem: OrderItemID {orderItemID} not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting OrderItem: {ex.Message}");
                return false;
            }
        }

        public List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> orderItemList = new List<OrderItem>();

            // Construct SELECT query
            string query = "SELECT * FROM OrderItem";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new OrderItem object and populate it with data from the database
                    OrderItem orderItem = new OrderItem
                    {
                        OrderItemID = reader.GetInt32("OrderItemID"),
                        OrderID = reader.GetInt32("OrderID"),
                        ProductID = reader.GetInt32("ProductID"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity")
                    };

                    // Add the orderItem object to the list
                    orderItemList.Add(orderItem);
                }
            }

            return orderItemList;
        }

        public OrderItem GetOrderItemByID(int orderItemID)
        {
            OrderItem orderItem = null;

            // Construct the SQL query to select orderItem by OrderItemID
            string query = $"SELECT * FROM OrderItem WHERE OrderItemID = {orderItemID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new OrderItem object and populate it with data from the database
                    orderItem = new OrderItem
                    {
                        OrderItemID = reader.GetInt32("OrderItemID"),
                        OrderID = reader.GetInt32("OrderID"),
                        ProductID = reader.GetInt32("ProductID"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity")
                    };
                }
            }

            // Return the orderItem object (might be null if no orderItem found with the given OrderItemID)
            return orderItem;
        }
    }
}
