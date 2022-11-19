
namespace Project_Goettergaemmerung;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.folderBrowserDialogOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.labelPrintSetup = new System.Windows.Forms.Label();
            this.listBoxPrintModus = new System.Windows.Forms.ListBox();
            this.labelPrintModus = new System.Windows.Forms.Label();
            this.listBoxPrintLayout = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMainName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonJsonExport = new System.Windows.Forms.Button();
            this.buttonShowCard = new System.Windows.Forms.Button();
            this.inputCardId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLoad.Location = new System.Drawing.Point(265, 22);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(146, 22);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Cardinformation";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonExport.Enabled = false;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonExport.Location = new System.Drawing.Point(265, 49);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(146, 22);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Choose Output Folder";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonConvert.Enabled = false;
            this.buttonConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConvert.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonConvert.Location = new System.Drawing.Point(265, 75);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(146, 22);
            this.buttonConvert.TabIndex = 3;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = false;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // labelPrintSetup
            // 
            this.labelPrintSetup.AutoSize = true;
            this.labelPrintSetup.BackColor = System.Drawing.Color.Goldenrod;
            this.labelPrintSetup.Location = new System.Drawing.Point(265, 107);
            this.labelPrintSetup.Name = "labelPrintSetup";
            this.labelPrintSetup.Size = new System.Drawing.Size(114, 15);
            this.labelPrintSetup.TabIndex = 8;
            this.labelPrintSetup.Text = "Choose Print Layout";
            // 
            // listBoxPrintModus
            // 
            this.listBoxPrintModus.BackColor = System.Drawing.Color.Goldenrod;
            this.listBoxPrintModus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPrintModus.FormattingEnabled = true;
            this.listBoxPrintModus.ItemHeight = 15;
            this.listBoxPrintModus.Location = new System.Drawing.Point(265, 239);
            this.listBoxPrintModus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxPrintModus.Name = "listBoxPrintModus";
            this.listBoxPrintModus.Size = new System.Drawing.Size(131, 45);
            this.listBoxPrintModus.TabIndex = 9;
            this.listBoxPrintModus.SelectedIndexChanged += new System.EventHandler(this.ListBoxPrintModus_SelectedIndexChanged);
            // 
            // labelPrintModus
            // 
            this.labelPrintModus.AutoSize = true;
            this.labelPrintModus.Location = new System.Drawing.Point(265, 210);
            this.labelPrintModus.Name = "labelPrintModus";
            this.labelPrintModus.Size = new System.Drawing.Size(156, 15);
            this.labelPrintModus.TabIndex = 10;
            this.labelPrintModus.Text = "Choose Cardsaveing Format";
            this.labelPrintModus.Click += new System.EventHandler(this.LabelPrintModus_Click);
            // 
            // listBoxPrintLayout
            // 
            this.listBoxPrintLayout.BackColor = System.Drawing.Color.Goldenrod;
            this.listBoxPrintLayout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPrintLayout.FormattingEnabled = true;
            this.listBoxPrintLayout.ItemHeight = 15;
            this.listBoxPrintLayout.Location = new System.Drawing.Point(265, 136);
            this.listBoxPrintLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxPrintLayout.Name = "listBoxPrintLayout";
            this.listBoxPrintLayout.Size = new System.Drawing.Size(131, 60);
            this.listBoxPrintLayout.TabIndex = 11;
            this.listBoxPrintLayout.SelectedIndexChanged += new System.EventHandler(this.ListBoxPrintLayout_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_Goettergaemmerung.Properties.Resources.Face;
            this.pictureBox1.Location = new System.Drawing.Point(0, 146);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // labelMainName
            // 
            this.labelMainName.AutoSize = true;
            this.labelMainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMainName.Location = new System.Drawing.Point(12, 9);
            this.labelMainName.Name = "labelMainName";
            this.labelMainName.Size = new System.Drawing.Size(223, 58);
            this.labelMainName.TabIndex = 13;
            this.labelMainName.Text = "Götterdämmerung\r\nKarteneditor";
            this.labelMainName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMainName.Click += new System.EventHandler(this.LabelMainName_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project_Goettergaemmerung.Properties.Resources.Textline;
            this.pictureBox2.Location = new System.Drawing.Point(265, 124);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 8);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Project_Goettergaemmerung.Properties.Resources.Textline;
            this.pictureBox3.Location = new System.Drawing.Point(265, 227);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(122, 8);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // buttonJsonExport
            // 
            this.buttonJsonExport.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonJsonExport.Enabled = false;
            this.buttonJsonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJsonExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonJsonExport.Location = new System.Drawing.Point(444, 270);
            this.buttonJsonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonJsonExport.Name = "buttonJsonExport";
            this.buttonJsonExport.Size = new System.Drawing.Size(99, 22);
            this.buttonJsonExport.TabIndex = 16;
            this.buttonJsonExport.Text = "Export JSON";
            this.buttonJsonExport.UseVisualStyleBackColor = false;
            this.buttonJsonExport.Click += new System.EventHandler(this.ButtonJsonExport_Click);
            // 
            // buttonShowCard
            // 
            this.buttonShowCard.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonShowCard.Enabled = false;
            this.buttonShowCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowCard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonShowCard.Location = new System.Drawing.Point(444, 75);
            this.buttonShowCard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShowCard.Name = "buttonShowCard";
            this.buttonShowCard.Size = new System.Drawing.Size(99, 22);
            this.buttonShowCard.TabIndex = 17;
            this.buttonShowCard.Text = "Show Card";
            this.buttonShowCard.UseVisualStyleBackColor = false;
            this.buttonShowCard.Click += new System.EventHandler(this.ButtonShowCard_Click);
            // 
            // inputCardId
            // 
            this.inputCardId.Enabled = false;
            this.inputCardId.Location = new System.Drawing.Point(443, 44);
            this.inputCardId.Name = "inputCardId";
            this.inputCardId.Size = new System.Drawing.Size(100, 23);
            this.inputCardId.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter Card-Id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(555, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputCardId);
            this.Controls.Add(this.buttonShowCard);
            this.Controls.Add(this.buttonJsonExport);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelMainName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBoxPrintLayout);
            this.Controls.Add(this.labelPrintModus);
            this.Controls.Add(this.listBoxPrintModus);
            this.Controls.Add(this.labelPrintSetup);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karteneditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonLoad;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button buttonExport;
    private System.Windows.Forms.Button buttonConvert;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutputFolder;
    private System.Windows.Forms.Label labelPrintSetup;
    private System.Windows.Forms.ListBox listBoxPrintModus;
    private System.Windows.Forms.Label labelPrintModus;
    private System.Windows.Forms.ListBox listBoxPrintLayout;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label labelMainName;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.PictureBox pictureBox3;
    private Button buttonJsonExport;
    private Button buttonShowCard;
    private TextBox inputCardId;
    private Label label1;
}

