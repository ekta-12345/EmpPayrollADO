using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServiceADO.NET
{
    public class EmployeeRepository
    { // UC1: Ability to create a payroll service database and have C# program connect to database.

        public static string connectionString = @"Data Source=ABHISHEK\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Specifying the connection string from the sql server connection.

        SqlConnection connection = new SqlConnection(connectionString); // Establishing the connection using the Sqlconnection.  

        public bool DataBaseConnection()
        {
            try
            {
                DateTime now = DateTime.Now; //create object DateTime class //DateTime.Now class access system date and time 
                connection.Open(); // open connection
                using (connection)  //using SqlConnection
                {
                    Console.WriteLine($"Connection is created Successful {now}"); //print msg
                }
                connection.Close(); //close connection
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        // UC2: Ability for Employee Payroll Service to retrieve the Employee Payroll from the Database.

        public void GetAllEmployeeData()
        {

            EmployeeModel employeemodel = new EmployeeModel(); //Creating Employee model class object
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.payroll_service"; // Query to get all the data from table./*TableName:-dbo.payroll_service*/

                    this.connection.Open(); //open connection

                    SqlCommand command = new SqlCommand(query, connection); //accept query and connection

                    SqlDataReader reader = command.ExecuteReader(); // Execute sqlDataReader to fetching all records

                    if (reader.HasRows)     // Checking datareader has rows or not.               
                    {
                        // Console.WriteLine("EmployeeId, EmployeeName, PhoneNumber, Address, Department, Gender, BasicPay, Deductions, TaxablePay, TaxablePay, Tax, NetPay, StartDate, City, Country");                                            
                        while (reader.Read()) //using while loop for read multiple rows.
                        {
                            employeemodel.EmployeeId = reader.GetInt32(0);
                            employeemodel.EmployeeName = reader.GetString(1);
                            employeemodel.PhoneNumber = reader.GetString(2);
                            employeemodel.Address = reader.GetString(3);
                            employeemodel.Department = reader.GetString(4);
                            employeemodel.Gender = reader.GetString(5);
                            employeemodel.BasicPay = reader.GetDouble(6);
                            employeemodel.Deductions = reader.GetDouble(7);
                            employeemodel.TaxablePay = reader.GetDouble(8);
                            employeemodel.Tax = reader.GetDouble(9);
                            employeemodel.NetPay = reader.GetDouble(10);
                            employeemodel.StartDate = reader.GetDateTime(11);
                            employeemodel.City = reader.GetString(12);
                            employeemodel.Country = reader.GetString(13);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", employeemodel.EmployeeId, employeemodel.EmployeeName, employeemodel.PhoneNumber,
                            employeemodel.Address, employeemodel.Department, employeemodel.Gender, employeemodel.BasicPay, employeemodel.Deductions, employeemodel.TaxablePay, employeemodel.Tax, employeemodel.NetPay, employeemodel.StartDate, employeemodel.City, employeemodel.Country);

                        }
                    }
                    else
                    {
                        Console.WriteLine(" Record Not found on Table "); //print 
                    }
                    reader.Close(); //close
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close(); //Always ensuring the closing of the connection
            }
        }
        public void AddEmployee(EmployeeModel model) //insert record to the table
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SqlProcedureName", this.connection);   //Creating a stored Procedure for adding employees into database

                    command.CommandType = CommandType.StoredProcedure; //Command type is a class to set as stored procedure
                                                                       // Adding values from employeemodel to stored procedure 

                    command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Record Successfully Inserted On Table");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
        // UC3:- Ability to update the salary i.e. the base pay for Employee  Terisa to 3000000.00 and sync it with Database.
                         
        public bool UpdateBasicPay(string EmployeeName, double BasicPay)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = @"update dbo.payroll_service set BasicPay=@inputBasicPay where EmployeeName=@inputEmployeeName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@inputBasicPay", BasicPay); //parameters transact SQl stament or store procedure
                    command.Parameters.AddWithValue("@inputEmployeeName", EmployeeName);
                    var result = command.ExecuteNonQuery(); //ExecuteNonQuery and store result
                    Console.WriteLine("Record Update Successfully");
                    connection.Close();
                    GetAllEmployeeData(); // call method and show record
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        //UC4: Ability to update the salary i.e. the base pay for Employee Terisa to 3000000.00 and sync it with Database using JDBC Prepared Statement.


        public double UpdatedSalaryFromDatabase(string EmployeeName)
        {

            string cconnectionString = @"Data Source=ABHISHEK\SQLEXPRESS;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Specifying the connection string from the sql server connection.

            SqlConnection connection = new SqlConnection(cconnectionString);
            try
            {
                using (connection)
                {
                    string query = @"select BasicPay from dbo.payroll_service where EmployeeName=@inputEmployeeName";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@inputEmployeeName", EmployeeName);
                    return (double)command.ExecuteScalar();//Using ExecuteScalar for retrieve a single value from Database after the execution of the SQL Statement. 
                }                                               //The ExecuteScalar() executes SQL statements as well as Stored Procedure and returned a scalar value on first column of first row in the returned Result Set.
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}