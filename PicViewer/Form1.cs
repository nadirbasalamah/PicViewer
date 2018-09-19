using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Kode program untuk proses logika (logic process) pada aplikasi PicViewer
namespace PicViewer
{
    public partial class Form_1015_1 : Form
    {
        int deg;
        Image gbrAsli;
        public Form_1015_1()
        {
            InitializeComponent();
            printDocument_1015_1.PrintPage += printImage;
            this.MouseWheel += picture_MouseWheel;
            pictureBox_1015_1.Focus();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private void openFileDialog_Click(object sender, EventArgs e)
        {
            if (openFileDialog_1015_1.ShowDialog() == DialogResult.OK)
            {
                gbrAsli = Image.FromFile(openFileDialog_1015_1.FileName);
                pictureBox_1015_1.Image = gbrAsli;
            }
        }
        private void zoominButton_Click(object sender, EventArgs e)
        {
            pictureBox_1015_1.Width += 50;
            pictureBox_1015_1.Height+= 50;
        }
        private void zoomoutButton_Click(object sender, EventArgs e)
        {
            pictureBox_1015_1.Width-= 50;
            pictureBox_1015_1.Height-= 50;
        }
        private void rotateLeftButton_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1015_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            if (deg > 270)
            {
                pictureBox_1015_1.Image = gbrAsli;
                deg = 0;
                return;
            }
            pictureBox_1015_1.Image = flipImage;
            deg += 90;
        }
        private void rotateRightButton_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1015_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (deg > 270)
            {
                pictureBox_1015_1.Image = gbrAsli;
                deg = 0;
                return;
            }
            pictureBox_1015_1.Image = flipImage;
            deg += 90;
        }
        private void printImage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox_1015_1.Image, 0, 0);
        }
        private void printImage_Click(object sender, EventArgs e)
        {
            if(printDialog_1015_1.ShowDialog() == DialogResult.OK)
            {
                printDocument_1015_1.Print();
            }
        }
        private void saveImage_Click(object sender, EventArgs e)
        {
            System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            if (saveFileDialog_1015_1.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(saveFileDialog_1015_1.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ".png":
                        format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                }
                pictureBox_1015_1.Image.Save(saveFileDialog_1015_1.FileName, format);
            }
        }
        private void picture_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                pictureBox_1015_1.Width += 50;
                pictureBox_1015_1.Height += 50;
            } else if (e.KeyChar == '-')
            {
                pictureBox_1015_1.Width -= 50;
                pictureBox_1015_1.Height -= 50;
            }
        }
        private void picture_KeyDown(object sender, KeyEventArgs e)
        {
            Image flipImage = pictureBox_1015_1.Image;
            if (KeyIsDown(Keys.RControlKey))
            {
                flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (deg > 270)
                {
                    pictureBox_1015_1.Image = gbrAsli;
                    deg = 0;
                    return;
                }
                pictureBox_1015_1.Image = flipImage;
                deg += 90;
            } else if(KeyIsDown(Keys.LControlKey))
            {
                flipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                if (deg > 270)
                {
                    pictureBox_1015_1.Image = gbrAsli;
                    deg = 0;
                    return;
                }
                pictureBox_1015_1.Image = flipImage;
                deg += 90;
            }
        }
        private void picture_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                pictureBox_1015_1.Width += 50;
                pictureBox_1015_1.Height += 50;
            }
            else
            {
                pictureBox_1015_1.Width -= 50;
                pictureBox_1015_1.Height -= 50;
            }
        }
        private bool KeyIsDown(Keys key)
        {
            return (GetAsyncKeyState(key) < 0);
        }
        private void printPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog_1015_1.ShowDialog();
        }
    }
}
