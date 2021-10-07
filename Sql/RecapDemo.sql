create database Recapsql
sp_databases
use Recapsql
create table Movie
(
MovieID int primary key identity,
Title varchar(50) not null,
Duration int not null,
Rating decimal not null,
DirectorId int not null)
select * from Movie
create table Director
(
DirectorId int primary key identity,
DirectorName varchar(50) not null,
Rating decimal not null 
)
insert into Director values('Siva',9.5)
insert into Director values('Hari',9.3)
insert into Director values('Ramesh',9.2)
insert into Director values('Ravi',9.6)
insert into Director values('Manoj',9.4)
select * from Director
insert into Movie values('Nenunnanu',180,9,1)
insert into Movie values('Namo Venkatesha',185,8,1)
insert into Movie values('Chennai Express',160,8,1)
insert into Movie values('Daddy',170,9,2)
insert into Movie values('Khadgam',190,9,2)
insert into Movie values('Ranam',180,9,2)
insert into Movie values('Kushi',150,9,3)
insert into Movie values('Attarinitidaredi',140,8,3)
insert into Movie values('Malleswari',190,8,3)
insert into Movie values('Lakshyam',140,8,4)
insert into Movie values('Yemmaya chesave',200,8,4)
insert into Movie values('Radha Gopalam',160,9,4)
insert into Movie values('Naa alludu',140,8,5)
insert into Movie values('Singam',157,8,5)
insert into Movie values('Shivaji',198,7,5)
select * from Movie
alter table Movie 
add foreign key (DirectorID) references Director(DirectorID) 
CREATE PROCEDURE InsertMovie
(
	@name varchar(20),
	@duration int,
	@rating decimal,
	@directorid int,
	@movieid int output
	)
AS
    insert into Movie values(@name,@duration,@rating,@directorid)
	set @movieid=@@IDENTITY
create procedure AddDirector
(
@name varchar(50),
@rating decimal,
@dirid int output
)
as 
insert into Director values(@name,@rating)
set @dirid=@@IDENTITY

-------------------------------------------------------------------------------
create function findDirector(@Directorname varchar(20))
 returns int
 begin
   declare @id int
   set @id=(select DirectorId from Director where DirectorName=@Directorname)
   if(@id=null)
    return -1;	
   return @id;
 end
