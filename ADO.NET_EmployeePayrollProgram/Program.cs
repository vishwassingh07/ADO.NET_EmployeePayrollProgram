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
            bool end = true;
            Console.WriteLine("1. Get All The Employees\n2. Add Employee\n3. Update Employee Details\n4. " +
                "Delete Employee \n5.End The Program");
            while (end)
            {
                Console.WriteLine("Choose an option to execute : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        repository.GetAllEmployees();
                        break;
                    case 2:
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
                        break;
                    case 3:
                        model.Name = "Vishwas";
                        model.EmployeeID = 1;
                        model.BasicPay = 99999;
                        repository.UpdateEmployeeDetails(model);
                        break;
                    case 4:
                        model.Name = "Virat";
                        model.EmployeeID = 13;
                        repository.DeleteEmployee(model);
                        break;
                    case 5:
                        end = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }

            
            

           
        }
    }
}