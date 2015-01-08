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

        private bool useBGM = true;
        private bool imgListBoxLoaded = false;
        private List<uint> imgOffs = new List<uint>();
        private List<uint> imgLens = new List<uint>();
        public static List<Bitmap> images = new List<Bitmap>();
        private uint unk = 0;
        private uint cwavOff;
        public static byte magicByte;
        private static int[] Convert5To8 = { 0x00,0x08,0x10,0x18,0x20,0x29,0x31,0x39,
                                            0x41,0x4A,0x52,0x5A,0x62,0x6A,0x73,0x7B,
                                            0x83,0x8B,0x94,0x9C,0xA4,0xAC,0xB4,0xBD,
                                            0xC5,0xCD,0xD5,0xDE,0xE6,0xEE,0xF6,0xFF };

        private void openFile_Click(object sender, EventArgs e) {
            if (openFileLZ.ShowDialog() == DialogResult.OK) {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "DSDecmp.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "-d " + openFileLZ.FileName + " dec_LZ.bin";
                if(!File.Exists("dec_LZ.bin")){
                    MessageBox.Show("Something went wrong with the decompression.");
                    return;
                }
                try {
                    using (Process exeProcess = Process.Start(startInfo)) {
                        exeProcess.WaitForExit();
                    }

                    BinaryReader br = new BinaryReader(File.Open("dec_LZ.bin", FileMode.Open));
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
                    br.BaseStream.Position = 0xBC;  //cwav
                    cwavOff = (br.ReadBytes(4)).ToU32();
                    br.Close();
                }
                catch (IOException) {
                }
                loadList();
                SimToolStrip.Enabled = true;
            }
        }

        private void loadList(){
            List<string> strList = new List<string>();
            foreach (uint i in imgOffs){
                strList.Add(i.ToString("X08"));
            }
            imgListBox.DataSource = strList.ToArray();
            imgLens.Add(imgOffs[1] - imgOffs[0]);
            imgLens.Add(unk - imgOffs[1]);
            imgLens.Add(0x10000);
            imgLens.Add(0x10000);
            imgLens.Add(0x10000);
            imgLens.Add(0x4000);
            imgListBoxLoaded = true;
        }

        private void imgListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (imgListBoxLoaded == true){
                int item = imgListBox.SelectedIndex;
                pictureBox1.Image = getImage(imgOffs[item], imgLens[item]);
            }
        }

        private Bitmap getImage(uint offset, uint length) {
            byte[] buff = new byte[length];
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
            BinaryReader dec_br = new BinaryReader(File.Open("dec_LZ.bin", FileMode.Open));
            ushort val;
            int i = 0;
            long len = dec_br.BaseStream.Length;
            while (i < len) {
               //MessageBox.Show("buffleng=" + buff.Length.ToString("X") + " | i=" + i.ToString());
                dec_br.BaseStream.Position = offset;
                val = dec_br.ReadUInt16();
                red = Convert5To8[(val >> 11) & 0x1F];
                green = (byte)(((val >> 5) & 0x3F) * 4);
                blue = Convert5To8[val & 0x1F];
                
                i++;
            }
            for (int x = 0; x < imgWidth; x++) {
                for (int y = 0; y < imgHeight; y++) {
                    img.SetPixel(x, y, Color.FromArgb(0xFF, red, green, blue));
                    Console.WriteLine(img.GetPixel(1, 4).ToString());
                }
            }
            dec_br.Close();
            images.Add(img);
            return img;
        }

        private void SimToolStrip_Click(object sender, EventArgs e) {
            Sim sim = new Sim();
            sim.Show();
        }
    }
    public static class exten {
        public static uint ToU32(this byte[] b) {
            return (uint)BitConverter.ToInt32(b, 0);
        }
    }
}
