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
                        seuraList.Add(new Seura(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(3), rdr.GetString(2)));
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
                //cmd.Dispose();
            }


        }


        internal void setSeura(List<SeuraListLine> seuraList)
        {
            String lyhenne;
            String KokoNimi;
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
                    KokoNimi = seuraList[i].KokoNimi;
                    alue = seuraList[i].Alue;

                    Console.WriteLine("SEURA ID:" + idNumber);
                    
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Seura (seuraID, seura, alue, KokoNimi) Values(@idNumero, @lyhenne, @alue, @KokoNimi)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("KokoNimi", KokoNimi);
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

        /// <summary>
        /// Hakee kaikki seurat tietokannasta
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Hakee kaikki sarjat tietokannasta
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Hakee kilpailussa mukana olevat uniikit sarjat
        /// </summary>
        /// <returns></returns>
        public List<string> getKilpailussaOlevatSarjatBox()
        {
            // hakee tietokannasta comboboxissa esitettävät kentät
            List<string> tiedot = new List<string>();
            SqlCeCommand cmd = null;
            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" SELECT DISTINCT Sarja.sarja FROM Osallistuja INNER JOIN
                                              Sarja ON Osallistuja.sarjaID = Sarja.sarjaID");
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

        /// <summary>
        /// Hakee tietokannasta uniikit erat (ei kahta samanlaista eranumeroa)
        /// </summary>
        /// <returns></returns>
        public List<int> getEraBox()
        {
            // hakee tietokannasta comboboxissa esitettävät kentät
            List<int> tiedot = new List<int>();
            SqlCeCommand cmd = null;
            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string Sql = String.Format(@" SELECT DISTINCT era FROM Osallistuja");
                cmd = new SqlCeCommand(Sql, con);
                cmd.ExecuteNonQuery();

                try
                {
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tiedot.Add(dr.GetInt32(0)); //tiedot.Add(dr.GetString(0));
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

        /// <summary>
        /// Hakee tietokannassa olevat joukkueet
        /// </summary>
        /// <returns></returns>
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
            int eraNro = 1;
            String joukkue = "";
            //contestantList.Add(new Contestant(generateId("Osallistuja","OsallistujaID"), "Ceppo", "Töppönen", "OSH", "Y", ""));
            //contestantList.Add(new RoundDivider(false, 1, "Erä"));


            
            // Testataan hakua. Katsotaan saadaanko uutta idNro.ta

            SqlCeConnection con = _connection;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                string Sql = String.Format("SELECT * FROM  Osallistuja LEFT JOIN Seura ON Osallistuja.seuraID = Seura.seuraID LEFT JOIN Sarja ON Osallistuja.sarjaID = Sarja.sarjaID LEFT OUTER JOIN Joukkue ON Osallistuja.joukkueID = Joukkue.joukkueID ORDER BY Osallistuja.era ASC");
                cmd = new SqlCeCommand(Sql, con);


                rdr = cmd.ExecuteReader();
                if (null != cmd.ExecuteScalar())
                {
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
                        //Lisätään jälki-ilmottautunut, jos 
                        Console.WriteLine("NIMI: " + rdr.GetString(2));
                        if (string.IsNullOrEmpty(rdr.GetString(2)) && string.IsNullOrEmpty(rdr.GetString(3)) )
                        {
                            Console.WriteLine("Jälki-ilmottautuja lisätty");
                            contestantList.Add(new Contestant(rdr.GetInt32(0), "", "", "", "", ""));
                        }
                        // Oikeaosallstija id, nimi, sukunimi, seura, sarja, joukkue
                        else
                        {
                            contestantList.Add(new Contestant(rdr.GetInt32(0), rdr.GetString(2), rdr.GetString(3), rdr.GetString(19), rdr.GetString(23), joukkue));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Tietoa osallistujista ei ole kannassa");
                    contestantList.Add(new RoundDivider(false, 1, "Erä"));
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
            }

       

            return contestantList;
        }

        //Tallenetaan käyttätiedot tietokantaan.
        // JOS löytyy ID päivitetään tiedot, muussa tapauksessa lisätään.
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
            SqlCeDataReader rdr = null;

            try
            {
                for (int i = 0; i < contestantList.Count; i++)
                {


                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    if (contestantList[i] is RoundDivider)
                    {
                        eraNro = contestantList[i].Id;
                        kuuma = Convert.ToInt32(contestantList[i].HotRound);
                    }

                    if (contestantList[i] is Contestant)
                    {
                        selkalappu++;

                        idNumber = contestantList[i].Id;

                        Console.WriteLine("ID NUMERO HENKILÖLLÖ:" + idNumber );

                        //JOS ID löytyy päivitetään tidot, muussatapauksessa lisätään uusi

                        if (checkIfexist("Osallistuja", "osallistujaID", idNumber.ToString()))
                        {
                            Console.WriteLine("LÖYTYI SAMANLAINENNENENENEN !!!!!");
                        }

                        if (con.State == ConnectionState.Closed)
                            con.Open();


                        string Sql = String.Format(@"SELECT * FROM osallistuja WHERE osallistujaID = @idNumero");
                        cmd = new SqlCeCommand(Sql, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("idNumero", idNumber);
                        rdr = cmd.ExecuteReader();
                        if (null != cmd.ExecuteScalar())
                        {
                            Console.WriteLine("Päivitetään tiedot osallistuja");
                            nimi = contestantList[i].FirstName;
                            sukunimi = contestantList[i].LastName;
                            seuraID = getTableID("Seura", "seura", contestantList[i].Seura);
                            joukkueID = getTableID("Joukkue", "joukkue", contestantList[i].Team);
                            sarjaID = getTableID("Sarja", "sarja", contestantList[i].Sarja);

                            if (con.State == ConnectionState.Closed)
                                con.Open();


                            string Sql2 = String.Format(@"UPDATE Osallistuja SET nimi = @nimi, sukunimi = @sukunimi, seuraID = @seuraID, joukkueID = @joukkueID, sarjaID = @sarjaID, era = @era, hotOrNot = @hotOrNot WHERE OsallistujaID = @idNumero  ");
                            cmd = new SqlCeCommand(Sql2, con);
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
                        else
                        {
                            if (!string.IsNullOrEmpty(contestantList[i].FirstName) && !string.IsNullOrEmpty(contestantList[i].LastName))
                            {
                                Console.WriteLine("Lisätään osallistuja");
                            
                                nimi = contestantList[i].FirstName;
                                sukunimi = contestantList[i].LastName;
                                seuraID = getTableID("Seura", "seura", contestantList[i].Seura);
                                joukkueID = getTableID("Joukkue", "joukkue", contestantList[i].Team);
                                sarjaID = getTableID("Sarja", "sarja", contestantList[i].Sarja);
                            }
                            // Jälki-ilmottautuja paikka
                            else
                            {
                                Console.WriteLine("Lisätään jälki-ilmottautumispaikka");
                                nimi = "";
                                sukunimi = "";
                                seuraID = 0;
                                joukkueID = 0;
                                sarjaID = 0;
                            }
                           

                            //GENEROIDAAN UUSI ID
                            idNumber = generateId("Osallistuja", "osallistujaID");

                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            // Lisätään uusi osallistuja
                            string Sql3 = String.Format("INSERT INTO Osallistuja (osallistujaID, nro, nimi, sukunimi, seuraID, joukkueID, sarjaID, era, hotOrNot, kierros25, kierros50, kierros75, kierros100, kierros125, kierrosRatkonta, finaaliKierros, finaaliRatkonta, yht) Values(@idNumero, @nro, @nimi, @sukunimi, @seuraID, @joukkueID, @sarjaID, @era, @hotOrNot,0,0,0,0,0,0,0,0,0) ");
                            cmd = new SqlCeCommand(Sql3, con);
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
            Console.WriteLine("getTableID " + taulu + " " + sarake + " " + nimike);
            int id = 0;
            SqlCeConnection con = _connection;
            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            //jos jälki-ilmottauttunut, niin annetaan arvoksi tyhjä, muussatapauksessa haetaan id
            if (!string.IsNullOrEmpty(nimike) )
            {
                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string Sql = String.Format(@" SELECT * FROM {0} WHERE {1} = @nimike ", taulu, sarake);
                    cmd = new SqlCeCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("nimike", nimike);

                    rdr = cmd.ExecuteReader();
                    if (null != cmd.ExecuteScalar())
                    {
                        rdr.Read();
                        Console.WriteLine("HAETTU ID: " + rdr.GetInt32(0) + " JOTAIN: " + nimike);
                        id = rdr.GetInt32(0);
                    }
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
            }

            return id;
        }


        public List<int> getRoundColumn()
        {
            List<int> columnData = new List<int>();

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
                    columnData.Add(rdr.GetInt32(0));
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

        /// <summary>
        /// Hakee valitun eran kilpailijoiden pisteet
        /// </summary>
        /// <param name="eraNro">valittu era</param>
        /// <returns></returns>
        public List<OsallistujaListLine> getOsallistujaList(int eraNro)
        {
            List<OsallistujaListLine> osallistujaList;
            osallistujaList = new List<OsallistujaListLine>();

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;

            do
            {
                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string Sql = String.Format(" SELECT * FROM Osallistuja WHERE era =" + eraNro);
                    cmd = new SqlCeCommand(Sql, con);

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        osallistujaList.Add(new Osallistuja(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(3), rdr.GetString(2), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9), rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(17)));
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS getOsallistujaList");
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

            return osallistujaList;
        }

        /// <summary>
        /// Hakee sarjan osallistujien pisteet
        /// </summary>
        /// <param name="sarja">valittu sarja</param>
        /// <returns></returns>
        public List<OsallistujaListLine> getScores(string sarja)
        {
            List<OsallistujaListLine> osallistujaList2;
            osallistujaList2 = new List<OsallistujaListLine>();
            
            SqlCeCommand cmd = new SqlCeCommand();
           // cmd.Parameters.Add("@sarja", sarja);
            SqlCeDataReader rdr = null;
            bool ok = false;

            do
            {
                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                  /*  string Sql = String.Format(@"SELECT * FROM Osallistuja INNER JOIN Sarja ON Osallistuja.sarjaID = Sarja.sarjaID 
                                                 WHERE Sarja.sarja = @sarja"); */
                    string Sql = String.Format(@"SELECT *, Osallistuja.kierros25 + Osallistuja.kierros50 + Osallistuja.kierros75 + Osallistuja.kierros100 + Osallistuja.kierros125 + Osallistuja.kierrosRatkonta + Osallistuja.finaaliKierros
                                                 + Osallistuja.finaaliRatkonta AS sum
                                                 FROM Osallistuja INNER JOIN Sarja ON Osallistuja.sarjaID = Sarja.sarjaID
                                                 WHERE (Sarja.sarja = @sarja)
                                                 ORDER BY sum DESC, Osallistuja.finaaliRatkonta DESC, Osallistuja.finaaliKierros DESC, Osallistuja.kierrosRatkonta DESC, Osallistuja.kierros125 DESC, 
                                                 Osallistuja.kierros100 DESC, Osallistuja.kierros75 DESC, Osallistuja.kierros50 DESC, Osallistuja.kierros25 DESC");
                    cmd = new SqlCeCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("sarja", sarja);

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        osallistujaList2.Add(new Osallistuja(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(3), rdr.GetString(2), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9), rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(17)));
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS getScores()");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    //  rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return osallistujaList2;
        }

        /// <summary>
        /// Hakee valitun sarjan kuusi parasta kilpailijaa finaaliin
        /// </summary>
        /// <param name="sarja">valitu sarja</param>
        /// <returns></returns>
        public List<OsallistujaListLine> getFinal6(string sarja)
        {
            List<OsallistujaListLine> osallistujaList3;
            osallistujaList3 = new List<OsallistujaListLine>();
            int count = 0;;
            int[] finNro = new int[] { 1, 2, 3, 4, 5, 6 };
            SqlCeCommand cmd = new SqlCeCommand();
            // cmd.Parameters.Add("@sarja", sarja);
            SqlCeDataReader rdr = null;
            bool ok = false;

            do
            {
                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    String Sql = String.Format(@"SELECT *, Osallistuja.kierros25 + Osallistuja.kierros50 + Osallistuja.kierros75 + Osallistuja.kierros100 + Osallistuja.kierros125 + Osallistuja.kierrosRatkonta AS sum
                    FROM Osallistuja 
                    INNER JOIN Sarja ON Osallistuja.sarjaID = Sarja.sarjaID
                    WHERE (Sarja.sarja = @sarja)
                    ORDER BY sum DESC, Osallistuja.kierrosRatkonta DESC, Osallistuja.kierros125 DESC, Osallistuja.kierros100 DESC, Osallistuja.kierros75 DESC, 
                    Osallistuja.kierros50 DESC, Osallistuja.kierros25 DESC");
                    
                    cmd = new SqlCeCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("sarja", sarja);

                    rdr = cmd.ExecuteReader();
    
                    while (rdr.Read() && count < 6)
                    {
                        osallistujaList3.Add(new Osallistuja(rdr.GetInt32(0),finNro[count]/* rdr.GetInt32(1)*/, rdr.GetString(3), rdr.GetString(2), rdr.GetInt32(4), rdr.GetInt32(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9), rdr.GetInt32(10), rdr.GetInt32(11), rdr.GetInt32(17)));
                        count++;
                    }
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS: getFinal6()");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    //  rdr.Close();
                    cmd.Dispose();
                    ok = true;
                }

            } while (!ok);

            return osallistujaList3;
        }

        /// <summary>
        /// Paivittaa osallistujalistassa olevien kilpailijoiden
        /// pisteet (paitsi finaalin pisteet)
        /// </summary>
        /// <param name="Osallistujalist">lista, jossa on kilpailijoiden tietoja</param>
        internal void setScores(List<OsallistujaListLine> Osallistujalist)
        {
            int id;
            int k25;
            int k50;
            int k75;
            int k100;
            int k125;
            int kRat;
            int kFin;
            int kFinRat;
            int yht;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            SqlCeConnection con = _connection;
            Console.WriteLine("Kilpailun pisteet (setScores)");
            try
            {
                for (int i = 0; i < Osallistujalist.Count; i++)
                {
                    id = Osallistujalist[i].Id;
                    k25 = Osallistujalist[i].Kierros25;
                    k50 = Osallistujalist[i].Kierros50;
                    k75 = Osallistujalist[i].Kierros75;
                    k100 = Osallistujalist[i].Kierros100;
                    k125 = Osallistujalist[i].Kierros125;
                    kRat = Osallistujalist[i].KierrosRatkonta;
                    kFin = Osallistujalist[i].FinaaliKierros;
                    kFinRat = Osallistujalist[i].FinaaliRatkonta;

                    Console.WriteLine(id + " " + k25 + " " + k50 + " " + k75 + " " + k100 + " " + k125 + " " + kRat);

                    yht = k25 + k50 + k75 + k100 + k125 + kRat + kFin + kFinRat;                   

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Osallistuja SET [kierros25] = @k25, [kierros50] = @k50, [kierros75] = @k75, [kierros100] = @k100, [kierros125] = @k125, [kierrosRatkonta] = @kRat, [yht] = @yht WHERE [OsallistujaID] = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("k25", k25);
                    cmd.Parameters.AddWithValue("k50", k50);                 
                    cmd.Parameters.AddWithValue("k75", k75);
                    cmd.Parameters.AddWithValue("k100", k100);
                    cmd.Parameters.AddWithValue("k125", k125);
                    cmd.Parameters.AddWithValue("kRat", kRat);
                    cmd.Parameters.AddWithValue("yht", yht);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException e)
            {
                Console.WriteLine("setscores");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //cmd.Dispose();
            }
        }

        /// <summary>
        /// Paivittaa osallistujalistassa olevien kilpailijoiden
        /// finaalin pisteet
        /// </summary>
        /// <param name="Osallistujalist">lista, jossa on kilpailijoiden tietoja</param>
        internal void setScoresFinal(List<OsallistujaListLine> Osallistujalist)
        {
            int id;
            int k25;
            int k50;
            int k75;
            int k100;
            int k125;
            int kRat;
            int kFin;
            int kFinRat;
            int yht;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            SqlCeConnection con = _connection;
            Console.WriteLine("Kilpailun finaalin pisteet (setScoresFinal)");
            
            try
            {
                for (int i = 0; i < Osallistujalist.Count; i++)
                {
                    id = Osallistujalist[i].Id;
                    k25 = Osallistujalist[i].Kierros25;
                    k50 = Osallistujalist[i].Kierros50;
                    k75 = Osallistujalist[i].Kierros75;
                    k100 = Osallistujalist[i].Kierros100;
                    k125 = Osallistujalist[i].Kierros125;
                    kRat = Osallistujalist[i].KierrosRatkonta;
                    kFin = Osallistujalist[i].FinaaliKierros;
                    kFinRat = Osallistujalist[i].FinaaliRatkonta;

                    Console.WriteLine(id + " " + kFin + " " + kFinRat);

                    yht = k25 + k50 + k75 + k100 + k125 + kRat + kFin + kFinRat;

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Osallistuja SET [finaaliKierros] = @kFin, [finaaliRatkonta] = @kFinRat, [yht] = @yht WHERE [OsallistujaID] = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("kFin", kFin);
                    cmd.Parameters.AddWithValue("kFinRat", kFinRat);
                    cmd.Parameters.AddWithValue("yht", yht);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlCeException e)
            {
                Console.WriteLine("setscores");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                //cmd.Dispose();
            }
        }

        /// <summary>
        /// Hakee tietokannasta osallistujien ID:T ja paivittaa onkoTyhja
        /// arvon osallistujien ID-listan pituudella. Arvoa tarvitaan
        /// evaamaan tai sallimaan paasy tulosten kirjaukseen 
        /// </summary>
        /// <param name="onkoTyhja"> arvo kertoo montako osallistujaa tietokannassa on </param>
        /// <returns></returns>
        public int checkOsallistujat(int onkoTyhja)
        {
            List<int> osallistujat = new List<int>();           

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            bool ok = false;

            do
            {
                SqlCeConnection con = _connection;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string Sql = String.Format(" SELECT osallistujaID FROM Osallistuja");
                    cmd = new SqlCeCommand(Sql, con);

                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        osallistujat.Add(rdr.GetInt32(0));
                    }

                    onkoTyhja = osallistujat.Count();
                    Console.WriteLine("Osallistujien maara tietokannassa: " + onkoTyhja);
                }
                catch (SqlCeException ex)
                {
                    //ShowErrors(ex);
                    Console.WriteLine("VIRHEILMOITUS checkOsallistujat");
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

            return onkoTyhja;
        }
 
    }//End db
} //end db class