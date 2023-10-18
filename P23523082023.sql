Create Database P23523082023

Use P23523082023

Create Table Groups
(
	Id int identity Primary Key,
	Name nvarchar(10) Not NUll Unique
)

Insert Into Groups
Values
('P234'),
('P235'),
('P229'),
('P133')

Select * From Groups

Create Table Students
(
	Id int identity Primary Key,
	Name nvarchar(100),
	SurName nvarchar(100),
	Age TinyInt,
	Email nvarchar(100) Unique Not Null,
	GroupId int Foreign Key References Groups(Id)
)

Alter table Students Alter Column Grade decimal(5,2) Check(Grade Between 0 And 100)
Insert Into Students(Name,SurName,Age,Email,GroupId)
Values
('Hamid','Mammadov',33,'hamidvm1@gmail.com',null),
('Ehmed','Mehdiyev',23,'ahmad1@mail.ru',1),
('Emrah','Nesirov',23,'amrah1@hotmail.com',1),
('Nesrin','Asadli',16,'nasrin1@inbox.ru',1),
('Murad','Aliyev',20,'murad1@gmail.com',2),
('Nicat','Misirxanli',27,'nica1t@mail.ru',2),
('Ayxan','Quliyev',20,'aykha1n@box.az',2),
('Necef','necefli',16,'naja1f@yahoo.com',2),
('Elbrus','Zeynalov',21,'elbr1us@list.ru',2),
('Yunis','Huseynov',23,'yuni1s@gmail.com',2),
('Medine','Ceferova',24,'madin1a@code.edu.az',2),
('Mahmud','Aliyev',21,'mahmu1d@bk.ru',3),
('Merahim','Imamaliyev',23,'mar1ahim@cod.ru',3)

Create Table Certificates
(
	Id int identity primary key,
	Name nvarchar(100),
	Min int,
	Max int
)

Insert Into Certificates(name, Min,Max)
Values
('Standar',65,84),
('Honour',85,94),
('High Honour',95,100)


Create Table Teachers
(
	Id int identity primary key,
	FullName nvarchar(255)
)

Create table TeacherGroups
(
	Id int identity primary key,
	TeacherId int Foreign Key References Teachers(Id),
	GroupId int Foreign Key References Groups(Id),
)

--Inner Join (Join)
Select 
	s.Name, 
	SurName, 
	Age,
	Email,
	g.Name 
From Students s
Inner Join Groups g 
On s.GroupId = g.Id

Select 
	s.Name, 
	SurName, 
	Age,
	Email,
	g.Name 
From Students s
Join Groups g 
On s.GroupId = g.Id

--Right Otter Join (Right Join)
Select  s.Name,  SurName, Age,Email, g.Name From Students s Right Outer Join Groups g On s.GroupId = g.Id
Select  s.Name,  SurName, Age,Email, g.Name From Students s Right Join Groups g On s.GroupId = g.Id

--Left Outer Join (Left Join)
Select  s.Name,  SurName, Age,Email, g.Name From Students s Left Outer Join Groups g On s.GroupId = g.Id
Select  s.Name,  SurName, Age,Email, g.Name From Students s Left Join Groups g On s.GroupId = g.Id

--Full Outer Join (Full Join)
Select  s.Name,  SurName, Age,Email, g.Name From Students s Full Outer Join Groups g On s.GroupId = g.Id
Select  s.Name,  SurName, IIF(Age >= 33, 99,Age),Email, ISNULL(g.Name,'-') From Students s Full Join Groups g On s.GroupId = g.Id

Select s.Name,s.SurName,s.Age,s.Email,g.Name,t.FullName From Students s
join Groups g
on s.GroupId = g.Id
join TeacherGroups tg
on tg.GroupId = g.Id
join Teachers t
on t.Id = tg.TeacherId

--Non Equal Join
Select s.Name,s.SurName,c.Name From Students s
join Certificates c
On s.Grade Between c.Min And c.Max

Create table Categories
(
	Id int identity primary key,
	Name nvarchar(50),
	ParentId int Foreign Key References Categories(Id)
)

--Self Join
Select child.Name 'child',parent.Name 'parent'  From Categories child
join Categories parent
on child.ParentId = parent.Id

Create table Products
(
	Id int identity primary key,
	Name nvarchar(50)
)

Create table Colors
(
	Id int identity primary key,
	Name nvarchar(50)
)

--Cross Join
Select Products.Name, Colors.Name From Products
cross Join Colors


Select Count(distinct Name) From Students

Select * From Students
Order By  Age Asc

Select SUBSTRING(Email,CHARINDEX('@',Email) +1,LEN(Email)) From Students