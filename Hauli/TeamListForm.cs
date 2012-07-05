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

        public TeamListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();

            this.dbHandler = dbHandler;

            teamList = new List<TeamListLine>();
            teamListOrginal = new List<TeamListLine>();

            teamList = dbHandler.getTeamList();
            teamListOrginal = dbHandler.getTeamList();


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
            //teamListOrginal = teamList;
            //teamList = new List<TeamListLine>();
            //TeamsList.RefreshObject(teamList);
            //TeamsList.RefreshObject(teamListOrginal);
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

                refresTeamListView();
            }
        }


        private void Close_Click(object sender, EventArgs e)
        {


            teamComparer TeamComparer = new teamComparer();
            IEnumerable<TeamListLine> differences3 = teamList.Except(teamListOrginal, TeamComparer);

            int onko = differences3.Count();
            int pituus = teamList.Count() - teamListOrginal.Count();




            if (onko != 0 || pituus != 0)
            {

                switch (MessageBox.Show("Haluatko tallentaa muutokset?",
                            "Seurojen tallennus",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        dbHandler.delDBTable("Joukkue");
                        dbHandler.setTeam(teamList);
                        refresTeamListView();
                        this.Close();
                        break;

                    case DialogResult.No:
                        this.Close();
                        break;

                    case DialogResult.Cancel:
                        break;
                }
            }
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
                refresTeamListView();
                joukkueTextBox.Clear();
            }
        }

        private void saveTeam_Click(object sender, EventArgs e)
        {
            //teamList = new List<TeamListLine>();
            teamListOrginal = teamList;
            dbHandler.delDBTable("Joukkue");
            dbHandler.setTeam(teamList);
            refresTeamListView();
        }
    }
}
