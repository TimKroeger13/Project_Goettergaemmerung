using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Project_Goettergaemmerung.Components;

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
