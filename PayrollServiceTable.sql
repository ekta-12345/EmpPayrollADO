create table payroll_service (EmployeeId int ,EmployeeName varchar(50),PhoneNumber varchar(50),Address varchar(50),Department varchar(50),Gender char(1),BasicPay float,Deductions float,TaxablePay float,Tax float,NetPay float,StartDate Date,City varchar(50),Country varchar(50))


select * from payroll_service;

insert into payroll_service values('1','Ekta','1234567891','Aundh','HR','F','25000','1200','1000','1230','450','2021-05-23','Pune','IN');

select * from payroll_service;