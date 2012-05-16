namespace Hauli
{
    partial class MainUIform
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
            this.AddContestGroupBox = new System.Windows.Forms.GroupBox();
            this.contestantListButton = new System.Windows.Forms.Button();
            this.roundScheduleButton = new System.Windows.Forms.Button();
            this.printViewButton = new System.Windows.Forms.Button();
            this.scoreInputViewButton = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.AddContestGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddContestGroupBox
            // 
            this.AddContestGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.AddContestGroupBox.Controls.Add(this.monthCalendar1);
            this.AddContestGroupBox.Location = new System.Drawing.Point(12, 33);
            this.AddContestGroupBox.Name = "AddContestGroupBox";
            this.AddContestGroupBox.Size = new System.Drawing.Size(305, 488);
            this.AddContestGroupBox.TabIndex = 0;
            this.AddContestGroupBox.TabStop = false;
            this.AddContestGroupBox.Text = "Lisää kisa";
            // 
            // contestantListButton
            // 
            this.contestantListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contestantListButton.Location = new System.Drawing.Point(358, 45);
            this.contestantListButton.Name = "contestantListButton";
            this.contestantListButton.Size = new System.Drawing.Size(124, 33);
            this.contestantListButton.TabIndex = 1;
            this.contestantListButton.Text = "Osallistujaluettelo";
            this.contestantListButton.UseVisualStyleBackColor = true;
            this.contestantListButton.Click += new System.EventHandler(this.contestantListButton_Click);
            // 
            // roundScheduleButton
            // 
            this.roundScheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundScheduleButton.Location = new System.Drawing.Point(358, 134);
            this.roundScheduleButton.Name = "roundScheduleButton";
            this.roundScheduleButton.Size = new System.Drawing.Size(124, 33);
            this.roundScheduleButton.TabIndex = 2;
            this.roundScheduleButton.Text = "Eräaikataulu";
            this.roundScheduleButton.UseVisualStyleBackColor = true;
            // 
            // printViewButton
            // 
            this.printViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printViewButton.Location = new System.Drawing.Point(358, 223);
            this.printViewButton.Name = "printViewButton";
            this.printViewButton.Size = new System.Drawing.Size(124, 33);
            this.printViewButton.TabIndex = 3;
            this.printViewButton.Text = "Tulostukset";
            this.printViewButton.UseVisualStyleBackColor = true;
            // 
            // scoreInputViewButton
            // 
            this.scoreInputViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreInputViewButton.Location = new System.Drawing.Point(358, 312);
            this.scoreInputViewButton.Name = "scoreInputViewButton";
            this.scoreInputViewButton.Size = new System.Drawing.Size(124, 33);
            this.scoreInputViewButton.TabIndex = 4;
            this.scoreInputViewButton.Text = "Tulosten kirjaus";
            this.scoreInputViewButton.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(81, 61);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // MainUIform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 549);
            this.Controls.Add(this.scoreInputViewButton);
            this.Controls.Add(this.printViewButton);
            this.Controls.Add(this.roundScheduleButton);
            this.Controls.Add(this.contestantListButton);
            this.Controls.Add(this.AddContestGroupBox);
            this.Name = "MainUIform";
            this.Text = "Hauli - tulospalvelu";
            this.AddContestGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AddContestGroupBox;
        private System.Windows.Forms.Button roundScheduleButton;
        private System.Windows.Forms.Button printViewButton;
        private System.Windows.Forms.Button scoreInputViewButton;
        private System.Windows.Forms.Button contestantListButton;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}

