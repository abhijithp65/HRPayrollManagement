USE Database_HRPayrollManagement;

-- Creates a table to store user information

CREATE TABLE Table_Users
(
    id INT IDENTITY(1,1) PRIMARY KEY,         
    username VARCHAR(255) NOT NULL,          
    passwordHash VARCHAR(255) NOT NULL,       
    role VARCHAR(50) NOT NULL                
);


--Inserts admin user into Table_Users

INSERT INTO Table_Users (username, passwordHash, role)
VALUES ('admin', 'Admin@123', 'Admin');

--Creates a unique index on the username column

CREATE UNIQUE INDEX IX_Username ON Table_Users (Username);



-- Create a trigger to insert a user after registration in Table_Users
CREATE TRIGGER trg_InsertUserAfterRegistration
ON Table_Registration
AFTER INSERT
AS
BEGIN
    INSERT INTO Table_Users (username, [password], role)
    SELECT
        i.username,
        i.[password],
        'User' 
    FROM inserted i;
END;

--Defines a stored procedure to authenticate a user

CREATE PROCEDURE SPA_User
    @Username VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Table_Users
        WHERE username = @Username
        AND passwordHash = @Password  
    )
    BEGIN
        SELECT 'Authenticated' AS Status;
    END
    ELSE
    BEGIN
        SELECT 'NotAuthenticated' AS Status;
    END
END;

--Defines a stored procedure to retrieve a user's role

CREATE PROCEDURE SPG_UserRole
    @Username VARCHAR(255)
AS
BEGIN
    SELECT role
    FROM Table_Users
    WHERE username = @Username;
END;


-- Execute the SPA_User to authenticate a user

EXEC SPA_User 'xsa', 'aaa';

-- Execute the SPG_UserRole to retrieve a user's role

EXEC SPG_UserRole 'xsa';
