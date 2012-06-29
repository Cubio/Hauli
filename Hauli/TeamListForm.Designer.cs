namespace Hauli
{
    partial class TeamListForm
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
            this.saveSeurat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.kokoNimiTextBox = new System.Windows.Forms.TextBox();
            this.addSeura = new System.Windows.Forms.Button();
            this.SeriesList = new BrightIdeasSoftware.ObjectListView();
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.joukkueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).BeginInit();
            this.SuspendLayout();
            // 
            // saveSeurat
            // 
            this.saveSeurat.Location = new System.Drawing.Point(311, 300);
            this.saveSeurat.Name = "saveSeurat";
            this.saveSeurat.Size = new System.Drawing.Size(75, 23);
            this.saveSeurat.TabIndex = 31;
            this.saveSeurat.Text = "Tallenna";
            this.saveSeurat.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Joukkue :";
            // 
            // kokoNimiTextBox
            // 
            this.kokoNimiTextBox.Location = new System.Drawing.Point(110, 274);
            this.kokoNimiTextBox.Name = "kokoNimiTextBox";
            this.kokoNimiTextBox.Size = new System.Drawing.Size(236, 20);
            this.kokoNimiTextBox.TabIndex = 26;
            // 
            // addSeura
            // 
            this.addSeura.Location = new System.Drawing.Point(392, 300);
            this.addSeura.Name = "addSeura";
            this.addSeura.Size = new System.Drawing.Size(75, 23);
            this.addSeura.TabIndex = 24;
            this.addSeura.Text = "Lisää";
            this.addSeura.UseVisualStyleBackColor = true;
            // 
            // SeriesList
            // 
            this.SeriesList.AccessibleName = "SeriesList";
            this.SeriesList.AllColumns.Add(this.idColumn);
            this.SeriesList.AllColumns.Add(this.joukkueColumn);
            this.SeriesList.AllColumns.Add(this.buttonColumn);
            this.SeriesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeriesList.AutoArrange = false;
            this.SeriesList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.SeriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.joukkueColumn,
            this.buttonColumn});
            this.SeriesList.HasCollapsibleGroups = false;
            this.SeriesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SeriesList.Location = new System.Drawing.Point(12, 12);
            this.SeriesList.Name = "SeriesList";
            this.SeriesList.OwnerDraw = true;
            this.SeriesList.ShowGroups = false;
            this.SeriesList.Size = new System.Drawing.Size(455, 238);
            this.SeriesList.TabIndex = 23;
            this.SeriesList.UseCompatibleStateImageBehavior = false;
            this.SeriesList.View = System.Windows.Forms.View.Details;
            // 
            // idColumn
            // 
            this.idColumn.IsVisible = false;
            this.idColumn.Text = "ID";
            this.idColumn.Width = 0;
            // 
            // joukkueColumn
            // 
            this.joukkueColumn.Text = "Joukkue";
            this.joukkueColumn.Width = 96;
            // 
            // buttonColumn
            // 
            this.buttonColumn.Text = "";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(392, 329);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 32;
            this.Close.Text = "Sulje";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // TeamListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 439);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.saveSeurat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kokoNimiTextBox);
            this.Controls.Add(this.addSeura);
            this.Controls.Add(this.SeriesList);
            this.Name = "TeamListForm";
            this.Text = "TeamListForm";
            ((System.ComponentModel.ISupportInitialize)(this.SeriesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveSeurat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kokoNimiTextBox;
        private System.Windows.Forms.Button addSeura;
        private BrightIdeasSoftware.ObjectListView SeriesList;
        private BrightIdeasSoftware.OLVColumn idColumn;
        private BrightIdeasSoftware.OLVColumn joukkueColumn;
        private BrightIdeasSoftware.OLVColumn buttonColumn;
        private System.Windows.Forms.Button Close;
    }
}