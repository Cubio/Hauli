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
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).BeginInit();
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
            this.SeriesList.HasCollapsibleGroups = false;
            this.SeriesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SeriesList.Location = new System.Drawing.Point(12, 12);
            this.SeriesList.Name = "SeriesList";
            this.SeriesList.OwnerDraw = true;
            this.SeriesList.ShowGroups = false;
            this.SeriesList.Size = new System.Drawing.Size(455, 238);
            this.SeriesList.SmallImageList = this.imageList1;
            this.SeriesList.TabIndex = 0;
            this.SeriesList.UseCompatibleStateImageBehavior = false;
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
            this.kokoNimiColumn.Width = 136;
            // 
            // alueColumn
            // 
            this.alueColumn.Text = "Paikkakunta";
            this.alueColumn.Width = 96;
            // 
            // buttonColumn
            // 
            this.buttonColumn.Text = "";
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
            this.addSeura.Location = new System.Drawing.Point(392, 300);
            this.addSeura.Name = "addSeura";
            this.addSeura.Size = new System.Drawing.Size(75, 23);
            this.addSeura.TabIndex = 1;
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
            this.openPathButton.Location = new System.Drawing.Point(183, 362);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(34, 23);
            this.openPathButton.TabIndex = 12;
            this.openPathButton.Text = "...";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // importFilePathTextBox
            // 
            this.importFilePathTextBox.Location = new System.Drawing.Point(15, 362);
            this.importFilePathTextBox.Name = "importFilePathTextBox";
            this.importFilePathTextBox.Size = new System.Drawing.Size(162, 20);
            this.importFilePathTextBox.TabIndex = 13;
            // 
            // importSeriesFile
            // 
            this.importSeriesFile.Location = new System.Drawing.Point(223, 362);
            this.importSeriesFile.Name = "importSeriesFile";
            this.importSeriesFile.Size = new System.Drawing.Size(75, 23);
            this.importSeriesFile.TabIndex = 14;
            this.importSeriesFile.Text = "Tallenna";
            this.importSeriesFile.UseVisualStyleBackColor = true;
            this.importSeriesFile.Click += new System.EventHandler(this.importSeriesFile_Click);
            // 
            // lyhenneTextBox
            // 
            this.lyhenneTextBox.Location = new System.Drawing.Point(12, 274);
            this.lyhenneTextBox.Name = "lyhenneTextBox";
            this.lyhenneTextBox.Size = new System.Drawing.Size(92, 20);
            this.lyhenneTextBox.TabIndex = 15;
            // 
            // kokoNimiTextBox
            // 
            this.kokoNimiTextBox.Location = new System.Drawing.Point(110, 274);
            this.kokoNimiTextBox.Name = "kokoNimiTextBox";
            this.kokoNimiTextBox.Size = new System.Drawing.Size(236, 20);
            this.kokoNimiTextBox.TabIndex = 16;
            // 
            // alueTextBox
            // 
            this.alueTextBox.Location = new System.Drawing.Point(352, 274);
            this.alueTextBox.Name = "alueTextBox";
            this.alueTextBox.Size = new System.Drawing.Size(115, 20);
            this.alueTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lyhenne:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Kokonimi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Paikkakunta:";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(392, 359);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 21;
            this.Close.Text = "Sulje";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // saveSeurat
            // 
            this.saveSeurat.Location = new System.Drawing.Point(311, 300);
            this.saveSeurat.Name = "saveSeurat";
            this.saveSeurat.Size = new System.Drawing.Size(75, 23);
            this.saveSeurat.TabIndex = 22;
            this.saveSeurat.Text = "Tallenna";
            this.saveSeurat.UseVisualStyleBackColor = true;
            this.saveSeurat.Click += new System.EventHandler(this.saveSeurat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tuo seurat txt filusta";
            // 
            // SeriesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saveSeurat);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.alueTextBox);
            this.Controls.Add(this.kokoNimiTextBox);
            this.Controls.Add(this.lyhenneTextBox);
            this.Controls.Add(this.importSeriesFile);
            this.Controls.Add(this.importFilePathTextBox);
            this.Controls.Add(this.openPathButton);
            this.Controls.Add(this.addSeura);
            this.Controls.Add(this.SeriesList);
            this.Name = "SeriesListForm";
            this.Text = "SeriesListForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeriesListForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}