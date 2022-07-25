using System;
using System.Collections.Generic;
using System.Data;
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
        public void UpdateSalary()
        {
            //Open Connection
            sqlConnection.Open();
            string query = "update employee_payroll set basicPay=3670000 where name= 'suresh'";
            //Pass query to TSql
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();
            if (result != 0)
            {
                Console.WriteLine("Updated!");
            }
            else
            {
                Console.WriteLine("Not Updated!");
            }
            //Close Connection
            sqlConnection.Close();
            GetDataFromSql();
        }

        public int UpdateSalary(EmployeeDataManager employeeDataManager)
        {
            int result = 0;
            try
            {
                using (sqlConnection)
                {
                    //Give stored Procedure
                    SqlCommand sqlCommand = new SqlCommand("dbo.spUpdateSalary", this.sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@salary", employeeDataManager.salary);
                    sqlCommand.Parameters.AddWithValue("@EmpName", employeeDataManager.name);
                    sqlCommand.Parameters.AddWithValue("@EmpId", employeeDataManager.id);
                    //Open Connection
                    sqlConnection.Open();
                    //Return Number of Rows affected
                    result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public int RetrieveQuery(EmployeeDataManager employeeDataManager)
        {

            int result = 0;
            try
            {
                using (sqlConnection)
                {
                    //Give stored Procedure
                    SqlCommand sqlCommand = new SqlCommand("dbo.spRetrieveDataUsingName", this.sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", employeeDataManager.name);
                    //Open Connection
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    //Check if swlDataReader has Rows
                    if (sqlDataReader.HasRows)
                    {
                        //Read each row
                        while (sqlDataReader.Read())
                        {
                            result++;
                            //Read data SqlDataReader and store 
                            employeeDataManager.id = sqlDataReader.GetInt32(0);
                            employeeDataManager.name = sqlDataReader["name"].ToString();
                            employeeDataManager.salary = Convert.ToDouble(sqlDataReader["BasicPay"]);
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
                            Console.WriteLine("\nEmployee ID: {0} \t Employee Name: {1} \nBasic Pay: {2} \t Deduction: {3} \t Income Tax: {4} \t Taxable Pay: {5} \t NetPay: {6} \nGender: {7} \t PhoneNumber: {8} \t Department: {9} \t Address: {10}", employeeDataManager.id, employeeDataManager.name, employeeDataManager.salary, employeeDataManager.Deduction, employeeDataManager.IncomeTax, employeeDataManager.TaxablePay, employeeDataManager.NetPay, employeeDataManager.Gender, employeeDataManager.EmployeePhoneNumber, employeeDataManager.EmployeeDepartment, employeeDataManager.Address);
                        }
                        //Close sqlDataReader Connection
                        sqlDataReader.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlConnection.Close();
            return result;
        }

        //Uc-5 employees in a given range from start date to current
        public string DataBasedOnDateRange()
        {
            string nameList = "";
            try
            {
                using (sqlConnection)
                {
                    //query execution
                    string query = @"select * from employee_payroll where startDate BETWEEN Cast('2019-11-12' as Date) and GetDate();";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    //open sql connection
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            DisplayEmployeeDetails(sqlDataReader);
                            nameList += sqlDataReader["EmployeeName"].ToString() + " ";
                        }
                    }
                    //close reader
                    sqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                sqlConnection.Close();
            }
            //returns the count of employee in the list between the given range
            return nameList;

        }
        public void DisplayEmployeeDetails(SqlDataReader sqlDataReader)
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
            employeeDataManager.startDate = Convert.ToDateTime(sqlDataReader["StartDate"]);
            //Display 
            Console.WriteLine("\nEmployee ID: {0} \t Employee Name: {1} \nBasic Pay: {2} \t Deduction: {3} \t Income Tax: {4} \t Taxable Pay: {5} \t NetPay: {6} \nGender: {7} \t PhoneNumber: {8} \t Department: {9} \t Address: {10} \t Start Date: {11}", employeeDataManager.id, employeeDataManager.name, employeeDataManager.salary, employeeDataManager.Deduction, employeeDataManager.IncomeTax, employeeDataManager.TaxablePay, employeeDataManager.NetPay, employeeDataManager.Gender, employeeDataManager.EmployeePhoneNumber, employeeDataManager.EmployeeDepartment, employeeDataManager.Address, employeeDataManager.startDate);

        }
    }
}
