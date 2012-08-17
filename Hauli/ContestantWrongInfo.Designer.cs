namespace Hauli
{
    partial class ContestantWrongInfo
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
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lastnameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.seuraColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sarjaColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.nameColumn);
            this.objectListView1.AllColumns.Add(this.lastnameColumn);
            this.objectListView1.AllColumns.Add(this.seuraColumn);
            this.objectListView1.AllColumns.Add(this.sarjaColumn);
            this.objectListView1.AutoArrange = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.lastnameColumn,
            this.seuraColumn,
            this.sarjaColumn});
            this.objectListView1.HasCollapsibleGroups = false;
            this.objectListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.objectListView1.Location = new System.Drawing.Point(12, 12);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.OwnerDrawnHeader = true;
            this.objectListView1.RenderNonEditableCheckboxesAsDisabled = true;
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(492, 205);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvCellEditStarting);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Nimi";
            // 
            // lastnameColumn
            // 
            this.lastnameColumn.Text = "Sukunimi";
            // 
            // seuraColumn
            // 
            this.seuraColumn.Text = "Seura";
            // 
            // sarjaColumn
            // 
            this.sarjaColumn.Text = "Sarja";
            // 
            // ContestantWrongInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 312);
            this.Controls.Add(this.objectListView1);
            this.Name = "ContestantWrongInfo";
            this.Text = "ContestantWrongInfo";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn lastnameColumn;
        private BrightIdeasSoftware.OLVColumn seuraColumn;
        private BrightIdeasSoftware.OLVColumn sarjaColumn;
    }
}