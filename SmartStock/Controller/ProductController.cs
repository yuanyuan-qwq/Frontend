using MySql.Data.MySqlClient;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IronPython.Modules.PythonIterTools;

namespace SmartStock.Controller
{
    internal class ProductController
    {
        private MySQLDatabase db;

        public ProductController()
        {
            db = new MySQLDatabase();
        }

        public bool ValidateProductData(string productID, string SupplierID, string productName, string unitPrice, string quantity, out string errorMessage)
        {
            errorMessage = "";

            // Check for empty fields
            if (string.IsNullOrEmpty(productID) || string.IsNullOrEmpty(SupplierID) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(unitPrice) || string.IsNullOrEmpty(quantity))
            {
                errorMessage = "Please fill in all required fields.";
                return false;
            }

            if (!int.TryParse(productID, out _))
            {
                errorMessage = "productID must be a valid number.";
                return false;
            }


            // Validate unit price
            if (!double.TryParse(unitPrice, out _))
            {
                errorMessage = "Unit price must be a valid number.";
                return false;
            }

            // Validate quantity
            if (!int.TryParse(quantity, out _))
            {
                errorMessage = "Quantity must be a valid number.";
                return false;
            }

            return true; // Validation passed
        }

        public bool AddProduct(Product product)
        {
            try
            {

                // Check if the product image path is not null or empty
                if (!string.IsNullOrEmpty(product.ProductImage))
                {
                    // Define the folder path where you want to store the images
                    string imagePath = "D://Programming//FYP1//ProductImage//"; // Update this with the actual folder path

                    // Create a unique file name for the image
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(product.ProductImage)}"; // Use the same extension as the original image

                    // Combine the folder path and file name to get the full file path
                    string fullPath = Path.Combine(imagePath, fileName);

                    // Copy the image file to the specified folder path
                    File.Copy(product.ProductImage, fullPath, true);

                    // Store the relative file path of the saved image in the database
                    product.ProductImage = fullPath;

                }

                // Create the SQL query
                string query = $"INSERT INTO Product (SupplierID, ProductName, UnitPrice, Quantity, ProductImage) VALUES " +
                                $"({product.SupplierID}, '{product.ProductName}', {product.UnitPrice}, {product.Quantity}, '{product.ProductImage}')";

                // Execute INSERT query
                db.ExecuteNonQuery(query);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                // Check if the product image path is not null or empty
                if (!string.IsNullOrEmpty(product.ProductImage))
                {
                    // Define the folder path where you want to store the images
                    string imagePath = "D://Programming//FYP1//ProductImage//"; // Update this with the actual folder path

                    // Create a unique file name for the image
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(product.ProductImage)}"; // Use the same extension as the original image

                    // Combine the folder path and file name to get the full file path
                    string fullPath = Path.Combine(imagePath, fileName);

                    // Copy the image file to the specified folder path
                    File.Copy(product.ProductImage, fullPath, true);

                    // Store the relative file path of the saved image in the database
                    product.ProductImage = fullPath;
                }

                // Create the SQL query for updating the product
                string query = $"UPDATE Product SET " +
                               $"SupplierID = {product.SupplierID}, " +
                               $"ProductName = '{product.ProductName}', " +
                               $"UnitPrice = {product.UnitPrice}, " +
                               $"Quantity = {product.Quantity}, " +
                               $"ProductImage = '{product.ProductImage}' " +
                               $"WHERE ProductID = {product.ProductID}";

                // Execute the UPDATE query
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
                MessageBox.Show($"Error updating Product: {ex.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                // Construct DELETE query
                string query = $"DELETE FROM Product WHERE ProductID = {productID}";

                // Execute DELETE query
                int rowsAffected = db.ExecuteNonQuery(query);

                // Check if any rows were affected
                if (rowsAffected > 0)
                {
                    return true; // Deletion successful
                }
                else
                {
                    MessageBox.Show($"Error deleting Product: ProductID {productID} not found");
                    return false; // No rows were affected, deletion failed 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Product: {ex.Message}");
                return false;
            }
        }


        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query with a JOIN to fetch supplier name
            string query = "SELECT p.ProductID, p.SupplierID, p.ProductName, p.UnitPrice, p.Quantity, s.CompanyName AS SupplierName,p.ProductImage " +
                           "FROM Product p " +
                           "INNER JOIN Supplier s ON p.SupplierID = s.SupplierID";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        SupplierID = reader.GetInt32("SupplierID"),
                        // Get the supplier name from supplier table
                        SupplierName = reader.GetString("SupplierName"),
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity"),
                        ProductImage = reader.GetString("ProductImage")

                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }


