USE Database_HRPayrollManagement;

--Creates a new table to store contact form data

CREATE TABLE Table_contactForms (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) NOT NULL,
    message NVARCHAR(MAX) NOT NULL
)

-- Stored procedure to insert data into the contact form table

CREATE PROCEDURE insertContactForm
    @name NVARCHAR(255),
    @email NVARCHAR(255),
    @message NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Table_contactForms (name, email, message)
    VALUES (@name, @email, @message)
END

-- Retrieves all rows and columns from the contact form table

SELECT * FROM Table_contactForms;