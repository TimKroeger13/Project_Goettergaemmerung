﻿using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung;

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
        openFileDialog1.Filter = "Cardinformation (*.sqlite3,*.csv,*.CSV)|*.sqlite3;*.csv;*.CSV";
        openFileDialog1.ShowDialog();
        _userData.ImportPath = openFileDialog1.FileName;
        _userData.ImportType = _userData.ImportPath.EndsWith("csv", StringComparison.InvariantCultureIgnoreCase) ? CardImportType.CSV :
            _userData.ImportPath.EndsWith("sqlite3", StringComparison.InvariantCultureIgnoreCase) ? CardImportType.Sqlite :
            CardImportType.NA;
        buttonExport.Enabled = true;
        buttonJsonExport.Enabled = true;
        inputCardId.Enabled = true;
        buttonShowCard.Enabled = true;
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

    private void ListBoxPrintModus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxPrintModus.SelectedItems[0]?.ToString() == "Normal")
        {
            _userData.CurrentFormat = SaveFormat.normal;
        }
        if (listBoxPrintModus.SelectedItems[0]?.ToString() == "Tabeltop")
        {
            _userData.CurrentFormat = SaveFormat.tabeltop;
        }
        if (listBoxPrintModus.SelectedItems[0]?.ToString() == "Rebalence")
        {
            _userData.CurrentFormat = SaveFormat.rebalence;
        }
    }

    private void LabelPrintModus_Click(object sender, EventArgs e)
    {
    }

    private void ListBoxPrintLayout_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxPrintLayout.SelectedItems[0]?.ToString() == "Druck 1")
        {
            _userData.Printer = PrintType.Print1;
        }
        if (listBoxPrintLayout.SelectedItems[0]?.ToString() == "Druck 2")
        {
            _userData.Printer = PrintType.Print2;
        }
        if (listBoxPrintLayout.SelectedItems[0]?.ToString() == "Druck 3")
        {
            _userData.Printer = PrintType.Print3;
        }
        if (listBoxPrintLayout.SelectedItems[0]?.ToString() == "Druck 4")
        {
            _userData.Printer = PrintType.Print4;
        }
    }

    private void LabelMainName_Click(object sender, EventArgs e)
    {
    }

    private void ButtonJsonExport_Click(object sender, EventArgs e)
    {
        var fileDialog = new OpenFileDialog()
        {
            Filter = "JSON (*.json)|*.json",
        };
        var result = fileDialog.ShowDialog();
        if (result != DialogResult.OK) throw new Exception("No Valid file given");
        _cardPrinter.ExportCardInformationAsJSON(fileDialog.FileName);
    }

    private void ButtonShowCard_Click(object sender, EventArgs e)
    {
        var success = long.TryParse(inputCardId.Text, out var id);
        if (!success) throw new Exception("Card-Id must be a number");
        var cardToShow = _cardPrinter.CreateBitmap(id);
        var form = new Form
        {
            Height = cardToShow.Height,
            Width = cardToShow.Width
        };
        var pictureBox = new PictureBox()
        {
            Image = cardToShow,
            Dock = DockStyle.Fill
        };
        form.Controls.Add(pictureBox);
        form.Show();
    }
}
