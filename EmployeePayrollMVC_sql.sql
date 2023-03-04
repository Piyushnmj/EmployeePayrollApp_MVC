create database EmployeePayrollMVC

create table PayrollDetails
(
	Id int Identity(1,1) Not Null Primary Key,
	Name varchar(50) Not Null,
	Profile_Image varchar(255) Not Null,
	Gender varchar(10) Not Null,
	Department varchar(255) Not Null,
	Salary money Not Null,
	StartDate datetime Not Null,
	Notes varchar(max) Not Null
)

--drop table PayrollDetails

create or alter procedure AddEmployee
(
	@Name varchar(max),
	@Profile_Image varchar(max),
	@Gender varchar(max),
	@Department varchar(max),
	@Salary money,
	@StartDate datetime,
	@Notes varchar(max)
)
as
begin
	insert into PayrollDetails values(@Name, @Profile_Image, @Gender, @Department, @Salary, @StartDate, @Notes)
end

create or alter procedure GetAllEmployee
as      
Begin      
    select *      
    from PayrollDetails      
End

create or alter procedure UpdateEmployeeDetails
(  
	@Id int,
	@Name varchar(max),
	@Profile_Image varchar(max),
	@Gender varchar(max),
	@Department varchar(max),
	@Salary money,
	@StartDate datetime,
	@Notes varchar(max)       
)          
as          
begin          
   Update PayrollDetails           
   set Name=@Name, Profile_Image=@Profile_Image, Gender=@Gender, Department=@Department, Salary=@Salary, StartDate=@StartDate, Notes=@Notes
   where Id=@Id
End

create or alter procedure DeleteEmployeeDetails         
(          
   @Id int          
)          
as           
begin          
   Delete from PayrollDetails where Id=@Id          
End

create or alter procedure GetEmployeeById
(
	@Id int
)
as      
Begin      
    select *      
    from PayrollDetails where Id=@Id
End
