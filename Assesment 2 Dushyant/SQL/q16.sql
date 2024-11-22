-- 16] Write a stored procedure that takes PractitionerId as input and returns all the appointments they have


CREATE TABLE Practitioner2 (
    PractitionerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Specialty NVARCHAR(100),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Practitioner2 (FirstName, LastName, Specialty, Active)
VALUES ('Dr. Alice', 'Wong', 'Cardiology', 1),
       ('Dr. Bob', 'Lee', 'Neurology', 1),
	   ('Dr. Ashish', 'Gaikwad', 'Opth', 1),
	   ('Dr. Robin', 'Lee', 'Gnya', 1)


CREATE TABLE Appointment2 (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
	PractitionerId INT FOREIGN KEY REFERENCES Practitioner2(PractitionerId),
	AppointmentStatusId INT,
    AppointmentDate DATETIME,
    Reason NVARCHAR(255),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);


-- Sample Data
INSERT INTO Appointment2 (PatientId,PractitionerId, AppointmentStatusId, AppointmentDate, Reason)
VALUES (1,1, 1, '2024-09-25 10:00', 'Routine Checkup'),
       (2,1, 2, '2024-09-25 11:30', 'Follow-up'),
	   (3,2, 1, '2024-09-25 12:30', 'Routine Checkup'),
	   (4,2, 1, '2024-09-25 03:30', 'Follow-up'),
	   (5,2, 3, '2024-09-25 05:30', 'Routine Checkup')



	   /*
Title:			spappointments
Creator:		Dushyant Bhaambore

Purpose: 		 takes PractitionerId as input and returns all the appointments they have
Functionality:	
Created:		
Applications:	

Comments:		
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Example:		

           spappointments @InputId=2


Output:		
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Return Values:	
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Modifications:

Date          Develope	r        Description
----------  --------------	--------------------------------------------------------------------------------------------------------------------
20/09/2024   Dushyant Bhaambore             takes PractitionerId as input and returns all the appointments they have
*/

/*
spappointments @InputId=2

*/


create or alter Procedure spappointments @InputId int 
As
Begin
		Select AppointmentDate,
				PractitionerId,
				Reason
		from Appointment2
		Where PractitionerId=@InputId
End

	 



