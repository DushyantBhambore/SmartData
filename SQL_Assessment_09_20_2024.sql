/********************************************************************************************************
                                         SQL Assessment 2                            Total Marks - 20
*********************************************************************************************************/


-- Execute below tables with the data and Solve the Questions
use PateintDb


CREATE TABLE Patient  (
    PatientId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Patient (FirstName, LastName, DateOfBirth, Gender, Active) 
VALUES ('Sam', 'Will', '1985-06-15', 'Male', 1),
       ('Mark', 'Wagh', '1990-03-10', 'Female', 1),
	   ('Maria', 'Joseph', '1990-03-10', 'Female', 1),
	   ('Jane', 'Foster', '1990-03-10', 'Female', 1),
	   ('Ramesh', 'Kumar', '1990-03-10', 'Male', 0),
	   ('Will', 'Smith', '1990-03-10', 'Male', 1),
	   ('Julia', 'Robert', '1990-03-10', 'Female', 0)



CREATE TABLE PatientContact (
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    ContactType NVARCHAR(50),
    ContactValue NVARCHAR(100),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO PatientContact (PatientId, ContactType, ContactValue) 
VALUES (1, 'phone', '9638527412'),
       (2, 'phone', '8638527412'),
       (3, 'phone', '7638527412'),
	   (4, 'phone', '6638527412'),
	   (5, 'phone', '5638527412'),
	   (6, 'phone', '4638527412')




CREATE TABLE Practitioner (
    PractitionerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Specialty NVARCHAR(100),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Practitioner (FirstName, LastName, Specialty, Active)
VALUES ('Dr. Alice', 'Wong', 'Cardiology', 1),
       ('Dr. Bob', 'Lee', 'Neurology', 1),
	   ('Dr. Ashish', 'Gaikwad', 'Opth', 1),
	   ('Dr. Robin', 'Lee', 'Gnya', 1)





CREATE TABLE AppointmentStatus (
    AppointmentStatusId INT PRIMARY KEY IDENTITY(1,1),
    Status NVARCHAR(50),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);


-- Sample Data
INSERT INTO AppointmentStatus (Status)
VALUES ('Scheduled'),
       ('Completed'),
       ('Cancelled');



CREATE TABLE Appointment (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    AppointmentStatusId INT,
    AppointmentDate DATETIME,
    Reason NVARCHAR(255),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Appointment (PatientId, AppointmentStatusId, AppointmentDate, Reason)
VALUES (1, 1, '2024-09-25 10:00', 'Routine Checkup'),
       (2, 2, '2024-09-25 11:30', 'Follow-up'),
	   (3, 1, '2024-09-25 12:30', 'Routine Checkup'),
	   (4, 1, '2024-09-25 03:30', 'Follow-up'),
	   (5, 3, '2024-09-25 05:30', 'Routine Checkup')




CREATE TABLE PatientPractitionerAppointmentMapping (
    MappingId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    PractitionerId INT FOREIGN KEY REFERENCES Practitioner(PractitionerId),
    AppointmentId INT FOREIGN KEY REFERENCES Appointment(AppointmentId),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO PatientPractitionerAppointmentMapping (PatientId, PractitionerId, AppointmentId)
VALUES (1, 1, 1),
       (2, 2, 2),
	   (5, 3, 2),
	   (6, 4, 2)




select * from Patient
select * from PatientContact
select * from Practitioner
select * from AppointmentStatus
select * from Appointment
select * from PatientPractitionerAppointmentMapping





-- 1] Retrieve all patient details along with their appointment status with only Active patients.

select
		FirstName,
		AppointmentStatusId,
		LastName,
		AppointmentId,
		DateOfBirth,
		Active
from	Patient Left join Appointment 
On		(Patient.PatientId = Appointment.AppointmentId)
Where	(Patient.Active =1) 


-- 2] Fetch the names of patients along with their practitioner for each appointment.
select  
		AppointmentStatusId,
		Appointment.AppointmentDate,
		Practitioner.PractitionerId,
	   CONCAT(Patient.FirstName ,' ',Patient.LastName) As PatientName,
		PractitionerId,
		CONCAT(Practitioner.FirstName,' ',Practitioner.LastName) As PractiitonerName,
		Appointment.Reason,
		AppointmentId,
		DateOfBirth,
		Patient.Active
from	Patient inner join Practitioner 
On		(Patient.PatientId = Practitioner.PractitionerId)
		inner join Appointment 
On		(Patient.PatientId = Appointment.AppointmentId)

-- 3] Get the contact details of all patients who have an appointment.

Select FirstName,
		LastName,
		ContactType ,
		AppointmentDate ,
		Reason
from   Patient inner join Appointment  
		On(Patient.PatientId = Appointment.AppointmentId)
		inner Join
	    PatientContact On(Patient.PatientId =PatientContact.ContactId)

-- 4] Find the appointment details for a patient named 'Sam Will'

Select	* 
from	Patient inner join Appointment
On		(Patient.PatientId = Appointment.AppointmentId)
Where	Patient.FirstName ='Sam' And Patient.LastName='Will'

-- 5]List all practitioners along with the patients they have treated.

Select  FirstName,
		LastName,
		Specialty,
		AppointmentId,
		AppointmentDate,
		Reason
from Practitioner left join Appointment 
On	(PractitionerId = AppointmentId)

-- 6] Retrieve a list of all patients and their corresponding appointment status (if any).
Select 	Patient.PatientId,
		Patient.FirstName,
		Patient.LastName ,
		Patient.DateOfBirth ,
		Patient.CreatedDatetime,
		AppointmentStatus.Status AS AppointmentStatus
