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
            if (File.Exists("HauliDB.sdf"))
                _connection = new SqlCeConnection(@"Data Source = |DataDirectory|\HauliDB.sdf");
            else
            {
                throw new HauliException("Tiedostoa HauliDB.sdf ei löytynyt");                
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

                    Console.WriteLine("NRO:" + idNumber);

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                   // string Sql = String.Format(@" SELECT * FROM {0} WHERE seuraID = @numero", "Seura");
                    //cmd = new SqlCeCommand(Sql, con);
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Seura (seuraID, seura, lyhenne, alue) Values(@idNumero, @seura, @lyhenne, @alue)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("seura", seura);
                    cmd.Parameters.AddWithValue("lyhenne", lyhenne);
                    cmd.Parameters.AddWithValue("alue", alue);

                    cmd.ExecuteNonQuery();

                    //Console.WriteLine("RIVAREITA:" + RowsAffected);


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
                        seuraList.Add(new Seura( rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3) ));
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

            SqlCeConnection con =_connection;
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
                        Console.WriteLine(rdr.GetString(1));
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

            Console.WriteLine("ID:" + idNro);
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

        /*
       internal void setTeam(List<TeamListLine> teamList)
       {

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
                        seuraBox.Items.Add(dr["seura"]);
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
        }

*/
        public void LoadSeuraBox(ComboBox seuraBox)
        {
            // hakee tietokannasta comboboxissa esitettävät kentät

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
                        seuraBox.Items.Add(dr["seura"]);
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
        }

        public void LoadSarjaBox(ComboBox sarjaBox)
        {
            // hakee tietokannasta comboboxissa esitettävät kentät

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
                        sarjaBox.Items.Add(dr["sarja"]);
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
        }

        public void LoadJoukkueBox(ComboBox joukkueBox)
        {
            // hakee tietokannasta comboboxissa esitettävät kentät

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
                        joukkueBox.Items.Add(dr["joukkue"]);
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
        }

/*

           
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

*/







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
                        teamList.Add(new Team(rdr.GetInt32(0), rdr.GetString(1) ));
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
            int seura;
            int era;

            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            SqlCeConnection con = _connection;
            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    nimi = lines[i][0];
                    sukunimi = lines[i][1];
                    seuraID = ToInt32(lines[i][2]);
                    joukkueID = lines[i][3];
                    sarjaID = lines[i][4];
                    era = lines[i][5];

                    idNumber = generateId("Seura", "seuraID");

                    Console.WriteLine("NRO:" + idNumber);

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    // string Sql = String.Format(@" SELECT * FROM {0} WHERE seuraID = @numero", "Seura");
                    //cmd = new SqlCeCommand(Sql, con);
                    cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Seura (seuraID, seura, lyhenne, alue) Values(@idNumero, @seura, @lyhenne, @alue)";

                    cmd.Parameters.AddWithValue("idNumero", idNumber);
                    cmd.Parameters.AddWithValue("seura", seura);
                    cmd.Parameters.AddWithValue("lyhenne", lyhenne);
                    cmd.Parameters.AddWithValue("alue", alue);

                    cmd.ExecuteNonQuery();

                    //Console.WriteLine("RIVAREITA:" + RowsAffected);


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
    }//End db
} //end db class