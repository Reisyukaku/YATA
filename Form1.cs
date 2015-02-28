using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YATA {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }
        //Constants
        private const int RGB565 = 0;
        private const int RGB888 = 1;
        private const int BGR888 = 2;
        private readonly string[] imgEnum = { 
                                         "Top",
                                         "Bottom",
                                         "Folder Closed",
                                         "Folder Open",
                                         "Border-48px",
                                         "Border-24px"
                                         };

        //Flags
        public static uint useBGM = 0; //0x5
        public static uint topDraw = 0;  //0xC
        public static uint topFrame = 0;  //0x10
        public static uint bottomDraw = 0;  //0x20
        public static uint bottomFrame = 0;   //0x24
        public static uint[] enableSec;

        //Other
        private bool imgListBoxLoaded = false;
        private string path = null;
        private string filename = null;
        private uint[] imgOffs;
        private uint[] imgLens;
        private uint[] colorOffs;
        public static byte[][] colChunks;
        private uint topColorOff = 0;
        private uint addTopColorOff = 0;
        public static Bitmap[] imageArray;
        private static List<uint> RGBOffs = new List<uint>();
        private uint unk = 0;
        private uint cwavOff = 0;
        private uint cwavLen = 0;
        private byte[] cwav;
        public static byte magicByte;
        public static byte[] outFile;

        private void newFile_Click(object sender, EventArgs e) {
            MessageBox.Show("Not implemented yet.");
        }

        private void openFile_Click(object sender, EventArgs e) {
            if (openFileLZ.ShowDialog() == DialogResult.OK) {
                //clear stuff
                imgOffs = null;
                imgLens = null;
                colorOffs = null;
                imageArray = null;
                RGBOffs.Clear();
                colChunks = null;
                imgListBoxLoaded = false;
                path = openFileLZ.FileName.Substring(0, openFileLZ.FileName.LastIndexOf("\\") + 1);
                filename = openFileLZ.FileName.Substring(path.Length, openFileLZ.FileName.Length - path.Length);
                dsdecmp.Decompress(openFileLZ.FileName, path + "dec_" + filename);

                try {
                    BinaryReader br = new BinaryReader(File.Open(path + "dec_" + filename, FileMode.Open));
                    if ((br.ReadBytes(4)).ToU32() != 0x1) { MessageBox.Show("Not a proper theme."); return; }
                    List<uint> offs = new List<uint>();
                    br.BaseStream.Position = 0x18;  //top
                    offs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x28;  //bot
                    offs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x30;  //unk
                    unk = (br.ReadBytes(4)).ToU32();
                    br.BaseStream.Position = 0x40;  //f1
                    offs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x44;  //f2
                    offs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x54;  //b1
                    offs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0x58;  //b2
                    offs.Add((br.ReadBytes(4)).ToU32());
                    br.BaseStream.Position = 0xC0;  //cwav
                    cwavOff = (br.ReadBytes(4)).ToU32();
                    br.Close();
                    imgOffs = offs.ToArray();
                }
                catch (IOException) {
                }
                loadFlags();
                loadList();
                loadColors();
                SimToolStrip.Enabled = true;
                toolStripSettings.Enabled = true;
                saveFile.Enabled = true;
                saveAsFile.Enabled = true;
                saveImage.Enabled = true;
                importImage.Enabled = true;
                saveCWAVButton.Enabled = true;
                importCWAVButton.Enabled = true;
            }
        }

        private void loadList() {
            List<string> strList = new List<string>();
            int e = 0;
            foreach (uint i in imgOffs) {
                if (i > 0) strList.Add(imgEnum[e] + " (" + i.ToString("X08") + ")");
                e++;
            }
            imgListBox.DataSource = strList.ToArray();
            List<uint> lens = new List<uint>();
            List<Bitmap> images = new List<Bitmap>();
            if (topDraw >= 2) lens.Add((uint)(topFrame == 1 ? 0x40000 : 0x80000)); else lens.Add(0);
            if (bottomDraw == 3) lens.Add((uint)(bottomFrame == 1 ? 0x40000 : 0x80000)); else lens.Add(0);
            if (enableSec[2] > 0) lens.Add(0x10000); else lens.Add(0);
            if (enableSec[2] > 0) lens.Add(0x10000); else lens.Add(0);
            if (enableSec[4] > 0) lens.Add(0x10000); else lens.Add(0);
            if (enableSec[4] > 0) lens.Add(0x4000); else lens.Add(0);
            imgLens = lens.ToArray();
            for (int i = 0; i < imgOffs.Length; i++) {
                if (imgLens[i] > 0) images.Add(getImage(imgOffs[i], imgLens[i], i > 1 ? RGB888 : RGB565));
            }
            if (cwavOff > 0) cwav = getCWAV();
            imageArray = images.ToArray();
            imgListBoxLoaded = true;
            updatePicBox(0);
        }

        private void loadFlags() {
            BinaryReader dec_br = new BinaryReader(File.Open(path + "dec_" + filename, FileMode.Open));
            List<uint> enables = new List<uint>();
            dec_br.BaseStream.Position = 0x5;
            useBGM = dec_br.ReadByte();
            dec_br.BaseStream.Position = 0xC;
            topDraw = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x10;
            topFrame = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x20;
            bottomDraw = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x24;
            bottomFrame = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x2C;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //0 - Cursor
            dec_br.BaseStream.Position = 0x30;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x34;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //1 - 3D Folder
            dec_br.BaseStream.Position = 0x38;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x3C;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //2 - Folder tex'
            dec_br.BaseStream.Position = 0x48;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //3 - file graphic
            dec_br.BaseStream.Position = 0x4C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x50;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //4 - Border tex'
            dec_br.BaseStream.Position = 0x5C;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //5 - Arrow But
            dec_br.BaseStream.Position = 0x60;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x64;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //6 - Arrow
            dec_br.BaseStream.Position = 0x68;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x6C;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //7 - Bottom/Close But
            dec_br.BaseStream.Position = 0x70;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x74;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x78;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //8 - Game text
            dec_br.BaseStream.Position = 0x7C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x80;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //9 - Bottom Solid
            dec_br.BaseStream.Position = 0x84;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x88;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //10 - Bottom Outer
            dec_br.BaseStream.Position = 0x8C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x90;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //11 - Folder BG
            dec_br.BaseStream.Position = 0x94;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x98;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //12 - Folder Arrow
            dec_br.BaseStream.Position = 0x9C;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xA0;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //13 - Icon-resize
            dec_br.BaseStream.Position = 0xA4;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xA8;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //14 - Top Overlay
            dec_br.BaseStream.Position = 0xAC;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xB0;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //15 - Demo Msg
            dec_br.BaseStream.Position = 0xB4;
            RGBOffs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xB8;
            enables.Add(dec_br.ReadBytes(4).ToU32());   //16 - SFX
            dec_br.BaseStream.Position = 0xBC;
            cwavLen = dec_br.ReadBytes(4).ToU32();
            dec_br.Close();
            enableSec = enables.ToArray();
        }

        private void loadColors() {
            BinaryReader dec_br = new BinaryReader(File.Open(path + "dec_" + filename, FileMode.Open));
            List<uint> offs = new List<uint>();
            dec_br.BaseStream.Position = 0x14;
            topColorOff = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x1C;
            addTopColorOff = dec_br.ReadBytes(4).ToU32();
            dec_br.BaseStream.Position = 0x30;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x38;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x4C;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x60;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x68;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x70;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x74;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x7C;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x84;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x8C;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x94;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0x9C;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xA4;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xAC;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            dec_br.BaseStream.Position = 0xB4;
            offs.Add(dec_br.ReadBytes(4).ToU32());
            colorOffs = offs.ToArray();
            List<byte[]> cols = new List<byte[]>();
            int cnt = 0;
            foreach (uint i in colorOffs) {
                dec_br.BaseStream.Position = i;
                switch (cnt) {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 13:
                    case 14:
                        cols.Add(dec_br.ReadBytes(0x10));
                        break;
                    case 5:
                    case 6:
                    case 11:
                    case 12:
                        cols.Add(dec_br.ReadBytes(0x20));
                        break;
                }
                cnt++;
            }
            dec_br.Close();
            colChunks = cols.ToArray();
        }

        private void updatePicBox(int i) {
            pictureBox1.Image = imageArray[i];
        }

        private void imgListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (imgListBoxLoaded == true) {
                updatePicBox(imgListBox.SelectedIndex);
            }
        }

        private byte[] getCWAV() {
            BinaryReader dec_br = new BinaryReader(File.Open(path + "dec_" + filename, FileMode.Open));
            long cLen = dec_br.BaseStream.Length - cwavOff;
            byte[] wav;
            dec_br.BaseStream.Position = cwavOff;
            wav = dec_br.ReadBytes((int)cLen);
            dec_br.Close();
            return wav;
        }

        private Bitmap getImage(uint offset, uint length, int type) {
            int red = 0, green = 0, blue = 0;
            int imgWidth = 0, imgHeight = 0;
            if (offset != imgOffs[4]) {
                switch (length) {
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
            BinaryReader dec_br = new BinaryReader(File.Open(path + "dec_" + filename, FileMode.Open));
            dec_br.BaseStream.Position = offset;
            try {
                uint x = 0, y = 0;
                int p = gcm(img.Width, 8) / 8;
                if (p == 0) p = 1;

                if (type == RGB565) {
                    uint i = 0;
                    int[] u16s = new int[length / 2];
                    for (int j = 0; j <= (length / 2) - 1; j++) { u16s[j] = dec_br.ReadInt16(); }
                    foreach (int pix in u16s) {
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
                    for (uint i = 0; i < length / 8; i++) {
                        d2xy(i % 64, out x, out y);
                        uint tile = i / 64;
                        // Shift Tile Coordinate into Tilemap
                        x += (uint)(tile % p) * 8;
                        y += (uint)(tile / p) * 8;
                        byte[] data = dec_br.ReadBytes(3);
                        img.SetPixel((int)x, (int)y, Color.FromArgb(0xFF, data[0], data[1], data[2]));
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine(e.StackTrace);
            }
            dec_br.Close();
            return img;
        }

        private byte[] bitmapToRawImg(Bitmap img, int format) {
            List<byte> array = new List<byte>();
            int w = img.Width;
            int h = img.Height;
            w = h = Math.Max(nlpo2(w), nlpo2(h));
            uint x = 0, y = 0;
            uint val = 0;
            Color c;
            int p = gcm(w, 8) / 8;
            if (p == 0) p = 1;
            for (uint i = 0; i < w * h; i++) {
                d2xy(i % 64, out x, out y);
                uint tile = i / 64;
                x += (uint)(tile % p) * 8;
                y += (uint)(tile / p) * 8;
                if (!(x >= img.Width || y >= img.Height)) {
                    c = img.GetPixel((int)x, (int)y);
                    if (c.A == 0) c = Color.FromArgb(0, 86, 86, 86);
                    if (format == RGB565) {
                        val = (uint)((c.R / 8) & 0x1f) << 11;
                        val += (uint)(((c.G / 4) & 0x3f) << 5);
                        val += (uint)((c.B / 8) & 0x1f);
                        array.Add((byte)(val & 0xFF));
                        array.Add((byte)((val >> 8) & 0xFF));
                    }
                    else if (format == RGB888) {
                        array.Add((byte)c.R);
                        array.Add((byte)c.G);
                        array.Add((byte)c.B);
                    }
                    else if (format == BGR888)
                    {
                        array.Add((byte)c.B);
                        array.Add((byte)c.G);
                        array.Add((byte)c.R);
                    }
                }

            }

            return array.ToArray();
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

        private void makeTheme(string file, bool for3DS) {
            using (BinaryWriter bw = new BinaryWriter(File.Create(file))) {
                //header
                bw.Write(1);
                bw.Write((byte)0);
                bw.Write((byte)useBGM);
                bw.Write((byte)0);
                bw.Write((byte)0);
                bw.Write(0);
                bw.Write(topDraw);
                bw.Write(topFrame);
                bw.Write(topColorOff);
                bw.Write(imgOffs[0]);
                bw.Write(addTopColorOff);
                bw.Write(bottomDraw);
                bw.Write(bottomFrame);
                bw.Write(imgOffs[1]);
                bw.Write(enableSec[0]);
                bw.Write(colorOffs[0]);
                bw.Write(enableSec[1]);
                bw.Write(colorOffs[1]);
                bw.Write(enableSec[2]);
                bw.Write(imgOffs[2]);
                bw.Write(imgOffs[3]);
                bw.Write(enableSec[3]);
                bw.Write(colorOffs[2]);
                bw.Write(enableSec[4]);
                bw.Write(imgOffs[4]);
                bw.Write(imgOffs[5]);
                bw.Write(enableSec[5]);
                bw.Write(colorOffs[3]);
                bw.Write(enableSec[6]);
                bw.Write(colorOffs[4]);
                bw.Write(enableSec[7]);
                bw.Write(colorOffs[5]);
                bw.Write(colorOffs[6]);
                bw.Write(enableSec[8]);
                bw.Write(colorOffs[7]);
                bw.Write(enableSec[9]);
                bw.Write(colorOffs[8]);
                bw.Write(enableSec[10]);
                bw.Write(colorOffs[9]);
                bw.Write(enableSec[11]);
                bw.Write(colorOffs[10]);
                bw.Write(enableSec[12]);
                bw.Write(colorOffs[11]);
                bw.Write(enableSec[13]);
                bw.Write(colorOffs[12]);
                bw.Write(enableSec[14]);
                bw.Write(colorOffs[13]);
                bw.Write(enableSec[15]);
                bw.Write(colorOffs[14]);
                bw.Write(enableSec[16]);
                bw.Write(cwavLen);
                bw.Write(cwavOff);
                bw.Write(0);
                bw.Write(0);
                bw.Write(0);
                //top image
                if(topDraw == 2 || topDraw == 3) bw.Write(bitmapToRawImg(imageArray[0], RGB565));
                if(bottomDraw == 3) bw.Write(bitmapToRawImg(imageArray[1], RGB565));
                if(enableSec[0] == 1) bw.Write(colChunks[0]);
                if (enableSec[1] == 1) bw.Write(colChunks[1]);
                if (enableSec[2] == 1)
                {
                    if (for3DS)
                    {
                        bw.Write(bitmapToRawImg(imageArray[2], BGR888));
                    }
                    else
                    {
                        bw.Write(bitmapToRawImg(imageArray[2], RGB888));
                    }
                }
                if (enableSec[2] == 1)
                {
                    if (for3DS)
                    {
                        bw.Write(bitmapToRawImg(imageArray[3], BGR888));
                    }
                    else
                    {
                        bw.Write(bitmapToRawImg(imageArray[3], RGB888));
                    }
                }
                if (enableSec[3] == 1) bw.Write(colChunks[2]);
                if (enableSec[4] == 1)
                {
                    if (for3DS)
                    {
                        bw.Write(bitmapToRawImg(imageArray[4], BGR888));
                    }
                    else
                    {
                        bw.Write(bitmapToRawImg(imageArray[4], RGB888));
                    }
                }
                if (enableSec[4] == 1)
                {
                    if (for3DS)
                    {
                        bw.Write(bitmapToRawImg(imageArray[5], BGR888));
                    }
                    else
                    {
                        bw.Write(bitmapToRawImg(imageArray[5], RGB888));
                    }
                }
                if (enableSec[5] == 1) bw.Write(colChunks[3]);
                if (enableSec[6] == 1) bw.Write(colChunks[4]);
                if (enableSec[7] == 1) bw.Write(colChunks[5]);
                if (enableSec[7] == 1) bw.Write(colChunks[6]);
                if (enableSec[8] == 1) bw.Write(colChunks[7]);
                if (enableSec[9] == 1) bw.Write(colChunks[8]);
                if (enableSec[10] == 1) bw.Write(colChunks[9]);
                if (enableSec[11] == 1) bw.Write(colChunks[10]);
                if (enableSec[12] == 1) bw.Write(colChunks[11]);
                if (enableSec[13] == 1) bw.Write(colChunks[12]);
                if (enableSec[14] == 1) bw.Write(colChunks[13]);
                if (enableSec[15] == 1) bw.Write(colChunks[14]);
                if (enableSec[16] == 1) bw.Write(cwav);
                bw.Close();
            }
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
            if (openNewImg.ShowDialog() == DialogResult.OK) {
                byte[] png = File.ReadAllBytes(openNewImg.FileName);
                using (Stream BitmapStream = new MemoryStream(png)) {
                    Image img = Image.FromStream(BitmapStream);
                    Bitmap mBitmap = new Bitmap(img);
                    if (mBitmap.Size.Height.isPower2() && mBitmap.Size.Width.isPower2()) {
                        imageArray[imgListBox.SelectedIndex] = mBitmap;
                        updatePicBox(imgListBox.SelectedIndex);
                    }
                    else {
                        MessageBox.Show("Error: Image is not a power of 2.");
                        return;
                    }
                    BitmapStream.Close();
                }
            }
        }

        private void saveFile_Click(object sender, EventArgs e) {
            makeTheme(path + "new_dec_" + filename, false);
            dsdecmp.Compress(path + "new_dec_" + filename, path + filename);
            File.Delete(path + "new_dec_" + filename);
            MessageBox.Show("Theme saved!");
        }
        
        private void saveAsFile_Click(object sender, EventArgs e) {
            if (saveTheme.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string newpath = saveTheme.FileName.Substring(0, saveTheme.FileName.LastIndexOf("\\") + 1);
                makeTheme(newpath + "new_dec_" + filename, false);
                dsdecmp.Compress(path + "new_dec_" + filename, saveTheme.FileName);
                File.Delete(path + "new_dec_" + filename);
                MessageBox.Show("Theme saved for later editing!");
            }
        }
        private void saveFor3DS_Click(object sender, EventArgs e)
        {
            if (saveTheme.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string newpath = saveTheme.FileName.Substring(0, saveTheme.FileName.LastIndexOf("\\") + 1);
                makeTheme(newpath + "new_dec_" + filename, true);
                dsdecmp.Compress(path + "new_dec_" + filename, saveTheme.FileName);
                File.Delete(path + "new_dec_" + filename);
                MessageBox.Show("Theme saved for use with the 3DS!");
            }
        }

        private void saveImage_Click(object sender, EventArgs e) {
            if (savePng.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                imageArray[imgListBox.SelectedIndex].Save(savePng.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void saveCWAVButton_Click(object sender, EventArgs e) {
            if (saveCWAVDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                BinaryWriter br = new BinaryWriter(File.Create(saveCWAVDialog.FileName));
                br.Write(getCWAV());
                br.Close();
            }
        }

        private void importCWAVButton_Click(object sender, EventArgs e) {
            if (openCWAVDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                cwav = File.ReadAllBytes(openCWAVDialog.FileName);
            }
        }

        

    }
    public static class exten {
        public static uint ToU32(this byte[] b) {
            return (uint)BitConverter.ToInt32(b, 0);
        }
        public static bool isPower2(this int x) {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
    }
}
