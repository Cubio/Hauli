namespace Hauli
{
    partial class SeriesListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesListForm));
            this.SeriesList = new BrightIdeasSoftware.ObjectListView();
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lyhenneColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.kokoNimiColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.alueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.addSeura = new System.Windows.Forms.Button();
            this.openFileDialogSeurat = new System.Windows.Forms.OpenFileDialog();
            this.openPathButton = new System.Windows.Forms.Button();
            this.importFilePathTextBox = new System.Windows.Forms.TextBox();
            this.importSeriesFile = new System.Windows.Forms.Button();
            this.lyhenneTextBox = new System.Windows.Forms.TextBox();
            this.kokoNimiTextBox = new System.Windows.Forms.TextBox();
            this.alueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.saveSeurat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeriesList
            // 
            this.SeriesList.AccessibleName = "SeriesList";
            this.SeriesList.AllColumns.Add(this.idColumn);
            this.SeriesList.AllColumns.Add(this.lyhenneColumn);
            this.SeriesList.AllColumns.Add(this.kokoNimiColumn);
            this.SeriesList.AllColumns.Add(this.alueColumn);
            this.SeriesList.AllColumns.Add(this.buttonColumn);
            this.SeriesList.AlternateRowBackColor = System.Drawing.Color.White;
            this.SeriesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SeriesList.AutoArrange = false;
            this.SeriesList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.SeriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.lyhenneColumn,
            this.kokoNimiColumn,
            this.alueColumn,
            this.buttonColumn});
            this.SeriesList.FullRowSelect = true;
            this.SeriesList.HasCollapsibleGroups = false;
            this.SeriesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SeriesList.Location = new System.Drawing.Point(12, 12);
            this.SeriesList.Name = "SeriesList";
            this.SeriesList.OwnerDraw = true;
            this.SeriesList.ShowGroups = false;
            this.SeriesList.Size = new System.Drawing.Size(455, 261);
            this.SeriesList.SmallImageList = this.imageList1;
            this.SeriesList.TabIndex = 0;
            this.SeriesList.TabStop = false;
            this.SeriesList.UseCompatibleStateImageBehavior = false;
            this.SeriesList.UseTranslucentSelection = true;
            this.SeriesList.View = System.Windows.Forms.View.Details;
            this.SeriesList.Click += new System.EventHandler(this.SeriesList_Click);
            // 
            // idColumn
            // 
            this.idColumn.IsVisible = false;
            this.idColumn.Text = "ID";
            this.idColumn.Width = 0;
            // 
            // lyhenneColumn
            // 
            this.lyhenneColumn.AspectName = "";
            this.lyhenneColumn.Text = "Lyhenne";
            this.lyhenneColumn.Width = 95;
            // 
            // kokoNimiColumn
            // 
            this.kokoNimiColumn.Text = "Nimi";
            this.kokoNimiColumn.Width = 170;
            // 
            // alueColumn
            // 
            this.alueColumn.Text = "Paikkakunta";
            this.alueColumn.Width = 132;
            // 
            // buttonColumn
            // 
            this.buttonColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonColumn.Text = "";
            this.buttonColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonColumn.Width = 32;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "editIcon");
            this.imageList1.Images.SetKeyName(1, "deleteIcon");
            this.imageList1.Images.SetKeyName(2, "fire");
            this.imageList1.Images.SetKeyName(3, "grabDotsS.png");
            this.imageList1.Images.SetKeyName(4, "warning.ico");
            // 
            // addSeura
            // 
            this.addSeura.Location = new System.Drawing.Point(159, 128);
            this.addSeura.Name = "addSeura";
            this.addSeura.Size = new System.Drawing.Size(75, 23);
            this.addSeura.TabIndex = 3;
            this.addSeura.Text = "Lisää";
            this.addSeura.UseVisualStyleBackColor = true;
            this.addSeura.Click += new System.EventHandler(this.addSeura_Click);
            // 
            // openFileDialogSeurat
            // 
            this.openFileDialogSeurat.FileName = "openFileDialogSeurat";
            this.openFileDialogSeurat.FileOk += new System.ComponentModel.CancelEventHandler(this.selectFile);
            // 
            // openPathButton
            // 
            this.openPathButton.Location = new System.Drawing.Point(159, 35);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(34, 23);
            this.openPathButton.TabIndex = 12;
            this.openPathButton.TabStop = false;
            this.openPathButton.Text = "...";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // importFilePathTextBox
            // 
            this.importFilePathTextBox.Location = new System.Drawing.Point(15, 37);
            this.importFilePathTextBox.Name = "importFilePathTextBox";
            this.importFilePathTextBox.Size = new System.Drawing.Size(138, 20);
            this.importFilePathTextBox.TabIndex = 11;
            this.importFilePathTextBox.TabStop = false;
            // 
            // importSeriesFile
            // 
            this.importSeriesFile.Location = new System.Drawing.Point(118, 92);
            this.importSeriesFile.Name = "importSeriesFile";
            this.importSeriesFile.Size = new System.Drawing.Size(75, 23);
            this.importSeriesFile.TabIndex = 13;
            this.importSeriesFile.TabStop = false;
            this.importSeriesFile.Text = "Tuo";
            this.importSeriesFile.UseVisualStyleBackColor = true;
            this.importSeriesFile.Click += new System.EventHandler(this.importSeriesFile_Click);
            // 
            // lyhenneTextBox
            // 
            this.lyhenneTextBox.Location = new System.Drawing.Point(87, 37);
            this.lyhenneTextBox.Name = "lyhenneTextBox";
            this.lyhenneTextBox.Size = new System.Drawing.Size(147, 20);
            this.lyhenneTextBox.TabIndex = 0;
            // 
            // kokoNimiTextBox
            // 
            this.kokoNimiTextBox.Location = new System.Drawing.Point(87, 63);
            this.kokoNimiTextBox.Name = "kokoNimiTextBox";
            this.kokoNimiTextBox.Size = new System.Drawing.Size(147, 20);
            this.kokoNimiTextBox.TabIndex = 1;
            // 
            // alueTextBox
            // 
            this.alueTextBox.Location = new System.Drawing.Point(87, 89);
            this.alueTextBox.Name = "alueTextBox";
            this.alueTextBox.Size = new System.Drawing.Size(147, 20);
            this.alueTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Lyhenne";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Seuran nimi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Paikkakunta";
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Close.Location = new System.Drawing.Point(392, 437);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 23;
            this.Close.TabStop = false;
            this.Close.Text = "Sulje";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // saveSeurat
            // 
            this.saveSeurat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveSeurat.Location = new System.Drawing.Point(311, 437);
            this.saveSeurat.Name = "saveSeurat";
            this.saveSeurat.Size = new System.Drawing.Size(75, 23);
            this.saveSeurat.TabIndex = 22;
            this.saveSeurat.TabStop = false;
            this.saveSeurat.Text = "Tallenna";
            this.saveSeurat.UseVisualStyleBackColor = true;
            this.saveSeurat.Click += new System.EventHandler(this.saveSeurat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tuo seurat tiedostosta";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.alueTextBox);
            this.groupBox1.Controls.Add(this.kokoNimiTextBox);
            this.groupBox1.Controls.Add(this.lyhenneTextBox);
            this.groupBox1.Controls.Add(this.addSeura);
            this.groupBox1.Location = new System.Drawing.Point(14, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 157);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seuran lisäys";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.importSeriesFile);
            this.groupBox2.Controls.Add(this.importFilePathTextBox);
            this.groupBox2.Controls.Add(this.openPathButton);
            this.groupBox2.Location = new System.Drawing.Point(268, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 127);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seurojen tuonti";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(-6, -13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 486);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // SeriesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 469);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveSeurat);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.SeriesList);
            this.Controls.Add(this.groupBox3);
            this.Name = "SeriesListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seurojen muokkaus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeriesListForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView SeriesList;
        private System.Windows.Forms.Button addSeura;
        private System.Windows.Forms.OpenFileDialog openFileDialogSeurat;
        private System.Windows.Forms.Button openPathButton;
        private System.Windows.Forms.TextBox importFilePathTextBox;
        private System.Windows.Forms.Button importSeriesFile;
        private System.Windows.Forms.TextBox lyhenneTextBox;
        private System.Windows.Forms.TextBox kokoNimiTextBox;
        private System.Windows.Forms.TextBox alueTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BrightIdeasSoftware.OLVColumn lyhenneColumn;
        private BrightIdeasSoftware.OLVColumn kokoNimiColumn;
        private BrightIdeasSoftware.OLVColumn alueColumn;
        private BrightIdeasSoftware.OLVColumn idColumn;
        private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn buttonColumn;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button saveSeurat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}