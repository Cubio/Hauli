using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Hauli
{
    public class HauliDBHandler
    {
        private SqlCeConnection _connection;


        public HauliDBHandler()
        {
            updateHauliDB();
        }

        public void updateHauliDB()
        {
            String paht = Properties.Settings.Default.DBpath;

            if (File.Exists(paht))
                _connection = new SqlCeConnection(@"Data Source = " + paht);
            else
            {
                throw new HauliException("Tietokantaa ei löytynyt. Asenna uudelleen sovellus");
            }


        }


        /// <summary>
        /// Lisätään tiedoston tiedot tietokantaan
        /// </summary>
        internal void addFileSeurat(List<string[]> lines)
        {
            String lyhenne;
            String seura;
            String alue;
            int idNumber;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {


                for (int i = 0; i < lines.Count; i++)
                {
                    lyhenne = lines[i][0];
                    seura = lines[i][1];
                    alue = lines[i][2];

                    idNumber = generateId("Seura", "seuraID");

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Seura (seuraID, seura, lyhenne, alue) Values(@idNumero, @seura, @lyhenne, @alue)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("seura", seura);
                    cmd.Parameters.AddWithValue("lyhenne", lyhenne);
                    cmd.Parameters.AddWithValue("alue", alue);

                    cmd.ExecuteNonQuery();
                }


            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }
        }




        public List<SeuraListLine> getSeuraList()
        {
            List<SeuraListLine> seuraList;
            seuraList = new List<SeuraListLine>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;

            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta
            do
            {

                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    string Sql = String.Format(" SELECT * FROM Seura");
                    cmd = new SqlCeCommand(Sql, con);


                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        seuraList.Add(new Seura(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3)));
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return seuraList;
        }




        // Luo ID numero halutulle taululle. Palauttaa ID numeron, jota ei ole olemassa kyseisessä taulussa.
        public int generateId(String taulu, String sarake)
        {
            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;
            Random random = new Random();
            int idNro = 0;
            idNro = random.Next(10000, 99999);


            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta
            do
            {

                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    string Sql = String.Format(@" SELECT * FROM {0} WHERE {1} = @numero", taulu, sarake);
                    cmd = new SqlCeCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", idNro);

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        //Console.WriteLine(rdr.GetString(1));
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(e);
                    Console.WriteLine("VIRHEILMOITUS, Generointi ID");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    //rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return idNro;
        }

        public void delDBTable(String taulu)
        {


            SqlCeCommand cmd = null;

            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" DELETE FROM {0}", taulu);
                cmd = new SqlCeCommand(Sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }
        }

        internal void setContestant(List<ContestantListLine> contestantList)
        {

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {
                for (int i = 0; i < contestantList.Count; i++)
                {



                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Seura (seuraID, seura, lyhenne, alue) Values(@idNumero, @seura, @lyhenne, @alue)";


                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }
        }


        internal void setTeam(List<TeamListLine> teamList)
        {
            String joukkue;
            int idNumber;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {


                for (int i = 0; i < teamList.Count; i++)
                {
                    idNumber = teamList[i].Id;
                    joukkue = teamList[i].Joukkue;


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Joukkue (joukkueID, joukkue) Values(@idNumero, @joukkue)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("joukkue", joukkue);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }


        }


        internal void setSeura(List<SeuraListLine> seuraList)
        {
            String lyhenne;
            String seura;
            String alue;
            int idNumber;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {


                for (int i = 0; i < seuraList.Count; i++)
                {
                    idNumber = seuraList[i].Id;
                    lyhenne = seuraList[i].Lyhenne;
                    seura = seuraList[i].KokoNimi;
                    alue = seuraList[i].Alue;


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Seura (seuraID, seura, lyhenne, alue) Values(@idNumero, @seura, @lyhenne, @alue)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("seura", seura);
                    cmd.Parameters.AddWithValue("lyhenne", lyhenne);
                    cmd.Parameters.AddWithValue("alue", alue);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }


        }


        public List<string> getSeuraBox()
        {
            // hakee tietokannasta comboboxissa esitettävät kentät
            List<string> tiedot = new List<string>();
            SqlCeCommand cmd = null;
            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" SELECT seura FROM Seura ORDER BY seura ASC");
                cmd = new SqlCeCommand(Sql, con);
                cmd.ExecuteNonQuery();

                try
                {
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tiedot.Add(dr.GetString(0));
                    }
                }
                catch (SqlCeException e)
                {
                    //show errors
                    Console.WriteLine(e.Message);
                }

                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tiedot;
        }

        public List<string> getSarjaBox()
        {
            // hakee tietokannasta comboboxissa esitettävät kentät
            List<string> tiedot = new List<string>();
            SqlCeCommand cmd = null;
            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" SELECT sarja FROM Sarja ORDER BY sarja ASC");
                cmd = new SqlCeCommand(Sql, con);
                cmd.ExecuteNonQuery();

                try
                {
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tiedot.Add(dr.GetString(0));
                    }
                }
                catch (SqlCeException e)
                {
                    //show errors
                    Console.WriteLine(e.Message);
                }

                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tiedot;
        }


        internal List<TeamListLine> getTeamList()
        {
            List<TeamListLine> teamList;
            teamList = new List<TeamListLine>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;

            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta
            do
            {

                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    string Sql = String.Format(" SELECT * FROM Joukkue");
                    cmd = new SqlCeCommand(Sql, con);


                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teamList.Add(new Team(rdr.GetInt32(0), rdr.GetString(1)));
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return teamList;
        }

        internal List<SerialListLine> getSerialList()
        {
            List<SerialListLine> serialList;
            serialList = new List<SerialListLine>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;

            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta
            do
            {

                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    string Sql = String.Format(" SELECT * FROM Sarja");
                    cmd = new SqlCeCommand(Sql, con);


                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        serialList.Add(new Serial(rdr.GetInt32(0), rdr.GetString(1)));
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return serialList;
        }


        internal void setSerial(List<SerialListLine> serialList)
        {

            String sarja;
            int idNumber;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {


                for (int i = 0; i < serialList.Count; i++)
                {
                    idNumber = serialList[i].Id;
                    sarja = serialList[i].Sarja;


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Sarja (sarjaID, sarja) Values(@idNumero, @sarja)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("sarja", sarja);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }
        }

        internal void addFileOsallistujat(List<string[]> lines)
        {
            String nimi;
            String sukunimi;
            int idNumber;
            int seuraID;
            int joukkueID;
            int sarjaID;
            int era;
            int selkalappu;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    selkalappu = int.Parse(lines[i][0]);
                    nimi = lines[i][1];
                    sukunimi = lines[i][2];
                    seuraID = int.Parse(lines[i][3]);

                    if (string.IsNullOrEmpty(lines[i][4]))
                    {
                        joukkueID = 0;
                    }
                    else
                    {
                        joukkueID = int.Parse(lines[i][4]);
                    }
                    sarjaID = int.Parse(lines[i][5]);
                    era = int.Parse(lines[i][6]);

                    idNumber = generateId("Osallistuja", "osallistujaID");


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    // string Sql = String.Format(@" SELECT * FROM {0} WHERE seuraID = @numero", "Seura");
                    //cmd = new SqlCeCommand(Sql, con);
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Osallistuja (osallistujaID, nro, nimi, sukunimi, seuraID, joukkueID, sarjaID, era) Values(@idNumero, @nro, @nimi, @sukunimi, @seuraID, @joukkueID, @sarjaID, @era)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("nro", selkalappu);
                    cmd.Parameters.AddWithValue("nimi", nimi);
                    cmd.Parameters.AddWithValue("sukunimi", sukunimi);
                    cmd.Parameters.AddWithValue("seuraID", seuraID);
                    cmd.Parameters.AddWithValue("joukkueID", joukkueID);
                    cmd.Parameters.AddWithValue("sarjaID", sarjaID);
                    cmd.Parameters.AddWithValue("era", era);

                    cmd.ExecuteNonQuery();

                }


            }
            catch (SqlCeException e)
            {
                Console.WriteLine("VIRHE user add form file");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }
        }

        internal void setCompetitionDatetime(string d1, string d2, string contest, string organizer, string place, string rata, string era)
        {
            SqlCeCommand cmd = null;
            SqlCeConnection con = _connection;

            //Pyyhitään vanhat tiedot veke.
            delDBTable("Asetukset");

            try
            {
                int id = 1;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                cmd = con.CreateCommand();

                if (d2 == "")
                {
                    cmd.CommandText = "INSERT INTO Asetukset (AsetuksetID, jarjestaja, tapahtuma, paikkakunta, radat, erankesto, paiva1) Values(@idNumero, @contest, @organizer, @place, @rata, @era, @paiva1)";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Asetukset (AsetuksetID, jarjestaja, tapahtuma, paikkakunta, radat, erankesto, paiva1, paiva2) Values(@idNumero, @contest, @organizer, @place, @rata, @era, @paiva1, @paiva2)";
                }

                cmd.Parameters.AddWithValue("idNumero", id);
                cmd.Parameters.AddWithValue("contest", contest);
                cmd.Parameters.AddWithValue("organizer", organizer);
                cmd.Parameters.AddWithValue("place", place);
                cmd.Parameters.AddWithValue("rata", rata);
                cmd.Parameters.AddWithValue("era", era);
                cmd.Parameters.AddWithValue("paiva1", d1);
                cmd.Parameters.AddWithValue("paiva2", d2);

                cmd.ExecuteNonQuery();

            }
            catch (SqlCeException e)
            {
                Console.WriteLine("VIRHE add date");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }

        }

        internal List<Object> getMainInfo()
        {
            List<Object> tiedot = new List<Object>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;

            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta
            do
            {

                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    string Sql = String.Format(" SELECT * FROM Asetukset WHERE asetuksetID = 1");
                    cmd = new SqlCeCommand(Sql, con);


                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        // tiedot.Add(rdr.GetString(0));
                        tiedot.Add(rdr.GetString(1));
                        tiedot.Add(rdr.GetString(2));
                        tiedot.Add(rdr.GetString(3));
                        tiedot.Add(rdr.GetInt32(4));
                        tiedot.Add(rdr.GetInt32(5));
                        tiedot.Add(rdr.GetDateTime(6));

                        if (!rdr.IsDBNull(7))
                        {
                            tiedot.Add(rdr.GetDateTime(7));
                        }
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return tiedot;
        }

        internal List<string> getJoukkueBox()
        {
            // hakee tietokannasta comboboxissa esitettävät kentät
            List<string> tiedot = new List<string>();
            SqlCeCommand cmd = null;
            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" SELECT joukkue FROM Joukkue ORDER BY joukkue ASC");
                cmd = new SqlCeCommand(Sql, con);
                cmd.ExecuteNonQuery();

                try
                {
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tiedot.Add(dr.GetString(0));
                    }
                }
                catch (SqlCeException e)
                {
                    //show errors
                    Console.WriteLine(e.Message);
                }

                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tiedot;
        }

        internal List<ContestantListLine> getContestant()
        {
            List<ContestantListLine> contestantList = new List<ContestantListLine>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;
            int eraNro = 1;
            String joukkue = "";
            //contestantList.Add(new Contestant(generateId(), "Ceppo", "Töppönen", "OSH", "Y", ""));
            //contestantList.Add(new RoundDivider(false, 2, "Erä"));



            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta

            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                string Sql = String.Format("SELECT * FROM  Osallistuja LEFT JOIN Seura ON Osallistuja.seuraID = Seura.seuraID LEFT JOIN Sarja ON Osallistuja.sarjaID = Sarja.sarjaID LEFT OUTER JOIN Joukkue ON Osallistuja.joukkueID = Joukkue.joukkueID ORDER BY Osallistuja.era ASC");
                cmd = new SqlCeCommand(Sql, con);


                rdr = cmd.ExecuteReader();
                rdr.Read();
                contestantList.Add(new RoundDivider(Convert.ToBoolean(rdr.GetInt32(16)), rdr.GetInt32(15), "Erä"));
                eraNro = rdr.GetInt32(15);

                rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    if (eraNro < rdr.GetInt32(15))
                    {
                        contestantList.Add(new RoundDivider(Convert.ToBoolean(rdr.GetInt32(16)), rdr.GetInt32(15), "Erä"));
                        eraNro = rdr.GetInt32(15);
                    }

                    if (!rdr.IsDBNull(24))
                    {
                        joukkue = rdr.GetString(24);
                    }

                    if (string.IsNullOrEmpty(rdr.GetString(2)))
                    {
                        contestantList.Add(new Contestant(rdr.GetInt32(0), "", "", "", "", ""));
                    }
                    else
                    {
                        contestantList.Add(new Contestant(rdr.GetInt32(0), rdr.GetString(2), rdr.GetString(3), rdr.GetString(18), rdr.GetString(22), joukkue));
                    }

                    
                }
            }
            catch (SqlCeException ex)
            {
                //ShowErrors(ex);
                Console.WriteLine("VIRHEILMOITUS");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                rdr.Close();
                cmd.Dispose();
                ok = true;
            }

            return contestantList;
        }

        internal void setContestantSS(List<ContestantListLine> contestantList)
        {

           

            int eraNro = 0;
            int kuuma = 0;
            int idNumber = 0;
            String nimi = "";
            String sukunimi = "";
            int seuraID = 0;
            int joukkueID = 0;
            int sarjaID = 0;
            int selkalappu = 0;


            SqlCeConnection con = _connection;
            SqlCeCommand cmd = null;
            try
            {
                for (int i = 0; i < contestantList.Count; i++)
                {
                    selkalappu++;
                    if (contestantList[i] is RoundDivider)
                    {
                        eraNro = contestantList[i].Id;
                        kuuma = Convert.ToInt32(contestantList[i].HotRound);
                    }

                    if (contestantList[i] is Contestant)
                    {
                        idNumber = contestantList[i].Id;

                        if (!string.IsNullOrEmpty(contestantList[i].FirstName) )
                        {
                            
                            nimi = contestantList[i].FirstName;
                            sukunimi = contestantList[i].LastName;
                            seuraID = getTableID("Seura", "seura", contestantList[i].Seura);
                            joukkueID = getTableID("Joukkue", "joukkue", contestantList[i].Team);
                            sarjaID = getTableID("Sarja", "sarja", contestantList[i].Sarja);
                        }
                        else
                        {
                            nimi = "";
                            sukunimi = "";
                            seuraID = 0;
                            joukkueID = 0;
                            sarjaID = 0;
                        }


                        if (con.State == ConnectionState.Closed)
                            con.Open();


                        string Sql = String.Format("INSERT INTO Osallistuja (osallistujaID, nro, nimi, sukunimi, seuraID, joukkueID, sarjaID, era, hotOrNot, kierros25, kierros50, kierros75, kierros125, kierrosRatkonta, finaaliKierros, finaaliRatkonta) Values(@idNumero, @nro, @nimi, @sukunimi, @seuraID, @joukkueID, @sarjaID, @era, @hotOrNot,0,0,0,0,0,0,0) " );
                        cmd = new SqlCeCommand(Sql, con);
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("idNumero", idNumber);
                        cmd.Parameters.AddWithValue("nro", selkalappu);
                        cmd.Parameters.AddWithValue("nimi", nimi);
                        cmd.Parameters.AddWithValue("sukunimi", sukunimi);
                        cmd.Parameters.AddWithValue("seuraID", seuraID);
                        cmd.Parameters.AddWithValue("joukkueID", joukkueID);
                        cmd.Parameters.AddWithValue("sarjaID", sarjaID);
                        cmd.Parameters.AddWithValue("era", eraNro);
                        cmd.Parameters.AddWithValue("hotOrNot", kuuma);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlCeException e)
            {
                Console.WriteLine("VIRHE osallistujien tallentamisessa");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();


            }
        }

        private int getTableID(string taulu, string sarake, string nimike)
        {
            int id = 0;
            SqlCeConnection con = _connection;
            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" SELECT * FROM {0} WHERE {1} = @nimike ", taulu, sarake);
                cmd = new SqlCeCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("nimike", nimike);

                rdr = cmd.ExecuteReader();
                rdr.Read();
                id = rdr.GetInt32(0);

                

            }
            catch (SqlCeException ex)
            {
                Console.WriteLine("VIRHEILMOITUS getTableID");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.Dispose();
            }


            return id;
        }


        public List<string> getRoundColumn()
        {
            List<string> columnData = new List<string>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format("SELECT era FROM Osallistuja");
                cmd = new SqlCeCommand(Sql, con);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //columnData.Add(rdr.GetString(0));
                }
            }
            catch (SqlCeException ex)
            {
                //ShowErrors(ex);
                Console.WriteLine("TIETOKANTAVIRHE: getRoundColumn()");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                rdr.Close();
                cmd.Dispose();
            }
            return columnData;
        }

        internal Boolean checkIfexist(string taulu, string sarake, string tarkista)
        {
            Boolean tulos = false;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                string Sql = String.Format(@" SELECT COUNT(*) FROM {0} WHERE {1} = @tarkista", taulu, sarake);
                cmd = new SqlCeCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("tarkista", tarkista);

                Int32 count = (Int32)cmd.ExecuteScalar();

                if (count != 0)
                {
                    tulos = true;
                }



            }
            catch (SqlCeException ex)
            {
                //ShowErrors(ex);
                Console.WriteLine("TIETOKANTAVIRHE: getRoundColumn()");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //rdr.Close();
                cmd.Dispose();
            }
            return tulos;
        }
    }//End db
} //end db class