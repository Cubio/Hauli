﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hauli
{
    public partial class scoreInputView : Form
    {
        public scoreInputView()
        {
            InitializeComponent();


            //Laitetaan socers taulukkoon uusi välilehti
            //Infoa: http://msdn.microsoft.com/en-us/library/system.windows.forms.tabcontrol.aspx
            tabPage1 = new System.Windows.Forms.TabPage();
            tabPage1.Text = "teeesti";
            tabPage1.Size = new System.Drawing.Size(256, 214);
            tabPage1.TabIndex = 0;
            scores.Controls.Add(tabPage1);
        }

        private void scoreInputView_Load(object sender, EventArgs e)
        {

        }



    }
}
