using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using WebSocketSharp;

namespace SmartStock.View
{
    public partial class cam1 : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        WebSocket ws;

        public cam1()
        {
            InitializeComponent();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoCaptureDevice = new VideoCaptureDevice();

            // Initialize WebSocket connection
            ws = new WebSocket("ws://localhost:8765");
            ws.OnMessage += Ws_OnMessage;
            ws.Connect();
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            var bytes = e.RawData;
            using (var ms = new MemoryStream(bytes))
            {
                var image = Image.FromStream(ms);
                pictureBox1.Image = image;  // Display the image in a PictureBox
            }
        }
    }
}
