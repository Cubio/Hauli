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
        List<ContestantListLine> contestantList;

        public ContestantListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;

            //masterList.Add(new Person("Mister Null"));
            //list = new List<Person>();
            //foreach (Person p in masterList)
            //    list.Add(new Person(p));

            objectListView1.DragSource = new SimpleDragSource();

            RearrangingDropSink dropsink = new RearrangingDropSink(true);
            dropsink.FeedbackColor = Color.Black;
            objectListView1.DropSink = dropsink;
            objectListView1.ItemDrag += objectListView1_ItemDrag;

            contestantList = new List<ContestantListLine>();

            contestantList.Add(new RoundDivider("round 1", "Erä 1"));
            contestantList.Add(new Contestant("1234", "1", "Teppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1235", "2", "Aeppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1236", "3", "Beppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1239", "6", "Ceppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider("round 2", "Erä 2"));
            contestantList.Add(new Contestant("1237", "4", "Deppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1238", "5", "Eeppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1239", "6", "Feppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1239", "6", "Geppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider("round 3", "Erä 3"));
            contestantList.Add(new Contestant("1239", "6", "Heppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1239", "6", "Ieppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1239", "6", "Jeppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("1239", "6", "Keppo Töppönen", "OSH", "Y", ""));

            idColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Id; };
            
            nameColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Name; };
            nameColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Name = newValue.ToString(); };
            
            seuraColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Seura; };
            seuraColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Seura = newValue.ToString(); };
            
            sarjaColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Sarja; };
            sarjaColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Sarja = newValue.ToString(); };
            
            joukkueColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Team; };
            joukkueColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Team = newValue.ToString(); };
            
            objectListView1.SetObjects(contestantList);

            //Console.WriteLine(objectListView1.Items[0].Name);
            //objectListView1.item
            //objectListView1.Items[3].BackColor = Color.LightSteelBlue;

            foreach (ListViewItem item in objectListView1.Items)
            {
                if (item.SubItems[0].Text.Contains("round"))
                {
                    item.BackColor = Color.LightGray;
                }
            }
        }

        private void objectListView1_ItemDrag(Object sender, ItemDragEventArgs e)
        {

            if (((ListViewItem)e.Item).SubItems[0].Text.Contains("round"))
            {
                Console.WriteLine("Roundia liikutetaan");
                ((ListViewItem)e.Item).Selected = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(contestantList[i].Name);

            //masterList.Add(new Person("Erä 1", "Pensseli-setä", "Singer", 35, new DateTime(1970, 9, 29), 1145, false, "Introverted, relationally challenged"));

            //list = new List<Person>();
            //foreach (Person p in masterList)
                //list.Add(new Person(p));

            //contestantObjectListView.SetObjects(list);
        }

        private void contestantObjectListView_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop-event");

            //for (int i = 0; i < masterList.Count; i++)
                //Console.WriteLine(masterList[i].Name);
            
            //Console.WriteLine("------------");
            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(contestantList[i].Name);
        }
    }

}
