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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContestantListForm));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.grabColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.seuraColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sarjaColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.joukkueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fillerColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.newContestantGroupBox = new System.Windows.Forms.GroupBox();
            this.joukkueComboBox = new System.Windows.Forms.ComboBox();
            this.sarjaComboBox = new System.Windows.Forms.ComboBox();
            this.seuraComboBox = new System.Windows.Forms.ComboBox();
            this.addContestantButton = new System.Windows.Forms.Button();
            this.sarjaLabel = new System.Windows.Forms.Label();
            this.joukkueLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.seuraLabel = new System.Windows.Forms.Label();
            this.reorderListGroupBox = new System.Windows.Forms.GroupBox();
            this.addNewRoundButton = new System.Windows.Forms.Button();
            this.addEmptyRowButton = new System.Windows.Forms.Button();
            this.addEmptyRowsButton = new System.Windows.Forms.Button();
            this.evenOutRounds = new System.Windows.Forms.Button();
            this.mixListOrderButton = new System.Windows.Forms.Button();
            this.contestantImportGroupBox = new System.Windows.Forms.GroupBox();
            this.importContestantsButton = new System.Windows.Forms.Button();
            this.openPathButton = new System.Windows.Forms.Button();
            this.importFilePathTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.avaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asetuksetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tulostuksetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogContestant = new System.Windows.Forms.OpenFileDialog();
            this.contestantRowContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editContestantItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContestantItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundDividerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hotColdItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDividerItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.newContestantGroupBox.SuspendLayout();
            this.reorderListGroupBox.SuspendLayout();
            this.contestantImportGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contestantRowContextMenuStrip.SuspendLayout();
            this.roundDividerContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.idColumn);
            this.objectListView1.AllColumns.Add(this.grabColumn);
            this.objectListView1.AllColumns.Add(this.nameColumn);
            this.objectListView1.AllColumns.Add(this.seuraColumn);
            this.objectListView1.AllColumns.Add(this.sarjaColumn);
            this.objectListView1.AllColumns.Add(this.joukkueColumn);
            this.objectListView1.AllColumns.Add(this.buttonColumn1);
            this.objectListView1.AllColumns.Add(this.buttonColumn2);
            this.objectListView1.AllColumns.Add(this.fillerColumn);
            this.objectListView1.AllowDrop = true;
            this.objectListView1.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.AutoArrange = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumn,
            this.grabColumn,
            this.nameColumn,
            this.seuraColumn,
            this.sarjaColumn,
            this.joukkueColumn,
            this.buttonColumn1,
            this.buttonColumn2,
            this.fillerColumn});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HasCollapsibleGroups = false;
            this.objectListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.objectListView1.IsSimpleDragSource = true;
            this.objectListView1.IsSimpleDropSink = true;
            this.objectListView1.Location = new System.Drawing.Point(249, 34);
            this.objectListView1.MultiSelect = false;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.RowHeight = 27;
            this.objectListView1.SelectAllOnControlA = false;
            this.objectListView1.ShowGroups = false;
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.Size = new System.Drawing.Size(493, 570);
            this.objectListView1.SmallImageList = this.imageList1;
            this.objectListView1.TabIndex = 4;
            this.objectListView1.TabStop = false;
            this.objectListView1.UseAlternatingBackColors = true;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseOverlays = false;
            this.objectListView1.UseTranslucentSelection = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellOver += new System.EventHandler<BrightIdeasSoftware.CellOverEventArgs>(this.objectListView1_CellOver);
            this.objectListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.objectListView1_CellRightClick);
            this.objectListView1.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.objectListView1_CellToolTipShowing);
            this.objectListView1.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.objectListView1_Dropped);
            this.objectListView1.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.objectListView1_FormatCell);
            this.objectListView1.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.objectListView1_FormatRow);
            this.objectListView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.objectListView1_ItemDrag);
            this.objectListView1.Click += new System.EventHandler(this.objectListView1_Click);
            this.objectListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objectListView1_MouseDoubleClick);
            this.objectListView1.MouseLeave += new System.EventHandler(this.objectListView1_MouseLeave);
            // 
            // idColumn
            // 
            this.idColumn.MaximumWidth = 0;
            this.idColumn.ShowTextInHeader = false;
            this.idColumn.Sortable = false;
            this.idColumn.Text = "";
            this.idColumn.Width = 0;
            // 
            // grabColumn
            // 
            this.grabColumn.MaximumWidth = 11;
            this.grabColumn.MinimumWidth = 11;
            this.grabColumn.ShowTextInHeader = false;
            this.grabColumn.Sortable = false;
            this.grabColumn.Text = "";
            this.grabColumn.Width = 11;
            // 
            // nameColumn
            // 
            this.nameColumn.Sortable = false;
            this.nameColumn.Text = "Nimi";
            this.nameColumn.Width = 150;
            this.nameColumn.WordWrap = true;
            // 
            // seuraColumn
            // 
            this.seuraColumn.Sortable = false;
            this.seuraColumn.Text = "Seura";
            // 
            // sarjaColumn
            // 
            this.sarjaColumn.Sortable = false;
            this.sarjaColumn.Text = "Sarja";
            // 
            // joukkueColumn
            // 
            this.joukkueColumn.Sortable = false;
            this.joukkueColumn.Text = "Joukkue";
            this.joukkueColumn.Width = 120;
            // 
            // buttonColumn1
            // 
            this.buttonColumn1.MaximumWidth = 20;
            this.buttonColumn1.MinimumWidth = 20;
            this.buttonColumn1.ShowTextInHeader = false;
            this.buttonColumn1.Sortable = false;
            this.buttonColumn1.Text = " ";
            this.buttonColumn1.Width = 20;
            // 
            // buttonColumn2
            // 
            this.buttonColumn2.MaximumWidth = 20;
            this.buttonColumn2.MinimumWidth = 20;
            this.buttonColumn2.ShowTextInHeader = false;
            this.buttonColumn2.Sortable = false;
            this.buttonColumn2.Text = " ";
            this.buttonColumn2.Width = 20;
            // 
            // fillerColumn
            // 
            this.fillerColumn.FillsFreeSpace = true;
            this.fillerColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fillerColumn.ShowTextInHeader = false;
            this.fillerColumn.Sortable = false;
            this.fillerColumn.Text = " ";
            this.fillerColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(62, 25);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(6, 28);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(41, 13);
            this.firstNameLabel.TabIndex = 6;
            this.firstNameLabel.Text = "Etunimi";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(6, 60);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(50, 13);
            this.lastNameLabel.TabIndex = 7;
            this.lastNameLabel.Text = "Sukunimi";
            // 
            // newContestantGroupBox
            // 
            this.newContestantGroupBox.Controls.Add(this.joukkueComboBox);
            this.newContestantGroupBox.Controls.Add(this.sarjaComboBox);
            this.newContestantGroupBox.Controls.Add(this.seuraComboBox);
            this.newContestantGroupBox.Controls.Add(this.addContestantButton);
            this.newContestantGroupBox.Controls.Add(this.sarjaLabel);
            this.newContestantGroupBox.Controls.Add(this.joukkueLabel);
            this.newContestantGroupBox.Controls.Add(this.lastNameTextBox);
            this.newContestantGroupBox.Controls.Add(this.seuraLabel);
            this.newContestantGroupBox.Controls.Add(this.firstNameLabel);
            this.newContestantGroupBox.Controls.Add(this.lastNameLabel);
            this.newContestantGroupBox.Controls.Add(this.firstNameTextBox);
            this.newContestantGroupBox.Location = new System.Drawing.Point(12, 73);
            this.newContestantGroupBox.Name = "newContestantGroupBox";
            this.newContestantGroupBox.Size = new System.Drawing.Size(218, 233);
            this.newContestantGroupBox.TabIndex = 8;
            this.newContestantGroupBox.TabStop = false;
            this.newContestantGroupBox.Text = "Lisää uusi osallistuja";
            // 
            // joukkueComboBox
            // 
            this.joukkueComboBox.FormattingEnabled = true;
            this.joukkueComboBox.Location = new System.Drawing.Point(62, 155);
            this.joukkueComboBox.Name = "joukkueComboBox";
            this.joukkueComboBox.Size = new System.Drawing.Size(135, 21);
            this.joukkueComboBox.TabIndex = 5;
            // 
            // sarjaComboBox
            // 
            this.sarjaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sarjaComboBox.FormattingEnabled = true;
            this.sarjaComboBox.Location = new System.Drawing.Point(62, 122);
            this.sarjaComboBox.Name = "sarjaComboBox";
            this.sarjaComboBox.Size = new System.Drawing.Size(44, 21);
            this.sarjaComboBox.TabIndex = 4;
            // 
            // seuraComboBox
            // 
            this.seuraComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.seuraComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.seuraComboBox.FormattingEnabled = true;
            this.seuraComboBox.Location = new System.Drawing.Point(62, 89);
            this.seuraComboBox.Name = "seuraComboBox";
            this.seuraComboBox.Size = new System.Drawing.Size(135, 21);
            this.seuraComboBox.TabIndex = 3;
            // 
            // addContestantButton
            // 
            this.addContestantButton.Location = new System.Drawing.Point(9, 192);
            this.addContestantButton.Name = "addContestantButton";
            this.addContestantButton.Size = new System.Drawing.Size(97, 23);
            this.addContestantButton.TabIndex = 6;
            this.addContestantButton.Text = "Lisää osallistuja";
            this.addContestantButton.UseVisualStyleBackColor = true;
            this.addContestantButton.Click += new System.EventHandler(this.addContestantButton_Click);
            // 
            // sarjaLabel
            // 
            this.sarjaLabel.AutoSize = true;
            this.sarjaLabel.Location = new System.Drawing.Point(6, 125);
            this.sarjaLabel.Name = "sarjaLabel";
            this.sarjaLabel.Size = new System.Drawing.Size(31, 13);
            this.sarjaLabel.TabIndex = 12;
            this.sarjaLabel.Text = "Sarja";
            // 
            // joukkueLabel
            // 
            this.joukkueLabel.AutoSize = true;
            this.joukkueLabel.Location = new System.Drawing.Point(6, 158);
            this.joukkueLabel.Name = "joukkueLabel";
            this.joukkueLabel.Size = new System.Drawing.Size(48, 13);
            this.joukkueLabel.TabIndex = 11;
            this.joukkueLabel.Text = "Joukkue";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(62, 57);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // seuraLabel
            // 
            this.seuraLabel.AutoSize = true;
            this.seuraLabel.Location = new System.Drawing.Point(6, 92);
            this.seuraLabel.Name = "seuraLabel";
            this.seuraLabel.Size = new System.Drawing.Size(35, 13);
            this.seuraLabel.TabIndex = 10;
            this.seuraLabel.Text = "Seura";
            // 
            // reorderListGroupBox
            // 
            this.reorderListGroupBox.Controls.Add(this.addNewRoundButton);
            this.reorderListGroupBox.Controls.Add(this.addEmptyRowButton);
            this.reorderListGroupBox.Controls.Add(this.addEmptyRowsButton);
            this.reorderListGroupBox.Controls.Add(this.evenOutRounds);
            this.reorderListGroupBox.Controls.Add(this.mixListOrderButton);
            this.reorderListGroupBox.Location = new System.Drawing.Point(12, 312);
            this.reorderListGroupBox.Name = "reorderListGroupBox";
            this.reorderListGroupBox.Size = new System.Drawing.Size(218, 204);
            this.reorderListGroupBox.TabIndex = 9;
            this.reorderListGroupBox.TabStop = false;
            this.reorderListGroupBox.Text = "Järjestä lista";
            // 
            // addNewRoundButton
            // 
            this.addNewRoundButton.Location = new System.Drawing.Point(20, 33);
            this.addNewRoundButton.Name = "addNewRoundButton";
            this.addNewRoundButton.Size = new System.Drawing.Size(173, 23);
            this.addNewRoundButton.TabIndex = 14;
            this.addNewRoundButton.TabStop = false;
            this.addNewRoundButton.Text = "Lisää erä";
            this.addNewRoundButton.UseVisualStyleBackColor = true;
            this.addNewRoundButton.Click += new System.EventHandler(this.addNewRoundButton_Click);
            // 
            // addEmptyRowButton
            // 
            this.addEmptyRowButton.Location = new System.Drawing.Point(20, 91);
            this.addEmptyRowButton.Name = "addEmptyRowButton";
            this.addEmptyRowButton.Size = new System.Drawing.Size(173, 23);
            this.addEmptyRowButton.TabIndex = 13;
            this.addEmptyRowButton.TabStop = false;
            this.addEmptyRowButton.Text = "Lisää jälki-ilmoittautumispaikka";
            this.addEmptyRowButton.UseVisualStyleBackColor = true;
            this.addEmptyRowButton.Click += new System.EventHandler(this.addEmptyRowButton_Click);
            // 
            // addEmptyRowsButton
            // 
            this.addEmptyRowsButton.Location = new System.Drawing.Point(20, 120);
            this.addEmptyRowsButton.Name = "addEmptyRowsButton";
            this.addEmptyRowsButton.Size = new System.Drawing.Size(173, 37);
            this.addEmptyRowsButton.TabIndex = 9;
            this.addEmptyRowsButton.TabStop = false;
            this.addEmptyRowsButton.Text = "Täytä vajaat erät jälki-ilmoittautumispaikoilla";
            this.addEmptyRowsButton.UseVisualStyleBackColor = true;
            this.addEmptyRowsButton.Click += new System.EventHandler(this.addEmptyRowsButton_Click);
            // 
            // evenOutRounds
            // 
            this.evenOutRounds.Location = new System.Drawing.Point(20, 62);
            this.evenOutRounds.Name = "evenOutRounds";
            this.evenOutRounds.Size = new System.Drawing.Size(173, 23);
            this.evenOutRounds.TabIndex = 8;
            this.evenOutRounds.TabStop = false;
            this.evenOutRounds.Text = "Tasaa erät";
            this.evenOutRounds.UseVisualStyleBackColor = true;
            this.evenOutRounds.Click += new System.EventHandler(this.evenOutRounds_Click);
            // 
            // mixListOrderButton
            // 
            this.mixListOrderButton.Location = new System.Drawing.Point(20, 163);
            this.mixListOrderButton.Name = "mixListOrderButton";
            this.mixListOrderButton.Size = new System.Drawing.Size(173, 24);
            this.mixListOrderButton.TabIndex = 7;
            this.mixListOrderButton.TabStop = false;
            this.mixListOrderButton.Text = "Sekoita järjestys";
            this.mixListOrderButton.UseVisualStyleBackColor = true;
            this.mixListOrderButton.Click += new System.EventHandler(this.mixListOrderButton_Click);
            // 
            // contestantImportGroupBox
            // 
            this.contestantImportGroupBox.Controls.Add(this.importContestantsButton);
            this.contestantImportGroupBox.Controls.Add(this.openPathButton);
            this.contestantImportGroupBox.Controls.Add(this.importFilePathTextBox);
            this.contestantImportGroupBox.Location = new System.Drawing.Point(12, 522);
            this.contestantImportGroupBox.Name = "contestantImportGroupBox";
            this.contestantImportGroupBox.Size = new System.Drawing.Size(218, 82);
            this.contestantImportGroupBox.TabIndex = 10;
            this.contestantImportGroupBox.TabStop = false;
            this.contestantImportGroupBox.Text = "Tuo osallistujia tiedostosta";
            // 
            // importContestantsButton
            // 
            this.importContestantsButton.Enabled = false;
            this.importContestantsButton.Location = new System.Drawing.Point(6, 49);
            this.importContestantsButton.Name = "importContestantsButton";
            this.importContestantsButton.Size = new System.Drawing.Size(97, 23);
            this.importContestantsButton.TabIndex = 12;
            this.importContestantsButton.TabStop = false;
            this.importContestantsButton.Text = "Lisää";
            this.importContestantsButton.UseVisualStyleBackColor = true;
            this.importContestantsButton.Click += new System.EventHandler(this.importContestantsButton_Click);
            // 
            // openPathButton
            // 
            this.openPathButton.Location = new System.Drawing.Point(174, 21);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(34, 23);
            this.openPathButton.TabIndex = 11;
            this.openPathButton.TabStop = false;
            this.openPathButton.Text = "...";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // importFilePathTextBox
            // 
            this.importFilePathTextBox.Location = new System.Drawing.Point(6, 23);
            this.importFilePathTextBox.Name = "importFilePathTextBox";
            this.importFilePathTextBox.Size = new System.Drawing.Size(162, 20);
            this.importFilePathTextBox.TabIndex = 10;
            this.importFilePathTextBox.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 34);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Tallenna";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(669, 613);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 14;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "Sulje";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avaaToolStripMenuItem,
            this.asetuksetToolStripMenuItem,
            this.tulostuksetToolStripMenuItem,
            this.ohjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // avaaToolStripMenuItem
            // 
            this.avaaToolStripMenuItem.Name = "avaaToolStripMenuItem";
            this.avaaToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.avaaToolStripMenuItem.Text = "Avaa";
            // 
            // asetuksetToolStripMenuItem
            // 
            this.asetuksetToolStripMenuItem.Name = "asetuksetToolStripMenuItem";
            this.asetuksetToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.asetuksetToolStripMenuItem.Text = "Asetukset";
            // 
            // tulostuksetToolStripMenuItem
            // 
            this.tulostuksetToolStripMenuItem.Name = "tulostuksetToolStripMenuItem";
            this.tulostuksetToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.tulostuksetToolStripMenuItem.Text = "Tulostukset";
            // 
            // ohjeToolStripMenuItem
            // 
            this.ohjeToolStripMenuItem.Name = "ohjeToolStripMenuItem";
            this.ohjeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ohjeToolStripMenuItem.Text = "Ohje";
            // 
            // openFileDialogContestant
            // 
            this.openFileDialogContestant.FileName = "openFileDialogContestant";
            this.openFileDialogContestant.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // contestantRowContextMenuStrip
            // 
            this.contestantRowContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editContestantItem,
            this.deleteContestantItem});
            this.contestantRowContextMenuStrip.Name = "contestantRowContextMenuStrip";
            this.contestantRowContextMenuStrip.Size = new System.Drawing.Size(185, 48);
            // 
            // editContestantItem
            // 
            this.editContestantItem.Name = "editContestantItem";
            this.editContestantItem.Size = new System.Drawing.Size(184, 22);
            this.editContestantItem.Text = "Muokkaa osallistujaa";
            // 
            // deleteContestantItem
            // 
            this.deleteContestantItem.Name = "deleteContestantItem";
            this.deleteContestantItem.Size = new System.Drawing.Size(184, 22);
            this.deleteContestantItem.Text = "Poista osallistuja";
            this.deleteContestantItem.Click += new System.EventHandler(this.deleteContestantItem_Click);
            // 
            // roundDividerContextMenuStrip
            // 
            this.roundDividerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotColdItem,
            this.deleteDividerItem});
            this.roundDividerContextMenuStrip.Name = "roundDividerContextMenuStrip";
            this.roundDividerContextMenuStrip.Size = new System.Drawing.Size(249, 48);
            // 
            // hotColdItem
            // 
            this.hotColdItem.Name = "hotColdItem";
            this.hotColdItem.Size = new System.Drawing.Size(248, 22);
            this.hotColdItem.Text = "Muuta erä kuumaksi/normaaliksi";
            // 
            // deleteDividerItem
            // 
            this.deleteDividerItem.Name = "deleteDividerItem";
            this.deleteDividerItem.Size = new System.Drawing.Size(248, 22);
            this.deleteDividerItem.Text = "Poista erä";
            // 
            // ContestantListForm
            // 
            this.AcceptButton = this.addContestantButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 643);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.contestantImportGroupBox);
            this.Controls.Add(this.reorderListGroupBox);
            this.Controls.Add(this.newContestantGroupBox);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(606, 604);
            this.Name = "ContestantListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContestantListForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContestantListForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.newContestantGroupBox.ResumeLayout(false);
            this.newContestantGroupBox.PerformLayout();
            this.reorderListGroupBox.ResumeLayout(false);
            this.contestantImportGroupBox.ResumeLayout(false);
            this.contestantImportGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contestantRowContextMenuStrip.ResumeLayout(false);
            this.roundDividerContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn seuraColumn;
        private BrightIdeasSoftware.OLVColumn sarjaColumn;
        private BrightIdeasSoftware.OLVColumn joukkueColumn;
        private BrightIdeasSoftware.OLVColumn idColumn;
        private BrightIdeasSoftware.OLVColumn fillerColumn;
        private BrightIdeasSoftware.OLVColumn buttonColumn1;
        private BrightIdeasSoftware.OLVColumn buttonColumn2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.GroupBox newContestantGroupBox;
        private System.Windows.Forms.Label sarjaLabel;
        private System.Windows.Forms.Label joukkueLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label seuraLabel;
        private System.Windows.Forms.ComboBox sarjaComboBox;
        private System.Windows.Forms.ComboBox seuraComboBox;
        private System.Windows.Forms.Button addContestantButton;
        private System.Windows.Forms.GroupBox reorderListGroupBox;
        private System.Windows.Forms.Button evenOutRounds;
        private System.Windows.Forms.Button mixListOrderButton;
        private System.Windows.Forms.GroupBox contestantImportGroupBox;
        private System.Windows.Forms.Button importContestantsButton;
        private System.Windows.Forms.Button openPathButton;
        private System.Windows.Forms.TextBox importFilePathTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox joukkueComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem avaaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asetuksetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tulostuksetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ohjeToolStripMenuItem;
        private System.Windows.Forms.Button addEmptyRowsButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogContestant;
        private BrightIdeasSoftware.OLVColumn grabColumn;
        private System.Windows.Forms.Button addEmptyRowButton;
        private System.Windows.Forms.Button addNewRoundButton;
        private System.Windows.Forms.ContextMenuStrip contestantRowContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editContestantItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContestantItem;
        private System.Windows.Forms.ContextMenuStrip roundDividerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem hotColdItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDividerItem;
    }
}