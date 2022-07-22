------ Stored Procedure For Updating ------

Create Procedure spUpdateEmployee
@Name nvarchar(200),
@Id int,
@Basic_Pay float
AS
Update Employee_Payroll_Table Set Basic_Pay = @Basic_Pay Where Id = @Id and Name = @Name;