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
        private readonly int MaximumRoundSize = 10;
        private HauliDBHandler dbHandler;
        private List<ContestantListLine> contestantList;
        private List<string> seuraList;
        private List<string> sarjaList;
        private Cursor moveHandCursor;
        private List<int> roundContestantCounts;
        private List<int> roundDividerIndices;

        public ContestantListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;

            AutoCompleteStringCollection seuraAutoCompleteCollection = new AutoCompleteStringCollection();
            seuraList = new List<string>();
            sarjaList = new List<string>();

            moveHandCursor = new Cursor("Resources/move.cur");

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

            contestantList = new List<ContestantListLine>();
            
            contestantList.Add(new RoundDivider("roundCold;1", "Erä"));
            
            contestantList.Add(new Contestant(generateId(), "Teppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Aeppo", "Töppönen", "OSH", "Y", "Ninja-pinjat"));
            contestantList.Add(new Contestant(generateId(), "Beppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Ceppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider("roundCold;2", "Erä"));
            contestantList.Add(new Contestant(generateId(), "Deppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Eeppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Feppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Geppoliina", "Töppönen", "OSH", "N", "Ninja-pinjat"));
            contestantList.Add(new RoundDivider("roundCold;3", "Erä"));
            contestantList.Add(new Contestant(generateId(), "Heppo", "Töppönen", "OSH", "Y", "Ninja-pinjat"));
            contestantList.Add(new Contestant(generateId(), "Ieppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Jeppoliina", "Töppönen", "OSH", "N", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Keppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider("roundCold;4", "Erä"));
            contestantList.Add(new Contestant(generateId(), "Zeppo", "Töppönen", "OSH", "Y", ""));
            
            idColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Id; };

            grabColumn.AspectGetter = delegate(object x) { return " "; };

            nameColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).FullName; };
            nameColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).FullName = newValue.ToString(); };

            seuraColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Seura; };
            seuraColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Seura = newValue.ToString(); };

            sarjaColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Sarja; };
            sarjaColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Sarja = newValue.ToString(); };

            joukkueColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Team; };
            joukkueColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Team = newValue.ToString(); };

            grabColumn.DisplayIndex = 1;
            grabColumn.ImageGetter = delegate(object row)
            {
                if (((ContestantListLine)row).Id.Contains("round"))
                    return -1;
                else
                    return 3;

            };
            grabColumn.Tag = "grabColumn";

            buttonColumn1.ImageGetter = delegate(object row)
            {
                if (!((ContestantListLine)row).Id.Contains("round"))
                    return 0;
                else
                    return 2;

            };
            buttonColumn1.Tag = "buttonColumn1";

            buttonColumn2.ImageGetter = delegate(object row)
            {
                string[] id = ((ContestantListLine)row).Id.Split(';');
                if (!((ContestantListLine)row).Id.Contains("round") || (id[1] != "1"))
                    return 1;
                else
                    return -1;
            };
            buttonColumn2.Tag = "buttonColumn2";

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
                ((ListViewItem)e.Item).Selected = false;
            }
        }

        private void objectListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - objectListView1.Location.X - 2;
            int y = cursor.Y - objectListView1.Location.Y - 2;

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
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - objectListView1.Location.X - 2;
            int y = cursor.Y - objectListView1.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem clickedItem = objectListView1.GetItemAt(x, y, out hitColumn);
            Contestant selectedContestant = null;

            if (hitColumn != null && hitColumn.Tag != null)
            {
                if (hitColumn.Tag.ToString() == "buttonColumn1")
                {
                    string[] listIdColumnText = clickedItem.SubItems[0].Text.Split(';');

                    if (listIdColumnText[0] == "roundHot")
                    {
                        //Console.WriteLine("hot->cold");

                        foreach (ContestantListLine line in contestantList)
                        {
                            if (line.Id.Contains("round"))
                            {
                                string[] modelIdColumnText = line.Id.Split(';');
                                if (modelIdColumnText[1] == listIdColumnText[1])
                                    line.Id = "roundCold" + ";" + listIdColumnText[1];
                            }
                        }

                        refreshContestantListView();
                    }
                    else if (listIdColumnText[0] == "roundCold")
                    {
                        //Console.WriteLine("cold->hot");

                        foreach (ContestantListLine line in contestantList)
                        {
                            if (line.Id.Contains("round"))
                            {
                                string[] modelIdColumnText = line.Id.Split(';');
                                if (modelIdColumnText[1] == listIdColumnText[1])
                                    line.Id = "roundHot" + ";" + listIdColumnText[1];
                            }
                        }

                        refreshContestantListView();
                    }
                    else
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
                }
                else if (hitColumn.Tag.ToString() == "buttonColumn2")
                {

                    string[] id = clickedItem.SubItems[0].Text.Split(';');
                    if (!(clickedItem.SubItems[0].Text.Contains("round")) || (id[1] != "1"))
                        deleteLine(clickedItem);
                }
            }
        }

        private void deleteLine(ListViewItem item)
        {
            DialogResult result;
            string message;

            if (item.SubItems[0].Text.Contains("round"))
                message = "Haluatko varmasti poistaa erän?\nErän osallistujat liitetään edelliseen erään";
            else
                message = "Haluatko varmasti poistaa osallistujan?";

            result = MessageBox.Show(message, "Hauli", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < contestantList.Count; i++)
                    if (contestantList[i].Id == item.SubItems[0].Text.ToString())
                        contestantList.RemoveAt(i);

                if (item.SubItems[0].Text.Contains("round"))
                    validateRoundDividerIDs();

                refreshContestantListView();
                countRoundSizes();
            }
        }

        private void validateRoundDividerIDs()
        {
            int round = 1;
            for (int i = 0; i < contestantList.Count; i++)
            {
                if (contestantList[i].Id.Contains("round"))
                {
                    string[] id = contestantList[i].Id.Split(';');
                    contestantList[i].Id = id[0] + ";" + round;
                    round++;
                }
            }
        }

        private void refreshContestantListView()
        {
            Console.WriteLine("refreshContestantListView");
                
            int topItemIndex = objectListView1.TopItemIndex;

            objectListView1.SetObjects(contestantList);
            countRoundSizes();
            objectListView1.SetObjects(contestantList);

            if (topItemIndex >= 0 && topItemIndex < objectListView1.Items.Count)
                objectListView1.TopItem = objectListView1.Items[topItemIndex];
            else
                objectListView1.EnsureVisible(objectListView1.Items.Count - 1);
        }

        private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;

            foreach (ListViewItem row in objectListView1.Items)
            {
                if (row.SubItems[0].Text.Contains("round"))
                {
                    if (row.SubItems[0].Text.Contains("roundCold"))
                        row.BackColor = Color.LightGray;
                    else if (row.SubItems[0].Text.Contains("roundHot"))
                        row.BackColor = Color.LightPink;
                }

                if (row.Index == 0 && !row.SubItems[0].Text.Contains("round"))
                {
                    for (int i = 0; i < objectListView1.Items.Count; i++)
                    {
                        if (objectListView1.Items[i].SubItems[0].Text.Contains("round"))
                        {
                            string[] id = objectListView1.Items[i].SubItems[0].Text.Split(';');

                            if (id[1] == "1")
                            {
                                ListViewItem item = objectListView1.Items[i];
                                objectListView1.Items.RemoveAt(i);
                                objectListView1.Items.Insert(0, item);
                                
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void updateModelList()
        {
            List<ContestantListLine> newList = new List<ContestantListLine>();

            Console.WriteLine("updateModelList");

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
                    newList.Add(new RoundDivider(row.SubItems[0].Text.ToString(), row.SubItems[2].Text.ToString()));
                }
            }

            contestantList = newList;
        }

        private void countRoundSizes()
        {
            Console.WriteLine("Count");

            int round = 1;

            updateDividerIndicesAndContestantCounts();

            foreach (ListViewItem row in objectListView1.Items)
            {
                if (row.SubItems[0].Text.Contains("round"))
                {
                    row.SubItems[2].Text = "Erä " + round + " (" + roundContestantCounts[round - 1] + "/" + MaximumRoundSize + ")";
                    round++;
                }
            }

            for (int i = 0; i < roundDividerIndices.Count; i++)
            {
                contestantList[roundDividerIndices[i]].FullName = "Erä " + (i + 1).ToString() +
                " (" + roundContestantCounts[i] + "/" + MaximumRoundSize + ")";
            }

            nameColumn.ImageGetter = delegate(object row)
            {
                if (((ContestantListLine)row).Id.Contains("round"))
                {
                    updateDividerIndicesAndContestantCounts();

                    string[] id = ((ContestantListLine)row).Id.Split(';');

                    if (roundContestantCounts[Convert.ToInt32(id[1]) - 1] > MaximumRoundSize)
                    {
                        return 4;
                    }
                }

                return -1;
            };
        }

        private void updateDividerIndicesAndContestantCounts()
        {
            roundDividerIndices = new List<int>();
            roundContestantCounts = new List<int>();

            for (int i = 0; i < contestantList.Count; i++)
            {
                if (contestantList[i].Id.Contains("round"))
                {
                    roundDividerIndices.Add(i);
                }
            }

            for (int i = 0; i < roundDividerIndices.Count; i++)
            {
                if (i != roundDividerIndices.Count - 1)
                {
                    roundContestantCounts.Add((roundDividerIndices[i + 1] - roundDividerIndices[i]) - 1);
                }
                else
                {
                    roundContestantCounts.Add(contestantList.Count - (roundDividerIndices[i] + 1));
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

            if (firstNameTextBox.Text.Trim() != "" && lastNameTextBox.Text.Trim() != "" && seuraComboBox.Text.Trim() != "")
            {
                if (roundContestantCounts[roundContestantCounts.Count - 1] >= MaximumRoundSize)
                    addNewRound();

                contestantList.Add(new Contestant(generateId(), firstNameTextBox.Text, lastNameTextBox.Text, seuraComboBox.Text, sarjaComboBox.Text, joukkueComboBox.Text));

                refreshContestantListView();

                firstNameTextBox.Clear();
                lastNameTextBox.Clear();
                seuraComboBox.Text = "";
                joukkueComboBox.Text = "";
                objectListView1.EnsureVisible(objectListView1.Items.Count - 1);
            }
            else
            {
                MessageBox.Show("Osallistujalla täytyy olla etunimi, sukunimi ja seura", "Varoitus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addNewRound()
        {
            if (roundDividerIndices != null || roundDividerIndices.Count > 0)
                contestantList.Add(new RoundDivider("roundCold;" + (roundDividerIndices.Count + 1).ToString(), "Erä"));
            else
                contestantList.Add(new RoundDivider("roundCold;1", "Erä"));

            updateDividerIndicesAndContestantCounts();
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
            List<int> indexList = new List<int>();
            List<ContestantListLine> newList = new List<ContestantListLine>();
            int index = 0;
            int newIndex = 0;

            foreach (ContestantListLine line in contestantList)
            {
                if (!line.Id.Contains("round") && line.FullName.Trim() != "")
                {
                    indexList.Add(index);
                }
                index++;
            }

            indexList.Shuffle();

            index = 0;
            newIndex = 0;

            foreach (ContestantListLine line in contestantList)
            {
                if (line.Id.Contains("round") || line.FullName.Trim() == "")
                {
                    newList.Insert(index, contestantList[index]);
                }
                else
                {
                    newList.Insert(index, contestantList[indexList[newIndex]]);
                    newIndex++;
                    Console.Write(".");
                }
                index++;
            }

            contestantList = newList;
            refreshContestantListView();
        }

        private void evenOutRounds_Click(object sender, EventArgs e)
        {
            List<ContestantListLine> newList = new List<ContestantListLine>();
            bool done = false;
            int index = MaximumRoundSize + 1;

            foreach (ListViewItem row in objectListView1.Items)
            {
                string[] id = row.SubItems[0].Text.Split(';');

                if (!row.SubItems[0].Text.Contains("round") && row.SubItems[2].Text.Trim() != "")
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
                else if (row.SubItems[0].Text.Contains("round") && id[1] == "1")
                {
                    newList.Add(new RoundDivider(row.SubItems[0].Text.ToString(), row.SubItems[2].Text.ToString()));
                }
            }

            while (!done)
            {
                if (newList.Count > index)
                {
                    double roundNumber = Math.Ceiling((double)newList.Count / (MaximumRoundSize+1));
                    newList.Insert(index, new RoundDivider("roundCold;" + roundNumber.ToString(), "Erä"));
                    index += (MaximumRoundSize + 1);
                }
                else
                    done = true;
            }

            contestantList = newList;
            
            refreshContestantListView();
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

        private void objectListView1_Dropped(object sender, OlvDropEventArgs e)
        {
            Console.WriteLine("dropped");

            updateModelList();
            refreshContestantListView();
        }

        private void importContestantsButton_Click(object sender, EventArgs e)
        {
            //todo
        }

        private void objectListView1_CellOver(object sender, CellOverEventArgs e)
        {
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - objectListView1.Location.X - 2;
            int y = cursor.Y - objectListView1.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem hoverItem = objectListView1.GetItemAt(x, y, out hitColumn);

            if (hitColumn != null && hitColumn.Tag != null && !hoverItem.SubItems[0].Text.Contains("round"))
            {
                if (hitColumn.Tag.ToString() == "grabColumn")
                    Cursor = moveHandCursor;
                else
                    Cursor = Cursors.Default;
            }
        }

        private void objectListView1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void objectListView1_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (e.Item.SubItems[0].Text.Contains("round"))
            {
                string[] id = e.Item.SubItems[0].Text.Split(';');
                if (roundContestantCounts[Convert.ToInt32(id[1]) - 1] > MaximumRoundSize)
                {
                    e.Title = "Varoitus";
                    e.StandardIcon = ToolTipControl.StandardIcons.Warning;
                    e.Text = "Erässä on liikaa kilpailijoita";
                }
            }
        }

        private void objectListView1_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.SubItem.Text.Trim() == "")
            {
                TextDecoration decoration = new TextDecoration("Jälki-ilmoittautumispaikka", 200);
                decoration.Alignment = ContentAlignment.MiddleLeft;
                decoration.Font = new Font(this.Font.Name, this.Font.SizeInPoints + 1);
                decoration.TextColor = Color.Gray;
                e.SubItem.Decoration = decoration;
            }
        }

        private void addEmptyRowButton_Click(object sender, EventArgs e)
        {
            if (roundContestantCounts[roundContestantCounts.Count - 1] >= MaximumRoundSize)
                addNewRound();

            contestantList.Add(new Contestant(generateId(), "", "", "", "", ""));
            refreshContestantListView();

            objectListView1.EnsureVisible(objectListView1.Items.Count-1);
        }

        private void addEmptyRowsButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < roundContestantCounts.Count; i++)
            {
                if (roundContestantCounts[i] < MaximumRoundSize)
                {
                    int emptySlots = MaximumRoundSize - roundContestantCounts[i];

                    while (emptySlots > 0)
                    {
                        if (i < roundDividerIndices.Count - 1)
                            contestantList.Insert(roundDividerIndices[i + 1], new Contestant(generateId(), "", "", "", "", ""));
                        else
                            contestantList.Add(new Contestant(generateId(), "", "", "", "", ""));

                        emptySlots--;
                    }
                    updateDividerIndicesAndContestantCounts();
                }                
            }
            refreshContestantListView();
        }

        private void addNewRoundButton_Click(object sender, EventArgs e)
        {
            addNewRound();
            refreshContestantListView();
            objectListView1.EnsureVisible(objectListView1.Items.Count - 1);
        }

        private void objectListView1_CellRightClick(object sender, CellRightClickEventArgs e)
        {

            if (e.Item.SubItems[0].Text.Contains("round"))
            {
                e.MenuStrip = roundDividerContextMenuStrip;
            }
            else
            {
                e.MenuStrip = contestantRowContextMenuStrip;
            }
        }

        private void deleteContestantItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Model:");

            //for (int i = 0; i < contestantList.Count; i++)
            //    //Console.WriteLine(contestantList[i].FullName);

            //Console.WriteLine("View:");
            //for (int i = 0; i < objectListView1.Items.Count; i++)
            //    //Console.WriteLine(objectListView1.Items[i].SubItems[2]);
        }
    }
}
