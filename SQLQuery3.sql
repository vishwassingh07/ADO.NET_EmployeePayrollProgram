Create Procedure spDeleteEmployee
@Name nvarchar(200),
@Id int
As
Delete From Employee_Payroll_Table Where Id = @Id and Name = @Name;