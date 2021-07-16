
namespace Project_Goettergaemmerung
{
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.folderBrowserDialogOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonPrint1 = new System.Windows.Forms.Button();
            this.buttonPrint2 = new System.Windows.Forms.Button();
            this.buttonPrint4 = new System.Windows.Forms.Button();
            this.buttonPrint3 = new System.Windows.Forms.Button();
            this.labelPrintSetup = new System.Windows.Forms.Label();
            this.listBoxPrintModus = new System.Windows.Forms.ListBox();
            this.labelPrintModus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(107, 106);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(94, 29);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load .CSV";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonExport
            // 
            this.buttonExport.Enabled = false;
            this.buttonExport.Location = new System.Drawing.Point(107, 163);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(167, 29);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Choose Output Folder";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Enabled = false;
            this.buttonConvert.Location = new System.Drawing.Point(107, 219);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(94, 29);
            this.buttonConvert.TabIndex = 3;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // buttonPrint1
            // 
            this.buttonPrint1.Enabled = false;
            this.buttonPrint1.Location = new System.Drawing.Point(315, 103);
            this.buttonPrint1.Name = "buttonPrint1";
            this.buttonPrint1.Size = new System.Drawing.Size(35, 35);
            this.buttonPrint1.TabIndex = 4;
            this.buttonPrint1.Text = "P1";
            this.buttonPrint1.UseVisualStyleBackColor = true;
            this.buttonPrint1.Click += new System.EventHandler(this.buttonPrint1_Click);
            // 
            // buttonPrint2
            // 
            this.buttonPrint2.Location = new System.Drawing.Point(356, 103);
            this.buttonPrint2.Name = "buttonPrint2";
            this.buttonPrint2.Size = new System.Drawing.Size(35, 35);
            this.buttonPrint2.TabIndex = 5;
            this.buttonPrint2.Text = "P2";
            this.buttonPrint2.UseVisualStyleBackColor = true;
            this.buttonPrint2.Click += new System.EventHandler(this.buttonPrint2_Click);
            // 
            // buttonPrint4
            // 
            this.buttonPrint4.Location = new System.Drawing.Point(438, 103);
            this.buttonPrint4.Name = "buttonPrint4";
            this.buttonPrint4.Size = new System.Drawing.Size(35, 35);
            this.buttonPrint4.TabIndex = 6;
            this.buttonPrint4.Text = "P4";
            this.buttonPrint4.UseVisualStyleBackColor = true;
            this.buttonPrint4.Click += new System.EventHandler(this.buttonPrint4_Click);
            // 
            // buttonPrint3
            // 
            this.buttonPrint3.Location = new System.Drawing.Point(397, 103);
            this.buttonPrint3.Name = "buttonPrint3";
            this.buttonPrint3.Size = new System.Drawing.Size(35, 35);
            this.buttonPrint3.TabIndex = 7;
            this.buttonPrint3.Text = "P3";
            this.buttonPrint3.UseVisualStyleBackColor = true;
            this.buttonPrint3.Click += new System.EventHandler(this.buttonPrint3_Click);
            // 
            // labelPrintSetup
            // 
            this.labelPrintSetup.AutoSize = true;
            this.labelPrintSetup.Location = new System.Drawing.Point(324, 80);
            this.labelPrintSetup.Name = "labelPrintSetup";
            this.labelPrintSetup.Size = new System.Drawing.Size(140, 20);
            this.labelPrintSetup.TabIndex = 8;
            this.labelPrintSetup.Text = "Choose Print Layout";
            // 
            // listBoxPrintModus
            // 
            this.listBoxPrintModus.FormattingEnabled = true;
            this.listBoxPrintModus.ItemHeight = 20;
            this.listBoxPrintModus.Location = new System.Drawing.Point(315, 184);
            this.listBoxPrintModus.Name = "listBoxPrintModus";
            this.listBoxPrintModus.Size = new System.Drawing.Size(150, 64);
            this.listBoxPrintModus.TabIndex = 9;
            this.listBoxPrintModus.SelectedIndexChanged += new System.EventHandler(this.listBoxPrintModus_SelectedIndexChanged);
            // 
            // labelPrintModus
            // 
            this.labelPrintModus.AutoSize = true;
            this.labelPrintModus.Location = new System.Drawing.Point(315, 161);
            this.labelPrintModus.Name = "labelPrintModus";
            this.labelPrintModus.Size = new System.Drawing.Size(194, 20);
            this.labelPrintModus.TabIndex = 10;
            this.labelPrintModus.Text = "Choose Cardsaveing Format";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(588, 373);
            this.Controls.Add(this.labelPrintModus);
            this.Controls.Add(this.listBoxPrintModus);
            this.Controls.Add(this.labelPrintSetup);
            this.Controls.Add(this.buttonPrint3);
            this.Controls.Add(this.buttonPrint4);
            this.Controls.Add(this.buttonPrint2);
            this.Controls.Add(this.buttonPrint1);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "Karteneditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutputFolder;
        private System.Windows.Forms.Button buttonPrint1;
        private System.Windows.Forms.Button buttonPrint2;
        private System.Windows.Forms.Button buttonPrint4;
        private System.Windows.Forms.Button buttonPrint3;
        private System.Windows.Forms.Label labelPrintSetup;
        private System.Windows.Forms.ListBox listBoxPrintModus;
        private System.Windows.Forms.Label labelPrintModus;
    }
}

