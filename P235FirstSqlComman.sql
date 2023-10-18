--DDL (Data Definition Language)
--Database Yaranmasi Sorgusu
CREATE DATABASE P235FirstDB

--Yaranmis Database Isdifade Olunmasi Sorgusu
USE P235FirstDB

--Yeni Cedvel(Table) Yaratmaq Sorgusu
CREATE TABLE Students
(
	Name nvarchar(50),
	SurName nvarchar(50),
	Age TINYINT
)

--Table-in Silinmesi Sorgusu
DROP TABLE Students

--Yaradilmis Table a Yeni Column Elave Edilme Sorgusu
ALTER TABLE Students ADD [Group] nvarchar(5)

--Yaradilmis Table a Column Silme Sorgusu
ALTER Table Students Drop Column Age 

ALTER TABLE Students Add Age TinyInt

--Table in Columunun Uzerinde Deyisiklik
Alter Table Students Alter Column Age int

--DML (Data Manipulation Language)
INSERT INTO Students 
Values
(N'Həmid','Məmmədov','P235',33)

INSERT Into Students 
Values
('Mustafa',N'Məlikov','P235',16),
('Nicat',N'MisirXanlı','P235',27),
('Ayxan','Quliyev','P235',20)

Insert Into Students(Age,Name,SurName)
Values
(21,'Mahmud',N'Əliyev'),
(16,N'Nəcəf',N'Nəcəfli')

Delete Students where Age < 20 

Update Students set Age = 21, Name = 'Mahmud' where SurName = N'Əliyev' 