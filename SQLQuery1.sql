Create Procedure spAddEmployee
@Name nvarchar(200),
@Basic_Pay float,
@StartDate DateTime,
@Gender char,
@Phone bigint,
@Department nvarchar,
@Address nvarchar,
@Deductions float,
@Taxable_Pay float,
@Income_Tax float,
@Net_Pay float
As
Insert Into Employee_Payroll_Table(Name,Basic_Pay,StartDate,Gender,Phone,Department,Address,Deductions,Taxable_Pay,Income_Tax,Net_Pay)
Values(@Name,@Basic_Pay,@StartDate,@Gender,@Phone,@Department,@Address,@Deductions, @Taxable_Pay, @Income_Tax,@Net_Pay);

