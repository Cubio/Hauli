using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hauli
{
    public partial class MainUIform : Form
    {
        private HauliDBHandler dbHandler;

        public MainUIform()
        {
            InitializeComponent();

            dbHandler = new HauliDBHandler(); 
        }

        private void contestantListButton_Click(object sender, EventArgs e)
        {
            new ContestantListForm(dbHandler).ShowDialog();
        }

        private void activeDay1Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (activeDay1Selection.Checked == true)
            {
                this.day1min.Enabled = true;
                this.day1h.Enabled = true;
                this.day1Calendar.Enabled = true;
            }
            else
            {
                this.day1min.Enabled = false;
                this.day1h.Enabled = false;
                this.day1Calendar.Enabled = false;
            }
        }

        private void activeDay2Selection_CheckedChanged(object sender, EventArgs e)
        {
            if (activeDay2Selection.Checked == true)
            {
                this.day2min.Enabled = true;
                this.day2h.Enabled = true;
                this.day2Calendar.Enabled = true;
            }
            else
            {
                this.day2min.Enabled = false;
                this.day2h.Enabled = false;
                this.day2Calendar.Enabled = false;
            }

        }

    }
}
