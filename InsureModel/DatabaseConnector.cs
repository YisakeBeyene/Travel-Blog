using MySql.Data.MySqlClient;

namespace InsureModel
{
    public class DatabaseConnector
    {
        private const string SERVER = "127.0.0.1";
        private const string DATABASE = "insureyou";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbConn;
         public DatabaseConnector() {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;
            builder.AllowZeroDateTime = true;

            string conString = builder.ToString();
            dbConn = new MySqlConnection(conString);

        }
        public static MySqlConnection GetConnection() => dbConn;


    }
}
