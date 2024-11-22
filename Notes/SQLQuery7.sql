create database STRINGSPLIT

use STRINGSPLIT

create schema sales

CREATE TABLE sales.contacts (
    id INT PRIMARY KEY IDENTITY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    phones VARCHAR(500)
);


INSERT INTO 
    sales.contacts(first_name, last_name, phones)
VALUES
    ('John','Doe','(408)-123-3456,(408)-123-3457'),
    ('Jane','Doe','(408)-987-4321,(408)-987-4322,(408)-987-4323');

SELECT 
    first_name, 
    last_name,
    value phone
FROM 
    sales.contacts
    CROSS APPLY STRING_SPLIT(phones, ',');

















