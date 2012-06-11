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
    /// <summary>
    /// Sisältää päännäkymäluokan tapahtumien käsittelymetodit ja luokan konstruktorin.
    /// </summary>
    public partial class MainUIform : Form
    {
        private HauliDBHandler dbHandler;

        /// <summary>
        /// MainUIform-konstruktori, joka alustaa käyttöliittymäkomponentit ja
        /// tietokannanmuokkausluokan.
        /// </summary>
        public MainUIform()
        {
            InitializeComponent();

            try
            {
                dbHandler = new HauliDBHandler();
            }
            catch (HauliException e)
            {
                MessageBox.Show(e.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void contestantListButton_Click(object sender, EventArgs e)
        {
            new ContestantListForm(dbHandler).ShowDialog();
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

        private void tietojaHauliTulospalvelustaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutHauli().ShowDialog();
        
        }

        private void roundScheduleButton_Click(object sender, EventArgs e)
        {
            new RoundScheduleView().ShowDialog();
        }

        private void scoreInputViewButton_Click(object sender, EventArgs e)
        {
            new scoreInputView().ShowDialog();
        }

        private void suljeSovellusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
