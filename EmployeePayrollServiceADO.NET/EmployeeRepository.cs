using EmployeePayrollServiceADO.NET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServiceADO.NET
{
    public class EmployeeRepository
    {
        // for Database Connection
        public static string connection = @"Server=.;Database=PayRoll_Service;Trusted_Connection=True;";
        SqlConnection sqlConnection = new SqlConnection(connection);

        //Create Object for EmployeeData Repository
        EmployeeDataManager employeeDataManager = new EmployeeDataManager();
        public void GetDataFromSql()
        {
            //Open Connection
            sqlConnection.Open();
            string query = "select * from employee_payroll";
            //Pass query to TSql
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                //Read each row
                while (sqlDataReader.Read())
                {
                    //Read data SqlDataReader and store 
                    employeeDataManager.id = sqlDataReader.GetInt32(0);
                    employeeDataManager.name = sqlDataReader["EmployeeName"].ToString();
                    employeeDataManager.salary = Convert.ToDouble(sqlDataReader["salary"]);
                    employeeDataManager.Deduction = Convert.ToDouble(sqlDataReader["Deduction"]);
                    employeeDataManager.IncomeTax = Convert.ToDouble(sqlDataReader["IncomeTax"]);
                    employeeDataManager.TaxablePay = Convert.ToDouble(sqlDataReader["TaxablePay"]);
                    employeeDataManager.NetPay = Convert.ToDouble(sqlDataReader["NetPay"]);
                    employeeDataManager.Gender = Convert.ToChar(sqlDataReader["Gender"]);
                    employeeDataManager.EmployeePhoneNumber = Convert.ToInt64(sqlDataReader["EmployeePhoneNumber"]);
                    employeeDataManager.EmployeeDepartment = sqlDataReader["EmployeeDepartment"].ToString();
                    employeeDataManager.Address = sqlDataReader["Address"].ToString();
                    employeeDataManager.startDate = Convert.ToDateTime(sqlDataReader["startDate"]);

                    //Display Data
                    Console.WriteLine("-------------------Dispalying Table  Details----------");
                    Console.WriteLine("\nEmployee id: {0} \t  Name: {1} \nSalary: {2} \t Deduction: {3} \t Income Tax: {4} \t Taxable Pay: {5} \t NetPay: {6} \nGender: {7} \t PhoneNumber: {8} \t Department: {9} \t Address: {10}", employeeDataManager.id, employeeDataManager.name, employeeDataManager.salary, employeeDataManager.Deduction, employeeDataManager.IncomeTax, employeeDataManager.TaxablePay, employeeDataManager.NetPay, employeeDataManager.Gender, employeeDataManager.EmployeePhoneNumber, employeeDataManager.EmployeeDepartment, employeeDataManager.Address);
                }
                //Close sqlDataReader Connection
                sqlDataReader.Close();
            }
            //Close Connection
            sqlConnection.Close();
        }
    }
}
