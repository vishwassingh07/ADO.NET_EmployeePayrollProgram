﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_EmployeePayrollProgram
{
    public class EmployeePayroll
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public double BasicPay { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }
        public long Phone { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public double Deductions{ get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }




    }
}
