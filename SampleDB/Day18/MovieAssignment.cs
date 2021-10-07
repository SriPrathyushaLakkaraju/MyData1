using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDB.Day18
{
    class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public override string ToString()
        {
            return $"Movie number {MovieID} , {MovieName} directed by {DirectorName} relesed on {ReleaseDate}";
        }
    }
    interface IMovieData
    {
        void AddMovie(int id, string name, string dirname, DateTime dt);
        void DeleteMovie(int id);
        void UpdateMovie(int id, string name, string dirname, DateTime dt);
        Movie FindMovie(int id);
        List<Movie> FindMovieByName(string name);
    }

    [Serializable]
    public class NoDatFoundException : ApplicationException
    {
        public NoDatFoundException() { }
        public NoDatFoundException(string message) : base(message) { }
        public NoDatFoundException(string message, Exception inner) : base(message, inner) { }
        protected NoDatFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    class MoviedB : IMovieData
    {
        const string strConnection = @"Data Source=FNFIADMUATSRV;Initial Catalog=fidelitytrainingdb;Integrated Security=True";
        public void AddMovie(int id,string name,string dirname,DateTime dt)
        {
                var query = "insert into Movie values (@id,@name,@dirname,@date)";
                var connection = new SqlConnection(strConnection);
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dirname", dirname);
                cmd.Parameters.AddWithValue("@date", dt);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                throw new NoDatFoundException("No data found");
                }
                finally
                {
                    connection.Dispose();
                }
            }

        public void DeleteMovie(int id)
        {
                var query = $"delete from Movie where MovieID=@id";
                var connection = new SqlConnection(strConnection);
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception)
                {
                throw new NoDatFoundException("No data found to delete");
                }
                finally
                {
                    connection.Dispose();
                }
            }

        public Movie FindMovie(int id)
        {
            var mv = new Movie();
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand($"select * from Movie where MovieID = ${id}", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mv = new Movie
                        {
                            MovieName = reader["MovieName"].ToString(),
                            DirectorName = reader["directorname"].ToString(),
                            MovieID = Convert.ToInt32(reader["MovieID"]),
                            ReleaseDate = Convert.ToDateTime(reader["releasedate"])

                        };
                    }
                    return mv;
                }
                else
                    throw new NoDatFoundException("No data found");
            }
            catch (Exception)
            {
                throw new NoDatFoundException("No data found");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Movie> FindMovieByName(string name)
        {
                var query = $"Select * from Movie where MovieName like '%{name}%'";
                var connection = new SqlConnection(strConnection);
                var cmd = new SqlCommand(query, connection);
                List<Movie> movies = new List<Movie>();
                try
                {
                    connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Movie movie = new Movie(); 
                        movie.MovieID = Convert.ToInt32(reader[0]);
                        movie.MovieName = reader[1].ToString();
                        movie.DirectorName = reader[2].ToString();
                        movie.ReleaseDate = Convert.ToDateTime(reader[3]);
                        movies.Add(movie);
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Dispose();
                    cmd.Dispose();
                }
                return movies;
            }

        public void UpdateMovie(int id,string name,string dirname,DateTime dt)
        {
                var query = "update Movie set movieid=@id,moviename=@name,directorname=@dirname,releasedate=@date where MovieId=@id";
                var connection = new SqlConnection(strConnection);
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dirname", dirname);
                cmd.Parameters.AddWithValue("@date", dt);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
    }

    class MovieAssignment
    {
        static void Main(string[] args)
        {
            IMovieData imd = new MoviedB();
            //imd.AddMovie(13, "Krishna", "Ravi", DateTime.Parse("5/6/2000"));
            //imd.DeleteMovie(1);
            //imd.UpdateMovie(2, "Nenunnanu", "Sagar", DateTime.Parse("06/09/2000"));
            //var list = imd.FindMovie(5);
            //Console.WriteLine(list);
            var list=imd.FindMovieByName("n");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
