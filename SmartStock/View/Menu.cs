using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SmartStock.View;

namespace SmartStock
{
    public partial class Menu : Form
    {
        private Button currentButton;
        private Color defaultButtonColor = Color.FromArgb(51, 51, 80);
        private Color btnDashboardColor = Color.DeepSkyBlue;
        private Color btnCCTVColor = Color.Coral;
        private Color btnMonitoringColor = Color.LightSeaGreen;
        private Color btnInventoryColor = Color.GreenYellow;
        private Color btnLogEventColor = Color.MediumPurple;
        private Color btnStaffColor = Color.LightPink;

        private Form activeForm;


        public Menu()
        {
            InitializeComponent();
            OpenChildForm(new DashboardForm(), btnDashboard);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                Button clickedButton = (Button)btnSender;

                if (currentButton != clickedButton)
                {
                    // Reset the color of the previously clicked button
                    ResetButtonColor();

                    // Set the color of the new button
                    Color color = GetButtonColor(clickedButton);
                    clickedButton.BackColor = color;
                    clickedButton.ForeColor = Color.Black;
                    clickedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = color;
                    // Store the current button
                    currentButton = clickedButton;

                }
            }
        }

        private void ResetButtonColor()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = defaultButtonColor;
                currentButton.ForeColor = Color.White; // Set to the default text color
                currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private Color GetButtonColor(Button button)
        {
            switch (button.Name)
            {
                case "btnDashboard":
                    return btnDashboardColor;
                case "btnCCTV":
                    return btnCCTVColor;
                case "btnMonitoring":
                    return btnMonitoringColor;
                case "btnInventory":
                    return btnInventoryColor;
                case "btnLogEvent":
                    return btnLogEventColor;
                case "btnStaff":
                    return btnStaffColor;
                default:
                    return defaultButtonColor;
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            // Close the currently active form if it exists
            if (activeForm != null)
                activeForm.Close();

            // Activate the button associated with the child form
            ActivateButton(btnSender);

            // Set the child form as the active form
            activeForm = childForm;

            // Configure the child form properties for embedding in the panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add the child form to the panel for display
            this.panelDisplay.Controls.Add(childForm);

            // Set the tag of the panel to reference the child form
            this.panelDisplay.Tag = childForm;

            // Bring the child form to the front for display
            childForm.BringToFront();

            // Show the child form
            childForm.Show();

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardForm(), sender);
        }

        private void btnCCTV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CCTVForm(), sender);
        }

        private void btnMonitoring_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MonitoringForm(), sender);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InventoryForm(), sender);
        }

        private void btnLogEvent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CCTVForm(), sender);
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {

            //Login loginForm = new Login();
            //loginForm.Show();

            //// Close the current form (Menu)
            //this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMIN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
    }
}
