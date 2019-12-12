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
        

        // Automatically create a connection string and pass to MysqlConnection
        // When calling the class
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


        // Insert userdata to database
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


        // Checking the username to the high score table
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


        // return true if the Highest score of the logged in username is true;
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


        // insert score if the score of the logged in username is the highest highscore

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


        // List that collect object from the database
        public List<HighScoreModel> GetHighScores()
        {
            List<HighScoreModel> hs = new List<HighScoreModel>();

            string query = "SELECT * FROM TBL_HIGHSCORES ORDER BY SCORE DESC LIMIT 10";
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

        public void insertStudentGrade(List<StudentGradeModel> stgrList)
        {

            string query = "INSERT INTO tbl_studentgrades (sname,subj,prelim, midterm, finals, ave, remarks) VALUES (@sname,@subj,@prelim, @midterm, @finals, @ave, @remarks)";
            
            cmd = new MySqlCommand(query,con);
            con.Open();


            foreach (var stgr in stgrList)
            {

                var param = cmd.Parameters;
                param.Clear();
                param.AddWithValue("@sname", stgr.sname);
                param.AddWithValue("@subj", stgr.subj);
                param.AddWithValue("@prelim", Math.Round(stgr.prelim,2));
                param.AddWithValue("@midterm", Math.Round(stgr.midterm,2));
                param.AddWithValue("@finals", Math.Round(stgr.finals,2));
                param.AddWithValue("@ave", Math.Round(stgr.ave,2));
                param.AddWithValue("@remarks", stgr.remarks);


                cmd.ExecuteNonQuery();

            }

            con.Close();





        }
        // list that collect students grade from the database

        public List<StudentGradeModel> getStudentGradeList()
        {
            var stgrList = new List<StudentGradeModel>();

            string query = "SELECT * FROM TBL_STUDENTGRADES ORDER BY SNAME ASC";

            cmd = new MySqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                stgrList.Add(new StudentGradeModel {
                    id = (int)dr["id"],
                    sname = (string)dr["sname"],
                    subj = (string)dr["subj"],
                    prelim = (double)dr["prelim"],
                    midterm = (double)dr["midterm"],
                    finals = (double)dr["finals"],
                    ave = (double)dr["ave"],
                    remarks = (string)dr["remarks"]


                });
            }

            con.Close();
            return stgrList;



        }

        // List that collect Customer from the database
        public List<CustomerModel> getCUstomerList()
        {
            var custList = new List<CustomerModel>();

            string query = "SELECT * FROM TBL_CUSTOMERS ORDER BY ID ASC";

            cmd = new MySqlCommand(query, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                custList.Add(new CustomerModel
                {
                    ID = (int)dr["id"],
                    CustName = (string)dr["custname"],
                    totalPurch = (double)dr["totalpurch"],
                    disc = (double)dr["disc"],
                    totalDue = (double)dr["totalDue"],
                    cpay = (double)dr["cpay"],
                    change = (double)dr["chng"]


                });
            }
            con.Close();
            return custList;



        }

        // insert customer that accep list of objects
        public void insertCustomer(List<CustomerModel> custList)
        {

            string query = "INSERT INTO tbl_customers (custname, totalPurch, disc, totalDue, cpay, chng) VALUES (@custname, @totalPurch, @disc, @totalDue, @cpay, @change)";

            cmd = new MySqlCommand(query, con);
            con.Open();


            foreach (var cust in custList)
            {

                var param = cmd.Parameters;
                param.Clear();
                param.AddWithValue("@custname", cust.CustName);
                param.AddWithValue("@totalPurch", Math.Round(cust.totalPurch,2));
                param.AddWithValue("@disc", Math.Round(cust.totalDue, 2));
                param.AddWithValue("@totalDue", Math.Round(cust.totalDue, 2));
                param.AddWithValue("@cpay", Math.Round(cust.cpay, 2));
                param.AddWithValue("@change", Math.Round(cust.change, 2));
    


                cmd.ExecuteNonQuery();

            }

            con.Close();





        }


        public void deleteStudent(int id)
        {
            string query = "DELETE FROM TBL_STUDENTGRADES WHERE ID = @id";

            cmd = new MySqlCommand(query,con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();

        }
        public void deleteCustomer(int id)
        {
            string query = "DELETE FROM TBL_CUSTOMERS WHERE ID = @id";

            cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();

        }

    }
}
