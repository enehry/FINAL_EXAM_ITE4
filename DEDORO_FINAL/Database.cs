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
            string query = "INSERT INTO TBL_USERS VALUES( @f, @m, @l, @u, @p, @ut)";
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

        private bool CheckUserName(string username)
        {
            string query = "SELECT * FROM TBL_HIGHSCORES WHERE un = @un";
            cmd = new MySqlCommand(query, con);
            con.Open();
            var param = cmd.Parameters;
            param.Clear();

            param.AddWithValue("@un", username);

            dr = cmd.ExecuteReader();

            bool hasRecord = (dr.HasRows) ? true : false;

            con.Close();

            return hasRecord;
        }

        private bool isHighestScore(string username,int score)
        {
            string query = "SELECT SCORE FROM TBL_HIGHSCORES WHERE un = @un";
            cmd = new MySqlCommand(query, con);
            con.Open();
            var param = cmd.Parameters;
            param.Clear();

            param.AddWithValue("@un", username);

            dr = cmd.ExecuteReader();
            dr.Read();


            bool isHighScore = ((int)dr["score"] < score) ? true : false;

            con.Close();

            return isHighScore;


        }


        public void insertScore(string username, int score)
        {
            if (!CheckUserName(username))
            {

                string query = "INSERT INTO TBL_HIGHSCORES VALUES(@un,@score)";
                cmd = new MySqlCommand(query, con);
                con.Open();
                var param = cmd.Parameters;

                param.AddWithValue("@un", username);
                param.AddWithValue("@score", score);
              

                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                if (isHighestScore(username,score))
                {

                    string query = "UPDATE TBL_HIGHSCORES SET score = @score WHERE un = @un";
                    cmd = new MySqlCommand(query, con);
                    con.Open();
                    var param = cmd.Parameters;

                    param.AddWithValue("@un", username);
                    param.AddWithValue("@score", score);


                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
        }

        public List<HighScoreModel> GetHighScores()
        {
            List<HighScoreModel> hs = new List<HighScoreModel>();

            string query = "SELECT * FROM TBL_HIGHSCORES";
            cmd = new MySqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();

         
            while (dr.Read())
            {
              
               
                hs.Add(new HighScoreModel { un = dr["un"].ToString(), highScore = int.Parse(dr["score"].ToString()) });

            }

            con.Close();
            return hs;



        }
    }
}
