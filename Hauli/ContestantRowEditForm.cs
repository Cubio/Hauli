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
    public partial class ContestantRowEditForm : Form
    {
        ContestantListLine contestant;

        public ContestantRowEditForm(ContestantListLine c)
        {
            InitializeComponent();
            contestant = c;
        }


    }
}