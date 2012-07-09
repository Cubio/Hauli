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
using System.IO;

namespace Hauli
{
    public partial class ContestantListForm : Form
    {
        private readonly int MaximumRoundSize = 6;
        private HauliDBHandler dbHandler;
        private List<ContestantListLine> contestantList;
        private List<string> seuraList;
        private List<string> sarjaList;
        private Cursor moveHandCursor;
        private List<int> roundContestantCounts;
        private List<int> roundDividerIndices;
        private StreamReader file;
        private Boolean virhe = false;

        public ContestantListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;

            AutoCompleteStringCollection seuraAutoCompleteCollection = new AutoCompleteStringCollection();
            seuraList = new List<string>();
            sarjaList = new List<string>();

            moveHandCursor = new Cursor("Resources/move.cur");


            seuraList = dbHandler.getSeuraBox();


            seuraAutoCompleteCollection.AddRange(seuraList.ToArray());
            seuraComboBox.AutoCompleteCustomSource = seuraAutoCompleteCollection;
            seuraComboBox.Items.AddRange(seuraList.ToArray());


            sarjaList = dbHandler.getSarjaBox();



            sarjaComboBox.Items.AddRange(sarjaList.ToArray());
            sarjaComboBox.Text = sarjaList[0];

            objectListView1.DragSource = new SimpleDragSource();

            RearrangingDropSink dropsink = new RearrangingDropSink(true);
            dropsink.FeedbackColor = Color.Black;
            objectListView1.DropSink = dropsink;

            contestantList = new List<ContestantListLine>();

            contestantList.Add(new RoundDivider(false, 1, "Erä"));

