namespace Hauli
{
    partial class SerialListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialListForm));
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Close = new System.Windows.Forms.Button();
            this.serialColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveTeam = new System.Windows.Forms.Button();
            this.serialTextBox = new System.Windows.Forms.TextBox();
            this.addTeam = new System.Windows.Forms.Button();
            this.SerialList = new BrightIdeasSoftware.ObjectListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.SerialList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idColumn
            // 
            this.idColumn.IsVisible = false;
            this.idColumn.Text = "ID";
            this.idColumn.Width = 0;
            // 
            // buttonColumn
            // 
            this.buttonColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonColumn.Text = "";
            this.buttonColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonColumn.Width = 28;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(189, 76);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(61, 23);
            this.Close.TabIndex = 4;
            this.Close.Text = "Sulje";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // serialColumn
            // 
            this.serialColumn.Text = "Sarja";
            this.serialColumn.Width = 203;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Sarja";
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
            // saveTeam
            // 
            this.saveTeam.Location = new System.Drawing.Point(122, 76);
            this.saveTeam.Name = "saveTeam";
            this.saveTeam.Size = new System.Drawing.Size(61, 23);
            this.saveTeam.TabIndex = 3;
            this.saveTeam.Text = "Tallenna";
            this.saveTeam.UseVisualStyleBackColor = true;
            this.saveTeam.Click += new System.EventHandler(this.saveTeam_Click);
            // 
            // serialTextBox
            // 
            this.serialTextBox.Location = new System.Drawing.Point(40, 21);
            this.serialTextBox.Name = "serialTextBox";
            this.serialTextBox.Size = new System.Drawing.Size(139, 20);
            this.serialTextBox.TabIndex = 1;
            // 
            // addTeam
            // 
            this.addTeam.Location = new System.Drawing.Point(185, 19);
            this.addTeam.Name = "addTeam";
            this.addTeam.Size = new System.Drawing.Size(61, 23);
            this.addTeam.TabIndex = 2;
            this.addTeam.Text = "Lisää";
            this.addTeam.UseVisualStyleBackColor = true;
            this.addTeam.Click += new System.EventHandler(this.addTeam_Click);
            // 
            // SerialList
            // 
            this.SerialList.AccessibleName = "SerialList";
            this.SerialList.AllColumns.Add(this.idColumn);
            this.SerialList.AllColumns.Add(this.serialColumn);
            this.SerialList.AllColumns.Add(this.buttonColumn);
            this.SerialList.AutoArrange = false;
            this.SerialList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.SerialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.serialColumn,
            this.buttonColumn});
            this.SerialList.FullRowSelect = true;
            this.SerialList.HasCollapsibleGroups = false;
            this.SerialList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SerialList.Location = new System.Drawing.Point(12, 12);
            this.SerialList.Name = "SerialList";
            this.SerialList.OwnerDraw = true;
            this.SerialList.ShowGroups = false;
            this.SerialList.Size = new System.Drawing.Size(258, 231);
            this.SerialList.SmallImageList = this.imageList1;
            this.SerialList.StateImageList = this.imageList1;
            this.SerialList.TabIndex = 33;
            this.SerialList.UseCompatibleStateImageBehavior = false;
            this.SerialList.UseTranslucentSelection = true;
            this.SerialList.View = System.Windows.Forms.View.Details;
            this.SerialList.Click += new System.EventHandler(this.SerialList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Close);
            this.groupBox1.Controls.Add(this.saveTeam);
            this.groupBox1.Controls.Add(this.serialTextBox);
            this.groupBox1.Controls.Add(this.addTeam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 105);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // SerialListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 366);
            this.Controls.Add(this.SerialList);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(290, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 400);
            this.Name = "SerialListForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sarjojen muokkaus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SerialListForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SerialList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn idColumn;
        private BrightIdeasSoftware.OLVColumn buttonColumn;
        private System.Windows.Forms.Button Close;
        private BrightIdeasSoftware.OLVColumn serialColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button saveTeam;
        private System.Windows.Forms.TextBox serialTextBox;
        private System.Windows.Forms.Button addTeam;
        private BrightIdeasSoftware.ObjectListView SerialList;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}