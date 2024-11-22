/********************************************************************************************************
                                         SQL Assessment                             Total Marks - 20
*********************************************************************************************************



Q.1] Imagine you are tasked with designing a database for a Hospital Management System. For this scenario,        [2]
     you need to create a schema that includes three tables to model the relationships between patients and practitioners and Appointment             
	 (Patient, Practitioner, Appointment) Please create these tables with proper relations.
	 Follow proper naming convention and datatype,
	 use identity,Constraints,Also Insert sample data (alteast 4 rows each)

Note :- While Designing the database please follow the normalization techniques.
*/

-- CREATE A PATIENTS TABLES 
CREATE TABLE PATIENTS 
(

)




Create below tables into the your database and solve below questions */

CREATE TABLE Product1 (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(100),
    Price DECIMAL(10, 2),
    ManufactureDate DATE,
    ExpiryDate DATE
);


-- Insert sample data into Product table
INSERT INTO Product1 (ProductName, Category, Price, ManufactureDate, ExpiryDate)
VALUES 
('Milk', 'Dairy', 1.50, '2024-01-15', '2024-04-15')
,('Bread', 'Bakery', 2.00, '2024-02-01', '2024-02-15')
,('Orange Juice', 'Beverages', 3.00, '2024-01-20', '2024-06-20')
,('Cereal', 'Groceries', 4.50, '2023-12-01', '2024-12-01')
,('Yogurt', 'Dairy', 2.75, '2024-01-10', '2024-03-10')
,('Apple', 'Fruits', 1.20, '2024-01-25', '2024-02-25')
,('Chicken Breast', 'Meat', 5.00, '2024-02-10', '2024-03-10')
,('Pasta', 'Groceries', 3.20, '2023-11-20', '2024-11-20')
,('Olive Oil', 'Condiments', 7.50, '2023-10-15', '2025-10-15')
,('Coffee', 'Beverages', 6.00, '2023-09-01', '2024-09-01')

/*

Each Question have 1 marks

Q[2]:  Retrieve details of products that belong to the 'Dairy' category.
Q[3]:  Find all products that are not in the 'Beverages' category.
Q[4]:  List products that have a price greater than 3.00.
Q[5]:  Retrieve products that have a price less than 2.00.
Q[6]:  Find products that were manufactured on or after '2024-01-01'.
Q[7]:  Get the list of products that have an expiry date on or before '2024-06-01'.
Q[8]:  Retrieve products whose price is not less than 4.00.
Q[9]:  Find products whose price is not greater than 2.50.
Q[10]: List products that belong to the 'Groceries' category and have a price greater than 3.00.
Q[11]: Find products that are either in the 'Dairy' category or have a price less than 2.00.
Q[12]: Retrieve products that are not 'Bread'.
Q[13]: Get products that have a price between 2.00 and 5.00 inclusive.
Q[14]: Find products whose names start with the letter 'C'.
Q[15]: Retrieve products whose names contain the word 'Oil'.
Q[16]: Retrieve the current date and time from the SQL server.
Q[17]: List all products that were manufactured today.
Q[18]: Give me list of product with Product Name (Orange Juice,Apple,Coffee).



/********************************************************************************************************
                                          ALL THE BEST
********************************************************************************************************* */*/






