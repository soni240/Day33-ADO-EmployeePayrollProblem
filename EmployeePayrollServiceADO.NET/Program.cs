// See https://aka.ms/new-console-template for more information
using EmployeePayrollServiceADO.NET;
using System;

namespace EmployeePayrollServiceADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Welcome TO Employee PayRoll Services Using ADO.NET----------");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.GetDataFromSql();

        }
    }
}