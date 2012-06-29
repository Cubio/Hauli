namespace Hauli
{
    partial class ScoreInputView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EräComboBox = new System.Windows.Forms.ComboBox();
            this.scoreNormal = new BrightIdeasSoftware.ObjectListView();
            this.nro = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lastname = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.round_25 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.round_50 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.round_75 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.round_100 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.round_125 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.solving = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ScoreFinal = new BrightIdeasSoftware.ObjectListView();
            this.nroFinaali = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameFinal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lastnameFinal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.scoreFinal25 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.solvingFinal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.sarjaComboBox = new System.Windows.Forms.ComboBox();
            this.scores = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreNormal)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreFinal)).BeginInit();
            this.scores.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.scores);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 607);
            this.splitContainer1.SplitterDistance = 597;
            this.splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 564);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Peruuta";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 564);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tallenna";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EräComboBox);
            this.groupBox1.Controls.Add(this.scoreNormal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 257);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kilpailun pisteytys";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Erä";
            // 
            // EräComboBox
            // 
            this.EräComboBox.FormattingEnabled = true;
            this.EräComboBox.Location = new System.Drawing.Point(6, 30);
            this.EräComboBox.Name = "EräComboBox";
            this.EräComboBox.Size = new System.Drawing.Size(121, 21);
            this.EräComboBox.TabIndex = 2;
            // 
            // scoreNormal
            // 
            this.scoreNormal.AllColumns.Add(this.nro);
            this.scoreNormal.AllColumns.Add(this.name);
            this.scoreNormal.AllColumns.Add(this.lastname);
            this.scoreNormal.AllColumns.Add(this.round_25);
            this.scoreNormal.AllColumns.Add(this.round_50);
            this.scoreNormal.AllColumns.Add(this.round_75);
            this.scoreNormal.AllColumns.Add(this.round_100);
            this.scoreNormal.AllColumns.Add(this.round_125);
            this.scoreNormal.AllColumns.Add(this.solving);
            this.scoreNormal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nro,
            this.name,
            this.lastname,
            this.round_25,
            this.round_50,
            this.round_75,
            this.round_100,
            this.round_125,
            this.solving});
            this.scoreNormal.Location = new System.Drawing.Point(6, 57);
            this.scoreNormal.Name = "scoreNormal";
            this.scoreNormal.Size = new System.Drawing.Size(558, 181);
            this.scoreNormal.TabIndex = 0;
            this.scoreNormal.UseCompatibleStateImageBehavior = false;
            this.scoreNormal.View = System.Windows.Forms.View.Details;
            // 
            // nro
            // 
            this.nro.Text = "Nro";
            // 
            // name
            // 
            this.name.Text = "Nimi";
            // 
            // lastname
            // 
            this.lastname.Text = "Sukunimi";
            // 
            // round_25
            // 
            this.round_25.Text = "25";
            this.round_25.Width = 73;
            // 
            // round_50
            // 
            this.round_50.Text = "50";
            // 
            // round_75
            // 
            this.round_75.Text = "75";
            // 
            // round_100
            // 
            this.round_100.Text = "100";
            // 
            // round_125
            // 
            this.round_125.Text = "125";
            // 
            // solving
            // 
            this.solving.Text = "Ratkonta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ScoreFinal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.sarjaComboBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 254);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finaalin pisteytys";
            // 
            // ScoreFinal
            // 
            this.ScoreFinal.AllColumns.Add(this.nroFinaali);
            this.ScoreFinal.AllColumns.Add(this.nameFinal);
            this.ScoreFinal.AllColumns.Add(this.lastnameFinal);
            this.ScoreFinal.AllColumns.Add(this.scoreFinal25);
            this.ScoreFinal.AllColumns.Add(this.solvingFinal);
            this.ScoreFinal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nroFinaali,
            this.nameFinal,
            this.lastnameFinal,
            this.scoreFinal25,
            this.solvingFinal});
            this.ScoreFinal.Location = new System.Drawing.Point(6, 57);
            this.ScoreFinal.Name = "ScoreFinal";
            this.ScoreFinal.Size = new System.Drawing.Size(558, 176);
            this.ScoreFinal.TabIndex = 1;
            this.ScoreFinal.UseCompatibleStateImageBehavior = false;
            this.ScoreFinal.View = System.Windows.Forms.View.Details;
            // 
            // nroFinaali
            // 
            this.nroFinaali.Text = "NroFinaali";
            // 
            // nameFinal
            // 
            this.nameFinal.Text = "Nimi";
            // 
            // lastnameFinal
            // 
            this.lastnameFinal.Text = "Sukunimi";
            // 
            // scoreFinal25
            // 
            this.scoreFinal25.Text = "Tulokset";
            this.scoreFinal25.Width = 73;
            // 
            // solvingFinal
            // 
            this.solvingFinal.Text = "Ratkonta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sarja";
            // 
            // sarjaComboBox
            // 
            this.sarjaComboBox.FormattingEnabled = true;
            this.sarjaComboBox.Location = new System.Drawing.Point(6, 30);
            this.sarjaComboBox.Name = "sarjaComboBox";
            this.sarjaComboBox.Size = new System.Drawing.Size(121, 21);
            this.sarjaComboBox.TabIndex = 2;
            // 
            // scores
            // 
            this.scores.Controls.Add(this.tabPage1);
            this.scores.Controls.Add(this.tabPage2);
            this.scores.Location = new System.Drawing.Point(147, 51);
            this.scores.Name = "scores";
            this.scores.SelectedIndex = 0;
            this.scores.Size = new System.Drawing.Size(388, 505);
            this.scores.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(380, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(380, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ScoreInputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 607);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ScoreInputView";
            this.Text = "scoreInputView";
            this.Load += new System.EventHandler(this.scoreInputView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scoreNormal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreFinal)).EndInit();
            this.scores.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EräComboBox;
        private BrightIdeasSoftware.ObjectListView scoreNormal;
        private BrightIdeasSoftware.OLVColumn nro;
        private BrightIdeasSoftware.OLVColumn name;
        private BrightIdeasSoftware.OLVColumn lastname;
        private BrightIdeasSoftware.OLVColumn round_25;
        private BrightIdeasSoftware.OLVColumn round_50;
        private BrightIdeasSoftware.OLVColumn round_75;
        private BrightIdeasSoftware.OLVColumn round_100;
        private BrightIdeasSoftware.OLVColumn round_125;
        private BrightIdeasSoftware.OLVColumn solving;
        private System.Windows.Forms.GroupBox groupBox2;
        private BrightIdeasSoftware.ObjectListView ScoreFinal;
        private BrightIdeasSoftware.OLVColumn nroFinaali;
        private BrightIdeasSoftware.OLVColumn nameFinal;
        private BrightIdeasSoftware.OLVColumn lastnameFinal;
        private BrightIdeasSoftware.OLVColumn scoreFinal25;
        private BrightIdeasSoftware.OLVColumn solvingFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sarjaComboBox;
        private System.Windows.Forms.TabControl scores;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}