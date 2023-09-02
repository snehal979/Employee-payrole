Create Database EmployeDB
USE EmployeDB

Create Table tableEmployee(
Id int identity(1,1) not null,
Name varchar(50) not null,
ImageLink varchar(255),
Gender varchar(10) not null,
Department varchar(20)  not null, 
Salary bigint not null,
StartDate Date not null,
 Note varchar(255)
);

--Create Store Procedure
alter Procedure spGetAllEmployee
as
begin
begin try
Select * from tableEmployee;
end try
begin catch
select ERROR_MESSAGE() as ErrorMessage;
end catch
end

--insert Store procedure
Alter Procedure spAddEmployee(@name varchar(50),@imagelink varchar(255),@gender varchar(10),@department varchar(20),@salary bigint,@startDate date,@note varchar(255))
as
begin
begin try
begin
Insert into tableEmployee(Name,ImageLink,Gender,Department,Salary,StartDate,Note ) values(@name,@imagelink,@gender,@department,@salary,@startDate,@note);
Print 'Employee added successfully' ;
end
end try
begin catch
begin
 Print 'Employee added not successfully' ;
 select ERROR_MESSAGE() as ErrorMessage;
 end
end catch
end


--Update store procedure
Alter Procedure spUpdateEmployee(@id int ,@name varchar(50),@imagelink varchar(255),@gender varchar(10),@department varchar(20),@salary bigint,@startDate date,@note varchar(255))
as
begin
begin try
 begin transaction;
declare @Checked int
set @Checked =( select count(*) from tableEmployee where Id=@id);
if(@Checked = 1)
begin
Update tableEmployee set Name = @name,ImageLink=@imagelink,Gender=@gender, Department=@department,Salary=@salary,StartDate = @startDate,Note=@note where Id=@id;
commit transaction;
Print 'Employee Update successfully' 
end
else
Print 'Not Found Employee' ;
end try
begin Catch
begin
if @@TRANCOUNT >0
 rollback transaction;
 select ERROR_MESSAGE() as ErrorMessage;
end
end catch
end

--Delete store procedure
Alter Procedure spDeleteEmployee(@id int)
as
begin
begin try
 begin transaction;
declare @Checked int
set @Checked =( select count(*) from tableEmployee where Id=@id);
if(@Checked = 1)
begin
Delete from tableEmployee where Id = @id
Print 'Employee delete successfully'
  commit transaction;
end
else
Print 'Not Found Employee' ;
end try
begin Catch
begin
 if @@TRANCOUNT >0
 rollback transaction;
 select ERROR_MESSAGE() as ErrorMessage;
end
end catch
end

