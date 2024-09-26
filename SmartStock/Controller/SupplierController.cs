using MySql.Data.MySqlClient;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartStock.Controller
{
    internal class SupplierController
    {
        private MySQLDatabase db;

        public SupplierController()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateSupplierData(string companyName, string phone, string email, out string errorMessage)
        {
            errorMessage = "";

            // Check for empty fields
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
            {
                errorMessage = "Please fill in all required fields.";
                return false;
            }

            // Validate phone
            if (!int.TryParse(phone, out _))
            {
                errorMessage = "Phone must be a valid number.";
                return false;
            }

            return true; // Validation passed
        }

        public bool AddSupplier(Supplier supplier)
        {
            try
            {
                string query = $"INSERT INTO Supplier (CompanyName, Phone, Email) VALUES " +
                               $"('{supplier.CompanayName}', {supplier.Phone}, '{supplier.Email}')";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Supplier: {ex.Message}");
                return false;
            }
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            try
            {
                string query = $"UPDATE Supplier SET CompanyName = '{supplier.CompanayName}', " +
                               $"Phone = {supplier.Phone}, Email = '{supplier.Email}' WHERE SupplierID = {supplier.SupplierID}";

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
                MessageBox.Show($"Error updating Supplier: {ex.Message}");
                return false;
            }
        }

        public bool DeleteSupplier(int supplierID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM Supplier WHERE SupplierID = {supplierID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting Supplier: SupplierID {supplierID} not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Supplier: {ex.Message}");
                return false;
            }
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> supplierList = new List<Supplier>();

            // Construct SELECT query
            string query = "SELECT * FROM Supplier";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Supplier object and populate it with data from the database
                    Supplier supplier = new Supplier
                    {
                        SupplierID = reader.GetInt32("SupplierID"),
                        CompanayName = reader.GetString("CompanyName"),
                        Phone = reader.GetInt32("Phone"),
                        Email = reader.GetString("Email")
                    };

                    // Add the supplier object to the list
                    supplierList.Add(supplier);
                }
            }

            return supplierList;
        }

        public Supplier GetSupplierByID(int supplierID)
        {
            Supplier supplier = null;

            // Construct the SQL query to select supplier by SupplierID
            string query = $"SELECT * FROM Supplier WHERE SupplierID = {supplierID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Supplier object and populate it with data from the database
                    supplier = new Supplier
                    {
                        SupplierID = reader.GetInt32("SupplierID"),
                        CompanayName = reader.GetString("CompanyName"),
                        Phone = reader.GetInt32("Phone"),
                        Email = reader.GetString("Email")
                    };
                }
            }

            // Return the supplier object (might be null if no supplier found with the given SupplierID)
            return supplier;
        }
    }
}
