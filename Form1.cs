﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Project_Goettergaemmerung.components;

namespace Project_Goettergaemmerung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBoxCards_Click(object sender, EventArgs e)
        {
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            var loadODS = new LoadODS();
        }

        public void RenderImage(Image image)
        {
            pictureBoxCards.Image = image;
        }

        public void SaveImage(String filename)
        {
            pictureBoxCards.Image.Save("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\" + filename + ".png", ImageFormat.Png);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}