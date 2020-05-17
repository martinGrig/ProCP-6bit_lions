using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlTut
{
    class Shop
    {
        private const String SERVER = "studmysql01.fhict.local";
        private const String DATABASE = "dbi400672";
        private const String UID = "dbi400672";
        private const String PASSWORD = "ProCPLions";
        private static MySqlConnection dbConn;

        // User class stuff
        public int ID { get; private set; }
        public int PositionID { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; } 
        public double Popularity { get; private set; }
        public double PriceRange { get; private set; }
        public string BusyHours { get; private set; }
        public string Category { get; private set; }

        private Shop(int ID, int PositionID, string Name, int Capacity, double Popularity, double PriceRange, string BusyHours, string Category)
        {
            this.ID = ID;
            this.PositionID = PositionID;
            this.Name = Name;
            this.Capacity = Capacity;
            this.Popularity = Popularity;
            this.PriceRange = PriceRange;
            this.BusyHours = BusyHours;
            this.Category = Category;

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

        public static List<Shop> GetShops()
        {
            List<Shop> shops = new List<Shop>();

            String query = "SELECT * FROM shop";

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int ID = (int)reader["ID"];
                int PositionID = (int)reader["PositionID"];
                string Name = reader["Name"].ToString();
                int Capacity = (int)reader["Capacity"];
                double Popularity = (double)reader["Popularity"];
                double PriceRange = (double)reader["PriceRange"];
                string BusyHours = reader["BusyHours"].ToString();
                string Category = reader["Category"].ToString();
                Shop s = new Shop(ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category);

                shops.Add(s);
            }

            reader.Close();
            dbConn.Close();
            return shops;
        }

        public static Shop Insert(int ID, int PositionID, string Name, int Capacity, double Popularity, double PriceRange, string BusyHours, string Category)
        {
            String query = string.Format("INSERT INTO shop(ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category ) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;

            Shop shop = new Shop(ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category);

            dbConn.Close();

            return shop;


        }
        public void Update(int ID, int PositionID, string Name, int Capacity, double Popularity, double PriceRange, string BusyHours, string Category)
        {

            String query = string.Format("UPDATE shop SET PositionID='{1}', Name='{2}', Capacity='{3}', Popularity='{4}', PriceRange='{5}', BusyHours='{6}', Category='{7}' WHERE ID={0}", ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();

        }

        public void Delete(int ID)
        {
            String query = string.Format("DELETE FROM shop WHERE ID={0}", ID);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }

    }
}

    

