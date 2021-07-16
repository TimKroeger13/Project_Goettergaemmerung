
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
            this.buttonLoad.Location = new System.Drawing.Point(303, 30);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(94, 29);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load .CSV";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.Goldenrod;
            this.buttonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonExport.Enabled = false;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonExport.Location = new System.Drawing.Point(303, 65);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(167, 29);
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
            this.buttonConvert.Location = new System.Drawing.Point(303, 100);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(94, 29);
            this.buttonConvert.TabIndex = 3;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = false;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // labelPrintSetup
            // 
            this.labelPrintSetup.AutoSize = true;
            this.labelPrintSetup.BackColor = System.Drawing.Color.Goldenrod;
            this.labelPrintSetup.Location = new System.Drawing.Point(303, 143);
            this.labelPrintSetup.Name = "labelPrintSetup";
            this.labelPrintSetup.Size = new System.Drawing.Size(140, 20);
            this.labelPrintSetup.TabIndex = 8;
            this.labelPrintSetup.Text = "Choose Print Layout";
            // 
            // listBoxPrintModus
            // 
            this.listBoxPrintModus.BackColor = System.Drawing.Color.Goldenrod;
            this.listBoxPrintModus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPrintModus.FormattingEnabled = true;
            this.listBoxPrintModus.ItemHeight = 20;
            this.listBoxPrintModus.Location = new System.Drawing.Point(303, 319);
            this.listBoxPrintModus.Name = "listBoxPrintModus";
            this.listBoxPrintModus.Size = new System.Drawing.Size(150, 60);
            this.listBoxPrintModus.TabIndex = 9;
            this.listBoxPrintModus.SelectedIndexChanged += new System.EventHandler(this.listBoxPrintModus_SelectedIndexChanged);
            // 
            // labelPrintModus
            // 
            this.labelPrintModus.AutoSize = true;
            this.labelPrintModus.Location = new System.Drawing.Point(303, 280);
            this.labelPrintModus.Name = "labelPrintModus";
            this.labelPrintModus.Size = new System.Drawing.Size(194, 20);
            this.labelPrintModus.TabIndex = 10;
            this.labelPrintModus.Text = "Choose Cardsaveing Format";
            this.labelPrintModus.Click += new System.EventHandler(this.labelPrintModus_Click);
            // 
            // listBoxPrintLayout
            // 
            this.listBoxPrintLayout.BackColor = System.Drawing.Color.Goldenrod;
            this.listBoxPrintLayout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPrintLayout.FormattingEnabled = true;
            this.listBoxPrintLayout.ItemHeight = 20;
            this.listBoxPrintLayout.Location = new System.Drawing.Point(303, 181);
            this.listBoxPrintLayout.Name = "listBoxPrintLayout";
            this.listBoxPrintLayout.Size = new System.Drawing.Size(150, 80);
            this.listBoxPrintLayout.TabIndex = 11;
            this.listBoxPrintLayout.SelectedIndexChanged += new System.EventHandler(this.listBoxPrintLayout_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_Goettergaemmerung.Properties.Resources.Face;
            this.pictureBox1.Location = new System.Drawing.Point(0, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // labelMainName
            // 
            this.labelMainName.AutoSize = true;
            this.labelMainName.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMainName.Location = new System.Drawing.Point(12, 56);
            this.labelMainName.Name = "labelMainName";
            this.labelMainName.Size = new System.Drawing.Size(248, 62);
            this.labelMainName.TabIndex = 13;
            this.labelMainName.Text = "Götterdämmerung\r\nKarteneditor";
            this.labelMainName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMainName.Click += new System.EventHandler(this.labelMainName_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project_Goettergaemmerung.Properties.Resources.Textline;
            this.pictureBox2.Location = new System.Drawing.Point(303, 165);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 10);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Project_Goettergaemmerung.Properties.Resources.Textline;
            this.pictureBox3.Location = new System.Drawing.Point(303, 303);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(140, 10);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(553, 403);
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
    }
}

