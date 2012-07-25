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
    public partial class ContestantRowEditForm : Form
    {
        private Contestant contestant;
        private ContestantListForm clf;

        public ContestantRowEditForm(ContestantListForm f, Contestant c)
        {
            InitializeComponent();
            contestant = c;
            clf = f;

            List<string> sarjaList = clf.getSarjaList();
            List<string> seuraList = clf.getSeuraList();
            List<string> joukkueList = clf.getJoukkueList();

            sarjaComboBox.Items.AddRange(sarjaList.ToArray());
            seuraComboBox.Items.AddRange(seuraList.ToArray());
            joukkueComboBox.Items.Add("");
            joukkueComboBox.Items.AddRange(joukkueList.ToArray());

            firstNameTextBox.Text = contestant.FirstName;
            lastNameTextBox.Text = contestant.LastName;
            
            joukkueComboBox.Text = contestant.Team;
            sarjaComboBox.Text = contestant.Sarja;
            seuraComboBox.Text = contestant.Seura;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text.Trim() != "" && lastNameTextBox.Text.Trim() != "" && seuraComboBox.Text.Trim() != "" && sarjaComboBox.Text.Trim() != "")
            {
                
                contestant.FirstName = firstNameTextBox.Text;
                contestant.LastName = lastNameTextBox.Text;
                contestant.FullName = firstNameTextBox.Text + " " + lastNameTextBox.Text;
                contestant.Team = joukkueComboBox.Text;
                contestant.Sarja = sarjaComboBox.Text;
                contestant.Seura = seuraComboBox.Text;

                clf.UpdateContestantLine(contestant);

                this.Close();
            }
            else
            {
                MessageBox.Show("Osallistujalla täytyy olla etunimi, sukunimi, seura ja sarja", "Varoitus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
