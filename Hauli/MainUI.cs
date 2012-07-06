using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Microsoft.Win32;

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


            // Hae kannasta näytettävää kamaa pääikkunaan
            getMainInfo();



        }

        private void getMainInfo()
        {
            List<Object> tiedot = dbHandler.getMainInfo();


            contestTextBox.Text = (String)tiedot[0];
            organizerTextBox.Text = (String)tiedot[1];
            placeTextBox.Text =  (String)tiedot[2];
            rataComboBox.Text = Convert.ToString((int)tiedot[3]);
            eraComboBox.Text = Convert.ToString((int)tiedot[4]);
            DateTime day1 = (DateTime)tiedot[5];

            day1Calendar.Value = new DateTime(day1.Year, day1.Month, day1.Day);

            day1h.Text = day1.Hour.ToString();
            if (day1.Minute.ToString() == "0")
            {
                day1min.Text = "00";
            }
            day1min.Text = day1.Minute.ToString();

            if (tiedot.Count == 7)
            {
                DateTime day2 = (DateTime)tiedot[6];
                day2h.Text = day2.Hour.ToString();

                if (day2.Minute.ToString() == "0")
                {
                    day2min.Text = "00";
                }
                day2min.Text = day2.Minute.ToString();
                day1Calendar.Value = new DateTime(day2.Year, day2.Month, day2.Day);
                activeDay2Selection.Checked = true;
                Console.WriteLine("J:" + day2.Minute);
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
            new RoundScheduleView(dbHandler).ShowDialog();
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
            String d1 = "";
            String d2 = "";
            

            d1 = day1Calendar.Value.ToString("dd-MM-yyyy "+ this.day1h.Text + ":" + this.day1min.Text);

            if( this.contestTextBox.Text =="" ||  this.organizerTextBox.Text == "" || this.placeTextBox.Text == "" ||  this.rataComboBox.Text == "" || this.eraComboBox.Text == "" || this.day1h.Text =="" || this.day1min.Text =="")  
            {
                MessageBox.Show("Kilpailutiedoissa puutteita. Tarkista että tekstikentissä on tietoa");
            } else {

                if (activeDay2Selection.Checked == true)
                {
                    if (this.day2Calendar.Value <= this.day1Calendar.Value || this.day2h.Text == "" || this.day2min.Text == "")
                    {
                        MessageBox.Show("Tarkista päivän 2 päivän alkamisajankohtatiedot");
                    }
                    else
                    {
                        d2 = day2Calendar.Value.ToString("dd-MM-yyyy " + this.day2h.Text + ":" + this.day2min.Text);
                    }

                }

                dbHandler.setCompetitionDatetime(d1, d2, this.contestTextBox.Text, this.organizerTextBox.Text, this.placeTextBox.Text, this.rataComboBox.Text, this.eraComboBox.Text);
                MessageBox.Show("Kilpailutapahtuman tiedot tallennettu");
            }
        }


        private void sarjatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new SerialListForm(dbHandler).ShowDialog();
        }

        private void tallennaKilpailuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Hauli-Solution|*.hauli";
            saveFileDialog1.Title = "Tallenna hauli kilpailutapahtuma";
            //saveFileDialog1.CheckFileExists = true;
           // saveFileDialog1.CheckPathExists = true;

            saveFileDialog1.FileName = "Hauli_" + contestTextBox.Text+ "_" + DateTime.Now.ToString( "yyyy-MM-dd" );


            //Kansio, jossa softa ajetaan
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (File.Exists(Properties.Settings.Default.DBpath))
            {
                FileStream fileStream = new FileStream(Properties.Settings.Default.DBpath, FileMode.Open);
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                File.Copy(Properties.Settings.Default.DBpath, filename, true);
            }
               fileStream.Close();
            }   
        }

        private void tuoKilpailuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader file;

            openFileDialog1.Filter = "Hauli|*.hauli";
            openFileDialog1.Title = "Valitse käytettävä tietokanta";
            openFileDialog1.ShowDialog();

            //Tarkistetaan onko tiedosto olemassa, jos on niin luetaan se.
            if (File.Exists(openFileDialog1.FileName))
            {
                Properties.Settings.Default.DBpath = openFileDialog1.FileName;
                dbHandler.updateHauliDB();
                getMainInfo();
            }

        }

    }
}
