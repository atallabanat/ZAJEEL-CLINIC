using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinics.Class
{
    class ClsHistory
    {
        //
        string Date;
        string year;
        string Time;

        public int Login = 4;
        public string NameLogin = "دخول";

        public int Exit = 5;
        public string NameExit = "خروج";

        public int ADD = 1;
        public string NameADD="إضافة";
        public int Edit = 2;
        public string NameEdit = "تعديل";
        public int Delete = 3;
        public string NameDelete = "حذف";
        public void EventHistory(string IDorder, int IDEvent,string NameEvent,int IDScreen,string NameScreen)
        {
             string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            OthersDataBase D = new OthersDataBase();
            DocType docType = new DocType();


            try
            {
                con.Open();
                SqlCommand cmd22 = new SqlCommand("select CONVERT(Date ,GETDATE(),111) as Date ,YEAR(GETDATE()) as year, CONVERT(varchar(15),CAST(convert(varchar,GETDATE() , 8) AS TIME),100) as Time", con);
                SqlDataReader dr2;
                dr2 = cmd22.ExecuteReader();

                if (dr2.Read())
                {
                    Date = dr2["Date"].ToString();
                    year = dr2["year"].ToString();
                    Time = dr2["Time"].ToString();
                }

            }
            catch
            {
            }
            finally
            {
                con.Close();
            }



            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO History (IDorder,Year, IDEvent, NameEvent, IDUser, NameUser, IDScreen, NameScreen, Date, Time) VALUES (@IDorder,@Year, @IDEvent, @NameEvent, @IDUser, @NameUser, @IDScreen, @NameScreen, @Date, @Time)";
                cmd.Parameters.AddWithValue("@IDorder", IDorder);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@IDEvent", IDEvent);
                cmd.Parameters.AddWithValue("@NameEvent", NameEvent);
                cmd.Parameters.AddWithValue("@IDUser", Program.user_ID);
                cmd.Parameters.AddWithValue("@NameUser", Program.Name_User);
                cmd.Parameters.AddWithValue("@IDScreen", IDScreen);
                cmd.Parameters.AddWithValue("@NameScreen", NameScreen);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
    }
}
