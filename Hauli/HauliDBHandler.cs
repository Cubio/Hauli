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
        internal void addFile(List<string[]> lines)
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

                    idNumber = generateId("Seura");

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




        // Palauttaa ID numeron, jota ei ole olemassa kyseisessä taulussa.
        public int generateId(String taulu)
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


                    string Sql = String.Format(@" SELECT * FROM {0} WHERE seuraID = @numero", taulu);
                    cmd = new SqlCeCommand(Sql, con);

                    //2 tapa muodostaa yhteys niin että korvataan taulunnimi. Työläs ja hidas tapa.
                    //cmd = new SqlCeCommand("SELECT * FROM _#table#_ WHERE seuraID = @numero ", con);
                    //cmd.CommandText = cmd.CommandText.Replace("_#table#_", taulu);
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






    }//End db
} //end db class