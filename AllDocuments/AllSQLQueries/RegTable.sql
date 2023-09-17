USE Database_HRPayrollManagement;

--Creates a new table to store registration data

CREATE TABLE Table_Registration (
    id INT IDENTITY(1,1) PRIMARY KEY,
    firstName VARCHAR(255) NOT NULL DEFAULT '',
    lastName VARCHAR(255) NOT NULL DEFAULT '',
    dateOfBirth DATE NOT NULL,
    gender VARCHAR(255) NOT NULL DEFAULT '',
    phoneNumber VARCHAR(20) NOT NULL DEFAULT '',
    emailAddress VARCHAR(255) NOT NULL DEFAULT '',
    address VARCHAR(MAX) NOT NULL DEFAULT '', 
    state VARCHAR(255) NOT NULL DEFAULT '',
    city VARCHAR(255) NOT NULL DEFAULT '',
    username VARCHAR(255) NOT NULL DEFAULT '',
    [password] VARCHAR(255) NOT NULL DEFAULT ''
);


--Delete all records from the specified tables
DELETE FROM Table_Users;
DELETE FROM Table_Registration;

--Reset identity values for tables to 1

DBCC CHECKIDENT ('Table_Users', RESEED, 1);
DBCC CHECKIDENT ('Table_Registration', RESEED, 1);


