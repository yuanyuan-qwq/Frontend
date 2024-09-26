using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WebSocketSharp;

namespace SmartStock.View
{
    public partial class MonitoringForm : Form
    {
        private WebSocket ws1;
        private WebSocket ws2;
        private WebSocket ws3;
        private WebSocket ws4;


        public MonitoringForm()
        {
            InitializeComponent();
            InitializeWebSocket();
        }

        private void InitializeWebSocket()
        {
            ws1 = new WebSocket("ws://localhost:8700");
            ws1.OnMessage += Ws1_OnMessage;
            ws1.Connect();

            ws2 = new WebSocket("ws://localhost:8701");
            ws2.OnMessage += Ws2_OnMessage;
            ws2.Connect();

            ws3 = new WebSocket("ws://localhost:8702");
            ws3.OnMessage += Ws3_OnMessage;
            ws3.Connect();

            ws4 = new WebSocket("ws://localhost:8703");
            ws4.OnMessage += Ws4_OnMessage;
            ws4.Connect();
        }

        private void Ws1_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                var bytes = e.RawData;
                using (var ms = new MemoryStream(bytes))
                {
                    var image = Image.FromStream(ms);
                    pictureBox1.Image = image;  // Display the image in PictureBox1
                }
            }
            catch (ArgumentException ex)
            {
                // Handle the exception, for example, by displaying an error message
                MessageBox.Show("Area 1 Shelf Updated", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ws2_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                var bytes = e.RawData;
                using (var ms = new MemoryStream(bytes))
                {
                    var image = Image.FromStream(ms);
                    pictureBox2.Image = image;  // Display the image in PictureBox2
                }
            }
            catch (ArgumentException ex)
            {
                // Handle the exception, for example, by displaying an error message
                MessageBox.Show("Area 2 Shelf Updated", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ws3_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                var bytes = e.RawData;
                using (var ms = new MemoryStream(bytes))
                {
                    var image = Image.FromStream(ms);
                    pictureBox3.Image = image;  // Display the image in PictureBox2
                }
            }
            catch (ArgumentException ex)
            {
                // Handle the exception, for example, by displaying an error message
                MessageBox.Show("Area 3 Shelf Updated", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Ws4_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                var bytes = e.RawData;
                using (var ms = new MemoryStream(bytes))
                {
                    var image = Image.FromStream(ms);
                    pictureBox4.Image = image;  // Display the image in PictureBox2
                }
            }
            catch (ArgumentException ex)
            {
                // Handle the exception, for example, by displaying an error message
                MessageBox.Show("Area 4 Shelf Updated", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SendVideoPathToServer1(string videoPath)
        {
            // Send the selected video path to the server via WebSocket
            ws1.Send(videoPath);
        }
        private void SendVideoPathToServer2(string videoPath)
        {
            // Send the selected video path to the server via WebSocket
            ws2.Send(videoPath);
        }
       private void SendVideoPathToServer3(string videoPath)
        {
            // Send the selected video path to the server via WebSocket
            ws3.Send(videoPath);
        }
        private void SendVideoPathToServer4(string videoPath)
        {
            // Send the selected video path to the server via WebSocket
            ws4.Send(videoPath);
        }

        private void Area1DoubleClick(object sender, EventArgs e)
        {
            // Double-clicking on the picture box to select a video file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    InitializeWebSocket();
                    string videoPath = ofd.FileName;
                    SendVideoPathToServer1(videoPath);
                }
            }
        }

        private void Area2DoubleClick(object sender, MouseEventArgs e)
        {
            // Double-clicking on the picture box to select a video file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    InitializeWebSocket();
                    string videoPath = ofd.FileName;
                    SendVideoPathToServer2(videoPath);
                }
            }
        }

        private void Area3DoubleClick(object sender, MouseEventArgs e)
        {
            // Double-clicking on the picture box to select a video file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    InitializeWebSocket();
                    string videoPath = ofd.FileName;
                    SendVideoPathToServer3(videoPath);
                }
            }
        }

        private void Area4DoubleClick(object sender, MouseEventArgs e)
        {
            // Double-clicking on the picture box to select a video file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    InitializeWebSocket();
                    string videoPath = ofd.FileName;
                    SendVideoPathToServer4(videoPath);
                }
            }
        }
    }
}
