select * from Customer

select * from Customer where City='Bangalore' and CustomerName like '%say%'

select top(10) CustomerName,City from Customer

Select top 15 percent CustomerName from Customer

select Distinct City from Customer

select top 20 CustomerName,City from Customer order by City DESC--desc for descending order

select CustomerName,VisitTime from Customer order by 2 desc,1 --sort by ordinal positions of the selected column,However it is not good practice.

select CustomerID,CustomerName from Customer order by CustomerID Offset 100 rows fetch next 30 rows only;--offset specifies the rows to skip before starting to return the rows from the query

select CustomerName,VisitTime from Customer where VisitTime between '2019-04-01' and Getdate()

select CustomerName,VisitTime from Customer where year(VisitTime)=2021--get the year part of the datetime

select CustomerName,VisitTime from Customer where datepart(year,VisitTime)=2021--old syntax

select Day(VisitTime) as Day,month(VisitTime) as month,Year(VisitTime) as year from Customer order by year;

select Day(VisitTime) as Day,month(VisitTime) as month,Year(VisitTime) as year from Customer where year(VisitTime) in (2000,2005,2010) order by year;

------------------------------------------------------------------------------------------------------------
create table candidate
(
id int primary key identity,
fullname varchar(50) not null
)
create table employee
(
id int primary key identity,
fullname varchar(50) not null
)
Insert into candidate values('Phaniraj'),('Gopal'),('Rajesh'), ('Suresh'),('Kumar'),('Rajneesh'), ('Sharma'), ('Naresh'),('Venkatesh'), ('Sai'), ('Ramnath'),('Vinod'),('Banu Prakash'),('Murali'), ('Janardhan'),('Srinivas'),('Pavani'),('Pratyusha'),('Sania'),('Kulkarni'), ('Nagesh')
Select * from candidate



Insert into employee values('Phaniraj'),('Hanumanth'),('Sudhindra'), ('Raghu'),('Kumar'),('Rajneesh'), ('Sharma'), ('Naresh'),('Venkatesh'), ('Sai'), ('Ramnath'),('Vinod'),('Banu Prakash'),('Murali'), ('Janardhan'),('Micheal'),('Fayaz'),('Syamala'),('Sania'),('Kulkarni'), ('Zaheer')
insert into employee(fullname) values ('joe'),('jah'),('sh'),('sjn')
----------------------------------Inner join------------------------------------------------------------------------
select c.id c_id,c.fullname c_name,e.id e_id,e.fullname employee_name from candidate c inner join employee e on e.fullname=c.fullname
-----------------------------------left join----------------------------------------------------------------------------
select c.id c_id,c.fullname c_name,e.id e_id,e.fullname employee_name from candidate c left join employee e on e.fullname=c.fullname 
--to get only the data of the left table but not from the right table
select c.id c_id,c.fullname c_name,e.id e_id,e.fullname employee_name from candidate c left join employee e on e.fullname=c.fullname where e.id is null
-------------------------------the reverse of left join ids right join-------------------------------------------
select c.id c_id,c.fullname c_name,e.id e_id,e.fullname employee_name from candidate c right join employee e on e.fullname=c.fullname 
---------------------------to get data from both the tables ,we use full join---------------------------------------------------
select c.id c_id,c.fullname c_name,e.id e_id,e.fullname employee_name from candidate c full join employee e on e.fullname=c.fullname

select c.id c_id,c.fullname c_name,e.id e_id,e.fullname employee_name from candidate c join employee e on e.fullname=c.fullname where c.id is null or e.id is null

---------------------------------------------------having clause-----------------------------------------------
------------Group the content and select based on an aggregate value ,then having would be needed.
--Having clause will work in conjunction with the group by clause to filter thr groups on a srecified list of conditions.
select City,count(City) as NoOfPeople from Customer group by City having Count(City)<=100

---------------------------------------stored procedures------------------------------------------------

create procedure InsertCustomer
@id int,@name varchar(50),@date datetime,@mobile bigint,@city varchar(50)
as
insert into Customer values(@id,@name,@date,@mobile,@city)

exec InsertCustomer @id=550,@name='sri',@date='09/27/2021',@mobile=1234567892,@city='Bangalore'
select * from Customer where CustomerID=550
-----------------------------------declaring variable and using it in Stored Proc
declare @vartime Datetime =getdate()

alter table Customer
add constraint visitDate
default getDate() for visitTime

alter procedure InsertCustomer
@id int,@name varchar(50),@mobile bigint,@city varchar(50)
as 
insert into Customer(CustomerID,CustomerName,ContactNo,City) values(@id,@name,@mobile,@city)

exec InsertCustomer @id=554,@name='anu',@mobile=1234567892,@city='Bangalore'
select * from Customer where CustomerID=554

----------------------Functions in SQL Server--------------------------------------

select count(distinct City) as totalcities from Customer

Create table Student
(
Id int primary key identity,
Name varchar(20) not null,
Marks int not null,
age int not null
)

Insert into Student values('Sunder', 90, 20)
Insert into Student values('Ramesh', 60, 19)
Insert into Student values('Pratik', 30, 19)
Insert into Student values('Ramraj', 70, 20)
Insert into Student values('Suman', 50, 20)
Insert into Student values('Nagesh', 45, 18)
Insert into Student values('Kamal', 56, 21)

select avg(marks) as Avg_marks from Student
select sum(marks) as sum_marks from Student
select max(marks) as max_marks from Student
select min(marks) as min_marks from Student
select count(distinct age) as distinct_age from Student
 select upper(name) as Student_name from Student
 select CONCAT(upper(name),'  is ',age,' years old.') from Student
 select FORMAT(ContactNo,'#####-#####') as Phone_number from Customer

 create function GetPhone(@CustomerID int)
 returns bigint
 begin
 declare @phone bigint
 set @phone=(select ContactNo from Customer where CustomerID=@CustomerID)
 return @phone
 end

 select CustomerName,dbo.GetPhone(CustomerID) as PhoneNumber from Customer
 
 create function CreateDate(@dt int,@mon int,@yr int)
 returns date
 begin
 declare @date date
 set @date=(select convert(date,concat(@mon,'/',@dt,'/',@yr)))
 return @date
 end

 select dbo.CreateDate(25,12,20)