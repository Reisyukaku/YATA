using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

    }
}
