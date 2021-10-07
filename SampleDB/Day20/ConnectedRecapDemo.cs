using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDB.Day20
{
    //to run this program have to chage initial catlog name fidilitytrainingdb to Recapsql in App.config
    class ConnectedRecapDemo
    {
        static string strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        const string query = "Select Movie.Title,Director.DirectorName from Movie inner join Director on Movie.DirectorId=Director.DirectorId where Director.DirectorName=@name";
        static void Main(string[] args)
        {
            showMoviesByDirector("Hari");
        }

        private static void showMoviesByDirector(string name)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                    Console.WriteLine($"{reader[0]}-{reader[1]}");
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}
