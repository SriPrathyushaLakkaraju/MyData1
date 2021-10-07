using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleDB
{
    class Customer
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
        public DateTime Visit { get; set; }
        public long Phone { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"The Customer {CustID} whose name is {CustName} from {City} visited the office {Visit.ToShortDateString()} and phone number {Phone} ";
       }

    }
    class Program
    {
        const string strConnection = @"Data Source=FNFIADMUATSRV;Initial Catalog=fidelitytrainingdb;Integrated Security=True";
        const string strSelect = "select CustomerName,ContactNo from Customer";
        static void connectToDB()
        {
            SqlConnection connection = new SqlConnection(strConnection);
            try
            {
                connection.Open();
                Console.WriteLine("Test connection is succeeded.");
                connection.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }
       
        static Customer findCustomer(int id)
        {
            var cst = new Customer();
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand($"select * from Customer where customerID = ${id}", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                   while(reader.Read())
                    {
                        cst = new Customer
                        {
                            City = reader["City"].ToString(),
                            CustName = reader["CustomerName"].ToString(),
                            CustID = Convert.ToInt32(reader["CustomerID"]),
                            Phone = Convert.ToInt64(reader["ContactNo"]),
                            Visit = Convert.ToDateTime(reader["VisitTime"])
                        };
                    }
                    return cst;
                }
                else
                    throw new Exception("No data found");
            }
            catch(SqlException)
            {
                throw new Exception("No data found");
            }
             finally
                {
                con.Close();
                con.Dispose();
            }
        }
        static List<Customer> getAllCustomers()
        {
            //create the connection
            SqlConnection conn = new SqlConnection(strConnection);
            //create the command
            SqlCommand cmd = new SqlCommand("select * from customer", conn);
            //create the blank list of customers
            List<Customer> customers = new List<Customer>();   
            try
            {
                conn.Open();
                //execute the command to return a reader
                var reader = cmd.ExecuteReader();
                //run through the while loop
                while(reader.Read())//to read one row at a time
                {
                    //convert the row of the reader into customer object
                    var cst = new Customer();
                    cst.CustID = Convert.ToInt32(reader[0]);
                    cst.CustName = reader[1].ToString();
                    cst.Visit = Convert.ToDateTime(reader[2]);
                    cst.Phone = Convert.ToInt64(reader[3]);
                    cst.City= reader[4].ToString();
                    //Add the customer object to the list
                    customers.Add(cst);
                }
                conn.Close();//close the connection
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally//finally dispose the object
            {
                conn.Dispose();
                cmd.Dispose();
            }
            //return the list
            return customers;
        }
        static void readNamesOfCustomers()
        {
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSelect, connection);
            try
            {
                connection.Open();//Open the connection
                SqlDataReader reader = command.ExecuteReader();//Execute the statement using Command object
                while (reader.Read())//Start reading it.....
                {
                    Console.WriteLine(reader["CustomerName"]);
                    Console.WriteLine( reader["ContactNo"]);
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
                command.Dispose();
            }
        }
        static void displayAllDetails()
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand("select * from customer",con);
            try
            {
                con.Open();//Open the connection
                var reader = cmd.ExecuteReader();//Execute the statement using Command object
                if (!reader.HasRows)
                {
                    Console.WriteLine("No data Found.");
                }
                else
                {

                    while (reader.Read())//Start reading it.....
                    {
                        Console.WriteLine($"Details of {reader[1]}");
                        Console.WriteLine($"ID : {reader[0]}");
                        DateTime dt = Convert.ToDateTime(reader[2]);
                        Console.WriteLine($"Visitdate : {dt.ToShortDateString()}");
                        Console.WriteLine($"Phone no :  {reader[3]}");
                        Console.WriteLine($"City : {reader[4]}");
                        Console.WriteLine("-------------------------------------------------------");
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }
        static void addCustomer(int id,string name,string city,long phone)
        {
            var insertStatement = $"insert into Customer values({id},'{name}','{DateTime.Now.ToShortDateString()}',{phone},'{city}')";
            using(var connection=new SqlConnection(strConnection))
            {
                var cmd = new SqlCommand(insertStatement, connection);
                try
                {
                    connection.Open();
                    var rowseffected = cmd.ExecuteNonQuery();
                    if(rowseffected==1)
                        Console.WriteLine("Added");
                    connection.Close();
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        //using parameters to insert a record
        static void addCustomerUsingParam(int id,string name,string city,long phone)
        {
            var query = "insert into customer values (@id,@name,@visit,@phone,@city)";
            var connection = new SqlConnection(strConnection);
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@visit", DateTime.Now);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }
        static void deleteCustomer(int id)
        {
            var query = $"delete from Customer where CustomerID=@id";
            var connection = new SqlConnection(strConnection);
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
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
        static void updateCustomer(int id, string name, string city, long phone)
        {
            var query = "update customer set CustomerID=@id,CustomerName=@name,visitTime=@visit,ContactNo=@phone,city=@city where CustomerId=@id";
            var connection = new SqlConnection(strConnection);
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@visit", DateTime.Now);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@city", city);
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

        static void Main(string[] args)
        {
            //connectToDB();
            //readNamesOfCustomers();
            //displayAllDetails();
            // displayCustomers();
            //findCustomerByID();
            //addCustomer(602, "Aparna", "Bangalore", 6589745258);
            //addCustomerUsingParam(603, "lakshmi", "Bangalore", 5623487596);
            deleteCustomer(602);
            updateCustomer(1, "sri", "Bangalore", 69856325422);

        }
        private static void findCustomerByID()
        {
            try
            {
                Console.WriteLine("Enter id to find");
                var id = int.Parse(Console.ReadLine());
                var list = findCustomer(id);
                Console.WriteLine(list.CustName);
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void displayCustomers()
        {
            var list = getAllCustomers();
            if (list.Count == 0) Console.WriteLine("no data found");
            else
            {
                foreach (var cst in list)
                {
                    Console.WriteLine(cst);
                }
            }
        }
    }
}
