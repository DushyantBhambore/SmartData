--17] Create a stored procedure to add a new patient, taking FirstName, LastName, DateOfBirth, and Gender as parameters.


CREATE TABLE Patient2 (
    PatientId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);


INSERT INTO Patient2 (FirstName, LastName, DateOfBirth, Gender, Active) 
VALUES ('Sam', 'Will', '1985-06-15', 'Male', 1),
       ('Mark', 'Wagh', '1990-03-10', 'Female', 1),
	   ('Maria', 'Joseph', '1990-03-10', 'Female', 1),
	   ('Jane', 'Foster', '1990-03-10', 'Female', 1),
	   ('Ramesh', 'Kumar', '1990-03-10', 'Male', 0),
	   ('Will', 'Smith', '1990-03-10', 'Male', 1),
	   ('Julia', 'Robert', '1990-03-10', 'Female', 0)


select * from Patient2

/*
Title:			spNewPateint
Creator:		Dushyant Bhaambore

Purpose: 		 add a new patient, taking FirstName, LastName, DateOfBirth, and Gender as parameters.
Functionality:	
Created:		
Applications:	

Comments:		
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Example:		

                   Exec spNewPateint @FirstName ='Vinit',
									  @LastName = 'Kumar',
									  @DateOfBirth = '2002-12-11',
									  @Gender = 'Male',
									  @Action ='A'


Output:		
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Return Values:	
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Modifications:

Date          Develope	r        Description
----------  --------------	--------------------------------------------------------------------------------------------------------------------
20/09/2024   Dushyant Bhaambore             add a new patient, taking FirstName, LastName, DateOfBirth, and Gender as parameters.
*/






/*

*/

Create or  Alter Procedure spNewPateint @FirstName varchar(10),
										@LastName varchar(10),
										@DateOfBirth Date,
										@Gender   varchar(10),
										@Action varchar(1)


As 
Begin 
	if @action ='A'
	Begin
		if not exists (select top 1 FirstName from Patient2 where FirstName=@FirstName)
	
	begin
		INSERT INTO Patient2(FirstName,LastName,DateOfBirth,Gender)
		VALUES 
					(@FirstName,@LastName,@DateOfBirth,@Gender)
	end
		else
	begin
		select 'Already exists'
	End
	End 
END



















