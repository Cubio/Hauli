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
            //objectListView1.MouseClick += objectListView1_MouseClick;

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

            refreshContestantList();
        }

        private void setCellBackgroundColors()
        {
            /*
            foreach (ListViewItem item in objectListView1.Items)
            {
                if (item.SubItems[0].Text.Contains("round"))
                {
                    item.BackColor = Color.LightGray;
                }

                if (item.SubItems[3].Text == "Y")
                {
                    item.BackColor = Color.LightBlue;

                }

                if (item.SubItems[3].Text == "N")
                {
                    item.BackColor = Color.LightPink;
                }
            }
              */
        }
        /*
        private void objectListView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = objectListView1.GetItemAt(e.X, e.Y);

            Console.WriteLine("Click: " + clickedItem.Text);

            if (clickedItem != null)
            {
                if (clickedItem.SubItems[1].Text.Contains("Teppo"))
                {
                    Console.WriteLine("Click");
                }
            }
        }
        */
        private void objectListView1_ItemDrag(Object sender, ItemDragEventArgs e)
        {

            if (((ListViewItem)e.Item).SubItems[0].Text.Contains("round"))
            {
                Console.WriteLine("Roundia liikutetaan");
                ((ListViewItem)e.Item).Selected = false;
            }
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            List<string> resultSet = new List<string>();
            resultSet = dbHandler.getContestants();

            if (resultSet == null)
                Console.WriteLine("NULLI ON");

            for (int i = 0; i < resultSet.Count; i++)
            {
                textBox1.AppendText(resultSet[i].ToString());
                textBox1.AppendText("\n");
            }
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            //contestantList[4].Name = "ASDF";
            Contestant cont = new Contestant((Contestant)contestantList[4]);
            contestantList.RemoveAt(4);
            contestantList.Insert(7, cont);
            objectListView1.SetObjects(contestantList);

            setCellBackgroundColors();

            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(contestantList[i].FullName);

            //masterList.Add(new Person("Erä 1", "Pensseli-setä", "Singer", 35, new DateTime(1970, 9, 29), 1145, false, "Introverted, relationally challenged"));

            //list = new List<Person>();
            //foreach (Person p in masterList)
            //list.Add(new Person(p));

            //contestantObjectListView.SetObjects(list);
        }
        */
        private void ObjectListView_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop-event");


            //for (int i = 0; i < masterList.Count; i++)
            //Console.WriteLine(masterList[i].Name);

            //Console.WriteLine("------------");
            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(contestantList[i].FullName);
        }

        private void objectListView1_DragDrop(object sender, DragEventArgs e)
        {
            setCellBackgroundColors();
        }

        private void objectListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //new ContestantRowEditForm().ShowDialog();

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
            ContestantListLine selectedContestant;

            if (hitColumn != null && !clickedItem.SubItems[0].Text.Contains("round") && (hitColumn.Tag != null))
                if (hitColumn.Tag.ToString() == "editButtonColumn")
                {
                    for (int i = 0; i < contestantList.Count; i++)
                        if (!contestantList[i].Id.Contains("round") && contestantList[i].Id == clickedItem.SubItems[0].Text)
                            selectedContestant = (Contestant)contestantList[i];


                    //new ContestantRowEditForm().ShowDialog(selectedContestant);

                }
                else if (hitColumn.Tag.ToString() == "deleteButtonColumn")
                    deleteLine(clickedItem);
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

                refreshContestantList();
            }
        }

        private void refreshContestantList()
        {
            objectListView1.SetObjects(contestantList);
            setCellBackgroundColors();
        }

        private void objectListView1_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;

            foreach (ListViewItem item in objectListView1.Items)
            {
                if (item.SubItems[0].Text.Contains("round"))
                {
                    item.BackColor = Color.LightGray;
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
            refreshContestantList();

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
    }

}