            contestantList.Add(new Contestant(generateId(), "Teppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Aeppo", "Töppönen", "OSH", "Y", "Ninja-pinjat"));
            contestantList.Add(new Contestant(generateId(), "Beppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Ceppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider(false, 2, "Erä"));
            contestantList.Add(new Contestant(generateId(), "Deppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Eeppo", "Töppönen", "OSH", "Y", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Feppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Geppoliina", "Töppönen", "OSH", "N", "Ninja-pinjat"));
            contestantList.Add(new RoundDivider(false, 3, "Erä"));
            contestantList.Add(new Contestant(generateId(), "Heppo", "Töppönen", "OSH", "Y", "Ninja-pinjat"));
            contestantList.Add(new Contestant(generateId(), "Ieppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant(generateId(), "Jeppoliina", "Töppönen", "OSH", "N", "Jouko-poukot"));
            contestantList.Add(new Contestant(generateId(), "Keppo", "Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider(false, 4, "Erä"));
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
                if (((ContestantListLine)row) is RoundDivider)
                    return -1;
                else
                    return 3;

            };
            grabColumn.Tag = "grabColumn";

            buttonColumn1.ImageGetter = delegate(object row)
            {
                if (!(((ContestantListLine)row) is RoundDivider))
                    return 0;
                else
                    return 2;

            };
            buttonColumn1.Tag = "buttonColumn1";

            buttonColumn2.ImageGetter = delegate(object row)
            {
                if (!(((ContestantListLine)row) is RoundDivider) || (((ContestantListLine)row).Id > 1))
                    return 1;
                else
                    return -1;
            };
            buttonColumn2.Tag = "buttonColumn2";

            objectListView1.SetObjects(contestantList);
            countRoundSizes();
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
            ContestantListLine tempLine = (ContestantListLine)objectListView1.GetModelObject(((ListViewItem)e.Item).Index);

            if (tempLine is RoundDivider)
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
            ContestantListLine clickedModelItem = (ContestantListLine)objectListView1.GetModelObject(clickedItem.Index);
            Contestant selectedContestant = null;

            if (!(clickedModelItem is RoundDivider))

                for (int i = 0; i < contestantList.Count; i++)
                {
                    if (!(contestantList[i] is RoundDivider) && contestantList[i].Id == clickedModelItem.Id)
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
            ContestantListLine clickedModelItem = null;
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - objectListView1.Location.X - 2;
            int y = cursor.Y - objectListView1.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem clickedItem = objectListView1.GetItemAt(x, y, out hitColumn);
            
            if(clickedItem != null)
                clickedModelItem = (ContestantListLine)objectListView1.GetModelObject(clickedItem.Index);
            
            Contestant selectedContestant = null;

            if (hitColumn != null && hitColumn.Tag != null && clickedItem != null)
            {
                if (hitColumn.Tag.ToString() == "buttonColumn1")
                {
                    if (clickedModelItem is RoundDivider && clickedModelItem.HotRound)
                    {
                        foreach (ContestantListLine line in contestantList)
                        {
                            if (line is RoundDivider && (line.Id == clickedModelItem.Id))
                            {
                                line.HotRound = false;
                            }
                        }
                        refreshContestantListView();
                    }
                    else if (clickedModelItem is RoundDivider && !clickedModelItem.HotRound)
                    {
                        foreach (ContestantListLine line in contestantList)
                        {
                            if (line is RoundDivider && (line.Id == clickedModelItem.Id))
                            {
                                line.HotRound = true;
                            }
                        }

                        refreshContestantListView();
                    }
                    else
                    {
                        for (int i = 0; i < contestantList.Count; i++)
                        {
                            if (!(clickedModelItem is RoundDivider) && contestantList[i].Id == clickedModelItem.Id)
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
                    if (!(clickedModelItem is RoundDivider) || (clickedModelItem.Id > 1))
                    {
                        Console.WriteLine("Poistonappi");
                        deleteLine(clickedItem);
                    }
                }
            }
        }

        private void deleteLine(ListViewItem item)
        {
            DialogResult result;
            string message;

            ContestantListLine modelLine = (ContestantListLine)objectListView1.GetModelObject(item.Index);

            if (modelLine is RoundDivider)
                message = "Haluatko varmasti poistaa erän?\nErän osallistujat liitetään edelliseen erään";
            else
                message = "Haluatko varmasti poistaa osallistujan?";

            result = MessageBox.Show(message, "Hauli", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < contestantList.Count; i++)
                {
                    if (contestantList[i].Id == modelLine.Id)
                    {
                        contestantList.RemoveAt(i);
                        objectListView1.RemoveObject(objectListView1.GetModelObject(item.Index));
                    }

                }
                if (modelLine is RoundDivider)
                    validateRoundDividerIDs();


                refreshContestantListView();
                countRoundSizes();
            }
        }

        private void validateRoundDividerIDs()
        {
            int round = 1;

            Console.WriteLine("ValidateRoundDividerIDs");

            for (int i = 0; i < contestantList.Count; i++)
            {
                if (contestantList[i] is RoundDivider)
                {
                    contestantList[i].Id = round;
                    round++;
                }
            }

            round = 1;

            for (int i = 0; i < objectListView1.Items.Count; i++)
            {
                ContestantListLine tempLine = (ContestantListLine)objectListView1.GetModelObject(i);

                if (tempLine is RoundDivider)
                {
                    objectListView1.Items[i].SubItems[0].Text = round.ToString();
                    objectListView1.RefreshSelectedObjects();
                    round++;
                }
            }

            objectListView1.RefreshObjects(contestantList);
        }

        private void refreshContestantListView()
        {
            Console.WriteLine("refreshContestantListView");

            int topItemIndex = objectListView1.TopItemIndex;

            objectListView1.SetObjects(contestantList);
            countRoundSizes();
            objectListView1.SetObjects(contestantList);

            OperatingSystem OS = Environment.OSVersion;

            if (OS.Version.Major > 5)
            {
                if (topItemIndex >= 0 && topItemIndex < objectListView1.Items.Count)
                    objectListView1.TopItem = objectListView1.Items[topItemIndex];
                else
                    objectListView1.EnsureVisible(objectListView1.Items.Count - 1);
            }
        }

        private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;

            foreach (ListViewItem row in objectListView1.Items)
            {
                ContestantListLine modelLine = (ContestantListLine)objectListView1.GetModelObject(row.Index);

                if (modelLine is RoundDivider)
                {
                    if (modelLine.HotRound)
                        row.BackColor = Color.LightPink;
                    else
                        row.BackColor = Color.LightGray;
                }

                //Tarkastetaan että erä 1:n divider on ensimmäisenä listassa                
                if (row.Index == 0 && !(modelLine is RoundDivider))
                {
                    for (int i = 0; i < objectListView1.Items.Count; i++)
                    {
                        ContestantListLine tempModelLine = (ContestantListLine)objectListView1.GetModelObject(i);

                        if (tempModelLine is RoundDivider && tempModelLine.Id == 1)
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

        private void updateModelList()
        {
            List<ContestantListLine> newList = new List<ContestantListLine>();

            Console.WriteLine("updateModelList");

            foreach (ListViewItem row in objectListView1.Items)
            {
                ContestantListLine modelLine = (ContestantListLine)objectListView1.GetModelObject(row.Index);
                if (modelLine is RoundDivider)
                    newList.Add(new RoundDivider(modelLine.HotRound, modelLine.Id, modelLine.FullName));
                else
                    newList.Add(new Contestant(modelLine.Id, modelLine.FirstName, modelLine.LastName, modelLine.Seura, modelLine.Sarja, modelLine.Team));
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
                ContestantListLine modelLine = (ContestantListLine)objectListView1.GetModelObject(row.Index);

                if (modelLine is RoundDivider)
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
                if (((ContestantListLine)row) is RoundDivider)
                {
                    updateDividerIndicesAndContestantCounts();

                    int roundNumber = ((ContestantListLine)row).Id;

                    if (roundNumber <= roundContestantCounts.Count && roundContestantCounts[roundNumber - 1] > MaximumRoundSize)
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
                if (contestantList[i] is RoundDivider)
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
            openFileDialogContestant.Filter = "Cursor Files|*.txt";
            openFileDialogContestant.Title = "Valitse ";
            openFileDialogContestant.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            importFilePathTextBox.Text = openFileDialogContestant.FileName;
        }

        private void addContestantButton_Click(object sender, EventArgs e)
        {

            if (firstNameTextBox.Text.Trim() != "" && lastNameTextBox.Text.Trim() != "" && seuraComboBox.Text.Trim() != "")
            {
                if (roundContestantCounts[roundContestantCounts.Count - 1] >= MaximumRoundSize)
                    addNewRound();

                int id = generateId();
                contestantList.Add(new Contestant(id, firstNameTextBox.Text, lastNameTextBox.Text, seuraComboBox.Text, sarjaComboBox.Text, joukkueComboBox.Text));
                objectListView1.AddObject(new Contestant(generateId(), firstNameTextBox.Text, lastNameTextBox.Text, seuraComboBox.Text, sarjaComboBox.Text, joukkueComboBox.Text));
                
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
            {
                contestantList.Add(new RoundDivider(false, roundDividerIndices.Count + 1, "Erä"));
                objectListView1.AddObject(new RoundDivider(false, roundDividerIndices.Count + 1, "Erä"));
            }
            else
            {
                contestantList.Add(new RoundDivider(false, 1, "Erä"));
                objectListView1.AddObject(new RoundDivider(false, 1, "Erä"));
            }
        }

        private int generateId()
        {
            List<int> idList = new List<int>();
            bool ok = false;
            Random random = new Random();
            int id = 0;

            if (contestantList.Count != 0)
                for (int i = 0; i < contestantList.Count; i++)
                    idList.Add(contestantList[i].Id);

            id = random.Next(10000, 99999);

            do
            {
                if (!idList.Contains(id))
                    ok = true;
                else
                    id = random.Next(10000, 99999);
            } while (!ok);

            return id;
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

                    break;
                }
            }

            for (int i = 0; i < objectListView1.Items.Count; i++)
            {
                if (objectListView1.Items[i].SubItems[0].Text == updatedContestant.Id.ToString())
                {
                    objectListView1.Items[i].SubItems[2].Text = updatedContestant.FullName;
                    objectListView1.Items[i].SubItems[3].Text = updatedContestant.Seura;
                    objectListView1.Items[i].SubItems[4].Text = updatedContestant.Sarja;
                    objectListView1.Items[i].SubItems[5].Text = updatedContestant.Team;

                    break;
                }
            }
            refreshContestantListView();
        }

        private void mixListOrderButton_Click(object sender, EventArgs e)
        {
            List<int> indexList = new List<int>();
            List<ContestantListLine> newModelList = new List<ContestantListLine>();
            List<ListViewItem> newViewList = new List<ListViewItem>();
            int index = 0;
            int newIndex = 0;

            foreach (ContestantListLine line in contestantList)
            {
                if (!(line is RoundDivider) && line.FullName.Trim() != "")
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
                if ((line is RoundDivider) || line.FullName.Trim() == "")
                {
                    newModelList.Insert(index, contestantList[index]);
                }
                else
                {
                    newModelList.Insert(index, contestantList[indexList[newIndex]]);

                    newIndex++;
                    Console.Write(".");
                }
                index++;
            }

            contestantList = newModelList;

            refreshContestantListView();
        }

        private void evenOutRounds_Click(object sender, EventArgs e)
        {
            List<ContestantListLine> newList = new List<ContestantListLine>();
            bool done = false;
            int index = MaximumRoundSize + 1;

            foreach (ListViewItem row in objectListView1.Items)
            {
                ContestantListLine modelLine = (ContestantListLine)objectListView1.GetModelObject(row.Index);

                if (!(modelLine is RoundDivider) && row.SubItems[2].Text.Trim() != "")
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
                else if (modelLine is RoundDivider && modelLine.Id == 1)
                {
                    newList.Add(new RoundDivider(modelLine.HotRound, modelLine.Id, modelLine.FullName));
                }
            }

            while (!done)
            {
                if (newList.Count > index)
                {
                    newList.Insert(index, new RoundDivider(false, 1, "Erä"));
                    index += (MaximumRoundSize + 1);
                }
                else
                    done = true;
            }

            contestantList = newList;
            validateRoundDividerIDs();
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
            //Tarkistetaan onko tiedosto olemassa, jos on niin luetaan se.
            if (File.Exists(openFileDialogContestant.FileName))
            {
                // Read the file and display it line by line.
                string line;
                int rivi = 0;
               
                List<string[]> lines = new List<string[]>();

                file = new StreamReader(openFileDialogContestant.FileName);
                try
                {


                    while ((line = file.ReadLine()) != null)
                    {
                        rivi++;
                        string[] tiedot = line.Split(',');
                        lines.Add(tiedot);
                        if (tiedot.Length != 7)
                        {
                            virhe = true;
                            throw new HauliException("Tekstitiedostossa on virheellisiä merkintöjä. Rivillä:" + rivi);
                        }
                    }
                }
                catch (HauliException ex)
                {
                    file.ReadToEnd();
                    MessageBox.Show(ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    file.Close();
                }
                if (virhe == false)
                {
                    dbHandler.addFileOsallistujat(lines);
                }
            }
        }

        private void objectListView1_CellOver(object sender, CellOverEventArgs e)
        {
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - objectListView1.Location.X - 2;
            int y = cursor.Y - objectListView1.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem hoverItem = objectListView1.GetItemAt(x, y, out hitColumn);

            if (hoverItem != null)
            {
                ContestantListLine modelItem = (ContestantListLine)objectListView1.GetModelObject(hoverItem.Index);

                if (hitColumn != null && hitColumn.Tag != null && !(modelItem is RoundDivider))
                {
                    if (hitColumn.Tag.ToString() == "grabColumn")
                        Cursor = moveHandCursor;
                    else
                        Cursor = Cursors.Default;
                }
            }
        }

        private void objectListView1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void objectListView1_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            ContestantListLine modelItem = (ContestantListLine)objectListView1.GetModelObject(e.Item.Index);

            if (modelItem is RoundDivider && (roundContestantCounts[Convert.ToInt32(e.Item.SubItems[0].Text)-1] > MaximumRoundSize))
            {
                e.Title = "Varoitus";
                e.StandardIcon = ToolTipControl.StandardIcons.Warning;
                e.Text = "Erässä on liikaa kilpailijoita";
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

            int id = generateId();

            objectListView1.AddObject(new Contestant(id, "", "", "", "", ""));
            contestantList.Add(new Contestant(id, "", "", "", "", ""));
            countRoundSizes();

            objectListView1.EnsureVisible(objectListView1.Items.Count - 1);
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
                        int id = generateId();

                        if (i < roundDividerIndices.Count - 1)
                        {
                            contestantList.Insert(roundDividerIndices[i + 1], new Contestant(id, "", "", "", "", ""));
                            object[] temp = new object[1];
                            temp[0] = new Contestant(id, "", "", "", "", "");
                            objectListView1.InsertObjects(roundDividerIndices[i + 1], temp);
                        }
                        else
                        {
                            contestantList.Add(new Contestant(id, "", "", "", "", ""));
                            objectListView1.AddObject(new Contestant(id, "", "", "", "", ""));
                        }

                        emptySlots--;
                    }
                    updateDividerIndicesAndContestantCounts();
                    countRoundSizes();
                }
            }
        }

        private void addNewRoundButton_Click(object sender, EventArgs e)
        {
            addNewRound();
            objectListView1.EnsureVisible(objectListView1.Items.Count - 1);
            countRoundSizes();
        }

        private void objectListView1_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            ContestantListLine modelLine = (ContestantListLine)objectListView1.GetModelObject(e.Item.Index);

            if (modelLine is RoundDivider)
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
            for (int i = 0; i < contestantList.Count; i++)
            {
                if (contestantList[i] is RoundDivider){
                    Console.WriteLine("Erä " + contestantList[i].Id + ", kuuma: " + contestantList[i].HotRound);

                    ContestantListLine tempLine = (ContestantListLine)objectListView1.GetModelObject(i);

                    Console.WriteLine("List model id: " + tempLine.Id);
                }else{
                    Console.WriteLine(contestantList[i].Id + " " + contestantList[i].FullName);
                    ContestantListLine tempLine = (ContestantListLine)objectListView1.GetModelObject(i);

                    Console.WriteLine("List model id: " + tempLine.Id);
                }
           }
        }
    }
}
