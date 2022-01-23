create database BloodBank
use BloodBank
create table Employee (
 EmpId int Identity(100,1) ,
 EmpName nvarchar(20) ,
 Email  varchar(200) Primary Key Not Null,
 EmpPassword nvarchar(20) Not Null,
 EmpContactNo nvarchar(10)
);
--Insert
create procedure EmpInsert(@EmpName nvarchar(20), @Email varchar(50),@EmpPassword nvarchar(50), @EmpContactNo nvarchar(10) )
as begin
insert into Employee values(@EmpName,@Email,@EmpPassword,@EmpContactNo)
end;

create procedure EmpLogin(@Email varchar(200),@EmpPassword nvarchar(20))
as begin
select * from Employee where Email=@Email AND EmpPassword=@EmpPassword
end
--Display all the emps
create procedure EmpDisplayAll
as begin
select * from  Employee
end;

update Employee set Email='ishumandliya1611@gmail.com' where EmpId=101


exec EmpInsert 'Pratha Yadav','prathayadavpy2@gmail.com','12345abc','9770044326'
exec EmpInsert 'Ishika Mandliya','shumandliya1611@gmail.com','abc12345','9753697768'
exec EmpDisplayAll
