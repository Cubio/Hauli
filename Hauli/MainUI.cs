using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            comboBox1.Text = "1";
            comboBox2.Text = "15";
            //LUENTAAN INI 


            //Tarkistetaan tietokanta
            try
            {
                dbHandler = new HauliDBHandler();

                if (!File.Exists("ObjectListView.dll"))
                    throw new HauliException("Tiedostoa ObjectListView.dll ei löytynyt");
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
            new RoundScheduleView(dbHandler, comboBox1.Text, comboBox2.Text, activeDay2Selection.Checked, day1h.Text, day1min.Text, day2h.Text, day2min.Text).ShowDialog();
        }

        private void scoreInputViewButton_Click(object sender, EventArgs e)
        {
            new ScoreInputView(dbHandler).ShowDialog();
        }


        private void suljeSovellusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void joukkueetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TeamListForm(dbHandler).ShowDialog();
        }

        private void seuratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SeriesListForm(dbHandler).ShowDialog();
        }

        private void day1min_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void day1Calendar_ValueChanged(object sender, EventArgs e)
        {
                day1Calendar.MinDate = DateTime.Now;
                day2Calendar.Value = day1Calendar.Value.AddDays(1);
        }

        private void day2Calendar_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            if (activeDay2Selection.Checked == true)
            {
                if (day2Calendar.Value <= day1Calendar.Value)
                {
                    DateErrorMessageBox();
                }
                else { }
            }
            else { }
        }

        private void DateErrorMessageBox()
        {
            MessageBox.Show("Tarkista päivän 2 päivämäärä!");
        }

        private void sarjatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new SerialListForm(dbHandler).ShowDialog();
        }
    }
}
