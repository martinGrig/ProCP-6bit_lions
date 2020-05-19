using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlTut
{
    class Result
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
        public int ShopID { get; private set; }
        public double Income { get; private set; }
        public int Visits { get; private set; }
        private Result(int ID, int ResultID, int ShopID, double Income, int Visits)
        {
            this.ID = ID;
            this.ResultID = ResultID;
            this.ShopID = ShopID;
            this.Income = Income;
            this.Visits = Visits;
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

        public static List<Result> GetResults()
        {
            List<Result> results = new List<Result>();

            String query = "SELECT * FROM shop_result";

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = (int)reader["ID"];
                int ResultID = (int)reader["ResultID"];
                int ShopID = (int)reader["ShopID"];
                double Income = (double)reader["Income"];
                int Visits = (int)reader["Visits"];

                Result s = new Result(ID, ResultID, ShopID, Income, Visits);


                results.Add(s);
            }

            reader.Close();

            dbConn.Close();

            return results;
        }

        public static Result Insert(int ID, int ResultID, int ShopID, double Income, int Visits)
        {
            String query = string.Format("INSERT INTO shop_result(ID, ResultID, ShopID, Income, Visits ) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", ID, ResultID, ShopID, Income, Visits);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;

            Result result = new Result(ID, ResultID, ShopID, Income, Visits);

            dbConn.Close();

            return result;
            

        }
        public void Update(int ID, double Income, int Visits)
        {
            
            String query = string.Format("UPDATE shop_result SET Income='{1}', Visits='{2}' WHERE ID={0}", ID, Income, Visits);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
            
        }

        public void Delete(int ID)
        {
            String query = string.Format("DELETE FROM shop_result WHERE ID={0}", ID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }

    }
}
