using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Hauli
{

    public partial class RoundScheduleView : Form
    {
        private readonly int MaximumTrackCount = 10;
        private HauliDBHandler dbHandler;
        //private List<eräKierrosListLine> eräKierrosList;
        private Cursor moveHandCursor;
        private List<Color> colorList;
        private int trackCount = 1;
        private double roundDuration = 1;
        private double startingHourDay1;
        private double startingMinuteDay1;
        private double startingHourDay2;
        private double startingMinuteDay2;
        private List<List<RoundLine>> trackModelList;
        private List<ObjectListView> trackObjectListViewList;

        public RoundScheduleView(HauliDBHandler dbHandler, string tc, string rd, bool dayTwo, string startingHday1, string startingMday1, string startingHday2, string startingMday2)
        {
            this.dbHandler = dbHandler;

            if (tc.Trim() != "")
                this.trackCount = Convert.ToInt32(tc);

            if (rd.Trim() != "")
                this.roundDuration = Convert.ToDouble(rd);

            if (startingHday1.Trim() != "")
                this.startingHourDay1 = Convert.ToDouble(startingHday1);

            if (startingHday2.Trim() != "")
                this.startingHourDay2 = Convert.ToDouble(startingHday2);

            if (startingMday1.Trim() != "")
                this.startingMinuteDay1 = Convert.ToDouble(startingMday1);

            if (startingMday2.Trim() != "")
                this.startingMinuteDay2 = Convert.ToDouble(startingMday2);

            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            moveHandCursor = new Cursor("Resources/move.cur");
            trackModelList = new List<List<RoundLine>>();

            colorList = new List<Color>();
            colorList.Add(Color.White);
            colorList.Add(Color.LightSkyBlue);
            colorList.Add(Color.Yellow);
            colorList.Add(Color.LightGreen);
            colorList.Add(Color.Orange);
            colorList.Add(Color.Violet);
            colorList.Add(Color.DarkKhaki);
            colorList.Add(Color.Lime);
            colorList.Add(Color.Cyan);
            colorList.Add(Color.LightPink);
            colorList.Add(Color.Tomato);
            colorList.Add(Color.MediumBlue);
            colorList.Add(Color.LemonChiffon);

            trackObjectListViewList = new List<ObjectListView>();
            trackObjectListViewList.Add(trackObjectListView1);
            trackObjectListViewList.Add(trackObjectListView2);
            trackObjectListViewList.Add(trackObjectListView3);
            trackObjectListViewList.Add(trackObjectListView4);
            trackObjectListViewList.Add(trackObjectListView5);
            trackObjectListViewList.Add(trackObjectListView6);
            trackObjectListViewList.Add(trackObjectListView7);
            trackObjectListViewList.Add(trackObjectListView8);
            trackObjectListViewList.Add(trackObjectListView9);
            trackObjectListViewList.Add(trackObjectListView10);

            List<ComboBox> trackNumberComboBoxList = new List<ComboBox>();
            trackNumberComboBoxList.Add(trackNumberComboBox1);
            trackNumberComboBoxList.Add(trackNumberComboBox2);
            trackNumberComboBoxList.Add(trackNumberComboBox3);
            trackNumberComboBoxList.Add(trackNumberComboBox4);
            trackNumberComboBoxList.Add(trackNumberComboBox5);
            trackNumberComboBoxList.Add(trackNumberComboBox6);
            trackNumberComboBoxList.Add(trackNumberComboBox7);
            trackNumberComboBoxList.Add(trackNumberComboBox8);
            trackNumberComboBoxList.Add(trackNumberComboBox9);
            trackNumberComboBoxList.Add(trackNumberComboBox10);

            List<string> trackList = new List<string>();
            for (int i = 1; i <= 10; i++)
                trackList.Add("Rata " + i);

            for (int i = 0; i < trackNumberComboBoxList.Count; i++)
            {
                trackNumberComboBoxList[i].Items.AddRange(trackList.ToArray());
                trackNumberComboBoxList[i].Text = trackList[i];
            }

            for (int i = 0; i < trackCount; i++)
                trackModelList.Add(new List<RoundLine>());


            for (int i = 0, k = 0; i < MaximumTrackCount; i++)
            {
                trackModelList[k].Add(new RoundLine((i + 1), "Erä " + (i + 1) + "\nKierros " + (i + 1)));

                if (i >= (MaximumTrackCount - 1))
                {
                    for (int n = 0; n < 30; n++)
                        trackModelList[k].Add(new RoundLine(0, ""));

                    if (k < (trackCount - 1))
                    {
                        i = -1;
                        k++;
                    }
                }
            }

            for (int i = MaximumTrackCount - 1; i >= trackCount; i--)
            {
                //trackObjectListViewList[i].Hide();
                trackNumberComboBoxList[i].Hide();
                trackObjectListViewList[i].Enabled = false;
            }

            for (int i = 0; i < trackCount; i++)
            {
                trackObjectListViewList[i].DropSink = new RearrangingDropSink(true);
                ((RearrangingDropSink)trackObjectListViewList[i].DropSink).CanDropOnBackground = false;
                trackObjectListViewList[i].GetColumn(0).AspectGetter = delegate(Object x) { return ((RoundLine)x).Text; };
                trackObjectListViewList[i].GetColumn(0).WordWrap = true;
                trackObjectListViewList[i].SetObjects(trackModelList[i]);
                trackObjectListViewList[i].GridLines = true;
                trackObjectListViewList[i].Cursor = moveHandCursor;
            }

            DateTime time = new DateTime();
            time = time.AddHours(startingHourDay1);
            time = time.AddMinutes(startingMinuteDay1);
            List<string> timeModelList = new List<string>();
            
            timeModelList.Add(time.ToShortTimeString());
            int timeIterations = 720 / Convert.ToInt16(roundDuration);

            for (int i = 0; i < timeIterations; i++)
            {
                time = time.AddMinutes(roundDuration);
                timeModelList.Add(time.ToShortTimeString());
            }

            timeObjectListView.GetColumn(0).AspectGetter = delegate(Object x) { return x.ToString(); };

            timeObjectListView.SetObjects(timeModelList);
            timeObjectListView.GridLines = true;

            //  RoundTable.DragSource = new SimpleDragSource();
            //  RearrangingDropSink dropsink = new RearrangingDropSink(true);
            //  dropsink.FeedbackColor = Color.Black;
            //  RoundTable.DropSink = dropsink;
            ////  dropsink.CanDropOnSubItem = true;

            //  eräKierrosList = new List<eräKierrosListLine>();
            //  eräKierrosList.Add(new Erä(/*generateId(), */"9:00", "Erä 1/1", "Erä 2/1", "Erä 3/1", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"9:30", "Erä 3/2", "Erä 1/2", "Erä 2/2", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"10:00", "Erä 2/3", "Erä 3/3", "Erä 1/3", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"10:30", "Erä 1/4", "Erä 2/4", "Erä 3/4", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"11:00", "Erä 3/5", "Erä 1/5", "Erä 2/5", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"11:30", "Erä 2/6", "Erä 3/6", "Erä 1/6", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"12:00", "", "", "gr", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"12:30", "fg", "", "", "efe", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"13:00", "", "", "", "", "", ""));
            //  eräKierrosList.Add(new Erä(/*generateId(), */"13:30", "rg", "rgr", "", "", "fe", "aaa"));

            ////  idColumn.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).Id; };
            //  kloColumn.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).Klo; };
            //  kloColumn.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).Klo = newValue.ToString(); };
            //  rataColumn1.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros1; };
            //  rataColumn1.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros1 = newValue.ToString(); };

            //  rataColumn2.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros2; };
            //  rataColumn2.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros2 = newValue.ToString(); };
            //  rataColumn3.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros3; };
            //  rataColumn3.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros3 = newValue.ToString(); };
            //  rataColumn4.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros4; };
            //  rataColumn4.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros4 = newValue.ToString(); };
            //  rataColumn5.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros5; };
            //  rataColumn5.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros5 = newValue.ToString(); };
            //  rataColumn6.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros6; };
            //  rataColumn6.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros6 = newValue.ToString(); };

            //  refreshEräKierrosListView();
        }

        private void formatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;

            ObjectListView tempOLV = (ObjectListView)sender;

            foreach (ListViewItem row in tempOLV.Items)
            {
                RoundLine modelLine = (RoundLine)tempOLV.GetModelObject(row.Index);
                if (modelLine != null && modelLine.Round < colorList.Count)
                    row.BackColor = colorList[modelLine.Round];
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            trackObjectListView1.GridLines = true;
            trackObjectListView1.Select();
            trackObjectListView1.RedrawItems(0, trackObjectListView1.Items.Count - 1, false);
            trackObjectListView1.Refresh();
            trackObjectListView1.RefreshObjects(trackModelList[0]);

        }
        /*
        private string generateId()
        {
            List<string> idList = new List<string>();
            bool ok = false;
            Random random = new Random();
            int id = 0;

            if (eräKierrosList.Count != 0)
                for (int i = 0; i < eräKierrosList.Count; i++)
                    idList.Add(eräKierrosList[i].Id);

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

        private void refreshEräKierrosListView()
        {
            Console.WriteLine("refreshEräKierrosListView");
            //RoundTable.SetObjects(eräKierrosList);
        }

        private void RoundTable_ItemDrag(Object sender, ItemDragEventArgs e)
        {
        /*    Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - RoundTable.Location.X - 2;
            int y = cursor.Y - RoundTable.Location.Y - 2;

            ListViewItem draggedItem = RoundTable.GetItemAt(x, y);
            */
        //  }  

        //private void RoundTable_Dropped(object sender, OlvDropEventArgs e)
        //{
        //    refreshEräKierrosListView();
        //}


        //// Moves the insertion mark as the item is dragged.
        //private void RoundTable_DragOver(object sender, DragEventArgs e)
        //{
        //    // Retrieve the client coordinates of the mouse pointer.
        //    Point targetPoint =
        //        RoundTable.PointToClient(new Point(e.X, e.Y));

        //    // Retrieve the index of the item closest to the mouse pointer.
        //    int targetIndex = RoundTable.InsertionMark.NearestIndex(targetPoint);

        //    // Confirm that the mouse pointer is not over the dragged item.
        //    if (targetIndex > -1)
        //    {
        //        // Determine whether the mouse pointer is to the left or
        //        // the right of the midpoint of the closest item and set
        //        // the InsertionMark.AppearsAfterItem property accordingly.
        //        Rectangle itemBounds = RoundTable.GetItemRect(targetIndex);
        //        if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
        //        {
        //            RoundTable.InsertionMark.AppearsAfterItem = true;
        //        }
        //        else
        //        {
        //            RoundTable.InsertionMark.AppearsAfterItem = false;
        //        }
        //    }

        //    // Set the location of the insertion mark. If the mouse is
        //    // over the dragged item, the targetIndex value is -1 and
        //    // the insertion mark disappears.
        //    RoundTable.InsertionMark.Index = targetIndex;
        //}
    }
}
