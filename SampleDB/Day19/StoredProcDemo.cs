using System;
using System.Data.SqlClient;
using System.Configuration;

namespace SampleDB.Day19
{
   
    class StoredProcDemo
    {
        static string strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        static void callingInsertProc()
        {
            string query = "InsertCustomer";
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", 615);
            cmd.Parameters.AddWithValue("@name", "sachin");
            cmd.Parameters.AddWithValue("@mobile", 6254865236);
            cmd.Parameters.AddWithValue("@city", "Mysore");
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
        }
        static void insertStudent()
        {
            string query = "InsertStudent";
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;//Tell the system that is is stored proc
            int studentID = 0;
            cmd.Parameters.AddWithValue("@name", "Ram");
            cmd.Parameters.AddWithValue("@marks", 98);
            cmd.Parameters.AddWithValue("@age", 22);
            cmd.Parameters.AddWithValue("id", studentID);
            cmd.Parameters[3].Direction = System.Data.ParameterDirection.Output;//Important for output parameters
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                studentID = Convert.ToInt32(cmd.Parameters[3].Value);
                Console.WriteLine("The id of the new student is "+studentID);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
        }
        static void Main(string[] args)
        {
            //callingInsertProc();
            insertStudent();
        }
    }
}
