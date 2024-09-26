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

namespace SmartStock.View
{
    public partial class LowStockAreaFrom : Form
    {
        private int area;
        private ProductController productController = new ProductController();
        private ShelfController shelfController = new ShelfController();
        private Product product =null;

        public LowStockAreaFrom(int area)
        {
            InitializeComponent();
            Product product = null;
            this.area = area;
            lbArea.Text=Convert.ToString(area);
            LoadData();
            dataGridView1.CellPainting += dataGridView1_CellPainting;
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
            List<ShelfItem> shelfItems = shelfController.GetShelfItem(area);
            dataGridView1.DataSource = shelfItems;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                product = new Product();
                product.ProductName = Convert.ToString(selectedRow.Cells["ProductName"].Value);
                product = productController.GetProductByName(product.ProductName);

                if (product != null)
                {
                    lbProductID.Text = Convert.ToString(product.ProductID);
                    lbProductName.Text = Convert.ToString(product.ProductName);
                    lbSupplierName.Text = Convert.ToString(product.SupplierName);
                    lbQuantity.Text = Convert.ToString(product.Quantity);
                    lbUnitPrice.Text = Convert.ToString(product.UnitPrice);
                }
                else
                {
                    MessageBox.Show("Product not found in inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string imagePath = product.ProductImage;

                // Check if the image path is not null or empty
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Check if the file exists at the specified path
                    if (File.Exists(imagePath))
                    {
                        // Assign the image path to pictureBox1.ImageLocation
                        //pbProduct.ImageLocation = imagePath;
                        pbProduct.Image = Image.FromFile(imagePath);
                    }
                    else
                    {   //image no available
                        pbProduct.ImageLocation = "D:\\Programming\\FYP1\\ProductImage\\photo.png";
                    }
                }
                else
                {
                    pbProduct.ImageLocation = "D:\\Programming\\FYP1\\ProductImage\\photo.png";
                }
            }
            
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            if (product != null)
            {
                // Create an instance of the VideoPopupForm
                RestockForm PopupForm = new RestockForm(product);

                // Show the VideoPopupForm as a modal dialog
                PopupForm.ShowDialog();

                LoadData();
                lbQuantity.Text = Convert.ToString(product.Quantity);
                product = null;

            }
            else
            {
                MessageBox.Show("Please select a row!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
