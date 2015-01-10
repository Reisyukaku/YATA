using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YATE {
    public partial class Sim : Form {

        Bitmap[] imgs;

        public Sim() {
            InitializeComponent();
            imgs = Form1.images.ToArray();
            loadImages();
        }

        private void loadImages() {
            topImage.Image = imgs[0];
            bottomImage.Image = imgs[1];
            Image bat = Properties.Resources.battery;
            Image inter = Properties.Resources.net;
            Image note = Properties.Resources.notes;
            Image friend = Properties.Resources.friends;
            Image news = Properties.Resources.news;
            Image web = Properties.Resources.web;
            Image mii = Properties.Resources.miiverse;

            using (Graphics gr = Graphics.FromImage(topImage.Image)) {
                gr.DrawImage(bat, new Point(370, -6));
                gr.DrawImage(inter, new Point(1, 0));
                gr.Flush();
                gr.Dispose();
            }
            using (Graphics gr = Graphics.FromImage(bottomImage.Image)) {
                gr.DrawImage(note, new Point(63, 3));
                gr.DrawImage(friend, new Point(104, 3));
                gr.DrawImage(news, new Point(146, 3));
                gr.DrawImage(web, new Point(188, 3));
                gr.DrawImage(mii, new Point(228, 3));
                gr.Flush();
                gr.Dispose();
            }
        }

    }
}
