using FluorineFx.Messaging.Messages;
using SmartStock.Controller;
using SmartStock.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IronPython.Modules.PythonIterTools;

namespace SmartStock.View
{
    public partial class InventoryForm : Form
    {
        private ProductController productController = new ProductController();
        private SupplierController supplierController = new SupplierController();
        private Product product = new Product();
        private List<Product> productList = null;
        string PKeyword = null;
        string PSelectedColumn = null;
        private OpenFileDialog openFileDialog1;

        public InventoryForm()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView2.CellPainting += dataGridView1_CellPainting;

            // Get all products from the database
            List<Supplier> allSupplier = supplierController.GetAllSuppliers();
            // Add each product's ID and name to the ComboBox
            foreach (Supplier supplier in allSupplier)
            {
                string item = $"{supplier.SupplierID} - {supplier.CompanayName}";
                cbSupplier.Items.Add(item);
            }


        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbSupplier.SelectedItem?.ToString();

            if (selectedItem != null)
            {
                // Split the selected item to extract the product ID and name
                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2)
                {
                    // Update the text of lbProductID with the product ID
                    product.SupplierID = Convert.ToInt32(parts[0]); 

                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                using (Brush brush = new SolidBrush(Color.LightBlue)) // Change the color as needed
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }

        private void LoadData()
        {
            List<Product> allProducts = productController.GetAllProducts();
            dataGridView1.DataSource = allProducts;
            dataGridView1.Columns["SupplierID"].Visible = false; //to hide supplierID
            dataGridView1.Columns["ProductImage"].Visible = false;

            if (tabControl1.SelectedTab == tabSearchResult)
            {
                search(PKeyword, PSelectedColumn);
            }

            tbProductID.Text = null;
            tbProductName.Text = null;
            tbQuantity.Text = null;
            tbUnitPrice.Text = null;
            cbSupplier.Text = null;

            pBProduct.ImageLocation = "D:\\Programming\\FYP1\\ProductImage\\photo.png";
        }

        private void TableDataConvertor(DataGridViewRow selectedRow)
        {
            product = new Product();
            product.ProductID = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
            product.SupplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);
            product.ProductName = Convert.ToString(selectedRow.Cells["ProductName"].Value);
            product.UnitPrice = Convert.ToDouble(selectedRow.Cells["UnitPrice"].Value);
            product.Quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
            product.ProductImage = Convert.ToString(selectedRow.Cells["ProductImage"].Value);

            tbProductID.Text = Convert.ToString(selectedRow.Cells["ProductID"].Value);
            tbProductName.Text = Convert.ToString(selectedRow.Cells["ProductName"].Value);
            tbQuantity.Text = Convert.ToString(selectedRow.Cells["Quantity"].Value);
            tbUnitPrice.Text = Convert.ToString(selectedRow.Cells["UnitPrice"].Value);

            // Get the image path from the product object
            string imagePath = product.ProductImage;

            // Check if the image path is not null or empty
            if (!string.IsNullOrEmpty(imagePath))
            {
                // Check if the file exists at the specified path
                if (File.Exists(imagePath))
                {
                    // Assign the image path to pictureBox1.ImageLocation
                    pBProduct.ImageLocation = imagePath;
                }
                else
                {
                    // Assign a default image path if the file does not exist
                    pBProduct.ImageLocation = "D:\\Programming\\FYP1\\ProductImage\\photo.png";
                }
            }
            else
            {
                // Clear pictureBox1 if no image is available
                pBProduct.ImageLocation = "D:\\Programming\\FYP1\\ProductImage\\photo.png";
            }

            // Get all products from the database
            List<Supplier> allSupplier = supplierController.GetAllSuppliers();
            foreach (Supplier supplier in allSupplier)
            {
                // Construct the item format to match the one in the ComboBox
                string item = $"{supplier.SupplierID} - {supplier.CompanayName}";
                // Check if the current supplier ID matches the product's supplier ID
                if (supplier.SupplierID == product.SupplierID)
                {
                    // Find the index of the item in the ComboBox
                    int index = cbSupplier.FindStringExact(item);
                    // Set the selected item if found
                    if (index != -1)
                    {
                        cbSupplier.SelectedIndex = index;
                        break; // Exit the loop once the item is found
                    }
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabDisplay)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                TableDataConvertor(selectedRow);
            }
            else if (dataGridView2.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabSearchResult)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                TableDataConvertor(selectedRow);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboSearch.SelectedItem == null)
            {
                MessageBox.Show("Please select a search column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentKeyword = tbSearch.Text;
            string currentSelectedColumn = cboSearch.SelectedItem.ToString();

            search(currentKeyword, currentSelectedColumn);

            tabControl1.SelectedTab = tabSearchResult;
        }

        private void search(string keyword, string selectedColumn)
        {
            productList = new List<Product>();

            switch (selectedColumn)
            {
                case "Product ID":
                    int productID;
                    if (int.TryParse(keyword, out productID))
                    {
                        Product product = productController.GetProductByID(productID);
                        if (product != null)
                        {
                            productList.Add(product);
                        }
                    }
                    break;
                case "Product Name":
                    productList = productController.GetProductsByName(keyword);
                    break;
                case "Supplier ID":
                    int supplierID;
                    if (int.TryParse(keyword, out supplierID))
                    {
                        productList = productController.GetProductsBySupplierID(supplierID);
                    }
                    break;
            }

            dataGridView2.DataSource = productList;
            dataGridView2.Columns["SupplierID"].Visible = false; //to hide supplierName
            dataGridView2.Columns["ProductImage"].Visible = false;

            PKeyword = keyword;
            PSelectedColumn = selectedColumn;
        }

        private void ConvertToProduct()
        {
            // Read the image file from the PictureBox
            string imagePath = pBProduct.ImageLocation;

            product.ProductName = tbProductName.Text;
            product.UnitPrice = Convert.ToDouble(tbUnitPrice.Text);
            product.Quantity = Convert.ToInt32(tbQuantity.Text);
            product.ProductImage = imagePath; // Assign the image path
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string errorMessage;
            if (!productController.ValidateProductData(tbProductID.Text, cbSupplier.Text, tbProductName.Text, tbUnitPrice.Text, tbQuantity.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ConvertToProduct();

                if (productController.AddProduct(product))
                {
                    // If addition is successful, display a success message
                    MessageBox.Show("Product information added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    // If addition fails, display an error message
                    MessageBox.Show("Failed to add product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product1: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage;
            if (!productController.ValidateProductData(tbProductID.Text, cbSupplier.Text, tbProductName.Text, tbUnitPrice.Text, tbQuantity.Text, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            product.ProductID = Convert.ToInt32(tbProductID.Text);
            ConvertToProduct();

            // Call the presenter to update product information
            if (productController.UpdateProduct(product))
            {
                // If update is successful, display a success message
                MessageBox.Show("Product information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                // If update fails, display an error message
                MessageBox.Show("Failed to update product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (product != null)
            {
                if (productController.DeleteProduct(product.ProductID))
                {
                    MessageBox.Show("Product information deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to delete product information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Open a file dialog to allow the user to select an image file
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Set the image location of the pictureBox to the selected image file
                        pBProduct.ImageLocation = openFileDialog1.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
