using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_EmployeePayrollProgram
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=EmployeePayrollService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False ";
        SqlConnection connection = null;
        /// <summary>
        /// UC1 - Getting All  Employees
        /// </summary>
        public void GetAllEmployees()
        {
            try
            {
                using(connection = new SqlConnection(connectionString))
                {
                    EmployeePayroll model = new EmployeePayroll();
                    string query = "Select * From Employee_Payroll_Table";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open(); 
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeID = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                            model.Name = Convert.ToString(reader["Name"] == DBNull.Value ? default : reader["Name"].ToString());
                            model.BasicPay = Convert.ToDouble(reader["Basic_Pay"] == DBNull.Value ? default : reader["Basic_Pay"]);
                            model.StartDate = (DateTime)(reader["StartDate"] == DBNull.Value ? default : reader["StartDate"]);
                            model.Gender = Convert.ToChar(reader["Gender"] == DBNull.Value ? default : reader["Gender"]);
                            model.Phone = Convert.ToInt64(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                            model.Department = Convert.ToString(reader["Department"] == DBNull.Value ? default : reader["Department"]);
                            model.Address = Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
                            model.Deductions = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                            model.TaxablePay = Convert.ToDouble(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                            model.IncomeTax = Convert.ToDouble(reader["Income_Tax"] == DBNull.Value ? default : reader["Income_Tax"]);
                            model.NetPay = Convert.ToDouble(reader["Net_Pay"] == DBNull.Value ? default : reader["Net_Pay"]);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.EmployeeID, model.Name, model.BasicPay, model.StartDate,
                                model.Gender, model.Phone, model.Department, model.Address, model.Deductions, model.TaxablePay, model.IncomeTax, model.NetPay);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// UC2- Adding Employee
        /// </summary>
        /// <param name="model"></param>
        
        public void AddEmployee(EmployeePayroll model)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spAddEmployee",connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Basic_Pay", model.BasicPay);
                command.Parameters.AddWithValue("@StartDate", model.StartDate);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@Phone", model.Phone);
                command.Parameters.AddWithValue("@Department", model.Department);
                command.Parameters.AddWithValue("Address", model.Address);
                command.Parameters.AddWithValue("@Deductions", model.Deductions);
                command.Parameters.AddWithValue("@Taxable_Pay", model.TaxablePay);
                command.Parameters.AddWithValue("@Income_Tax", model.IncomeTax);
                command.Parameters.AddWithValue("@Net_Pay", model.NetPay);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    Console.WriteLine("Employee Details Successfully Added To The Table");
                }
                else
                {
                    Console.WriteLine("Employee Details Could Not Be Inserted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC3 - Update Employee Details
        /// </summary>
        /// <param name="model"></param>
        public void UpdateEmployeeDetails(EmployeePayroll model)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("dbo.spUpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Id", model.EmployeeID);
                command.Parameters.AddWithValue("Basic_Pay", model.BasicPay);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if(result != 0)
                {
                    Console.WriteLine("Employee Details Successfully Upadated");
                }
                else
                {
                    Console.WriteLine("Failed To Update Employee Details");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
    }
    
}
