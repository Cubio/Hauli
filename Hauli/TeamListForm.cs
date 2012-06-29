using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrightIdeasSoftware;

namespace Hauli
{
    public partial class TeamListForm : Form
    {
        private HauliDBHandler dbHandler;
        private StreamReader file;
        private Boolean virhe = false;
        private List<TeamListLine> teamList;
        private List<TeamListLine> teamListOrginal;

        public TeamListForm()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
