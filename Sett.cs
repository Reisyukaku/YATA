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
    public partial class Sett : Form {
        public Sett() {
            InitializeComponent();
            texTopDraw.Text = Form1.topDraw.ToString();
            texBotDraw.Text = Form1.bottomDraw.ToString();
        }
    }
}
