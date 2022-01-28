using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MultiThreading
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Contact { get; set; }
        public DateTime DOB { get; set; }
    }
    public class AdoDotNet
    {
        public void Options()
        {
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            CreateTable();
                            break;
                        case 2:
                            AddCustomer();
                            break;
                        case 3:
                            GetCustomer();
                            break;

                        case 4:
                            GetCustomerById();
                            break;
                        case 5:
                            SerachingContactsByName();
                            break;
                        case 6:
                            NoOFRows();
                            break;
                        default:
                            Console.WriteLine("Please select a valid option!");
                            break;
                    }
                    Console.WriteLine("Do you want to exit?(y): ");
                    char exit = Convert.ToChar(Console.ReadLine());
                    if (exit == 'Y' || exit == 'y')
                    {
                        Environment.Exit(0);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public static void CreateTable()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= WebForm;TrustServerCertificate=true;Integrated Security=true");
            string query =
            @"CREATE TABLE dbo.Customer
                (
                    ID int IDENTITY(1,1) NOT NULL,
                    Name nvarchar(50) NULL,
                    Contact bigint NULL,
                    DOB datetime NULL,
                    CONSTRAINT pk_id PRIMARY KEY (ID)
                );";
            
            try
            {
                con.Open();
                
                DataTable dTable = con.GetSchema("TABLES",new string[] { null, null, "Customer" });
                if(dTable.Rows.Count > 0)
                {
                    Console.WriteLine("Table already exists!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Created Successfully");
                }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    Console.ReadKey();
                }
            }
        }
        public static void AddCustomer()
        {

            

            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= WebForm;TrustServerCertificate=true;Integrated Security=true"))
            {
                try
                {
                    Customer customer = new();
                    Console.Write("Enter Name of the Customer: ");
                    customer.Name = Console.ReadLine();
                    Console.Write("Enter Contact Number of the Customer: ");
                    customer.Contact = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Enter DOB of the Customer: ");
                    customer.DOB = Convert.ToDateTime(Console.ReadLine());
                    con.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Customer values(@Name,@Contact,@DOB)", con);
                    command.Parameters.AddWithValue("Contact", customer.Contact);
                    command.Parameters.AddWithValue("Name", customer.Name);
                    command.Parameters.AddWithValue("DOB", customer.DOB);

                    int rowCount = command.ExecuteNonQuery();
                    if(rowCount != 0)
                    {
                        Console.WriteLine("Customer is added to Database Successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Customer Name:{customer.Name} can not be added!");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error Generated. Details: " + ex.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if(con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Console.ReadKey();
                    }
                    
                }
            }
        }

        public static void GetCustomer()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= WebForm;TrustServerCertificate=true;Integrated Security=true"))
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Customer", con);
                    SqlDataReader sdr = command.ExecuteReader();
                    Console.WriteLine("Customer Details: ");
                    while (sdr.Read())
                    {
                        Console.WriteLine("Customer Name: "+ sdr["name"] );
                        Console.WriteLine("Customer Contact: " + sdr["Contact"]);
                        Console.WriteLine("Customer DOB: " + sdr["DOB"]);
                        Console.WriteLine("---------------------------------------------------");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Console.ReadKey();
                    }
                }
            }
        }

        public static void SerachingContactsByName()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= WebForm;TrustServerCertificate=true;Integrated Security=true"))
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Customer", con);
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = command;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Console.Write("Enter the Name to get details: ");
                            string name = Console.ReadLine();
                            var list_ids = (from DataRow dr in dt.Rows
                                            where (string)dr["Name"] == name
                                            select (long)dr["Contact"]).ToList();

                            if(list_ids.Count > 0)
                            {
                                Console.WriteLine("Contact numbers of selected Names are: ");
                                foreach(var item in list_ids)
                                {
                                    Console.WriteLine(item);
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine($"Name {name} is not Exists in customer table!");
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Console.ReadKey();
                    }
                }
            }
        }

        public static void GetCustomerById()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= WebForm;TrustServerCertificate=true;Integrated Security=true"))
            {
                try
                {
                    con.Open();
                    
                    Customer customer = new();
                    Console.Write("Please Enter Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    SqlCommand cmd = new SqlCommand("select * from Customer where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            customer.Name = Convert.ToString(dr["Name"]);
                            customer.Contact = Convert.ToInt64(dr["Contact"]);
                            customer.DOB = Convert.ToDateTime(dr["DOB"]);
                        }
                        Console.WriteLine($"Customer details of Id: {id}");
                        Console.WriteLine(customer.Name + " " + customer.Contact + " " + customer.DOB);
                    }
                    else
                    {
                        Console.WriteLine($"No data found with Id: {id}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Console.ReadKey();
                    }
                }
            }
        }
        public static void NoOFRows()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog= WebForm;TrustServerCertificate=true;Integrated Security=true"))
            {
                
                try
                {
                    con.Open();
                    var i = con.ClientConnectionId;
                    Console.WriteLine(i);
                    Console.WriteLine("Current Database: " + con.Database);
                    Console.WriteLine("Current DataSource: " + con.DataSource);
                    Console.WriteLine("Server Version: "+con.ServerVersion);
                    SqlCommand cmd = new SqlCommand("select count(*) from Customer", con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    Console.WriteLine(" No. of Rows " + count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! " + ex.Message);
                    
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Console.ReadKey();
                    }
                }
            }
        }

        public void DeleteCustomer()
        {
            //blank
        }
    }
}
