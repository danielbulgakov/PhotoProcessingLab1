﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        Bitmap prevImage;


        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files|*.jpg;*.png";
            dialog.Title = "Open an Image File.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                prevImage = new Bitmap(imagePath);
                this.pictureBox1.Image = new Bitmap(imagePath);

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "image files|*.jpg;*.png";
            dialog.Title = "Save an Image File.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "" && this.pictureBox1.Image != null)
                {
                    System.IO.FileStream fs = (System.IO.FileStream)dialog.OpenFile();

                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            this.pictureBox1.Image.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            this.pictureBox1.Image.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    fs.Close();
                }
            }
            else
                MessageBox.Show("Не удалось сохранить.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private bool ImageIsNull()
        {
            if (pictureBox1.Image == null) MessageBox.Show("Загрузите фото.", "Ошибка!");
            return pictureBox1.Image == null;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageIsNull()) return;
            this.pictureBox1.Image = prevImage;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageIsNull()) return;
            prevImage = new Bitmap(pictureBox1.Image);
            Cursor.Current = Cursors.WaitCursor;
            this.pictureBox1.Image = Filters.Grayscale.Execute((Bitmap)pictureBox1.Image);
            Cursor.Current = Cursors.Default;
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageIsNull()) return;
            prevImage = new Bitmap(pictureBox1.Image);
            Cursor.Current = Cursors.WaitCursor;
            this.pictureBox1.Image = Filters.Average.Execute((Bitmap)pictureBox1.Image);
            Cursor.Current = Cursors.Default;
        }

        private void autocontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageIsNull()) return;
            prevImage = new Bitmap(pictureBox1.Image);
            Cursor.Current = Cursors.WaitCursor;
            this.pictureBox1.Image = Filters.Autocontrast.Execute((Bitmap)pictureBox1.Image);
            Cursor.Current = Cursors.Default;
        }

        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageIsNull()) return;
            prevImage = new Bitmap(pictureBox1.Image);
            Cursor.Current = Cursors.WaitCursor;
            this.pictureBox1.Image = Filters.GlobalBinarization.Execute((Bitmap)pictureBox1.Image, this.trackBar1.Value);
            Cursor.Current = Cursors.Default;
        }

        private void niblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageIsNull()) return;
            prevImage = new Bitmap(pictureBox1.Image);
            Cursor.Current = Cursors.WaitCursor;
            this.pictureBox1.Image = Filters.Niblack.Execute((Bitmap)pictureBox1.Image);
            Cursor.Current = Cursors.Default;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.label1.Text = this.trackBar1.Value.ToString();
        }

    }
}