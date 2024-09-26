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
using AForge.Video.DirectShow;
using WebSocketSharp;

namespace SmartStock.View
{
    public partial class CCTVForm : Form
    {
        static WebSocket ws1 = null;
        static WebSocket ws2 = null;
        static WebSocket ws3 = null;
        static WebSocket ws4 = null;

        public CCTVForm()
        {
            InitializeComponent();

            if(ws1 == null && ws4 == null)
            {
                // Initialize WebSocket connections
                ws1 = new WebSocket("ws://127.0.0.1:8770");
                ws1.OnMessage += Ws1_OnMessage;
                ws1.Connect();

                ws2 = new WebSocket("ws://127.0.0.1:8771");
                ws2.OnMessage += Ws2_OnMessage;
                ws2.Connect();

                ws3 = new WebSocket("ws://127.0.0.1:8761");
                ws3.OnMessage += Ws3_OnMessage;
                ws3.Connect();

                ws4 = new WebSocket("ws://127.0.0.1:8760");
                ws4.OnMessage += Ws4_OnMessage;
                ws4.Connect();
            }
            else
            {
                ws1.OnMessage += Ws1_OnMessage;
                ws1.Connect();
                ws2.OnMessage += Ws2_OnMessage;
                ws2.Connect();
                ws3.OnMessage += Ws3_OnMessage;
                ws3.Connect();
                ws4.OnMessage += Ws4_OnMessage;
                ws4.Connect();
            }

        }

        private void Ws1_OnMessage(object sender, MessageEventArgs e)
        {
            var bytes = e.RawData;
            using (var ms = new MemoryStream(bytes))
            {
                try
                {
                    var image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Out of memory. Please try again.");
                }
            }
        }

        private void Ws2_OnMessage(object sender, MessageEventArgs e)
        {

            var bytes = e.RawData;
            using (var ms = new MemoryStream(bytes))
            {
                try
                {
                    var image = Image.FromStream(ms);
                    pictureBox2.Image = image;
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Out of memory. Please try again.");
                }
            }
        }

        private void Ws3_OnMessage(object sender, MessageEventArgs e)
        {
            var bytes = e.RawData;
            using (var ms = new MemoryStream(bytes))
            {
                try
                {
                    var image = Image.FromStream(ms);
                    pictureBox3.Image = image;
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Out of memory. Please try again.");
                }
            }
        }

        private void Ws4_OnMessage(object sender, MessageEventArgs e)
        {
            var bytes = e.RawData;
            using (var ms = new MemoryStream(bytes))
            {
                try
                {
                    var image = Image.FromStream(ms);
                    pictureBox4.Image = image;
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Out of memory. Please try again.");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Create an instance of the VideoPopupForm
            cam1 videoPopupForm = new cam1();

            // Show the VideoPopupForm as a modal dialog
            videoPopupForm.ShowDialog();
        }

        // No need for pictureBox2_Click event handler if the second PictureBox is just for display
    }
}
