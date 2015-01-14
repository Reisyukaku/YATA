using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YATE {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }
        //Constants
        private const int RGB565 = 0;
        private const int RGB888 = 1;
        private readonly string[] imgEnum = { 
                                         "Top",
                                         "Bottom",
                                         "Folder Closed",
                                         "Folder Open",
                                         "Border-48px",
                                         "Border-24px"
                                         };

        //Flags
        public static bool useBGM = true; //0x5
        public static uint topDraw = 0;  //0xC
        public static uint topFrame = 0;  //0x10
        public static uint bottomDraw = 0;  //0x20
        public static uint bottomFrame = 0;   //0x24
        public static uint[] enableSec;

        //Other
        private bool imgListBoxLoaded = false;
        private string path = null;
        private List<uint> imgOffs = new List<uint>();
        private List<uint> imgLens = new List<uint>();
        public static List<Bitmap> images = new List<Bitmap>();
        private static Bitmap[] imageArray;
        private static List<uint> RGBOffs = new List<uint>();
        private uint unk = 0;
        private uint cwavOff = 0;
        private uint cwavLen = 0;
        private List<byte[]> cwav = new List<byte[]>();
        public static byte magicByte;
        public static byte[] outFile;

        private void newFile_Click(object sender, EventArgs e) {
            MessageBox.Show("Not implemented yet.");
        }

        private void openFile_Click(object sender, EventArgs e) {
            if (openFileLZ.ShowDialog() == DialogResult.OK) {
                //clear stuff
                imgOffs.Clear();
                imgLens.Clear();
                images.Clear();
                path = openFileLZ.FileName.Substring(0, openFileLZ.FileName.LastIndexOf("\\") + 1);
                dsdecmp.Decompress(openFileLZ.FileName, path + "dec_LZ.bin");

                try {

                    BinaryReader br = new BinaryReader(File.Open(path + "dec_LZ.bin", FileMode.Open));
                    if ((br.ReadBytes(4)).ToU32() != 0x1) { MessageBox.Show("Not a proper theme."); return; }
                    br.BaseStream.Position = 0x5;
                    useBGM = br.ReadByte() == 0x0 ? false : true;
                    br.BaseStream.Position = 0x18;  //top
                    imgOffs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x28;  //bot
                    imgOffs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x30;  //unk
                    unk = (br.ReadBytes(4)).ToU32();
                    br.BaseStream.Position = 0x40;  //f1
                    imgOffs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x44;  //f2
                    imgOffs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x54;  //b1
                    imgOffs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x58;  //b2
                    imgOffs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0xC0;  //cwav
                    cwavOff = (br.ReadBytes(4)).ToU32();
                    br.Close();
                }
                catch (IOException) {
                }
                loadList();
                loadFlags();
                SimToolStrip.Enabled = true;
                toolStripSettings.Enabled = true;
                saveFile.Enabled = true;
                saveAsFile.Enabled = true;

            }
        }

        private void loadList(){
            List<string> strList = new List<string>();
            int e = 0;
            foreach (uint i in imgOffs){
                if(i > 0) strList.Add(imgEnum[e] + " (" + i.ToString("X08") + ")");
                e++;
            }
            imgListBox.DataSource = strList.ToArray();
            if(imgOffs[0] > 0) imgLens.Add(imgOffs[1] - imgOffs[0]);
            if (imgOffs[1] > 0) imgLens.Add(unk - imgOffs[1]);
            if (imgOffs[2] > 0) imgLens.Add(0x10000);
            if (imgOffs[3] > 0) imgLens.Add(0x10000);
            if (imgOffs[4] > 0) imgLens.Add(0x10000);
            if (imgOffs[5] > 0) imgLens.Add(0x4000);
            imgListBoxLoaded = true;
            uint[] imgO = imgOffs.ToArray();
            uint[] imgL = imgLens.ToArray();
            if (imgOffs[0] > 0) images.Add(getImage(imgO[0], imgL[0], RGB565));
            if (imgOffs[1] > 0) images.Add(getImage(imgO[1], imgL[1], RGB565));
            if (imgOffs[2] > 0) images.Add(getImage(imgO[2], imgL[2], RGB888));
            if (imgOffs[3] > 0) images.Add(getImage(imgO[3], imgL[3], RGB888));
            if (imgOffs[4] > 0) images.Add(getImage(imgO[4], imgL[4], RGB888));
            if (imgOffs[5] > 0) images.Add(getImage(imgO[5], imgL[5], RGB888));
            if (cwavOff > 0) //
            imageArray = images.ToArray();
            updatePicBox();
        }

        private void loadFlags() {
            BinaryReader dec_br = new BinaryReader(File.Open(path + "dec_LZ.bin", FileMode.Open));
            List<uint> enables = new List<uint>();
            dec_br.BaseStream.Position = 0x5;
            useBGM = dec_br.ReadByte() == 0x0 ? false : true;
            dec_br.BaseStream.Position = 0xC;
            topDraw = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x10;
            topFrame = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x20;
            bottomDraw = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x24;
            bottomFrame = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x2C;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x30;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x34;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x38;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x3C;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x48;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x4C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x50;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x5C;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x60;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x64;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x68;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x6C;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x70;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x74;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x78;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x7C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x80;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x84;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x88;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x8C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x90;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x94;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x98;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x9C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xA0;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xA4;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xA8;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xAC;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xB0;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xB4;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xB8;
            enables.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xBC;
            cwavLen = dec_br.ReadBytes(4).ToU32();
            enableSec = enables.ToArray();
        }

        private void updatePicBox() {
            pictureBox1.Image = imageArray[imgListBox.SelectedIndex];
        }

        private void imgListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (imgListBoxLoaded == true){
                updatePicBox();
            }
        }

        private Bitmap getImage(uint offset, uint length, int type) {
            int red = 0, green = 0, blue = 0;
            int imgWidth = 0, imgHeight = 0;
            if(offset != imgOffs[4]){
                switch(length){
                    case 0x40000:
                        imgWidth = 512;
                        imgHeight = 256;
                        break;
                    case 0x80000:
                        imgWidth = 1024;
                        imgHeight = 256;
                        break;
                    case 0x10000:
                        imgWidth = 128;
                        imgHeight = 64;
                        break;
                    case 0x4000:
                        imgWidth = 32;
                        imgHeight = 64;
                        break;
                }
            }
            else {
                imgWidth = 64;
                imgHeight = 128;
            }
            Bitmap img = new Bitmap(imgWidth, imgHeight);
            BinaryReader dec_br = new BinaryReader(File.Open(path + "dec_LZ.bin", FileMode.Open));
            dec_br.BaseStream.Position = offset;
            try {
                uint i = 0, x = 0, y = 0;
                int p = gcm(img.Width, 8) / 8;
                if (p == 0) p = 1;

                if(type == RGB565){
                    int[] u16s = new int[length/2];
                    for (int j = 0; j <= (length/2) - 1; j++) { u16s[j] = dec_br.ReadInt16(); }

                    foreach(int pix in u16s) {
                            d2xy(i % 64, out x, out y);
                            uint tile = i / 64;
                            // Shift Tile Coordinate into Tilemap
                            x += (uint)(tile % p) * 8;
                            y += (uint)(tile / p) * 8;
                            red = (byte)((pix >> 11) & 0x1f) * 8;
                            green = (byte)(((pix >> 5) & 0x3f) * 4);
                            blue = (byte)((pix) & 0x1f) * 8;
                            img.SetPixel((int)x, (int)y, Color.FromArgb(0xFF, red, green, blue));
                            i++;
                    }
                }
                else if (type == RGB888) {
                    byte[] u8s = dec_br.ReadBytes((int)length);
                    foreach (byte u in u8s ) {
                        d2xy(i % 64, out x, out y);
                        uint tile = i / 64;
                        // Shift Tile Coordinate into Tilemap
                        x += (uint)(tile % p) * 8;
                        y += (uint)(tile / p) * 8;
                        //img.SetPixel((int)x, (int)y, Color.FromArgb(0xFF, (int)u, (int)u, (int)u));
                        i++;
                    }
                }
             }catch(IOException e){
                Console.WriteLine(e.StackTrace);
             }
            dec_br.Close();
            return img;
        }

        /// <summary>
        /// Greatest common multiple (to round up)
        /// </summary>
        /// <param name="n">Number to round-up.</param>
        /// <param name="m">Multiple to round-up to.</param>
        /// <returns>Rounded up number.</returns>
        private static int gcm(int n, int m) {
            return ((n + m - 1) / m) * m;
        }
        /// <summary>
        /// Next Largest Power of 2
        /// </summary>
        /// <param name="x">Input to round up to next 2^n</param>
        /// <returns>2^n > x && x > 2^(n-1) </returns>
        private static int nlpo2(int x) {
            x--; // comment out to always take the next biggest power of two, even if x is already a power of two
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return (x + 1);
        }
        // Morton Translation
        /// <summary>
        /// Combines X/Y Coordinates to a decimal ordinate.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private uint xy2d(uint x, uint y) {
            x &= 0x0000ffff;
            y &= 0x0000ffff;
            x |= (x << 8);
            y |= (y << 8);
            x &= 0x00ff00ff;
            y &= 0x00ff00ff;
            x |= (x << 4);
            y |= (y << 4);
            x &= 0x0f0f0f0f;
            y &= 0x0f0f0f0f;
            x |= (x << 2);
            y |= (y << 2);
            x &= 0x33333333;
            y &= 0x33333333;
            x |= (x << 1);
            y |= (y << 1);
            x &= 0x55555555;
            y &= 0x55555555;
            return x | (y << 1);
        }
        /// <summary>
        /// Decimal Ordinate In to X / Y Coordinate Out
        /// </summary>
        /// <param name="d">Loop integer which will be decoded to X/Y</param>
        /// <param name="x">Output X coordinate</param>
        /// <param name="y">Output Y coordinate</param>
        private void d2xy(uint d, out uint x, out uint y) {
            x = d;
            y = (x >> 1);
            x &= 0x55555555;
            y &= 0x55555555;
            x |= (x >> 1);
            y |= (y >> 1);
            x &= 0x33333333;
            y &= 0x33333333;
            x |= (x >> 2);
            y |= (y >> 2);
            x &= 0x0f0f0f0f;
            y &= 0x0f0f0f0f;
            x |= (x >> 4);
            y |= (y >> 4);
            x &= 0x00ff00ff;
            y &= 0x00ff00ff;
            x |= (x >> 8);
            y |= (y >> 8);
            x &= 0x0000ffff;
            y &= 0x0000ffff;
        }

        private void makeTheme() {
            
        }

        private void SimToolStrip_Click(object sender, EventArgs e) {
            Sim sim = new Sim();
            sim.Show();
        }

        private void toolStripSettings_Click(object sender, EventArgs e) {
            Sett settings = new Sett();
            settings.Show();
        }

        private void prefToolStrip_Click(object sender, EventArgs e) {
            Prefs pref = new Prefs();
            pref.Show();
        }

        private void importToolstrip_Click(object sender, EventArgs e) {
            MessageBox.Show(imgListBox.SelectedIndex.ToString());
        }

        private void saveFile_Click(object sender, EventArgs e) {
            makeTheme();
        }

        private void saveAsFile_Click(object sender, EventArgs e) {

        }
    }
    public static class exten {
        public static uint ToU32(this byte[] b) {
            return (uint)BitConverter.ToInt32(b, 0);
        }
    }
}
