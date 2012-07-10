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
        private Cursor moveHandCursor;
        private int trackCount = 1;
        private double roundDuration = 1;
        private double startingHourDay1;
        private double startingMinuteDay1;
        private double startingHourDay2;
        private double startingMinuteDay2;
        private List<List<RoundLine>> trackModelList;
        private List<ObjectListView> trackObjectListViewList;
        private List<Color> roundColors;

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

            HauliColors colors = new HauliColors();
            
            roundColors = colors.GetColors();

            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            moveHandCursor = new Cursor("Resources/move.cur");
            trackModelList = new List<List<RoundLine>>();

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
            for (int i = 1; i <= MaximumTrackCount; i++)
                trackList.Add("Rata " + i);

            for (int i = 0; i < trackNumberComboBoxList.Count; i++)
            {
                trackNumberComboBoxList[i].Items.AddRange(trackList.ToArray());
                trackNumberComboBoxList[i].Text = trackList[i];
            }

            for (int i = 0; i < trackCount; i++)
                trackModelList.Add(new List<RoundLine>());


            for (int i = 0, k = 0; i < 40; i++)
            {
                trackModelList[k].Add(new RoundLine((i + 1), (i + 1)));

                if (i >= (40 - 1))
                {
                    for (int n = 0; n < 5; n++)
                        trackModelList[k].Add(new RoundLine(0, 0));

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
        }

        private void formatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;

            ObjectListView tempOLV = (ObjectListView)sender;

            foreach (ListViewItem row in tempOLV.Items)
            {
                RoundLine modelLine = (RoundLine)tempOLV.GetModelObject(row.Index);
                if (modelLine != null)
                    row.BackColor = roundColors[modelLine.Round % roundColors.Count];
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<string> rounds = dbHandler.getRoundColumn();
            for (int i = 0; i < rounds.Count; i++ )
                Console.WriteLine(rounds[i]);

            
        }
    }
}
