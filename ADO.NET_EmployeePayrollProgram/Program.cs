using System;
namespace ADO.NET_EmployeePayrollProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Employee Payroll Program With ADO.NET ");
            EmployeeRepository repository = new EmployeeRepository();
            EmployeePayroll model = new EmployeePayroll();
            model.Name = "Virat";
            model.BasicPay = 100000;
            model.StartDate = DateTime.Now;
            model.Gender = 'M';
            model.Phone = 4563217896;
            model.Department = "Sports";
            model.Address = "Mumbai";
            model.Deductions = 10000;
            model.TaxablePay = 80000;
            model.IncomeTax = 20000;
            model.NetPay = 70000;
            repository.AddEmployee(model);

            repository.GetAllEmployees();
        }
    }
}