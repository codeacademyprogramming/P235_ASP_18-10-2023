Create Database P23522082023

Use P23522082023

Create Table Groups
(
	Id int identity primary key,
	Name nvarchar(10) Check(Len(Name) >= 4) Not Null Unique,
	Count TinyInt Check(Count >= 12)
)

Alter Table Groups Drop constraint CK__Groups__Count__3B75D760
Alter Table Groups Drop constraint CK_Groups_Count
Alter Table Groups Add constraint CK_Groups_Count Check(Count>= 12)
Alter Table Groups Add Check(Count>= 12)

Alter Table Groups Alter Column Count TinyInt Not Null

Truncate table Groups

Create Table Students
(
	Id int identity primary key,
	Name nvarchar(50) Check(Len(Name) >= 3),
	SurName nvarchar(50) Check(Len(SurName) >= 3),
	Email nvarchar(100) Unique Not NUll,
	GroupId int Foreign key References Groups(Id),
	Age TinyInt Check(Age >= 18)
)

Alter Table Students Add  Default 'System' For Name
Alter Table Students Drop Constraint FK__Students__GroupI__52593CB8
Alter table Students Add Foreign key (GroupId) References Groups(Id)


Drop Table Students
Drop Table Groups

Alter Table Students Add Age TinyInt

Insert Into Groups(Id,Name,Count)
Values
(1,'P234',16),
(2,'P235',12)

Insert Into Students(Name,SurName,Email,GroupId)
Values
(N'Mustafa',N'Məlikov','mustafa@code.edu.az',1),
(N'Murad',N'Əliyev','muradrali@code.edu.az',2),
(N'Nicat',N'Misirxanlı','alinicat@code.edu.az',2),
(N'Əmrah',N'Nəsirov','amrahvn@code.edu.az',1),
(N'Əhməd',N'Mehdiyev','ahmadsm@code.edu.az',1),
(N'Ayxan',N'Quliyev','ayxanrg@code.edu.az',2),
(N'Mərahim',N'İmamƏliyev','marahimii@code.edu.az',2),
(N'Nəcəf',N'Nəcəfli','najafnn@code.edu.az',2)

Select Id,Name,Count from Groups

Select * from Groups

Select * From Students

Select SurName,Name from Students where GroupId = 2

Select SurName,Name from Students where GroupId = 2 AND Age < 20

Select SurName,Name from Students where GroupId = 2 OR Age < 20

Select (SurName+' '+Name) from Students where GroupId = 2 OR Age < 20

Select (SurName+' '+Name) 'Full Name' from Students where GroupId = 2 OR Age < 20

Select CONCAT(SurName,' ',Name) as [Full Name] from Students

Select Name as [Ad], SurName as [SoyAdy] From Students

Select Name [Ad], SurName [SoyAdy] From Students

Select Name Ad, SurName SoyAdy From Students

Select Name 'Ad', SurName 'SoyAd' From Students

Select * From Students where Name Like 'M%'

Select * From Students where Name Like '%d'

Select * From Students Where Name Like '%m%'

Select * From Students where Name Like 'M%' And Name Like '%a'

Select MIN(Age) 'Minimum Yas' From Students

Select Max(Age) 'Minimum Yas' From Students

Select AVG(Age) 'Minimum Yas' From Students

Select MIN(Name) 'Minimum Yas' From Students

Select SUM(Age) From Students

Select COUNT(*) from Students

Select CHARINDEX('n',Name) From Students

Select SUBSTRING(Name,2,999) From Students

Select LEN(Name) From Students

Select SUBSTRING(Name,2,LEN(Name)) From Students

Select * From Students where Age =(Select  MIN(Age) from Students)

Select * From Students where Exists(Select * From Groups where Id = Students.GroupId And Name like '%4%')

Select LOWER(Name)  From Students

Select Upper(Name)  From Students

Select REVERSE(Name) From Students

Select Replace(Name, 'n','#') From Students

Select * From Students where  Age <= 23 And  Age >= 18 

Select * From Students where Age Between 23 And 18

Select * From Students Where Age = 18 Or Age = 23 Or Age = 27

Select * from Students where Age In(27,23,18)