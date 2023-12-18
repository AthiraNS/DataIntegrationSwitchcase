using System;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
namespace Registernew
{
    public class Registernew
    {
        public class RegisterDatanew
        {
            public int Roll_No { get; set; }
            public string Student_Name { get; set; }
            public string Student_Place { get; set; }
            public string Student_Email { get; set; }

        }
        public static void Main(string[] args)
        {
            List<RegisterDatanew> list = new List<RegisterDatanew>()
            {       
                    new RegisterDatanew()
                    {
                        Student_Name="Arun",
                        Student_Place="Chennai",
                        Student_Email="arun@gmail.com"
                    },
                    new RegisterDatanew()
                    {

                        Student_Name="Manii",
                        Student_Place="Trivandrum",
                        Student_Email="manii@gmail.com"
                    },
                    new RegisterDatanew()
                    {
                        Student_Name="Kanna",
                        Student_Place="Delhi",
                        Student_Email="kanna@gmail.com"
                    },
                    new RegisterDatanew()
                    {

                        Student_Name="Sooraj",
                        Student_Place="Mangalore",
                        Student_Email="sooraj@gmail.com"
                    },
                    new RegisterDatanew()
                    {

                        Student_Name="Dhrish",
                        Student_Place="Up",
                        Student_Email="dhrish@gmail.com"
                    },
                    new RegisterDatanew()
                    {

                        Student_Name="Pramod",
                        Student_Place="Chennai",
                        Student_Email="pramod@gmail.com"
                    },
                    new RegisterDatanew()
                    {

                        Student_Name="Pramod",
                        Student_Place="Chennai",
                        Student_Email="pramod@gmail.com"
                    }
            };
            Console.WriteLine("1.Create a new Table");
            Console.WriteLine("2.Insert bulk Data");
            Console.WriteLine("2.Insert a student Data");
            Console.WriteLine("3.Update Data");
            Console.WriteLine("4.Delete student Data");
            Console.WriteLine("5.Insert a student Data");
            Console.WriteLine("Choose your option number to perform your request(1-5):");

            int Choice;


            if (int.TryParse(Console.ReadLine(), out Choice))
            {
                switch(Choice)
                {
                    case 1:
                        Create(list);
                        void Create(List<RegisterDatanew> list)
                        {
                            try      //NEW TABLE CREATION...
                            {
                                SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegisterSwitchcase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                                Conn.Open();
                                string query1 = $"CREATE TABLE StudentList(Roll_No INT IDENTITY, Student_Name NVARCHAR(40), Student_Place NVARCHAR(100), Student_Email NVARCHAR(100))";
                                SqlCommand cmd2 = new SqlCommand(query1, Conn);
                                cmd2.ExecuteNonQuery();
                                Conn.Close();
                                Console.WriteLine("Table Created");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("DataIntegration");
                            }
                        }
                        break;  

                        case 2:
                        Insert(list);
                        void Insert(List<RegisterDatanew> list)
                        {
                            try     // INSERT SINGLE/BULK VALUES..
                            {
                                SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegisterSwitchcase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                                Conn.Open();
                                String query2 = $"INSERT INTO StudentList (Student_Name,Student_Place,Student_Email) VALUES(@Student_Name,@Student_Place,@Student_Email)";
                                foreach (RegisterDatanew p in list)
                                {
                                    SqlCommand cmd = new SqlCommand(query2, Conn);
                                    {
                                        cmd.Parameters.AddWithValue("Student_Name", p.Student_Name);
                                        cmd.Parameters.AddWithValue("Student_Place", p.Student_Place);
                                        cmd.Parameters.AddWithValue("Student_Email", p.Student_Email);

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                Conn.Close();
                                Console.WriteLine("All Student details updated");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            finally
                            {
                                Console.WriteLine("Example for bulk update");
                            }
                        }
                        break;

                        case 3:

                        Update();
                        void Update()
                        {
                            try     // Update the value..
                            {
                                SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegisterSwitchcase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                                Conn.Open();
                                Console.Write("Enter the roll no to be updated:");
                                int update_rollno = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter the place to be updated:");
                                String place = Console.ReadLine();
                                String query4 = $"UPDATE StudentList SET Student_Place=@place WHERE Roll_No=@update_rollno";
                                foreach (RegisterDatanew m in list)
                                {
                                    SqlCommand cmd = new SqlCommand(query4, Conn);
                                    {
                                        cmd.Parameters.AddWithValue("@place", place);
                                        cmd.Parameters.AddWithValue("@update_rollno", update_rollno);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                Conn.Close();
                                Console.WriteLine("Row updated");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Example for update database integration");
                            }

                        }
                        break;

                        case 4:
                        Delete( );
                        void Delete()
                        {
                            try     // Delete the value..
                            {
                                SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegisterSwitchcase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                                Conn.Open();
                                Console.Write("Enter the roll no to be deleted:");
                                int del_rollno =Convert.ToInt32( Console.ReadLine());
                                String query3 = $"DELETE FROM StudentList where Roll_no=@del_rollno";
                                foreach (RegisterDatanew m in list)
                                {
                                    SqlCommand cmd = new SqlCommand(query3, Conn);
                                    {

                                        cmd.Parameters.AddWithValue("@del_rollno", del_rollno);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                Conn.Close();
                                Console.WriteLine("Row deleted");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Example for delete database integration");
                            }

                        }
                        break;

                        case 5:
                    
                        InsertSingle();
                        void InsertSingle()
                        {
                            try     // INSERT SINGLE/BULK VALUES..
                            {
                                SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RegisterSwitchcase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
                                Conn.Open();
                                Console.Write("Enter New Student Name:");
                                String Student_Name = Console.ReadLine();
                                Console.Write("Enter the Student place:");
                                String Student_Place = Console.ReadLine();
                                Console.Write("Enter the Student Email:");
                                String Student_Email = Console.ReadLine();

                                String query2 = $"INSERT INTO StudentList (Student_Name,Student_Place,Student_Email) VALUES(@Student_Name,@Student_Place,@Student_Email)";
                                SqlCommand cmd = new SqlCommand(query2, Conn);
                                    {
                                        cmd.Parameters.AddWithValue("@Student_Name", Student_Name);
                                        cmd.Parameters.AddWithValue("@Student_Place", Student_Place);
                                        cmd.Parameters.AddWithValue("@Student_Email", Student_Email);

                                        cmd.ExecuteNonQuery();
                                    }
                                Conn.Close();
                                Console.WriteLine("All Student details updated");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            finally
                            {
                                Console.WriteLine("Example for bulk update");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                     break;
                        

                }



            }

            else    
            { 
                Console.WriteLine("Invalid choice"); 
            }



        }
    }


}