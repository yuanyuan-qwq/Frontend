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
using static IronPython.Modules.PythonIterTools;

namespace SmartStock.View
{
    public partial class DashboardForm : Form
    {
        private ShelfController shelfController = new ShelfController();
        private DashboardController dashboardController = new DashboardController();
        private Car car = new Car();
        private People people = new People();

        public DashboardForm()
        {
            InitializeComponent();
            DGVLowShelf.CellPainting += DGVLowShelf_CellPainting;
            LoadData();
            timerRefresh.Start(); // Start the timer
        }


        private void DGVLowShelf_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                using (Brush brush = new SolidBrush(Color.FromArgb(254, 84, 110)))// Change the color as needed
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            label2.Parent = pictureBox1; 
            label2.BackColor = Color.Transparent;
            lbOutStock.Parent = pictureBox1;
            lbOutStock.BackColor = Color.Transparent;

            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
            lbClient.Parent = pictureBox2;
            lbClient.BackColor = Color.Transparent;

            label5.Parent = pictureBox3;
            label5.BackColor = Color.Transparent;
            lbParking.Parent = pictureBox3;
            lbParking.BackColor = Color.Transparent;

            label7.Parent = pictureBox4;
            label7.BackColor = Color.Transparent;
            lbShelf.Parent = pictureBox4;
            lbShelf.BackColor = Color.Transparent;
        }

        private void LoadData()
        {
            people = dashboardController.GetCurrentPeople();
            car = dashboardController.GetCurrentCar();

            lbOutStock.Text = Convert.ToString(dashboardController.GetTotalOos());

            if (people != null && car != null){
                lbClient.Text = Convert.ToString(people.Remain);
                lbParking.Text = Convert.ToString(car.Free);
                lbTotalClient.Text = Convert.ToString(people.ClientIN);
            }
            else
            {
                lbClient.Text = "0";
                lbParking.Text = "0";
                lbTotalClient.Text = "0";
            }

            //graph
            BindAggregatedDataToChart();

            //top 5
            chartTopRestockProducts.DataSource = dashboardController.GetTopRestockedProductsToday();
            chartTopRestockProducts.Series[0].XValueMember = "ProductName";
            chartTopRestockProducts.Series[0].YValueMembers = "Quantity";
            chartTopRestockProducts.DataBind();

            //low shelf table
            List<Shelf> ShelfArea = shelfController.GetAllShelves();
            DGVLowShelf.DataSource = ShelfArea;

            lbTotalRestock.Text = Convert.ToString(dashboardController.GetTotalRestockedQuantity());
            lbTotalInventory.Text = Convert.ToString(dashboardController.GetTotalInventory());
            lbShelf.Text = Convert.ToString(dashboardController.GetTotalShelfItem());


        }
        public void BindAggregatedDataToChart()
        {
            List<AggregatedData> aggregatedDataList = dashboardController.GetAggregatedDataByHoursIntervals();
            chartStatistic.DataSource = aggregatedDataList;

            chartStatistic.Series[0].XValueMember = "TimeOnly";
            chartStatistic.Series[0].YValueMembers = "TotalQuantity";

            chartStatistic.Series[1].XValueMember = "TimeOnly";
            chartStatistic.Series[1].YValueMembers = "RemainingPeople";

            chartStatistic.Series[2].XValueMember = "TimeOnly";
            chartStatistic.Series[2].YValueMembers = "ParkedCars";

            chartStatistic.DataBind();

            // Format the X-axis to show only time
            chartStatistic.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";

            chartStatistic.ChartAreas[0].AxisX.LineColor = Color.White;
            chartStatistic.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            chartStatistic.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chartStatistic.ChartAreas[0].AxisY.LineColor = Color.White;
            chartStatistic.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;
            chartStatistic.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
        }

        private void DGVLowShelf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = DGVLowShelf.SelectedRows[0];

            int Area = Convert.ToInt32(selectedRow.Cells["Area"].Value);

            // Create an instance of the VideoPopupForm
            LowStockAreaFrom PopupForm = new LowStockAreaFrom(Area);

            // Show the VideoPopupForm as a modal dialog
            PopupForm.ShowDialog();
            LoadData();
        }

        private void timerRefresh_Tick_1(object sender, EventArgs e)
        {
            LoadData();
            
            List<Shelf> ShelfArea = shelfController.GetAllShelves();
            foreach (Shelf shelf in ShelfArea)
            {
                if (shelf.OOS > 5)
                {
                    MessageBox.Show($"Area {shelf.Area} Currently High Out of Stock! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

    }
}
