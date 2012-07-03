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
            ((System.ComponentModel.ISupportInitialize)(this.TeamsList)).BeginInit();
            this.SuspendLayout();
            // 
            // saveTeam
            // 
            this.saveTeam.Location = new System.Drawing.Point(113, 305);
            this.saveTeam.Name = "saveTeam";
            this.saveTeam.Size = new System.Drawing.Size(75, 23);
            this.saveTeam.TabIndex = 31;
            this.saveTeam.Text = "Tallenna";
            this.saveTeam.UseVisualStyleBackColor = true;
            this.saveTeam.Click += new System.EventHandler(this.saveTeam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Joukkue :";
            // 
            // joukkueTextBox
            // 
            this.joukkueTextBox.Location = new System.Drawing.Point(12, 279);
            this.joukkueTextBox.Name = "joukkueTextBox";
            this.joukkueTextBox.Size = new System.Drawing.Size(257, 20);
            this.joukkueTextBox.TabIndex = 1;
            // 
            // addTeam
            // 
            this.addTeam.Location = new System.Drawing.Point(194, 305);
            this.addTeam.Name = "addTeam";
            this.addTeam.Size = new System.Drawing.Size(75, 23);
            this.addTeam.TabIndex = 2;
            this.addTeam.Text = "Lisää";
            this.addTeam.UseVisualStyleBackColor = true;
            this.addTeam.Click += new System.EventHandler(this.addTeam_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(194, 334);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 32;
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
            this.TeamsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeamsList.AutoArrange = false;
            this.TeamsList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.TeamsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.teamColumn,
            this.buttonColumn});
            this.TeamsList.HasCollapsibleGroups = false;
            this.TeamsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TeamsList.Location = new System.Drawing.Point(12, 12);
            this.TeamsList.Name = "TeamsList";
            this.TeamsList.OwnerDraw = true;
            this.TeamsList.ShowGroups = false;
            this.TeamsList.Size = new System.Drawing.Size(257, 245);
            this.TeamsList.SmallImageList = this.imageList1;
            this.TeamsList.TabIndex = 34;
            this.TeamsList.UseCompatibleStateImageBehavior = false;
            this.TeamsList.View = System.Windows.Forms.View.Details;
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
            this.teamColumn.Width = 96;
            // 
            // buttonColumn
            // 
            this.buttonColumn.Text = "";
            // 
            // TeamListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 380);
            this.Controls.Add(this.TeamsList);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.saveTeam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.joukkueTextBox);
            this.Controls.Add(this.addTeam);
            this.Name = "TeamListForm";
            this.Text = "TeamListForm";
            ((System.ComponentModel.ISupportInitialize)(this.TeamsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}