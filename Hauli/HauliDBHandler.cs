﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace Hauli
{
    public class HauliDBHandler
    {
        private SqlCeConnection _connection;

        public HauliDBHandler()
        {
            _connection = new SqlCeConnection(@"Data Source = |DataDirectory|\HauliDB.sdf");
        }


        public List<string> getContestants()
        {
            try
            {
                SqlCeCommand command = new SqlCeCommand();
                command.Connection = _connection;
                command.CommandText = "SELECT * FROM Contestants";
                _connection.Open();

                SqlCeDataReader reader = command.ExecuteReader();
                StringBuilder line = new StringBuilder();
                List<string> resultSet = new List<string>();


                while (reader.Read())
                {
                    line.Append(reader.GetString(0) + " ");
                    line.Append(reader.GetString(1) + " ");
                    line.Append(reader.GetString(2) + " ");
                    line.Append(reader.GetString(3) + " ");
                    line.Append(reader.GetString(4) + " ");
                    line.Append(reader.GetString(5));

                    resultSet.Add(line.ToString());
                    line.Clear();
                }

                reader.Close();
                _connection.Close();

                return resultSet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);   
            }

            return null;
        }

    }
}