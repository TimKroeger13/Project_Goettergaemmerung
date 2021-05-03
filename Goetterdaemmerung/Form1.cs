using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung
{
    public partial class Form1 : Form
    {
        private readonly ICardPrinter _cardPrinter;
        private readonly IUserData _userData;

        public Form1(ICardPrinter cardPrinter, IUserData userData)
        {
            InitializeComponent();
            _cardPrinter = cardPrinter;
            _userData = userData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var CardInformationList = _cardInformationGetter.GetCardInformation("M:\\Repos\\Project_Goettergaemmerung\\Götterdämmerung-Karten.csv").ToList();

            //var structure1 = CardInformationList[0].Structure;
            //var type1 = CardInformationList[0].CardType;
            //var race1 = CardInformationList[0].Race;
            //var extra1 = CardInformationList[0].ExtraDeck;
            //var name1 = CardInformationList[0].Name;

            //var Template = _templateBuilder.CardTemplate(structure1, type1, race1, extra1);

            //var FinalCard = _createPicture.MergedBitmaps(Template);
            //RenderImage(FinalCard);

            //_cardPrinter.SaveImage(FinalCard, name);

            //RenderImage(_picturesFromArchive._action);

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

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            folderBrowserDialogOutputFolder.ShowDialog();
            _userData.ExportPath = folderBrowserDialogOutputFolder.SelectedPath;
            buttonConvert.Enabled = true;
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            _cardPrinter.PrintCards();
        }
    }
}
