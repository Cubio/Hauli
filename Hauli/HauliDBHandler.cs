using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;

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
            String nimi;
            String alue;
            String idNumber;
            try
            {

               // SqlCeCommand command = new SqlCeCommand();
               // command.Connection = _connection;

                for (int i = 0; i < lines.Count; i++)
                {
                    lyhenne = lines[i][0];
                    nimi = lines[i][1];
                    alue = lines[i][2];

                    idNumber = generateId("Seura");

                   // _connection.Open();
                   // command.CommandText = "SELECT * FORM @taulu WHERE SeuraID = @randomID";
                  //  command.Parameters.AddWithValue("@taulu", taulu);

                  //  command.ExecuteNonQuery();
                }

               // _connection.Close();


            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            





        }

        private string generateId(String taulu)
        {
            bool ok = false;
            Random random = new Random();
            int id = 0;
            id = random.Next(10000, 99999);

            try
            {
                SqlCeCommand command = new SqlCeCommand();
                command.Connection = _connection;
                command.CommandText = "SELECT * FORM @taulu WHERE SeuraID = @randomID";
                command.Parameters.AddWithValue("@taulu", taulu);
                _connection.Open();

                SqlCeDataReader reader = command.ExecuteReader();
                StringBuilder line = new StringBuilder();
                List<string> resultSet = new List<string>();

                do
                {


                    Console.WriteLine(reader.GetString(0));



                    //if (!idList.Contains(id.ToString()))
                        ok = true;
                  //  else
                   //     id = random.Next(10000, 99999);
                } while (!ok);

                reader.Close();
                _connection.Close();
            }
            catch (SqlCeException e)
            {
                //ShowErrors(e);
                Console.WriteLine(e.Message);
            }
            return id.ToString();
        }

    }
}