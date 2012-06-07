namespace Hauli
{
    partial class ContestantListForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.contestantObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.round = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.seuraColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sarjaColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.joukkueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.contestantObjectListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(215, 404);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(604, 154);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contestantObjectListView
            // 
            this.contestantObjectListView.AllColumns.Add(this.round);
            this.contestantObjectListView.AllColumns.Add(this.olvColumn1);
            this.contestantObjectListView.AllColumns.Add(this.olvColumn2);
            this.contestantObjectListView.AllColumns.Add(this.olvColumn3);
            this.contestantObjectListView.AllColumns.Add(this.olvColumn4);
            this.contestantObjectListView.AllowDrop = true;
            this.contestantObjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contestantObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.round,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.contestantObjectListView.FullRowSelect = true;
            this.contestantObjectListView.HasCollapsibleGroups = false;
            this.contestantObjectListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.contestantObjectListView.IsSimpleDragSource = true;
            this.contestantObjectListView.IsSimpleDropSink = true;
            this.contestantObjectListView.Location = new System.Drawing.Point(569, 12);
            this.contestantObjectListView.Name = "contestantObjectListView";
            this.contestantObjectListView.ShowGroups = false;
            this.contestantObjectListView.Size = new System.Drawing.Size(250, 371);
            this.contestantObjectListView.TabIndex = 3;
            this.contestantObjectListView.UseCompatibleStateImageBehavior = false;
            this.contestantObjectListView.View = System.Windows.Forms.View.Details;
            this.contestantObjectListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.contestantObjectListView_DragDrop);
            // 
            // round
            // 
            this.round.AspectName = "Round";
            this.round.IsEditable = false;
            this.round.IsVisible = false;
            this.round.Width = 0;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Sortable = false;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Occupation";
            this.olvColumn2.Sortable = false;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "CulinaryRating";
            this.olvColumn3.Sortable = false;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "YearOfBirth";
            this.olvColumn4.Sortable = false;
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.nameColumn);
            this.objectListView1.AllColumns.Add(this.seuraColumn);
            this.objectListView1.AllColumns.Add(this.sarjaColumn);
            this.objectListView1.AllColumns.Add(this.joukkueColumn);
            this.objectListView1.AllowDrop = true;
            this.objectListView1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.objectListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.seuraColumn,
            this.sarjaColumn,
            this.joukkueColumn});
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HasCollapsibleGroups = false;
            this.objectListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.objectListView1.IsSimpleDragSource = true;
            this.objectListView1.IsSimpleDropSink = true;
            this.objectListView1.Location = new System.Drawing.Point(215, 12);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(348, 371);
            this.objectListView1.TabIndex = 4;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // ContestantListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 570);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.contestantObjectListView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "ContestantListForm";
            this.Text = "ContestantListForm";
            ((System.ComponentModel.ISupportInitialize)(this.contestantObjectListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private BrightIdeasSoftware.ObjectListView contestantObjectListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn round;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn seuraColumn;
        private BrightIdeasSoftware.OLVColumn sarjaColumn;
        private BrightIdeasSoftware.OLVColumn joukkueColumn;
    }
}