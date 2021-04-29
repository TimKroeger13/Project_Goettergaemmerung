using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung
{
    public partial class Form1 : Form
    {
        private readonly ICardPrinter _cardPrinter;
        private readonly ICreatePicture _createPicture;
        private readonly IUserData _userData;

        public Form1(ICardPrinter cardPrinter, ICreatePicture createPicture, IUserData userData)
        {
            InitializeComponent();
            _cardPrinter = cardPrinter;
            _createPicture = createPicture;
            _userData = userData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //RenderImage(_createPicture.MergedBitmaps(_createPicture.BledingMultiply(bmp1, bmp4), bmp2, bmp3));

            //mainForm.RenderImage(createPicture.BledingMultiply(bmp1, bmp4));
        }

        private void PictureCardBox_Click(object sender, EventArgs e)
        {
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            _userData.ImportPath = openFileDialog1.FileName;
            buttonExport.Enabled = true;
        }

        public void RenderImage(Image image)
        {
            pictureBoxCards.Image = image;
        }

        public void SaveImage(string filename)
        {
            pictureBoxCards.Image?.Save(_userData.ExportPath + "\\" + filename + ".png", ImageFormat.Png);
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            folderBrowserDialogOutputFolder.ShowDialog();
            _userData.ExportPath = folderBrowserDialogOutputFolder.SelectedPath;
            buttonConvert.Enabled = true;
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            _cardPrinter.PrintCards();
            //SaveImage("testname");
        }
    }
}
