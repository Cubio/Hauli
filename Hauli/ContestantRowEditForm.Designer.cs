namespace Hauli
{
    partial class ContestantRowEditForm
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
            this.joukkueComboBox = new System.Windows.Forms.ComboBox();
            this.sarjaComboBox = new System.Windows.Forms.ComboBox();
            this.seuraComboBox = new System.Windows.Forms.ComboBox();
            this.sarjaLabel = new System.Windows.Forms.Label();
            this.joukkueLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.seuraLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // joukkueComboBox
            // 
            this.joukkueComboBox.FormattingEnabled = true;
            this.joukkueComboBox.Location = new System.Drawing.Point(68, 142);
            this.joukkueComboBox.Name = "joukkueComboBox";
            this.joukkueComboBox.Size = new System.Drawing.Size(135, 21);
            this.joukkueComboBox.TabIndex = 17;
            // 
            // sarjaComboBox
            // 
            this.sarjaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sarjaComboBox.FormattingEnabled = true;
            this.sarjaComboBox.Location = new System.Drawing.Point(68, 109);
            this.sarjaComboBox.Name = "sarjaComboBox";
            this.sarjaComboBox.Size = new System.Drawing.Size(43, 21);
            this.sarjaComboBox.TabIndex = 16;
            // 
            // seuraComboBox
            // 
            this.seuraComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.seuraComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.seuraComboBox.FormattingEnabled = true;
            this.seuraComboBox.Location = new System.Drawing.Point(68, 76);
            this.seuraComboBox.Name = "seuraComboBox";
            this.seuraComboBox.Size = new System.Drawing.Size(135, 21);
            this.seuraComboBox.TabIndex = 15;
            // 
            // sarjaLabel
            // 
            this.sarjaLabel.AutoSize = true;
            this.sarjaLabel.Location = new System.Drawing.Point(12, 112);
            this.sarjaLabel.Name = "sarjaLabel";
            this.sarjaLabel.Size = new System.Drawing.Size(31, 13);
            this.sarjaLabel.TabIndex = 22;
            this.sarjaLabel.Text = "Sarja";
            // 
            // joukkueLabel
            // 
            this.joukkueLabel.AutoSize = true;
            this.joukkueLabel.Location = new System.Drawing.Point(12, 145);
            this.joukkueLabel.Name = "joukkueLabel";
            this.joukkueLabel.Size = new System.Drawing.Size(48, 13);
            this.joukkueLabel.TabIndex = 21;
            this.joukkueLabel.Text = "Joukkue";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(68, 44);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.lastNameTextBox.TabIndex = 14;
            // 
            // seuraLabel
            // 
            this.seuraLabel.AutoSize = true;
            this.seuraLabel.Location = new System.Drawing.Point(12, 79);
            this.seuraLabel.Name = "seuraLabel";
            this.seuraLabel.Size = new System.Drawing.Size(35, 13);
            this.seuraLabel.TabIndex = 20;
            this.seuraLabel.Text = "Seura";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(12, 15);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(41, 13);
            this.firstNameLabel.TabIndex = 18;
            this.firstNameLabel.Text = "Etunimi";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(12, 47);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(50, 13);
            this.lastNameLabel.TabIndex = 19;
            this.lastNameLabel.Text = "Sukunimi";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(68, 12);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.firstNameTextBox.TabIndex = 13;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(47, 186);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 23;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(128, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Peruuta";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ContestantRowEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(218, 221);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.joukkueComboBox);
            this.Controls.Add(this.sarjaComboBox);
            this.Controls.Add(this.seuraComboBox);
            this.Controls.Add(this.sarjaLabel);
            this.Controls.Add(this.joukkueLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.seuraLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(234, 260);
            this.MinimumSize = new System.Drawing.Size(234, 260);
            this.Name = "ContestantRowEditForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muokkaa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox joukkueComboBox;
        private System.Windows.Forms.ComboBox sarjaComboBox;
        private System.Windows.Forms.ComboBox seuraComboBox;
        private System.Windows.Forms.Label sarjaLabel;
        private System.Windows.Forms.Label joukkueLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label seuraLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button2;
    }
}