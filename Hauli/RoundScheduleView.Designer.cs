namespace Hauli
{
    partial class RoundScheduleView
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RoundTable = new BrightIdeasSoftware.ObjectListView();
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.kloColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rataColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.returnDefaultButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.actionsGroup = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundTable)).BeginInit();
            this.actionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(171, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 469);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RoundTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(661, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Päivä 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RoundTable
            // 
            this.RoundTable.AllColumns.Add(this.idColumn);
            this.RoundTable.AllColumns.Add(this.kloColumn);
            this.RoundTable.AllColumns.Add(this.rataColumn1);
            this.RoundTable.AllColumns.Add(this.rataColumn2);
            this.RoundTable.AllColumns.Add(this.rataColumn3);
            this.RoundTable.AllColumns.Add(this.rataColumn4);
            this.RoundTable.AllColumns.Add(this.rataColumn5);
            this.RoundTable.AllColumns.Add(this.rataColumn6);
            this.RoundTable.AllColumns.Add(this.rataColumn7);
            this.RoundTable.AllColumns.Add(this.rataColumn8);
            this.RoundTable.AllColumns.Add(this.rataColumn9);
            this.RoundTable.AllColumns.Add(this.rataColumn10);
            this.RoundTable.AllowDrop = true;
            this.RoundTable.AutoArrange = false;
            this.RoundTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.kloColumn,
            this.rataColumn1,
            this.rataColumn2,
            this.rataColumn3,
            this.rataColumn4,
            this.rataColumn5,
            this.rataColumn6,
            this.rataColumn7,
            this.rataColumn8,
            this.rataColumn9,
            this.rataColumn10});
            this.RoundTable.FullRowSelect = true;
            this.RoundTable.GridLines = true;
            this.RoundTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RoundTable.IsSimpleDragSource = true;
            this.RoundTable.IsSimpleDropSink = true;
            this.RoundTable.Location = new System.Drawing.Point(6, 3);
            this.RoundTable.Name = "RoundTable";
            this.RoundTable.OwnerDraw = true;
            this.RoundTable.Size = new System.Drawing.Size(650, 428);
            this.RoundTable.TabIndex = 0;
            this.RoundTable.UseCompatibleStateImageBehavior = false;
            this.RoundTable.UseTranslucentSelection = true;
            this.RoundTable.View = System.Windows.Forms.View.Details;
            // 
            // idColumn
            // 
            this.idColumn.IsEditable = false;
            this.idColumn.MaximumWidth = 0;
            this.idColumn.ShowTextInHeader = false;
            this.idColumn.Sortable = false;
            this.idColumn.Text = "id";
            this.idColumn.Width = 0;
            // 
            // kloColumn
            // 
            this.kloColumn.IsEditable = false;
            this.kloColumn.Text = "Klo";
            this.kloColumn.Width = 45;
            // 
            // rataColumn1
            // 
            this.rataColumn1.Text = "Rata 1";
            // 
            // rataColumn2
            // 
            this.rataColumn2.Text = "Rata 2";
            // 
            // rataColumn3
            // 
            this.rataColumn3.Text = "Rata 3";
            // 
            // rataColumn4
            // 
            this.rataColumn4.Text = "Rata 4";
            // 
            // rataColumn5
            // 
            this.rataColumn5.Text = "Rata 5";
            // 
            // rataColumn6
            // 
            this.rataColumn6.Text = "Rata 6";
            // 
            // rataColumn7
            // 
            this.rataColumn7.Text = "Rata 7";
            // 
            // rataColumn8
            // 
            this.rataColumn8.Text = "Rata 8";
            // 
            // rataColumn9
            // 
            this.rataColumn9.Text = "Rata 9";
            // 
            // rataColumn10
            // 
            this.rataColumn10.Text = "Rata 10";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(661, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Päivä 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // returnDefaultButton
            // 
            this.returnDefaultButton.Location = new System.Drawing.Point(17, 81);
            this.returnDefaultButton.Name = "returnDefaultButton";
            this.returnDefaultButton.Size = new System.Drawing.Size(93, 37);
            this.returnDefaultButton.TabIndex = 1;
            this.returnDefaultButton.Text = "Palauta oletusjärjestys";
            this.returnDefaultButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(17, 28);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(93, 37);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Tallenna";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // actionsGroup
            // 
            this.actionsGroup.Controls.Add(this.saveButton);
            this.actionsGroup.Controls.Add(this.returnDefaultButton);
            this.actionsGroup.Location = new System.Drawing.Point(12, 21);
            this.actionsGroup.Name = "actionsGroup";
            this.actionsGroup.Size = new System.Drawing.Size(128, 139);
            this.actionsGroup.TabIndex = 3;
            this.actionsGroup.TabStop = false;
            this.actionsGroup.Text = "Toiminnot";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(772, 492);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(68, 25);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Sulje";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // RoundScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 529);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.actionsGroup);
            this.Controls.Add(this.tabControl1);
            this.Name = "RoundScheduleView";
            this.Text = "Eräaikataulu";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoundTable)).EndInit();
            this.actionsGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button returnDefaultButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox actionsGroup;
        private System.Windows.Forms.Button closeButton;
        private BrightIdeasSoftware.ObjectListView RoundTable;
        private BrightIdeasSoftware.OLVColumn kloColumn;
        private BrightIdeasSoftware.OLVColumn rataColumn1;
        private BrightIdeasSoftware.OLVColumn rataColumn2;
        private BrightIdeasSoftware.OLVColumn rataColumn3;
        private BrightIdeasSoftware.OLVColumn rataColumn4;
        private BrightIdeasSoftware.OLVColumn rataColumn5;
        private BrightIdeasSoftware.OLVColumn rataColumn6;
        private BrightIdeasSoftware.OLVColumn rataColumn7;
        private BrightIdeasSoftware.OLVColumn rataColumn8;
        private BrightIdeasSoftware.OLVColumn rataColumn9;
        private BrightIdeasSoftware.OLVColumn rataColumn10;
        private BrightIdeasSoftware.OLVColumn idColumn;
    }
}