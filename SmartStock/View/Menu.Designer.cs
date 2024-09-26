namespace SmartStock
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnMIN = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnCCTV = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnMonitoring = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelall = new System.Windows.Forms.Panel();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.panelTitle.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelall.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelTitle.Controls.Add(this.btnMIN);
            this.panelTitle.Controls.Add(this.btnClose);
            this.panelTitle.Controls.Add(this.btnMax);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1582, 40);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // btnMIN
            // 
            this.btnMIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMIN.BackColor = System.Drawing.Color.Transparent;
            this.btnMIN.FlatAppearance.BorderSize = 0;
            this.btnMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMIN.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMIN.ForeColor = System.Drawing.Color.Lime;
            this.btnMIN.Location = new System.Drawing.Point(1476, 0);
            this.btnMIN.Name = "btnMIN";
            this.btnMIN.Size = new System.Drawing.Size(40, 40);
            this.btnMIN.TabIndex = 3;
            this.btnMIN.Text = "O";
            this.btnMIN.UseVisualStyleBackColor = false;
            this.btnMIN.Click += new System.EventHandler(this.btnMIN_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(1542, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "O";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.Color.Transparent;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.ForeColor = System.Drawing.Color.Yellow;
            this.btnMax.Location = new System.Drawing.Point(1509, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(40, 40);
            this.btnMax.TabIndex = 1;
            this.btnMax.Text = "O";
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.tableLayoutPanel1);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 40);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(248, 813);
            this.panelMenu.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnLogOut, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnDashboard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCCTV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInventory, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnMonitoring, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 211);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 602);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(3, 515);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogOut.Size = new System.Drawing.Size(242, 84);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "   LogOut";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click_1);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(242, 84);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnCCTV
            // 
            this.btnCCTV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.btnCCTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCCTV.FlatAppearance.BorderSize = 0;
            this.btnCCTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCCTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCTV.ForeColor = System.Drawing.Color.White;
            this.btnCCTV.Image = ((System.Drawing.Image)(resources.GetObject("btnCCTV.Image")));
            this.btnCCTV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCCTV.Location = new System.Drawing.Point(3, 93);
            this.btnCCTV.Name = "btnCCTV";
            this.btnCCTV.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCCTV.Size = new System.Drawing.Size(242, 84);
            this.btnCCTV.TabIndex = 1;
            this.btnCCTV.Text = "   CCTV";
            this.btnCCTV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCCTV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCCTV.UseVisualStyleBackColor = false;
            this.btnCCTV.Click += new System.EventHandler(this.btnCCTV_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(3, 273);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(242, 84);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "   Inventory";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.btnMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMonitoring.FlatAppearance.BorderSize = 0;
            this.btnMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonitoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonitoring.ForeColor = System.Drawing.Color.White;
            this.btnMonitoring.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitoring.Image")));
            this.btnMonitoring.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonitoring.Location = new System.Drawing.Point(3, 183);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnMonitoring.Size = new System.Drawing.Size(242, 84);
            this.btnMonitoring.TabIndex = 2;
            this.btnMonitoring.Text = "   Monitoring";
            this.btnMonitoring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMonitoring.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMonitoring.UseVisualStyleBackColor = false;
            this.btnMonitoring.Click += new System.EventHandler(this.btnMonitoring_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(248, 211);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelall
            // 
            this.panelall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(60)))));
            this.panelall.Controls.Add(this.panelDisplay);
            this.panelall.Controls.Add(this.panelMenu);
            this.panelall.Controls.Add(this.panelTitle);
            this.panelall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelall.Location = new System.Drawing.Point(0, 0);
            this.panelall.Name = "panelall";
            this.panelall.Size = new System.Drawing.Size(1582, 853);
            this.panelall.TabIndex = 2;
            // 
            // panelDisplay
            // 
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(248, 40);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1334, 813);
            this.panelDisplay.TabIndex = 3;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panelall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartStock";
            this.panelTitle.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelall.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnMIN;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCCTV;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnMonitoring;
        private System.Windows.Forms.Panel panelall;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

