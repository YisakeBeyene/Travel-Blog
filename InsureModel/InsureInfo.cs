using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace InsureModel
{
    public class InsureInfo
    {
        public int ID { get; set; }
        public String Provider { get; set; }
        public DateTime ExpireDate { get; set; }
        public String ItemID { get; set; }
        public int TotalWorth { get; set; }

        public InsureInfo(int ID,String Provider, DateTime ExpireDate,String ItemId,int TotalWorth)
        {

            this.ID = ID;
            this.ExpireDate = ExpireDate;
            this.Provider = Provider;
            this.ItemID = ItemID;
            this.TotalWorth = TotalWorth;
        }
        public static List<InsureInfo> GetAll() {
            new DatabaseConnector();
            MySqlConnection dbCon = DatabaseConnector.GetConnection();
            List<InsureInfo> all = new List<InsureInfo>();
            String query = "select * from insure";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader= cmd.ExecuteReader();
            while (reader.Read()) {
                DateTime date = reader.GetDateTime(2);
                InsureInfo info = new InsureInfo((int)reader["ID"], reader["Provider"].ToString(), date,reader["itemid"].ToString(),(int)reader["worth"]);
                all.Add(info);
            }
            dbCon.Close();
            return all;
        }

        public static void Edit(int idint, string prov, DateTime expDate, string mo)
        {
            String year = expDate.Year.ToString();
            String month = expDate.Month.ToString();
            String day = expDate.Day.ToString();
            String date = String.Format("{0}/{1}/{2}", year, month, day);
            new DatabaseConnector();
            MySqlConnection dbCon = DatabaseConnector.GetConnection();
            //MessageBox.Show(expDate.ToString());
            String query = String.Format($"update insure set Provider= '{prov}' ,Expire_Date='{date}' where ID={idint}; ");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();

            dbCon.Close();
        }

        public static void Add(string prov, DateTime expDate, string itemID,int worth)
        {
            String year = expDate.Year.ToString();
            String month = expDate.Month.ToString();
            String day = expDate.Day.ToString();
            String date = String.Format("{0}/{1}/{2}", year, month, day);
            new DatabaseConnector();
            MySqlConnection dbCon = DatabaseConnector.GetConnection();
            //MessageBox.Show(expDate.ToString());
            String query = String.Format("insert into insure(Provider,Expire_Date,worth,itemid) values ('{0}','{1}','{2}','{3}') ",prov,date,worth,itemID);
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();
            
            dbCon.Close();
            

        }

        public static void Delete(int intid)
        {
            new DatabaseConnector();
            MySqlConnection dbCon = DatabaseConnector.GetConnection();
            String query = String.Format($"delete from insure where ID={intid}; ");
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            cmd.ExecuteNonQuery();

            dbCon.Close();
        }
        public static int total() {
            int worth = 0;
            new DatabaseConnector();
            MySqlConnection dbCon = DatabaseConnector.GetConnection();
            String query = "select * from insure";
            MySqlCommand cmd = new MySqlCommand(query, dbCon);
            dbCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                worth += (int)reader["worth"];
            }
            dbCon.Close();
            return worth;
        }
    }
}
