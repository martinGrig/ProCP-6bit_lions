using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MySqlTut
{
    class ResultAll
    {
        private const String SERVER = "studmysql01.fhict.local";
        private const String DATABASE = "dbi400672";
        private const String UID = "dbi400672";
        private const String PASSWORD = "ProCPLions";
        private static MySqlConnection dbConn;

        // User class stuff
        public int ID { get; private set; }
        public int SimulationID { get; private set; }
        
        private ResultAll(int ID, int SimulationtID)
        {
            this.ID = ID;
            this.SimulationID = SimulationtID;
            
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

        public static List<ResultAll> GetAllResults()
        {
            List<ResultAll> results = new List<ResultAll>();

            String query = "SELECT * FROM results";

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = (int)reader["ID"];
                int SimulationID = (int)reader["SimulationID"];

                ResultAll s = new ResultAll(ID, SimulationID);


                results.Add(s);
            }

            reader.Close();

            dbConn.Close();

            return results;
        }

        public static ResultAll Insert(int ID, int SimulationID)
        {
            String query = string.Format("INSERT INTO result(ID, SimulationID) VALUES ('{0}', '{1}')", ID, SimulationID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;
             
            ResultAll result = new ResultAll(ID, SimulationID);

            dbConn.Close();

            return result;
        }
        public void Update(int ID, int SimulationID)
        {

            String query = string.Format("UPDATE result SET SimulationID='{1}' WHERE ID={0}", ID, SimulationID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();

        }

        public void Delete(int ID)
        {
            String query = string.Format("DELETE FROM result WHERE ID={0}", ID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }

    }
}

    

