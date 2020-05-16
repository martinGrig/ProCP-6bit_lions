using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlTut
{
    public class Simulation
    {
        //database stuff
        private const String SERVER = "studmysql01.fhict.local";
        private const String DATABASE = "dbi400672";
        private const String UID = "dbi400672";
        private const String PASSWORD = "ProCPLions";
        private static MySqlConnection dbConn;

        // User class stuff
        public int ID { get; private set; }
        public int ResultID { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public string Weather { get; private set; }
        public string Holiday { get; private set; }
        public string DayOfTheWeek { get; private set; }
        public double Sales { get; private set; }

        private Simulation(int ID, int ResultID, string StartTime, string EndTime, string Weather, string Holiday, string DayOfTheWeek, double Sales)
        {
            this.ID = ID;
            this.ResultID = ResultID;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Weather = Weather;
            this.Holiday = Holiday;
            this.DayOfTheWeek = DayOfTheWeek;
            this.Sales = Sales;
        }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;
            builder.SslMode = MySqlSslMode.None;
            String connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);

            dbConn = new MySqlConnection(connString);

             Application.ApplicationExit += (sender, args) =>
             {
                 if (dbConn != null)
                 {
                     dbConn.Dispose();
                     dbConn = null;
                 }
             };
        }

        public static List<Simulation> GetSimulations()
        {
            List<Simulation> simulations = new List<Simulation>();

            String query = "SELECT * FROM simulation";

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = (int)reader["ID"];
                int ResultID = (int)reader["ResultID"];
                string StartTime = reader["StartTime"].ToString();;
                string EndTime = reader["EndTime"].ToString();
                string Weather = reader["Weather"].ToString();
                string Holiday = reader["Holiday"].ToString();
                string DayOfTheWeek = reader["DayOfTheWeek"].ToString();
                double Sales = (double)reader["Sales"];

                Simulation s = new Simulation(ID, ResultID, StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales);

                simulations.Add(s);
            }

            reader.Close();

            dbConn.Close();

            return simulations;
        }

         public static Simulation Insert(int ID, int ResultID, string StartTime, string EndTime, string Weather, string Holiday, string DayOfTheWeek, double Sales)
        {
            String query = string.Format("INSERT INTO simulation(ID, ResultID, StartTime,EndTime, Weather, Holiday, DayOfTheWeek, Sales ) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", ID, ResultID, StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;

            Simulation simulation = new Simulation(ID, ResultID, StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales);

            dbConn.Close();

            return simulation;

        }
        public void Update(string u, string p)
        {
            /*
            String query = string.Format("UPDATE users SET username='{0}', password='{1}' WHERE ID={2}", u, p, Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
            */
        }

        public void Delete(int ID)
        {
            String query = string.Format("DELETE FROM simulation WHERE ID={0}", ID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }
        
    }
}