        public Product GetProductByID(int productID)
        {
            Product product = null;

            // Construct the SQL query to select product by ProductID
            string query = $"SELECT p.ProductID, p.SupplierID, p.ProductName, p.UnitPrice, p.Quantity, s.CompanyName AS SupplierName, p.ProductImage " +
                           $"FROM Product p " +
                           $"INNER JOIN Supplier s ON p.SupplierID = s.SupplierID " +
                           $"WHERE p.ProductID = {productID}";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity"),
                        SupplierID = reader.GetInt32("SupplierID"),
                        SupplierName = reader.GetString("SupplierName"),
                        ProductImage = reader.GetString("ProductImage")
                    };
                }
            }

            // Return the product object (might be null if no product found with the given ProductID)
            return product;
        }


        public Product GetProductByName(string productName)
        {
            Product product = null;

            // Construct the SQL query to select product by ProductID
            string query = $"SELECT p.ProductID, p.SupplierID, p.ProductName, p.UnitPrice, p.Quantity, s.CompanyName AS SupplierName, p.ProductImage " +
                           $"FROM Product p " +
                           $"INNER JOIN Supplier s ON p.SupplierID = s.SupplierID " +
                           $"WHERE p.ProductName LIKE '%{productName}%'";

            // Execute the query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if there are rows returned
                if (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity"),
                        SupplierID = reader.GetInt32("SupplierID"),
                        SupplierName = reader.GetString("SupplierName"),
                        ProductImage = reader.GetString("ProductImage")
                    };
                }
            }

            // Return the product object (might be null if no product found with the given ProductID)
            return product;
        }

        public List<Product> GetProductsByName(string productName)
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query
            string query = $"SELECT p.ProductID, p.SupplierID, p.ProductName, p.UnitPrice, p.Quantity, s.CompanyName AS SupplierName, p.ProductImage " +
                           $"FROM Product p " +
                           $"INNER JOIN Supplier s ON p.SupplierID = s.SupplierID " +
                           $"WHERE p.ProductName LIKE '%{productName}%'";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        SupplierID = reader.GetInt32("SupplierID"),
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity"),
                        SupplierName = reader.GetString("SupplierName"),
                        ProductImage = reader.GetString("ProductImage"),
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }



        public List<Product> GetProductsBySupplierID(int supplierID)
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query
            string query = $"SELECT p.ProductID, p.SupplierID, p.ProductName, p.UnitPrice, p.Quantity, s.CompanyName AS SupplierName, p.ProductImage " +
                           $"FROM Product p " +
                           $"INNER JOIN Supplier s ON p.SupplierID = s.SupplierID " +
                           $"WHERE p.SupplierID = {supplierID}";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        SupplierID = reader.GetInt32("SupplierID"),
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity"),
                        SupplierName = reader.GetString("SupplierName"),
                        ProductImage = reader.GetString("ProductImage"),
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }


        public List<Product> GetAllProductsOrderByQuantityAscending()
        {
            List<Product> productList = new List<Product>();

            // Construct SELECT query with ORDER BY clause
            string query = "SELECT * FROM Product ORDER BY Quantity ASC";

            // Execute SELECT query
            using (MySqlDataReader reader = db.ExecuteQuery(query))
            {
                // Check if the reader has any rows
                while (reader.Read())
                {
                    // Create a new Product object and populate it with data from the database
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32("ProductID"),
                        SupplierID = reader.GetInt32("SupplierID"),
                        ProductName = reader.GetString("ProductName"),
                        UnitPrice = reader.GetDouble("UnitPrice"),
                        Quantity = reader.GetInt32("Quantity")
                    };

                    // Add the product object to the list
                    productList.Add(product);
                }
            }

            return productList;
        }

        
    }
}
