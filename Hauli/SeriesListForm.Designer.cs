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
            this.SeriesList = new BrightIdeasSoftware.ObjectListView();
            this.lyhenne = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nimi = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paikkakunta = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialogSeurat = new System.Windows.Forms.OpenFileDialog();
            this.openPathButton = new System.Windows.Forms.Button();
            this.importFilePathTextBox = new System.Windows.Forms.TextBox();
            this.importSeriesFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).BeginInit();
            this.SuspendLayout();
            // 
            // SeriesList
            // 
            this.SeriesList.AccessibleName = "SeriesList";
            this.SeriesList.AllColumns.Add(this.lyhenne);
            this.SeriesList.AllColumns.Add(this.nimi);
            this.SeriesList.AllColumns.Add(this.paikkakunta);
            this.SeriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lyhenne,
            this.nimi,
            this.paikkakunta});
            this.SeriesList.Location = new System.Drawing.Point(12, 12);
            this.SeriesList.Name = "SeriesList";
            this.SeriesList.Size = new System.Drawing.Size(406, 238);
            this.SeriesList.TabIndex = 0;
            this.SeriesList.UseCompatibleStateImageBehavior = false;
            this.SeriesList.View = System.Windows.Forms.View.Details;
            // 
            // lyhenne
            // 
            this.lyhenne.AspectName = "";
            this.lyhenne.Text = "Lyhenne";
            this.lyhenne.Width = 95;
            // 
            // nimi
            // 
            this.nimi.Text = "Kokonimi";
            this.nimi.Width = 136;
            // 
            // paikkakunta
            // 
            this.paikkakunta.Text = "Paikkakunta";
            this.paikkakunta.Width = 96;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lisää";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // openFileDialogSeurat
            // 
            this.openFileDialogSeurat.FileName = "openFileDialogSeurat";
            this.openFileDialogSeurat.FileOk += new System.ComponentModel.CancelEventHandler(this.selectFile);
            // 
            // openPathButton
            // 
            this.openPathButton.Location = new System.Drawing.Point(215, 371);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(34, 23);
            this.openPathButton.TabIndex = 12;
            this.openPathButton.Text = "...";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // importFilePathTextBox
            // 
            this.importFilePathTextBox.Location = new System.Drawing.Point(47, 371);
            this.importFilePathTextBox.Name = "importFilePathTextBox";
            this.importFilePathTextBox.Size = new System.Drawing.Size(162, 20);
            this.importFilePathTextBox.TabIndex = 13;
            // 
            // importSeriesFile
            // 
            this.importSeriesFile.Location = new System.Drawing.Point(255, 371);
            this.importSeriesFile.Name = "importSeriesFile";
            this.importSeriesFile.Size = new System.Drawing.Size(75, 23);
            this.importSeriesFile.TabIndex = 14;
            this.importSeriesFile.Text = "Tallenna";
            this.importSeriesFile.UseVisualStyleBackColor = true;
            this.importSeriesFile.Click += new System.EventHandler(this.importSeriesFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 274);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 20);
            this.textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(303, 274);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(115, 20);
            this.textBox3.TabIndex = 17;
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
            this.label3.Location = new System.Drawing.Point(300, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Paikkakunta:";
            // 
            // SeriesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 442);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.importSeriesFile);
            this.Controls.Add(this.importFilePathTextBox);
            this.Controls.Add(this.openPathButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SeriesList);
            this.Name = "SeriesListForm";
            this.Text = "SeriesListForm";
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView SeriesList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialogSeurat;
        private System.Windows.Forms.Button openPathButton;
        private System.Windows.Forms.TextBox importFilePathTextBox;
        private System.Windows.Forms.Button importSeriesFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BrightIdeasSoftware.OLVColumn lyhenne;
        private BrightIdeasSoftware.OLVColumn nimi;
        private BrightIdeasSoftware.OLVColumn paikkakunta;
    }
}