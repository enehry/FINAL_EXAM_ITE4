using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DEDORO_FINAL
{
    public class Database
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        

        
        public Database()
        {
            string server = "localhost";
            string username = "root";
            string password = "*JavaOOP";
            string database = "db_dedoro";


            string conString = $"server={server};username={username};password={password};database={database}";
            con = new MySqlConnection(conString);
         
           
        }

        //Method that check username and password are registered in database
        public bool isRegistered(string user, string pass)
        {
            string query = "SELECT * FROM TBL_USERS WHERE un = @un AND pw = @pw";
            cmd = new MySqlCommand(query, con);
            con.Open();
            var param = cmd.Parameters;
            param.Clear();

            param.AddWithValue("@un", user);
            param.AddWithValue("@pw", pass);

            dr = cmd.ExecuteReader();

            bool hasRecord = (dr.HasRows) ? true : false;

            con.Close();

            return hasRecord;


        }

        public int Insert(string fn,string mn,string ln, string un, string pw, string ut)
        {
            string query = "INSERT INTO TBL_USERS (fn ,mn ,ln ,un ,pw ,ut )VALUES( @f, @m, @l, @u, @p, @ut)";
            cmd = new MySqlCommand(query, con);
            con.Open();
            var param = cmd.Parameters;

            param.AddWithValue("@f", fn);
            param.AddWithValue("@m", mn);
            param.AddWithValue("@l", ln);
            param.AddWithValue("@u", un);
            param.AddWithValue("@p", pw);
            param.AddWithValue("@ut", ut);

            int inserted = cmd.ExecuteNonQuery();
            con.Close();

            return inserted;

        }
    }
}