From	Patient Left Join AppointmentStatus
On		(Patient.PatientId=AppointmentStatus.AppointmentStatusId)



-- 7] Fetch the patient details along with their contact information. Include patients without contact details.

Select Patient.FirstName,
		Patient.LastName ,
		Patient.Gender,
		Patient.Active,
		Patient.CreatedDatetime,
		Patient.DateOfBirth,
		PatientContact.ContactType,
		PatientContact.ContactValue

From   Patient left Join PatientContact
On		(Patient.PatientId = PatientContact.ContactId)

-- 8] List all patients and their practitioner for each appointment, showing patients even if they don't have a practitioner assigned.

Select Patient.FirstName,
		Patient.LastName,
		Patient.Gender,
		Patient.DateOfBirth,
		Patient.Active,
		Practitioner.FirstName,
		Practitioner.LastName,
		Practitioner.Specialty,
		Appointment.CreatedDatetime,
		Appointment.AppointmentStatusId,
		Appointment.AppointmentDate,
		Appointment.Reason
From  Patient left Join Practitioner 
		On (Patient.PatientId = Practitioner.PractitionerId)
		Left Join Appointment
		On (Patient.PatientId = Appointment.AppointmentId)



--9] Get all practitioners and their appointments, including those practitioners without any appointments.

Select Practitioner.PractitionerId,
		Practitioner.FirstName,
		Practitioner.LastName,
		Practitioner.Active,
		Practitioner.CreatedDatetime,
		Practitioner.Specialty,
		Appointment.PatientId,
		Appointment.AppointmentStatusId,
		AppointmentStatus.Status
From	Practitioner Left Join Appointment
On		(Practitioner.PractitionerId = Appointment.AppointmentId)
		Left Join AppointmentStatus 
On		(Practitioner.PractitionerId = AppointmentStatus.AppointmentStatusId)


-- 10] Give me list off patients with contact details and having AppointmentReason = 'Follow-up'

Select *
From   Patient inner join PatientContact
On		(Patient.PatientId = PatientContact.ContactId)
		inner join Appointment
on		Patient.PatientId = Appointment.AppointmentId
Where  Appointment.Reason ='Follow-up'



-- 11] Count how many appointments each patient has.
select  COUNT(Appointment.AppointmentStatusId) AS Appoinment,
		CONCAT(Patient.FirstName ,' ',Patient.LastName) As PatientName
from	Patient inner  join Appointment 
on		(Patient.PatientId = Appointment.AppointmentId)
Group By	
		Appointment.AppointmentStatusId,
		Patient.FirstName,
		Patient.LastName


-- 12] Retrieve the number of patients for each gender.

Select  Patient.Gender ,
		Count(Patient.Gender) As Number 
From   Patient
Group By 
		Gender


-- 13] Give PatientName,PractitionerName,with their appointmentStatus.

Select Patient.PatientId,
		CONCAT(Patient.FirstName ,' ',Patient.LastName) As PatientName,
		PractitionerId,
		CONCAT(Practitioner.FirstName,' ',Practitioner.LastName) As PractiitonerName,
		AppointmentStatus.Status

From   Patient inner join Practitioner 
on		(Patient.PatientId = Practitioner.PractitionerId)
		inner join AppointmentStatus
On		(Patient.PatientId = AppointmentStatusId)

--14] Give me Patient,Practitioner,Appointment,AppointmentStatus informatin using joins

Select Patient.PatientId,
		CONCAT(Patient.FirstName ,' ',Patient.LastName) As PatientName,
		PractitionerId,
		CONCAT(Practitioner.FirstName,' ',Practitioner.LastName) As PractiitonerName,
		Appointment.AppointmentDate,
		Appointment.CreatedDatetime,
		Appointment.Reason,
		Appointment.AppointmentId,
		AppointmentStatus.Status,
		AppointmentStatus.AppointmentStatusId
From   Patient inner join Practitioner 
on		(Patient.PatientId = Practitioner.PractitionerId)
		inner join AppointmentStatus
On		(Patient.PatientId = AppointmentStatusId)
		inner Join Appointment
on		(Patient.PatientId = Appointment.AppointmentId)
		

/*

1] Retrieve all patient details along with their appointment status with only Active patients.


2] Fetch the names of patients along with their practitioner for each appointment.


3] Get the contact details of all patients who have an appointment.


4] Find the appointment details for a patient named 'Sam Will'.


5] List all practitioners along with the patients they have treated.


6] Retrieve a list of all patients and their corresponding appointment status (if any).


7] Fetch the patient details along with their contact information. Include patients without contact details.


8] List all patients and their practitioner for each appointment, showing patients even if they don't have a practitioner assigned.


9] Get all practitioners and their appointments, including those practitioners without any appointments.


10] Give me list off patients with contact details and having AppointmentReason = 'Follow-up'


11] Count how many appointments each patient has.


12] Retrieve the number of patients for each gender.


13] Give PatientName,PractitionerName,with their appointmentStatus.


14] Give me Patient,Practitioner,Appointment,AppointmentStatus informatin using joins


Stored Procedure Questions:   [2 Marks Each]

15] Write a stored procedure that takes a PatientId as input and returns the patient's contact details.


16] Write a stored procedure that takes PractitionerId as input and returns all the appointments they have.


17] Create a stored procedure to add a new patient, taking FirstName, LastName, DateOfBirth, and Gender as parameters.



*/



