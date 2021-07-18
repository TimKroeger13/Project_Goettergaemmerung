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
using Project_Goettergaemmerung.Components.Model;

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
            listBoxPrintModus.Items.Add("Normal");
            listBoxPrintModus.Items.Add("Tabeltop");
            listBoxPrintModus.Items.Add("Rebalence");
            listBoxPrintModus.SetSelected(0, true);

            listBoxPrintLayout.Items.Add("Druck 1");
            listBoxPrintLayout.Items.Add("Druck 2");
            listBoxPrintLayout.Items.Add("Druck 3");
            listBoxPrintLayout.Items.Add("Druck 4");
            listBoxPrintLayout.SetSelected(0, true);
        }

        private void PictureCardBox_Click(object sender, EventArgs e)
        {
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            _userData.ImportPath = openFileDialog1.FileName;
            buttonExport.Enabled = true;
            buttonLoad.BackColor = Color.Goldenrod;
            buttonExport.BackColor = Color.DarkGoldenrod;
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            folderBrowserDialogOutputFolder.ShowDialog();
            _userData.ExportPath = folderBrowserDialogOutputFolder.SelectedPath;
            buttonConvert.Enabled = true;
            buttonExport.BackColor = Color.Goldenrod;
            buttonConvert.BackColor = Color.DarkGoldenrod;
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            _cardPrinter.PrintCards();
        }

        private void listBoxPrintModus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPrintModus.SelectedItems[0].ToString() == "Normal")
            {
                _userData.CurrentFormat = SaveFormat.normal;
            }
            if (listBoxPrintModus.SelectedItems[0].ToString() == "Tabeltop")
            {
                _userData.CurrentFormat = SaveFormat.tabeltop;
            }
            if (listBoxPrintModus.SelectedItems[0].ToString() == "Rebalence")
            {
                _userData.CurrentFormat = SaveFormat.rebalence;
            }
        }

        private void labelPrintModus_Click(object sender, EventArgs e)
        {
        }

        private void listBoxPrintLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPrintLayout.SelectedItems[0].ToString() == "Druck 1")
            {
                _userData.Printer = PrintType.Print1;
            }
            if (listBoxPrintLayout.SelectedItems[0].ToString() == "Druck 2")
            {
                _userData.Printer = PrintType.Print2;
            }
            if (listBoxPrintLayout.SelectedItems[0].ToString() == "Druck 3")
            {
                _userData.Printer = PrintType.Print3;
            }
            if (listBoxPrintLayout.SelectedItems[0].ToString() == "Druck 4")
            {
                _userData.Printer = PrintType.Print4;
            }
        }

        private void labelMainName_Click(object sender, EventArgs e)
        {
        }
    }
}
