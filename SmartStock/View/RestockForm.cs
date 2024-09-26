using SmartStock.Controller;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartStock.View
{
    public partial class RestockForm : Form
    {
        Product product = new Product();
        ProductController productController = new ProductController();
        Restock restock = new Restock();
        DashboardController dashboardController = new DashboardController();
        public RestockForm(Product product)
        {
            InitializeComponent();
            this.product = product;
            lbProductName.Text = Convert.ToString(product.ProductName);
            lbQuantity.Text = Convert.ToString(product.Quantity);
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            int restockQuantity;

            // Check if tbRestock contains a valid integer
            if (int.TryParse(tbRestock.Text, out restockQuantity))
            {
                // Calculate the new quantity
                int newQuantity = product.Quantity - restockQuantity;

                restock.ProductName = product.ProductName;
                restock.Quantity = restockQuantity;

                // Check if the new quantity is positive
                if (newQuantity >= 0)
                {
                    // Update the product quantity
                    product.Quantity = newQuantity;

                    // Update the label to reflect the new quantity
                    lbQuantity.Text = product.Quantity.ToString();

                    if (productController.UpdateProduct(product) && dashboardController.AddRestock(restock))
                    {
                        // Display a success message
                        MessageBox.Show("Product restocked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // If update fails, display an error message
                        MessageBox.Show("Failed to update product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    this.Close();
                }
                else
                {
                    // Display an error message if the new quantity is not positive
                    MessageBox.Show("Insufficient Inventory!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Display an error message if tbRestock does not contain a valid integer
                MessageBox.Show("Please enter a valid integer for restock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
