using NUnit.Framework;
using EmployeePayrollServiceADO.NET;

namespace Employee_PayrollTest
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //TC1: Ability to create a payroll service database and have C# program connect to database.

        [Test]
        public void CheckConnection() //Create CheckConnection method to Check Connection

        {

            EmployeeRepository employeeRepository = new EmployeeRepository(); //create object EmployeeRepository class

            bool actual = employeeRepository.DataBaseConnection(); //call method

            bool expected = true; //expected true 

            Assert.AreEqual(expected, actual); // Check equal or not

        }
        //TC3:- Ability to update the salary i.e.the base pay for Employee Terisa to 3000000.00 and sync it with Database.

        [Test]

        public void UpdateRecord() //Create UpdateRecord method to Update value on the table

        {

            string EmployeeName = "Terisa";

            double BasicPay = 3000000;

            EmployeeRepository employeeRepository = new EmployeeRepository(); //create object EmployeeRepository class

            bool actual = employeeRepository.UpdateBasicPay(EmployeeName, BasicPay); //call method and pass parameter

            bool expected = true; //expected true 

            Assert.AreEqual(expected, actual); // Check equal or not

        }
        // TC4: Compare Employee Payroll Object with DB to pass the Test.

        [Test]
        public void GivenUpdateSalaryValue_CheckIfTheDatabaseGotUpdated()

        {

            string EmployeeName = "Terisa"; //Arrange

            double BasicPay = 60000;

            EmployeeRepository repository = new EmployeeRepository();


            repository.UpdateBasicPay(EmployeeName, BasicPay);//Act

            double expectedPay = repository.UpdatedSalaryFromDatabase(EmployeeName);


            Assert.AreEqual(BasicPay, expectedPay); //Assert

        }

    }
}


    


