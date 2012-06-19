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
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialogSeurat = new System.Windows.Forms.OpenFileDialog();
            this.openPathButton = new System.Windows.Forms.Button();
            this.importFilePathTextBox = new System.Windows.Forms.TextBox();
            this.importSeriesFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.Location = new System.Drawing.Point(136, 12);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(429, 238);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 256);
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
            this.openPathButton.Location = new System.Drawing.Point(320, 370);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(34, 23);
            this.openPathButton.TabIndex = 12;
            this.openPathButton.Text = "...";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // importFilePathTextBox
            // 
            this.importFilePathTextBox.Location = new System.Drawing.Point(152, 370);
            this.importFilePathTextBox.Name = "importFilePathTextBox";
            this.importFilePathTextBox.Size = new System.Drawing.Size(162, 20);
            this.importFilePathTextBox.TabIndex = 13;
            // 
            // importSeriesFile
            // 
            this.importSeriesFile.Location = new System.Drawing.Point(360, 370);
            this.importSeriesFile.Name = "importSeriesFile";
            this.importSeriesFile.Size = new System.Drawing.Size(75, 23);
            this.importSeriesFile.TabIndex = 14;
            this.importSeriesFile.Text = "Tallenna";
            this.importSeriesFile.UseVisualStyleBackColor = true;
            this.importSeriesFile.Click += new System.EventHandler(this.importSeriesFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 256);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 15;
            // 
            // SeriesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 483);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.importSeriesFile);
            this.Controls.Add(this.importFilePathTextBox);
            this.Controls.Add(this.openPathButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.objectListView1);
            this.Name = "SeriesListForm";
            this.Text = "SeriesListForm";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialogSeurat;
        private System.Windows.Forms.Button openPathButton;
        private System.Windows.Forms.TextBox importFilePathTextBox;
        private System.Windows.Forms.Button importSeriesFile;
        private System.Windows.Forms.TextBox textBox1;
    }
}