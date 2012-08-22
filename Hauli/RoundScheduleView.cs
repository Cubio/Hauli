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
        private readonly int MaximumSubRoundsMen = 5;
        private readonly int MaximumSubRoundsWomen = 3;
        private HauliDBHandler dbHandler;
        private Cursor moveHandCursor;
        private int trackCount = 1;
        private bool day2Enabled;
        private double roundDuration = 1;
        private double startingHourDay1;
        private double startingMinuteDay1;
        private double startingHourDay2;
        private double startingMinuteDay2;
        private List<List<RoundLine>> trackModelList;
        private List<List<RoundLine>> trackModelListDay2;
        private List<ObjectListView> trackObjectListViewList;
        private List<ObjectListView> trackObjectListViewListDay2;
        private List<Color> roundColors;

        public RoundScheduleView(HauliDBHandler dbHandler, string tc, string rd, bool dayTwo, string startingHday1, string startingMday1, string startingHday2, string startingMday2)
        {
            this.dbHandler = dbHandler;
            InitializeComponent();

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

            List<object> tiedot = new List<object>();
            tiedot = dbHandler.getMainInfo();

            for (int i = 0; i < tiedot.Count; i++)
            {
                Console.WriteLine(tiedot[i].ToString());
                Console.WriteLine(tiedot.Count);
            }

            if (tiedot.Count < 7)
                day2Enabled = true;
            else
                day2Enabled = false;

            if (day2Enabled)
                TabControl.TabPages.Remove(tabPage2);

            rataComboBox.Text = Convert.ToString((int)tiedot[3]);
            eraComboBox.Text = Convert.ToString((int)tiedot[4]);
            
            InitializeView();
            initializeTimeColumns();
            AutoArrangeRoundList();
            initializeTrackListViews();
        }

        private void InitializeView()
        {
            moveHandCursor = new Cursor("Resources/move.cur");
            trackModelList = new List<List<RoundLine>>();
            trackModelListDay2 = new List<List<RoundLine>>();

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

            trackObjectListViewListDay2 = new List<ObjectListView>();
            trackObjectListViewListDay2.Add(trackObjectListView1Day2);
            trackObjectListViewListDay2.Add(trackObjectListView2Day2);
            trackObjectListViewListDay2.Add(trackObjectListView3Day2);
            trackObjectListViewListDay2.Add(trackObjectListView4Day2);
            trackObjectListViewListDay2.Add(trackObjectListView5Day2);
            trackObjectListViewListDay2.Add(trackObjectListView6Day2);
            trackObjectListViewListDay2.Add(trackObjectListView7Day2);
            trackObjectListViewListDay2.Add(trackObjectListView8Day2);
            trackObjectListViewListDay2.Add(trackObjectListView9Day2);
            trackObjectListViewListDay2.Add(trackObjectListView10Day2);

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

            List<ComboBox> trackNumberComboBoxListDay2 = new List<ComboBox>();
            trackNumberComboBoxListDay2.Add(trackNumberComboBox1Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox2Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox3Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox4Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox5Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox6Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox7Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox8Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox9Day2);
            trackNumberComboBoxListDay2.Add(trackNumberComboBox10Day2);

            List<string> trackList = new List<string>();
            for (int i = 1; i <= MaximumTrackCount; i++)
                trackList.Add("Rata " + i);

            for (int i = 0; i < trackNumberComboBoxList.Count; i++)
            {
                trackNumberComboBoxList[i].Items.Clear();
                trackNumberComboBoxList[i].Items.AddRange(trackList.ToArray());
                trackNumberComboBoxList[i].Text = trackList[i];

                trackNumberComboBoxListDay2[i].Items.Clear();
                trackNumberComboBoxListDay2[i].Items.AddRange(trackList.ToArray());
                trackNumberComboBoxListDay2[i].Text = trackList[i];
            }

            for (int i = 0; i < trackCount; i++)
                trackModelList.Add(new List<RoundLine>());

            for (int i = 0; i < trackCount; i++)
                trackModelListDay2.Add(new List<RoundLine>());

            for (int i = MaximumTrackCount - 1; i >= 0; i--)
            {
                //trackObjectListViewList[i].Hide();
                if (i >= trackCount)
                {
                    trackObjectListViewList[i].Items.Clear();
                    trackNumberComboBoxList[i].Hide();
                    trackObjectListViewList[i].Enabled = false;

                    trackObjectListViewListDay2[i].Items.Clear();
                    trackNumberComboBoxListDay2[i].Hide();
                    trackObjectListViewListDay2[i].Enabled = false;
                }
                else
                {
                    trackNumberComboBoxList[i].Show();
                    trackObjectListViewList[i].Enabled = true;

                    trackNumberComboBoxListDay2[i].Show();
                    trackObjectListViewListDay2[i].Enabled = true;
                }
            }
        }

        private void initializeTimeColumns()
        {
            //lisätään ekan päivän kellonajat
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

            //lisätään toisen päivän kellonajat
            time = new DateTime();
            time = time.AddHours(startingHourDay2);
            time = time.AddMinutes(startingMinuteDay2);
            timeModelList.Clear();

            timeModelList.Add(time.ToShortTimeString());
            timeIterations = 720 / Convert.ToInt16(roundDuration);

            for (int i = 0; i < timeIterations; i++)
            {
                time = time.AddMinutes(roundDuration);
                timeModelList.Add(time.ToShortTimeString());
            }

            timeObjectListViewDay2.GetColumn(0).AspectGetter = delegate(Object x) { return x.ToString(); };
            timeObjectListViewDay2.SetObjects(timeModelList);
            timeObjectListViewDay2.GridLines = true;
        }

        private void initializeTrackListViews()
        {
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
            
            for (int i = 0; i < trackCount; i++)
            {
                trackObjectListViewListDay2[i].DropSink = new RearrangingDropSink(true);
                ((RearrangingDropSink)trackObjectListViewListDay2[i].DropSink).CanDropOnBackground = false;
                trackObjectListViewListDay2[i].GetColumn(0).AspectGetter = delegate(Object x) { return ((RoundLine)x).Text; };
                trackObjectListViewListDay2[i].GetColumn(0).WordWrap = true;
                trackObjectListViewListDay2[i].SetObjects(trackModelListDay2[i]);
                trackObjectListViewListDay2[i].GridLines = true;
                trackObjectListViewListDay2[i].Cursor = moveHandCursor;
            }            
        }

        private void AutoArrangeRoundList()
        {
            bool ok = false;
            int round = 1;
            int subround = 1;
            int trackIndex = 0;
            int roundLineIndex = 0;
            bool addEmptyRound = false;
            bool resetRoundNumber = false;

            List<int> rounds = dbHandler.getRoundColumn();
            List<RoundLine> defaultRoundLines = new List<RoundLine>();
            int RoundCount = rounds.Max();
            //int RoundCount = 8;

            int emptyRoundCount = 0;
            int emptyRounds = 0;

            if (trackCount > RoundCount)
                emptyRoundCount = trackCount - RoundCount;

            emptyRounds = emptyRoundCount;

            //todo: tarkasta onko naisten erä. Naisilla 3 kierrosta, miehillä 5.

            while (!ok)
            {
                if (addEmptyRound)
                {
                    defaultRoundLines.Add(new RoundLine(0, 0));
                    addEmptyRound = false;
                }
                else
                {
                    defaultRoundLines.Add(new RoundLine(round, subround));
                }

                if (RoundCount > trackCount) //eriä enemmän kuin ratoja
                {
                    //erien määrä on jaollinen ratojen määrällä
                    /*
                    if ((RoundCount % trackCount) == 0)
                    {
                        if (defaultRoundLines.Count >= RoundCount)
                        {
                            if (defaultRoundLines[defaultRoundLines.Count - 1].Round > trackCount)
                            {
                                //todo
                            }
                            else
                            {

                            }

                        }
                        else
                            round++;
                        
                    }
                    else */if (round >= RoundCount) //normaali lisäys
                    {
                        Console.WriteLine("Round reset");
                        round = 1;
                        subround++;
                        //resetRoundNumber = false;
                    }
                    else
                        round++;


                    /*
                    if (!resetRoundNumber)
                    {
                        if (round >= RoundCount)
                        {
                            Console.WriteLine("Round reset");
                            round = 1;
                            subround++;
                            //resetRoundNumber = false;
                        }
                        else
                            round++;
                    }
                    */
                    if (resetRoundNumber)
                    {
                        Console.WriteLine("resetRoundNumber");
                        round = 1;
                        resetRoundNumber = false;
                        /*
                        if (temp != 0)
                        {
                            round = temp;
                            temp = 0;
                        }
                         * */
                        //subround++;
                    }

                    if ((defaultRoundLines.Count % trackCount) == 0)
                    {
                        Console.WriteLine("rivin loppu");

                        //if ((subround <= MaximumSubRoundsMen) && (defaultRoundLines[defaultRoundLines.Count - 1].Round == RoundCount))
                        //if((subround % 2) == 0)
                        //{

                        //}

                        
                        if ((trackCount != 1) && ((RoundCount % trackCount) == 0) && ((subround % 2) == 0))
                        {
                            Console.WriteLine("parillisen kierrosrivin alku: " + defaultRoundLines[defaultRoundLines.Count - 1].Round);
                            //subround++;
                            //round = round / 2;
                            //if(round != RoundCount)
                            /*
                            temp = round;
                            round = round + trackCount - 1;
                            //round = round + trackCount - 1;
                            //subround++;
                            resetRoundNumber = true;
                            */
                        }
                    }

                    if (subround > MaximumSubRoundsMen)
                    {
                        ok = true;
                    }
                    /*
                    if (subround > MaximumSubRoundsMen)
                    {
                        ok = true;

                        int i = 0;
                        bool ok4 = false;

                        //parillisten kierrosten rivien ensimmäisen ja viimeisen laatikon paikat vaihdetaan jos erien määrä on jaollinen ratojen määrällä
                        
                        if ((trackCount != 1) && ((RoundCount % trackCount) == 0))
                        {
                            i += RoundCount + trackCount - 1;

                            List<int> templist = new List<int>();

                            while (!ok4)
                            {
                                if (i >= defaultRoundLines.Count)
                                {
                                    ok4 = true;
                                }
                                else
                                {
                                    //if((defaultRoundLines[i].SubRound % 2) == 0)
                                    //temp1 = defaultRoundLines[i - (trackCount - 1)].Round;
                                    //defaultRoundLines[i - (trackCount - 1)].Round = defaultRoundLines[i].Round;

                                    for (int k = i - (trackCount - 1); k <= i; k++)
                                    {
                                        if (defaultRoundLines[k].Round > 1)
                                            defaultRoundLines[k].Round = defaultRoundLines[k].Round - 1;
                                        else
                                            defaultRoundLines[k].Round = defaultRoundLines[i].Round;

                                        templist.Add(defaultRoundLines[k].Round);
                                    }

                                    for (int k = i - (trackCount - 1), n = 0; k <= i; k++, n++)
                                    {
                                        defaultRoundLines[k].Round = templist[n];

                                    }
                                    //defaultRoundLines[i].Round = temp1;
                                    // i *= RowsPerSubround, tehdään kunnes taulukko loppuu
                                }

                                i += trackCount;
                            }
                        }
                    }
                    */
                }
                else if (RoundCount <= trackCount) //eriä vähemmän tai saman verran kuin ratoja tai jos erien määrä on jaollinen ratojen määrällä
                {
                    //jos edellinen erä oli viimeisellä radalla, laitetaan saman erän seuraava kierros, tyhjä paikka toistetaan
                    if ((defaultRoundLines.Count % trackCount) == 0)
                    {
                        if (defaultRoundLines[defaultRoundLines.Count - 1].Round == 0)
                            addEmptyRound = true;

                        if (subround <= MaximumSubRoundsMen)
                        {
                            subround++;
                        }
                    }
                    else if ((trackCount > RoundCount) && (round >= RoundCount))
                    {
                        if (emptyRounds > 0)
                        {
                            addEmptyRound = true;
                            emptyRounds--;
                        }
                        else
                        {
                            round = 1;
                            emptyRounds = emptyRoundCount;
                        }
                    }
                    else if (round >= RoundCount)
                    {
                        round = 1;
                    }
                    else
                        round++;

                    if (subround > MaximumSubRoundsMen)
                        ok = true;
                }
            }

            ok = false;

            //lisätään erät ja kierrokset sarakkeisiin
            while (!ok)
            {
                if (day2Enabled != false || defaultRoundLines[roundLineIndex].SubRound <= 3)
                    trackModelList[trackIndex].Add(defaultRoundLines[roundLineIndex]);
                else
                    trackModelListDay2[trackIndex].Add(defaultRoundLines[roundLineIndex]);

                trackIndex = (trackIndex + 1) % trackCount;

                if (roundLineIndex < (defaultRoundLines.Count - 1))
                    roundLineIndex++;
                else
                    ok = true;
            }
            /*
            for (int i = 0, k = 0; i < RoundCount; i++)
            {
                int round = i + 1;
                int subround = i + 1;

                if (subround < MaximumSubRoundsMen)
                    trackModelList[k].Add(new RoundLine(round, subround));

                //tyhjien paikkojen lisäuys ja taulukon vaihto
                if (i >= (RoundCount - 1))
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
        */

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
            //todo
        }

        private void returnDefaultButton_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Haluatko varmasti peruuttaa kaikki muutokset eräaikatauluun?", "Hauli", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (result == DialogResult.Yes)
            {
                InitializeView();
                AutoArrangeRoundList();
                initializeTrackListViews();
            }
        }

        private void rataComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            trackCount = Convert.ToInt32(rataComboBox.Text);
            InitializeView();
            AutoArrangeRoundList();
            initializeTrackListViews();
        }

        private void eraComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            roundDuration = Convert.ToInt32(eraComboBox.Text);
            initializeTimeColumns();
        }
    }
}