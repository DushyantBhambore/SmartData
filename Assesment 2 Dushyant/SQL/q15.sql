--15] Write a stored procedure that takes a PatientId as input and returns the patient's contact details.



CREATE TABLE Patient3  (
    PatientId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Patient3 (FirstName, LastName, DateOfBirth, Gender, Active) 
VALUES ('Sam', 'Will', '1985-06-15', 'Male', 1),
       ('Mark', 'Wagh', '1990-03-10', 'Female', 1),
	   ('Maria', 'Joseph', '1990-03-10', 'Female', 1),
	   ('Jane', 'Foster', '1990-03-10', 'Female', 1),
	   ('Ramesh', 'Kumar', '1990-03-10', 'Male', 0),
	   ('Will', 'Smith', '1990-03-10', 'Male', 1),
	   ('Julia', 'Robert', '1990-03-10', 'Female', 0)

CREATE TABLE PatientContact2 (
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient3(PatientId),
    ContactType NVARCHAR(50),
    ContactValue NVARCHAR(100),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO PatientContact2 (PatientId, ContactType, ContactValue) 
VALUES (1, 'phone', '9638527412'),
       (2, 'phone', '8638527412'),
       (3, 'phone', '7638527412'),
	   (4, 'phone', '6638527412'),
	   (5, 'phone', '5638527412'),
	   (6, 'phone', '4638527412')


select * from PatientContact2
/*
Title:			spContact
Creator:		Dushyant Bhaambore

Purpose: 		takes a PatientId as input and returns the patient's contact details.
Functionality:	
Created:		
Applications:	

Comments:		
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Example:		
			Exec spContact @PatientId=2


Output:		
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Return Values:	
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Modifications:

Date          Develope	r        Description
----------  --------------	--------------------------------------------------------------------------------------------------------------------
20/09/2024   Dushyant Bhambore            takes a PatientId as input and returns the patient's contact details.
*/






/*

*/

create or alter procedure spContact @PatientId int
AS
Begin
	Select PatientId =@PatientId,
			CONCAT(Patient3.FirstName ,' ',Patient3.LastName) As PatientName,
			ContactId,
			ContactType, 
			ContactValue
	from  PatientContact2 inner join Patient3
	On	  (Patient3.PatientId = PatientContact2.ContactId)			
	Where Patient3.PatientId = @PatientId
End

