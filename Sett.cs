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
        private uint[] flags;
        public Sett() {
            InitializeComponent();
            Button[] col1 = AddButtons(4, 0);
            Button[] col2 = AddButtons(6, 1);
            Button[] col3 = AddButtons(3, 2);
            Button[] col4 = AddButtons(3, 3);
            Button[] col5 = AddButtons(3, 4);
            Button[] col6 = AddButtons(6, 5);
            Button[] col7 = AddButtons(6, 6);
            Button[] col8 = AddButtons(1, 7);
            Button[] col9 = AddButtons(3, 8);
            Button[] col10 = AddButtons(3, 9);
            Button[] col11 = AddButtons(3, 10);
            Button[] col12 = AddButtons(7, 11);
            Button[] col13 = AddButtons(4, 12);
            Button[] col14 = AddButtons(2, 13);
            foreach (Button b in col1) this.groupBox2.Controls.Add(b);
            foreach (Button b in col2) this.groupBox2.Controls.Add(b);
            foreach (Button b in col3) this.groupBox2.Controls.Add(b);
            foreach (Button b in col4) this.groupBox2.Controls.Add(b);
            foreach (Button b in col5) this.groupBox2.Controls.Add(b);
            foreach (Button b in col6) this.groupBox2.Controls.Add(b);
            foreach (Button b in col7) this.groupBox2.Controls.Add(b);
            foreach (Button b in col8) this.groupBox2.Controls.Add(b);
            foreach (Button b in col9) this.groupBox2.Controls.Add(b);
            foreach (Button b in col10) this.groupBox2.Controls.Add(b);
            foreach (Button b in col11) this.groupBox2.Controls.Add(b);
            foreach (Button b in col12) this.groupBox2.Controls.Add(b);
            foreach (Button b in col13) this.groupBox2.Controls.Add(b);
            foreach (Button b in col14) this.groupBox2.Controls.Add(b);
            flags = Form1.enableSec.ToArray();
            CB_topDraw.SelectedIndex = (int)Form1.topDraw;
            CB_botDraw.SelectedIndex = (int)Form1.bottomDraw;
            CB_topFrame.SelectedIndex = (int)Form1.topFrame;
            CB_botFrame.SelectedIndex = (int)Form1.bottomFrame;
            CHK0.Checked = flags[0] == 1 ? true : false;
            CHK1.Checked = flags[1] == 1 ? true : false;
            CHK2.Checked = flags[2] == 1 ? true : false;
            CHK3.Checked = flags[3] == 1 ? true : false;
            CHK4.Checked = flags[4] == 1 ? true : false;
            CHK5.Checked = flags[5] == 1 ? true : false;
            CHK6.Checked = flags[6] == 1 ? true : false;
            CHK7.Checked = flags[7] == 1 ? true : false;
            CHK8.Checked = flags[8] == 1 ? true : false;
            CHK9.Checked = flags[9] == 1 ? true : false;
            CHK10.Checked = flags[10] == 1 ? true : false;
            CHK11.Checked = flags[11] == 1 ? true : false;
            CHK12.Checked = flags[12] == 1 ? true : false;
            CHK13.Checked = flags[13] == 1 ? true : false;
            CHK14.Checked = flags[14] == 1 ? true : false;
            CHK15.Checked = flags[15] == 1 ? true : false;
            CHK16.Checked = flags[16] == 1 ? true : false;
        }

        private void buttonSaveSett_Click(object sender, EventArgs e) {
            flags[0] = (uint)(CHK0.Checked ? 1 : 0);
            flags[1] = (uint)(CHK1.Checked ? 1 : 0);
            flags[2] = (uint)(CHK2.Checked ? 1 : 0);
            flags[3] = (uint)(CHK3.Checked ? 1 : 0);
            flags[4] = (uint)(CHK4.Checked ? 1 : 0);
            flags[5] = (uint)(CHK5.Checked ? 1 : 0);
            flags[6] = (uint)(CHK6.Checked ? 1 : 0);
            flags[7] = (uint)(CHK7.Checked ? 1 : 0);
            flags[8] = (uint)(CHK8.Checked ? 1 : 0);
            flags[9] = (uint)(CHK9.Checked ? 1 : 0);
            flags[10] = (uint)(CHK10.Checked ? 1 : 0);
            flags[11] = (uint)(CHK11.Checked ? 1 : 0);
            flags[12] = (uint)(CHK12.Checked ? 1 : 0);
            flags[13] = (uint)(CHK13.Checked ? 1 : 0);
            flags[14] = (uint)(CHK14.Checked ? 1 : 0);
            flags[15] = (uint)(CHK15.Checked ? 1 : 0);
            flags[16] = (uint)(CHK16.Checked ? 1 : 0);
            Form1.topDraw = (uint)CB_topDraw.SelectedIndex;
            Form1.bottomDraw = (uint)CB_botDraw.SelectedIndex;
            Form1.topFrame = (uint)CB_topFrame.SelectedIndex;
            Form1.bottomFrame = (uint)CB_botFrame.SelectedIndex;
            Form1.enableSec = flags;
            closeForm();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            closeForm();
        }

        private void closeForm() {
            this.Close();
        }

        private void colorSelect(object sender, EventArgs e) {
            if(colDialog.ShowDialog() == DialogResult.OK){
                ((Button)sender).BackColor = colDialog.Color;
            }
        }

        private Button[] AddButtons(int amount, int yPos) {
            Button[] btnArray = new Button[amount + 1];
            for (int i = 0; i < amount; i++) { 
                btnArray[i] = new Button();
                btnArray[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnArray[i].Size = new System.Drawing.Size(20, 20);
                btnArray[i].Location = new System.Drawing.Point(90 + (i*22), 20 + (25*yPos));
                btnArray[i].Name = "colSet"+yPos+"But"+i;
                btnArray[i].Click += new System.EventHandler(colorSelect);
            }
            return btnArray;
        }

    }
}
