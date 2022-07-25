using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServiceADO.NET
{
    public class EmployeeDataManager
    {
        public int id { get; set; }
        public string name { get; set; }
        public double salary { get; set; }
        public DateTime startDate { get; set; }
        public char Gender { get; set; }
        public Int64 EmployeePhoneNumber { get; set; }
        public string EmployeeDepartment { get; set; }
        public string Address { get; set; }
        public double Deduction { get; set; }
        public double IncomeTax { get; set; }
        public double TaxablePay { get; set; }
        public double NetPay { get; set; }
    }
}
