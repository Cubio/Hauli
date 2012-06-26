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

            List<string> sarjaList = clf.GetSarjaList();
            List<string> seuraList = clf.GetSeuraList();

            sarjaComboBox.Items.AddRange(sarjaList.ToArray());
            seuraComboBox.Items.AddRange(seuraList.ToArray());

            firstNameTextBox.Text = contestant.FirstName;
            lastNameTextBox.Text = contestant.LastName;
            joukkueComboBox.Text = contestant.Team;
            sarjaComboBox.Text = contestant.Sarja;
            seuraComboBox.Text = contestant.Seura;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Console.WriteLine("Click: " + firstNameTextBox.Text + " " + lastNameTextBox.Text);

            contestant.FirstName = firstNameTextBox.Text;
            contestant.LastName = lastNameTextBox.Text;
            contestant.FullName = firstNameTextBox.Text + " " + lastNameTextBox.Text;

            Console.WriteLine("Click 2: " + contestant.FirstName + " " + contestant.LastName + " " + contestant.FullName);

            contestant.Team = joukkueComboBox.Text;
            contestant.Sarja = sarjaComboBox.Text;
            contestant.Seura = seuraComboBox.Text;

            clf.UpdateContestantLine(contestant);

            this.Close();
        }
    }
}
