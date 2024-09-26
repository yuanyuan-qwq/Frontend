using MySql.Data.MySqlClient;
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
    public partial class LoginForm : Form
    {
        private MySQLDatabase db;
        private LoginController loginController;

        public LoginForm()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            tbPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text;
            string password = tbPassword.Text;

            if (loginController.ValidateLogin(username, password))
            {
                // Open the main menu form
                Menu menuForm = new Menu();
                menuForm.Show();
                this.Hide();
            }
            else
            {
                // Show error message
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbUserName_Click(object sender, EventArgs e)
        {
            tbUserName.BackColor = Color.FromArgb(61, 80, 106);
            panel3.BackColor = Color.FromArgb(61, 80, 106);
            panel4.BackColor = Color.FromArgb(56, 75, 101);
            tbPassword.BackColor = Color.FromArgb(56, 75, 101);
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            tbUserName.BackColor = Color.FromArgb(56, 75, 101);
            panel3.BackColor = Color.FromArgb(56, 75, 101);
            panel4.BackColor = Color.FromArgb(61, 80, 106);
            tbPassword.BackColor = Color.FromArgb(61, 80, 106);
        }
    }
}
