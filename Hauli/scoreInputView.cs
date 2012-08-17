using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Hauli
{
    public partial class ScoreInputView : Form
    {
        private HauliDBHandler dbHandler;
        private List<OsallistujaListLine> osallistujaList; //lista kilpailun pisteista
        private List<OsallistujaListLine> osallistujaList2; //lista kokonaispisteista
        private List<OsallistujaListLine> osallistujaList3; //lista finaalin pisteista
        List<string> SarjaTiedot = new List<string>();
        List<int> Erat = new List<int>();
        int a = 0;
        string[] Sarjat = new string[30];

    /// <summary>
    /// Alustetaan komponentit, luodaan uudet osallistujaListat, 
    /// haetaan erien maara comboboxiin ja naytetaan ensimmainen era, 
    /// haetaan kilpailussa mukana olevat sarjat ja laitetaan ne comboboxiin, 
    /// piilotetaan valmiiksi tehdyt tabit, nimetaan ja esitetaan kilpailussa 
    /// mukana olevat sarjat seka esitetaan ensimmaisen tabin sarjatiedot
    /// </summary>
    /// <param name="dbHandler"></param>
        public ScoreInputView(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;
            osallistujaList = new List<OsallistujaListLine>();
            osallistujaList3 = new List<OsallistujaListLine>();

            Erat = dbHandler.getEraBox();
            foreach (int e in Erat)
            {
                EraComboBox.Items.Add(e);
            }
            EraComboBox.SelectedIndex = 0;
            OsallistujatListaan(Erat[0]);

            SarjaTiedot = dbHandler.getKilpailussaOlevatSarjatBox();
            foreach (string s in SarjaTiedot)
            {
                sarjaComboBox.Items.Add(s);

            }
            
            hideSarjaTabs();
            nameSarjaTabs();
            SarjaTulokset(SarjaTiedot[0]);
        }

        /// <summary>
        /// Haetaan valitun eran osallistujien tiedot osallistujaListaan kutsumalla 
        /// tietokantametodia ja esitetaan listan tiedot taulukossa
        /// </summary>
        /// <param name="eraNumero">Valitun eran numero</param>
        private void OsallistujatListaan(int eraNumero)
        {
            //osallistujaList = new List<OsallistujaListLine>();         
            osallistujaList = dbHandler.getOsallistujaList(eraNumero);

            id.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Id; };
            nro.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nro; };
            lastname.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
            lastname.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
            name.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
            name.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
            round_25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
            round_25.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Kierros25 = Convert.ToInt32(newValue); };
            round_50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
            round_50.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Kierros50 = Convert.ToInt32(newValue); };
            round_75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
            round_75.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Kierros75 = Convert.ToInt32(newValue); };
            round_100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
            round_100.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Kierros100 = Convert.ToInt32(newValue); };
            round_125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
            round_125.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Kierros125 = Convert.ToInt32(newValue); };
            solving.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
            solving.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).KierrosRatkonta = Convert.ToInt32(newValue); };

            scoreNormal.SetObjects(osallistujaList);
            //refresOsallistujaListView();
        }

        /// <summary>
        /// Haetaan valitun finaalisarjan osallistujien tiedot osallistujaListaan3 kutsumalla 
        /// tietokantametodia ja esitetaan listan tiedot taulukossa
        /// </summary>
        /// <param name="sarja">Valitun finaalisarjan nimi</param>
        private void OsallistujatFinaaliin(string sarja)
        {
            // osallistujaList3 = new List<OsallistujaListLine>();
            osallistujaList3 = dbHandler.getFinal6(sarja);

            id.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Id; };
            nroFinal.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nro; };
            lastnameFinal.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
            lastnameFinal.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
            nameFinal.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
            nameFinal.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
            scoreFinal25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
            scoreFinal25.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).FinaaliKierros = Convert.ToInt32(newValue); };
            solvingFinal.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };
            solvingFinal.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).FinaaliRatkonta = Convert.ToInt32(newValue); };

            ScoreFinal.SetObjects(osallistujaList3);
        }

        /// <summary>
        /// Haetaan valitun sarjan osallistujien tiedot osallistujaListaan2 ja esitetaan ne
        /// valitussa tabissa
        /// </summary>
        /// <param name="sarja">Valitun tabin sarjan nimi</param>
        private void SarjaTulokset(string sarja)
        {
            osallistujaList2 = new List<OsallistujaListLine>();
            osallistujaList2 = dbHandler.getScores(sarja);

            if (sarja == Sarjat[0])
            {
                YscoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                YscoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                YscoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                YscoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Yscore25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Yscore50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Yscore75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Yscore100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Yscore125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                YscoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                YscoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                YscoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                YscoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaYTulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[1])
            {
                Y15scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                Y15scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                Y15scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                Y15scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Y15score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Y15score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Y15score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Y15score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Y15score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                Y15scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                Y15scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                Y15scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                Y15scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaY15Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[2])
            {
                Y17scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                Y17scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                Y17scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                Y17scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Y17score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Y17score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Y17score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Y17score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Y17score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                Y17scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                Y17scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                Y17scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                Y17scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaY17Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[3])
            {
                Y20scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                Y20scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                Y20scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                Y20scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Y20score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Y20score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Y20score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Y20score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Y20score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                Y20scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                Y20scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                Y20scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                Y20scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaY20Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[4])
            {
                Y50scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                Y50scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                Y50scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                Y50scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Y50score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Y50score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Y50score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Y50score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Y50score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                Y50scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                Y50scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                Y50scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                Y50scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaY50Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[5])
            {
                Y60scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                Y60scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                Y60scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                Y60scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Y60score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Y60score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Y60score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Y60score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Y60score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                Y60scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                Y60scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                Y60scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                Y60scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaY60Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[6])
            {
                Y70scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                Y70scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                Y70scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                Y70scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Y70score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Y70score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Y70score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Y70score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Y70score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                Y70scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                Y70scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                Y70scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                Y70scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaY70Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[7])
            {
                NscoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                NscoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                NscoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                NscoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Nscore25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Nscore50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Nscore75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Nscore100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Nscore125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                NscoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                NscoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                NscoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                NscoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaNTulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[8])
            {
                N20scoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                N20scoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                N20scoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                N20scoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                N20score25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                N20score50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                N20score75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                N20score100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                N20score125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                N20scoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                N20scoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                N20scoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                N20scoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaN20Tulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[9])
            {
                AscoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                AscoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                AscoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                AscoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Ascore25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Ascore50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Ascore75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Ascore100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Ascore125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                AscoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                AscoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                AscoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                AscoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaATulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[10])
            {
                BscoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                BscoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                BscoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                BscoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Bscore25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Bscore50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Bscore75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Bscore100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Bscore125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                BscoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                BscoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                BscoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                BscoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaBTulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[11])
            {
                CscoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                CscoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                CscoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                CscoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Cscore25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Cscore50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Cscore75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Cscore100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Cscore125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                CscoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                CscoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                CscoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                CscoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaCTulokset.SetObjects(osallistujaList2);
            }
            else if (sarja == Sarjat[12])
            {
                DscoreSuku.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Sukunimi; };
                DscoreSuku.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Sukunimi = newValue.ToString(); };
                DscoreEtu.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Nimi; };
                DscoreEtu.AspectPutter = delegate(object x, object newValue) { ((OsallistujaListLine)x).Nimi = newValue.ToString(); };
                Dscore25.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros25; };
                Dscore50.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros50; };
                Dscore75.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros75; };
                Dscore100.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros100; };
                Dscore125.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Kierros125; };
                DscoreRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).KierrosRatkonta; };
                DscoreYht.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).Yht; };
                DscoreFin.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliKierros; };
                DscoreFinRat.AspectGetter = delegate(object x) { return ((OsallistujaListLine)x).FinaaliRatkonta; };

                SarjaDTulokset.SetObjects(osallistujaList2);
            }
            else 
            {
            }
        }
       
        /// <summary>
        /// Hakee kilpailussa mukana olevien sarjojen nimet ja lahettaa ne nimettaviksi
        /// </summary>
        private void nameSarjaTabs()
        {     
            int sarjaCount = sarjaComboBox.Items.Count;
            string sarja;

            for (int i = 0; i < sarjaCount; i++)
            {
                sarja = sarjaComboBox.Items[i].ToString();
                Console.WriteLine("hidesarja - combobox item[" + i + "] = " + sarja);

                Sarjat[i] = sarja;
                ShowSarjaTabs(sarja);
            }
        }

        /// <summary>
        /// Piilottaa valmiiksi tehdyt tabit
        /// </summary>
        private void hideSarjaTabs()
        {
            scores.TabPages.Remove(tabPage1);
            scores.TabPages.Remove(tabPage2);
            scores.TabPages.Remove(tabPage3);
            scores.TabPages.Remove(tabPage4);
            scores.TabPages.Remove(tabPage5);
            scores.TabPages.Remove(tabPage6);
            scores.TabPages.Remove(tabPage7);
            scores.TabPages.Remove(tabPage8);
            scores.TabPages.Remove(tabPage9);
            scores.TabPages.Remove(tabPage10);
            scores.TabPages.Remove(tabPage11);
            scores.TabPages.Remove(tabPage12);
            scores.TabPages.Remove(tabPage13);
        }

        /// <summary>
        /// Ottaa vastaan sarjan nimen, nimeaa silla seuraavan sarjatabin
        /// ja palauttaa kyseisen tabin nakyviin
        /// </summary>
        /// <param name="sarja"> Sarjan nimi</param>
        private void ShowSarjaTabs(string sarja)
        {
            a++;

            if (a == 1)
            {
                tabPage1.Text = sarja;
                scores.TabPages.Add(this.tabPage1);
            }
            else if (a == 2)
            {
                tabPage2.Text = sarja;
                scores.TabPages.Add(this.tabPage2);
            }
            else if (a == 3)
            {
                tabPage3.Text = sarja;
                scores.TabPages.Add(this.tabPage3);
            }
            else if (a == 4)
            {
                tabPage4.Text = sarja;
                scores.TabPages.Add(this.tabPage4);
            }
            else if (a == 5)
            {
                tabPage5.Text = sarja;
                scores.TabPages.Add(this.tabPage5);
            }
            else if (a == 6)
            {
                tabPage6.Text = sarja;
                scores.TabPages.Add(this.tabPage6);
            }
            else if (a == 7)
            {
                tabPage7.Text = sarja;
                scores.TabPages.Add(this.tabPage7);
            }
            else if (a == 8)
            {
                tabPage8.Text = sarja;
                scores.TabPages.Add(this.tabPage8);
            }
            else if (a == 9)
            {
                tabPage9.Text = sarja;
                scores.TabPages.Add(this.tabPage9);
            }            
            if (a == 10)
            {
                tabPage10.Text = sarja;
                scores.TabPages.Add(this.tabPage10);
            }
            else if (a == 11)
            {
                tabPage11.Text = sarja;
                scores.TabPages.Add(this.tabPage11);
            }            
            else if (a == 12)
            {
                tabPage12.Text = sarja;
                scores.TabPages.Add(this.tabPage12);
            }            
            else if (a == 13)
            {
                tabPage13.Text = sarja;
                scores.TabPages.Add(this.tabPage13);
            }
        }

        /// <summary>
        /// Eran vaihtamisen yhteydessa suoritetaan edellisen eran tietojen tallennus,
        /// valitun eran tietojen nayttaminen ja edellisen eran tietojen paivittaminen
        /// nykyiseen tabiin(erassa ei valttamatta ole nykyisessa tabissa olevia kilpailijoita) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //paivita tuloksien muutokset kantaan (vaikkei muuteta mitaan)
            dbHandler.setScores(osallistujaList);

            Console.WriteLine("eran index vaihtu");
            Object selectedEraItem = EraComboBox.SelectedItem;
            int eraNro = Convert.ToInt16(selectedEraItem);
            OsallistujatListaan(eraNro);

            //paivitetaan kokonaistilanteen taulukko nykyisessa tabissa
            string tabSarja = scores.SelectedTab.Text;
            SarjaTulokset(tabSarja);
        }

        /// <summary>
        /// Tallennetaan valittuina olevat era ja finaalitiedot seka
        /// esitetaan ilmoitus tapahtuman suorittamisesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoringSaveButton_Click(object sender, EventArgs e)
        {
            dbHandler.setScores(osallistujaList);
            dbHandler.setScoresFinal(osallistujaList3);
            DialogResult result;
            result = MessageBox.Show("Tulokset tallennettu", "Hauli", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Tallennetaan valittuina olevat era ja finaalitiedot ja suljetaan ikkuna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoringCloseButton_Click(object sender, EventArgs e)
        {
            dbHandler.setScores(osallistujaList);
            dbHandler.setScoresFinal(osallistujaList3);
            this.Close();
        }

        /// <summary>
        /// Otetaan talteen valitun tabin nimi ja lahetetaan se
        /// sarjatuloksiin, jotta kyseisen sarjan tiedot voidaan esittaa
        /// valitussa tabissa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scores_Selected(object sender, TabControlEventArgs e)
        {
            string sarja = scores.SelectedTab.Text;
            Console.WriteLine("Valittiin tabi: " + sarja);
            SarjaTulokset(sarja);
        }

        /// <summary>
        /// Valittaessa finaalisarjaa tallennetaan aukinaisen eran ja finaalisarjan tiedot
        /// otetaan valitun sarjan nimi talteen ja lahetetaan se finaalin tiedot nayttavalle
        /// metodille seka paivitetaan aukinaisen tabin tietoja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sarjaComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //paivita tuloksien muutokset kantaan (vaikkei muutettais mitaan)
            dbHandler.setScores(osallistujaList); //eraan syotetty pisteita, muttei tallennettu --> vaikutus finaaliin --> tallenna nyt
            dbHandler.setScoresFinal(osallistujaList3);

            Console.WriteLine("Finaalisarjan index vaihtu");
            Object selectedSarjaItem = sarjaComboBox.SelectedItem;
            string sarja = Convert.ToString(selectedSarjaItem);
            Console.WriteLine("Finaalisarjan nimi = " + sarja);
            OsallistujatFinaaliin(sarja);

            //paivitetaan kokonaistilanteen taulukko nykyisessa tabissa
            string tabSarja = scores.SelectedTab.Text;
            SarjaTulokset(tabSarja);
        }

        /// <summary>
        /// Tallennetaan valittuina olevat era ja finaalitiedot ja suljetaan ikkuna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreInputView_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbHandler.setScores(osallistujaList);
            dbHandler.setScoresFinal(osallistujaList3);
        }

    }
}

/********************************/
/*  TODO
 
 - onko edit kentan ulkonakoa mahollista muuttaa (nyt kak nuolta valikko)
 - tab/enter suunta (enter menee alas, tab menee sivulle)
 - seurat: uudet lisatyt A-D paikoille tai tee nimea vanhat uusiks...
 
 */