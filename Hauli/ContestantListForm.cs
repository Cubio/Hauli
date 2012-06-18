using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using BrightIdeasSoftware;

namespace Hauli
{
    public partial class ContestantListForm : Form
    {
        private HauliDBHandler dbHandler;
        private List<ContestantListLine> contestantList;
        private List<string> seuraList;
        private List<string> sarjaList;
        private bool rowMoved = false;

        public ContestantListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;

            AutoCompleteStringCollection seuraAutoCompleteCollection = new AutoCompleteStringCollection();
            seuraList = new List<string>();
            sarjaList = new List<string>();

            seuraList.Add("AavU");
            seuraList.Add("ASA");
            seuraList.Add("A-HA");
            seuraList.Add("A-SA");
            seuraList.Add("AlavV");
            seuraList.Add("AlavA");
            seuraList.Add("OSUMA");
            seuraList.Add("AK-945");
            seuraList.Add("AMP-67");
            seuraList.Add("OSH");

            seuraAutoCompleteCollection.AddRange(seuraList.ToArray());
            seuraComboBox.AutoCompleteCustomSource = seuraAutoCompleteCollection;
            seuraComboBox.Items.AddRange(seuraList.ToArray());


            sarjaList.Add("Y");
            sarjaList.Add("Y15");
            sarjaList.Add("Y17");
            sarjaList.Add("Y20");
            sarjaList.Add("Y55");
            sarjaList.Add("Y65");
            sarjaList.Add("Y70");
            sarjaList.Add("N");
            sarjaList.Add("N20");
            sarjaList.Add("A");
            sarjaList.Add("B");
            sarjaList.Add("C");
            sarjaList.Add("D");

            sarjaComboBox.Items.AddRange(sarjaList.ToArray());
            sarjaComboBox.Text = sarjaList[0];

            objectListView1.DragSource = new SimpleDragSource();

            RearrangingDropSink dropsink = new RearrangingDropSink(true);
            dropsink.FeedbackColor = Color.Black;
            objectListView1.DropSink = dropsink;
            objectListView1.ItemDrag += objectListView1_ItemDrag;

            contestantList = new List<ContestantListLine>();

            contestantList.Add(new RoundDivider("round 1", "Erä 1"));
            contestantList.Add(new Contestant(generateId(), "Teppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Aeppo", "Töppönen", "OSH", "Y", "Ninja-pinjat"));
            contestantList.Add(new Contestant(generateId(), "Beppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Ceppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider("round 2", "Erä 2"));
            contestantList.Add(new Contestant(generateId(), "Deppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Eeppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Feppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Geppoliina", "Töppönen", "OSH", "N", "Ninja-pinjat"));
            contestantList.Add(new RoundDivider("round 3", "Erä 3"));
            contestantList.Add(new Contestant(generateId(), "Heppo", "Töppönen", "OSH", "Y", "Ninja-pinjat"));
            contestantList.Add(new Contestant(generateId(), "Ieppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Jeppoliina", "Töppönen", "OSH", "N", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Keppo", "Töppönen", "OSH", "Y", ""));

            idColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Id; };

            nameColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).FullName; };
            nameColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).FullName = newValue.ToString(); };

            seuraColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Seura; };
            seuraColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Seura = newValue.ToString(); };

            sarjaColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Sarja; };
            sarjaColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Sarja = newValue.ToString(); };

            joukkueColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Team; };
            joukkueColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Team = newValue.ToString(); };

            editButtonColumn.ImageGetter = delegate(object row)
            {
                if (!((ContestantListLine)row).Id.Contains("round"))
                    return 0;
                else
                    return null;

            };
            editButtonColumn.Tag = "editButtonColumn";

            deleteButtonColumn.ImageGetter = delegate(object row)
            {
                if (!((ContestantListLine)row).Id.Contains("round"))
                    return 1;
                else
                    return null;
            };
            deleteButtonColumn.Tag = "deleteButtonColumn";

            refreshContestantListView();
        }

        public List<string> GetSarjaList()
        {
            return sarjaList;
        }

        public List<string> GetSeuraList()
        {
            return seuraList;
        }

        private void objectListView1_ItemDrag(Object sender, ItemDragEventArgs e)
        {

            if (((ListViewItem)e.Item).SubItems[0].Text.Contains("round"))
            {
                Console.WriteLine("Roundia liikutetaan");
                ((ListViewItem)e.Item).Selected = false;
            }
        }

        private void objectListView1_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("DROP!");
            //refreshContestantListView();
            rowMoved = true;
        }

        private void objectListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Point ptCursor = Cursor.Position;
            ptCursor = PointToClient(ptCursor);

            int x = ptCursor.X - objectListView1.Location.X - 2;
            int y = ptCursor.Y - objectListView1.Location.Y - 2;

            ListViewItem clickedItem = objectListView1.GetItemAt(x, y);
            Contestant selectedContestant = null;

            if (!clickedItem.SubItems[0].Text.Contains("round"))

                for (int i = 0; i < contestantList.Count; i++)
                {
                    if (!contestantList[i].Id.Contains("round") && contestantList[i].Id == clickedItem.SubItems[0].Text)
                    {
                        selectedContestant = new Contestant((Contestant)contestantList[i]);
                        break;
                    }
                }

            if (selectedContestant != null)
                new ContestantRowEditForm(this, selectedContestant).ShowDialog();
        }

        private void objectListView1_Click(object sender, EventArgs e)
        {
            Point ptCursor = Cursor.Position;
            ptCursor = PointToClient(ptCursor);

            int x = ptCursor.X - objectListView1.Location.X - 2;
            int y = ptCursor.Y - objectListView1.Location.Y - 2;

            Console.WriteLine("OLV Clicked: " + x.ToString() + " " + y.ToString());

            OLVColumn hitColumn;
            ListViewItem clickedItem = objectListView1.GetItemAt(x, y, out hitColumn);
            Contestant selectedContestant = null;

            if (hitColumn != null && !clickedItem.SubItems[0].Text.Contains("round") && (hitColumn.Tag != null))
            {
                if (hitColumn.Tag.ToString() == "editButtonColumn")
                {
                    for (int i = 0; i < contestantList.Count; i++)
                    {
                        if (!contestantList[i].Id.Contains("round") && contestantList[i].Id == clickedItem.SubItems[0].Text)
                        {
                            selectedContestant = new Contestant((Contestant)contestantList[i]);
                            break;
                        }
                    }

                    if (selectedContestant != null)
                        new ContestantRowEditForm(this, selectedContestant).ShowDialog();

                }
                else if (hitColumn.Tag.ToString() == "deleteButtonColumn")
                {
                    deleteLine(clickedItem);
                }
            }
        }

        private void deleteLine(ListViewItem item)
        {
            DialogResult result;
            result = MessageBox.Show("Haluatko varmasti poistaa osallistujan?", "Hauli", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < contestantList.Count; i++)
                    if (contestantList[i].Id == item.SubItems[0].Text.ToString())
                        contestantList.RemoveAt(i);

                refreshContestantListView();
            }
        }

        private void refreshContestantListView()
        {
            objectListView1.SetObjects(contestantList);
        }

        private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;

            if (rowMoved)
            {
                rowMoved = false;

                List<ContestantListLine> newList = new List<ContestantListLine>();

                foreach (ListViewItem row in objectListView1.Items)
                {
                    if (!row.SubItems[0].Text.Contains("round"))
                    {
                        for (int i = 0; i < contestantList.Count; i++)
                        {
                            if (contestantList[i].Id.ToString() == row.SubItems[0].Text.ToString())
                            {
                                newList.Add(new Contestant(contestantList[i].Id, contestantList[i].FirstName, contestantList[i].LastName, contestantList[i].Seura, contestantList[i].Sarja, contestantList[i].Team));
                                break;
                            }
                        }
                    }
                    else
                    {
                        newList.Add(new RoundDivider(row.SubItems[0].Text.ToString(), row.SubItems[1].Text.ToString()));
                    }
                }

                contestantList = newList;
            }

            foreach (ListViewItem row in objectListView1.Items)
            {
                if (row.SubItems[0].Text.Contains("round"))
                {
                    row.BackColor = Color.LightGray;
                }
            }
        }

        private void openPathButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            importFilePathTextBox.Text = openFileDialog1.FileName;
        }

        private void addContestantButton_Click(object sender, EventArgs e)
        {
            contestantList.Add(new Contestant(generateId(), firstNameTextBox.Text, lastNameTextBox.Text, seuraComboBox.Text, sarjaComboBox.Text, joukkueComboBox.Text));
            refreshContestantListView();

            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            seuraComboBox.Text = "";
            joukkueComboBox.Text = "";
        }

        private string generateId()
        {
            List<string> idList = new List<string>();
            bool ok = false;
            Random random = new Random();
            int id = 0;

            if (contestantList.Count != 0)
                for (int i = 0; i < contestantList.Count; i++)
                    idList.Add(contestantList[i].Id);

            id = random.Next(10000, 99999);

            do
            {
                if (!idList.Contains(id.ToString()))
                    ok = true;
                else
                    id = random.Next(10000, 99999);
            } while (!ok);


            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(idList[i]);

            return id.ToString();
        }

        internal void UpdateContestantLine(Contestant updatedContestant)
        {
            for (int i = 0; i < contestantList.Count; i++)
            {
                if (contestantList[i].Id == updatedContestant.Id)
                {
                    contestantList[i].FirstName = updatedContestant.FirstName;
                    contestantList[i].LastName = updatedContestant.LastName;
                    contestantList[i].Seura = updatedContestant.Seura;
                    contestantList[i].Sarja = updatedContestant.Sarja;
                    contestantList[i].Team = updatedContestant.Team;

                    refreshContestantListView();
                    break;
                }
            }
        }

        private void mixListOrderButton_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContestantListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Haluatko tallentaa muutokset?", "Hauli", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);

            if (result == DialogResult.Yes)
            {
                //saveList();
            }
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
