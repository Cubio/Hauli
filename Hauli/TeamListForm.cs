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
        private Boolean tallennettu = true;
        private List<TeamListLine> teamList;

        public TeamListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();

            this.dbHandler = dbHandler;

            teamList = new List<TeamListLine>();

            teamList = dbHandler.getTeamList();


            idColumn.AspectGetter = delegate(object x) { return ((TeamListLine)x).Id; };

            teamColumn.AspectGetter = delegate(object x) { return ((TeamListLine)x).Joukkue; };
            teamColumn.AspectPutter = delegate(object x, object newValue) { ((TeamListLine)x).Joukkue = newValue.ToString(); };

            buttonColumn.DisplayIndex = 2;
            buttonColumn.ImageGetter = delegate(object row)
            {
                return 1;
            };
            buttonColumn.Tag = "buttonColumn";


            refresTeamListView();
        }


        private void refresTeamListView()
        {
            TeamsList.SetObjects(teamList);
        }

        private void TeamList_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Painallus");
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - TeamsList.Location.X - 2;
            int y = cursor.Y - TeamsList.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem clickedItem = TeamsList.GetItemAt(x, y, out hitColumn);

            if (hitColumn != null && hitColumn.Tag != null)
            {
                if (hitColumn.Tag.ToString() == "buttonColumn")
                {

                    String testi = clickedItem.SubItems[0].Text.ToString();
                    int idNro = 0;
                    int.TryParse(testi, out idNro);
                    deleteLine(idNro);
                    refresTeamListView();
                }
            }
        }

        private void deleteLine(int idNro)
        {
            DialogResult result;
            result = MessageBox.Show("Haluatko varmasti poistaa seuran?", "Hauli", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < teamList.Count; i++)
                    if (teamList[i].Id == idNro)
                        teamList.RemoveAt(i);

                tallennettu = false;
                refresTeamListView();
            }
        }


        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addTeam_Click(object sender, EventArgs e)
        {
            if (this.joukkueTextBox.Text == "" )
            {
                MessageBox.Show("Uuden joukkueen tiedoissa puutteita. Tarkista että tekstikentissä on tietoa");
            }
            else
            {
                teamList.Add(new Team(dbHandler.generateId("Joukkue", "joukkueID"), joukkueTextBox.Text));
                joukkueTextBox.Clear();
                tallennettu = false;
                refresTeamListView();
            }
        }

        private void saveTeam_Click(object sender, EventArgs e)
        {
            tallennettu = true;
            dbHandler.delDBTable("Joukkue");
            dbHandler.setTeam(teamList);
            refresTeamListView();
        }

        private void TeamListForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!tallennettu)
            {

                switch (MessageBox.Show("Haluatko tallentaa muutokset?",
                            "Joukkueiden tallennus",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        dbHandler.delDBTable("Joukkue");
                        dbHandler.setTeam(teamList);
                        refresTeamListView();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
