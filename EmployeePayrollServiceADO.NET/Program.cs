using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServiceADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Services Using ADO.NET Problem");
            EmployeeRepository repository = new EmployeeRepository();//Creating a object of EmployeeRepository class.
            //repository.DataBaseConnection(); // UC1 Ensuring the database connection using the sql connection string
            repository.GetAllEmployeeData(); // UC2
            AddRecordInput(); // UC2 add Record for database
        }
        public static void AddRecordInput() //UC2 Adding record inputs on the table
        {
            try
            {
                EmployeeRepository repository = new EmployeeRepository();//Creating a object of EmployeeRepository class.

                EmployeeModel model = new EmployeeModel();// Adding Employee To Database
                DateTime now = DateTime.Now;
                model.EmployeeId = 10;
                model.EmployeeName = "Ekta";
                model.PhoneNumber = "1237896541";
                model.Address = "Lalolo";
                model.Department = "Developer";
                model.Gender = "F";
                model.BasicPay = 45000;
                model.Deductions = 4000;
                model.TaxablePay = 1200;
                model.Tax = 1000;
                model.NetPay = 1500;
                model.StartDate = now;
                model.City = "Chennai";
                model.Country = "IN";

                repository.AddEmployee(model);  //call AddEmployee method and pass model values       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}



