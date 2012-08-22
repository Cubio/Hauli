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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamListForm));
            this.saveTeam = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.joukkueTextBox = new System.Windows.Forms.TextBox();
            this.addTeam = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TeamsList = new BrightIdeasSoftware.ObjectListView();
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.teamColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveTeam
            // 
            this.saveTeam.Location = new System.Drawing.Point(122, 76);
            this.saveTeam.Name = "saveTeam";
            this.saveTeam.Size = new System.Drawing.Size(60, 23);
            this.saveTeam.TabIndex = 3;
            this.saveTeam.Text = "Tallenna";
            this.saveTeam.UseVisualStyleBackColor = true;
            this.saveTeam.Click += new System.EventHandler(this.saveTeam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Joukkue";
            // 
            // joukkueTextBox
            // 
            this.joukkueTextBox.Location = new System.Drawing.Point(60, 19);
            this.joukkueTextBox.Name = "joukkueTextBox";
            this.joukkueTextBox.Size = new System.Drawing.Size(122, 20);
            this.joukkueTextBox.TabIndex = 1;
            // 
            // addTeam
            // 
            this.addTeam.Location = new System.Drawing.Point(188, 17);
            this.addTeam.Name = "addTeam";
            this.addTeam.Size = new System.Drawing.Size(60, 23);
            this.addTeam.TabIndex = 2;
            this.addTeam.Text = "Lisää";
            this.addTeam.UseVisualStyleBackColor = true;
            this.addTeam.Click += new System.EventHandler(this.addTeam_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(188, 76);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(60, 23);
            this.Close.TabIndex = 4;
            this.Close.Text = "Sulje";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
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
            // TeamsList
            // 
            this.TeamsList.AccessibleName = "TeamsList";
            this.TeamsList.AllColumns.Add(this.idColumn);
            this.TeamsList.AllColumns.Add(this.teamColumn);
            this.TeamsList.AllColumns.Add(this.buttonColumn);
            this.TeamsList.AutoArrange = false;
            this.TeamsList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.TeamsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.teamColumn,
            this.buttonColumn});
            this.TeamsList.FullRowSelect = true;
            this.TeamsList.HasCollapsibleGroups = false;
            this.TeamsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TeamsList.Location = new System.Drawing.Point(12, 12);
            this.TeamsList.Name = "TeamsList";
            this.TeamsList.OwnerDraw = true;
            this.TeamsList.ShowGroups = false;
            this.TeamsList.Size = new System.Drawing.Size(258, 231);
            this.TeamsList.SmallImageList = this.imageList1;
            this.TeamsList.TabIndex = 34;
            this.TeamsList.UseCompatibleStateImageBehavior = false;
            this.TeamsList.UseTranslucentSelection = true;
            this.TeamsList.View = System.Windows.Forms.View.Details;
            this.TeamsList.Click += new System.EventHandler(this.TeamList_Click);
            // 
            // idColumn
            // 
            this.idColumn.IsVisible = false;
            this.idColumn.Text = "ID";
            this.idColumn.Width = 0;
            // 
            // teamColumn
            // 
            this.teamColumn.Text = "Joukkue";
            this.teamColumn.Width = 198;
            // 
            // buttonColumn
            // 
            this.buttonColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonColumn.Text = "";
            this.buttonColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonColumn.Width = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Close);
            this.groupBox1.Controls.Add(this.saveTeam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.joukkueTextBox);
            this.groupBox1.Controls.Add(this.addTeam);
            this.groupBox1.Location = new System.Drawing.Point(15, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 105);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // TeamListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TeamsList);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(290, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 400);
            this.Name = "TeamListForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Joukkueiden muokkaus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeamListForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TeamsList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveTeam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox joukkueTextBox;
        private System.Windows.Forms.Button addTeam;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.ObjectListView TeamsList;
        private BrightIdeasSoftware.OLVColumn idColumn;
        private BrightIdeasSoftware.OLVColumn teamColumn;
        private BrightIdeasSoftware.OLVColumn buttonColumn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}