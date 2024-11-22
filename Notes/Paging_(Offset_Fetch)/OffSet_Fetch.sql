/* SQL Server OFFSET FETCH

The OFFSET and FETCH clauses are the options
of the ORDER BY clause. 
They allow you to limit the number of rows to be returned by a query. 

Note that you must use the OFFSET and FETCH clauses with
the ORDER BY clause. Otherwise, you will get an error.
*/

create database OFFSETFETCH

use OFFSETFETCH

Create table Roles
(
RoleId smallint primary key identity(100,2),
RoleName varchar(50)
)


insert into Roles(RoleName)
values('Dean'),('Accountant'),('Professor'),('Staff'),('Admin')

select *
from   Roles




create table Users
(UserId smallint primary key identity,
 RoleId smallint foreign key references Roles(RoleID),
 UserName varchar(50) not null,
 Email varchar(50)not null)

 
insert into Users (RoleId,UserName,Email)
values(100,'DR.Parth','Dp.54@gmail.com'),
(104,'DR.Giri','Giri.54@gmail.com'),
(102,'Shubhash Sah','Shubhas@gmail.com'), 
(106,'Ramu Dawre','Rd@gmail.com'),
(108,'Mr Saini','Dp.54@gmail.com')

update Users
set Email = 'Saini@gmail.com'
where userid = 5


select * from  Roles
select * from  Users



CREATE TABLE [GlobalCategory](
	GlobalCategoryId int IDENTITY(1,1) primary key NOT NULL,
	category_name nvarchar(100) NOT NULL,
	category_key nvarchar(100) NOT NULL

)

insert into GlobalCategory(category_name,category_key)
values('Gender','Represent Genders'),
      ('Ethnicity','Represent Ethnicity'),
	  ('Comminication','Represent Ethnicity'),
	  ('Language','Communication Way')

select * from GlobalCategory
select * from CategoryToCode



CREATE TABLE [CategoryToCode](
	CategoryToCodeId int IDENTITY(500,1) primary key NOT NULL,
	GlobalCategoryId int foreign key references GlobalCategory(GlobalCategoryId),
	CategoryValue nvarchar(100) NOT NULL
	)

insert into CategoryToCode(GlobalCategoryId,CategoryValue)
values(1,'Male'),(1,'Female'),(1,'Gay'),(1,'Tran'),(1,'Other'),
      (2,'Asian'),(2,'Hispanic'),(2,'Black'),(2,'White'),(2,'Indian'),
	  (4,'English'),(4,'Arebic'),(4,'Hindi'),(4,'Urdu'),(4,'British English')


select * from GlobalCategory
select * from CategoryToCode



CREATE TABLE Patient (
    PatientId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(70),
    LastName VARCHAR(70),
    Dob DATE,
    Gender INT,
    PatientLanguage INT,
    Ethnicity INT,
	CreatedBy smallint foreign key references Users(UserId),

CONSTRAINT FK_Patient_Gender FOREIGN KEY (Gender) REFERENCES CategoryToCode(CategoryToCodeId),
CONSTRAINT FK_Patient_Language FOREIGN KEY (PatientLanguage) REFERENCES CategoryToCode(CategoryToCodeId),
CONSTRAINT FK_Patient_Ethnicity FOREIGN KEY (Ethnicity) REFERENCES CategoryToCode(CategoryToCodeId)
);



select *
from  Patient


select * from  GlobalCategory
select * from  CategoryToCode




INSERT INTO Patient (FirstName, LastName, Dob, Gender, PatientLanguage, Ethnicity,CreatedBy)
VALUES 
    ('John', 'Doe', '1985-05-15', 500, 510, 506,1),  
    ('Jane', 'Smith', '1990-08-22', 501, 511, 507,1),  
    ('Chris', 'Johnson', '1975-12-30', 500, 512, 505,1),  
    ('Emily', 'Davis', '2000-01-05', 501, 513, 508,1),  
    ('Michael', 'Brown', '1982-03-10', 500, 514, 509,2), 


	('Silva', 'Doe', '1985-05-15', 500, 510, 506,2),  
    ('Julia', 'Smith', '1990-08-22', 501, 511, 507,2),  
    ('Martian', 'Johnson', '1975-12-30', 500, 512, 505,1), 
    ('Lily', 'Davis', '2000-01-05', 501, 513, 508,2),  
    ('Mick', 'Brown', '1982-03-10', 500, 514, 509,1),  


	('Ram', 'Doe', '1985-05-15', 500, 510, 506,2),  
    ('Jeevna', 'Smith', '1990-08-22', 501, 511, 507,1),  
    ('Ramesh', 'Johnson', '1975-12-30', 500, 512, 505,1), 
    ('Ema', 'Davis', '2000-01-05', 501, 513, 508,2),  
    ('chael', 'Brown', '1982-03-10', 500, 514, 509,2) 

-- Order by clause 
select Patient.PatientId,
	   Patient.FirstName,
	   Patient.LastName,
	   Patient.Ethnicity

from Patient
order by PatientLanguage desc


select Patient.PatientId,
	   Patient.FirstName,
	   Patient.LastName
from Patient
order by Len(Patient.FirstName)   

select Patient.PatientId,
	   Patient.FirstName,
	   Patient.LastName
from Patient
order by 1,2

select *
from   Patient
ORDER BY PatientId
OFFSET 0 ROWS  -- Skip the Provider rows
FETCH NEXT 5 ROWS ONLY;  -- Retrieve the next 5 rows

DECLARE @PageNumber INT = 0;  -- The page number you want to retrieve
DECLARE @PageSize INT = 6;    -- Number of rows per page

select *
from   Patient
Order  by PatientId
offset @PageNumber rows
fetch next @PageSize rows only

-- i want logic for paging and sorting


DECLARE @PageNumber INT = 3;  -- The page number you want to retrieve
DECLARE @PageSize INT = 3;    -- Number of rows per page


select *
from   Patient p
Order  by p.FirstName
offset (@PageNumber - 1) * @PageSize rows
fetch next @PageSize rows only

-- Checkhow this logic works
select *
from   Patient
Order  by PatientId
offset 4 rows
fetch next 2 rows only



-- Calculate the OFFSET and FETCH values based on the page number and page size
declare @PageNumber int =1;
declare @PageSize int = 32;

DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
DECLARE @Fetch INT = @PageSize;

-- Use OFFSET and FETCH in your query to retrieve the desired page
SELECT *
FROM Patient
ORDER BY PatientId -- Replace 'YourColumn' with the column you want to order by
OFFSET @Offset ROWS
FETCH NEXT @Fetch ROWS ONLY;