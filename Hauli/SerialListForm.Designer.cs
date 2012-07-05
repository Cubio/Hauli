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
            ((System.ComponentModel.ISupportInitialize)(this.SerialList)).BeginInit();
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
            this.buttonColumn.Text = "";
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(194, 334);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 38;
            this.Close.Text = "Sulje";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // serialColumn
            // 
            this.serialColumn.Text = "Sarja";
            this.serialColumn.Width = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Sarja :";
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
            this.saveTeam.Location = new System.Drawing.Point(113, 305);
            this.saveTeam.Name = "saveTeam";
            this.saveTeam.Size = new System.Drawing.Size(75, 23);
            this.saveTeam.TabIndex = 4;
            this.saveTeam.Text = "Tallenna";
            this.saveTeam.UseVisualStyleBackColor = true;
            this.saveTeam.Click += new System.EventHandler(this.saveTeam_Click);
            // 
            // serialTextBox
            // 
            this.serialTextBox.Location = new System.Drawing.Point(12, 279);
            this.serialTextBox.Name = "serialTextBox";
            this.serialTextBox.Size = new System.Drawing.Size(257, 20);
            this.serialTextBox.TabIndex = 1;
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
            // SerialList
            // 
            this.SerialList.AccessibleName = "SerialList";
            this.SerialList.AllColumns.Add(this.idColumn);
            this.SerialList.AllColumns.Add(this.serialColumn);
            this.SerialList.AllColumns.Add(this.buttonColumn);
            this.SerialList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SerialList.AutoArrange = false;
            this.SerialList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.SerialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.serialColumn,
            this.buttonColumn});
            this.SerialList.HasCollapsibleGroups = false;
            this.SerialList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SerialList.Location = new System.Drawing.Point(12, 12);
            this.SerialList.Name = "SerialList";
            this.SerialList.OwnerDraw = true;
            this.SerialList.ShowGroups = false;
            this.SerialList.Size = new System.Drawing.Size(257, 245);
            this.SerialList.SmallImageList = this.imageList1;
            this.SerialList.TabIndex = 33;
            this.SerialList.UseCompatibleStateImageBehavior = false;
            this.SerialList.View = System.Windows.Forms.View.Details;
            // 
            // SerialListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 366);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveTeam);
            this.Controls.Add(this.serialTextBox);
            this.Controls.Add(this.addTeam);
            this.Controls.Add(this.SerialList);
            this.Name = "SerialListForm";
            this.Text = "SerialListForm";
            ((System.ComponentModel.ISupportInitialize)(this.SerialList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}