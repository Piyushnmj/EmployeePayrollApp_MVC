create database EmployeePayrollMVC

create table PayrollDetails
(
	Id int Identity(1,1) Not Null Primary Key,
	Name varchar(max) Not Null,
	Profile_Image varchar(max) Not Null,
	Gender varchar(max) Not Null,
	Department varchar(max) Not Null,
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