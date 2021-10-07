use fidelitytrainingdb;
Create table Customer
(
CustomerID int primary key,
CustomerName varchar(50) not null,
VisitTime dateTime,
ContactNo BIGint Not null
)
sp_tables
sp_columns @table_name='Customer'

alter table Customer
Add City varchar(50) Not null check(city in('Bangalore','Mangalore','Mysore','Hassan','Dharwad'))

alter table Customer
drop constraint CK__Customer__City__38996AB5

alter table Customer
drop column City

alter table Customer
alter column City varchar(20) not null
--u can alter only the data type,not null and size of the data.

------------------------------------------Data Manuplating Language---------------------
-------------------------INSERT Command------------------------------------
insert into Customer values(1,'Sri','12-04-2020',9550065359,'NRT')
insert into Customer values(2,'Prathyusha','12-07-2020',9550065359,'NRT')
insert into Customer values(3,'Prashanth','12-04-2020',9550065359,'NRT')
insert into Customer values(4,'Anusha','1-09-2020',9550065359,'NRT')
insert into Customer values(5,'Aparna','11-04-2020',9550065359,'NRT')
insert into Customer values(6,'Sowmya','12-04-2020',9550065359,'NRT')
insert into Customer values(7,'Bhargavi','12-06-2020',9550065359,'GNT')
insert into Customer values(8,'Pavani','7-04-2020',9550065359,'NRT')
insert into Customer values(9,'Meghana','6-05-2020',9550065359,'GNT')
insert into Customer values(10,'Ramya','12-04-2020',9550065359,'NRT')
insert into Customer values(11,'Sri Lakshmi','12-04-2020',9550065359,'NRT')
insert into Customer values(12,'Kalyani','12-04-2020',9550065359,'GNT')
insert into Customer values(13,'Sujatha','12-04-2020',9550065359,'NRT')
insert into Customer values(14,'Padma','12-04-2020',9550065359,'GNT')
insert into Customer values(15,'Raju','12-04-2020',9550065359,'NRT')
------------------------------------------TO DISPLAY DATA OF THE TABLE-------------------------------
select * from Customer
------------------------------------------DELETE Command-----------------------------------------------
Delete from Customer where CustomerID=1 and City='Bangalore'--0 rows effectd means no data deleted from table 
delete from Customer where CustomerID=1

--------------------------------------------------UPDATE Command-------------------------------------

update Customer set City='GNT' where CustomerID=1

update Customer set VisitTime=GETDATE();--if you don't sercify where clause all rows will effect

Delete Customer from Customer where CustomerID>1

Delete Customer from Customer where CustomerID=1
 
