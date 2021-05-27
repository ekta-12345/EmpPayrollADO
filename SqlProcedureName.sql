create procedure dbo.SqlProcedureName
	@EmployeeId int ,
	@EmployeeName varchar(150),
	@PhoneNumber varchar(10),
	@Address varchar(20),
	@Department varchar(20),
	@Gender char(1) ,
	@BasicPay float,
	@Deductions float ,
	@TaxablePay float  ,
	@Tax float  ,
	@NetPay float ,
	@StartDate DATETIME ,
	@City varchar(10) ,
	@Country varchar(10) 
	as begin
	Insert into payroll_service values ( @EmployeeId ,@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,@Deductions,@TaxablePay,@Tax,@NetPay,@StartDate,@City,@Country)
	End

	drop procedure SqlProcedureName

