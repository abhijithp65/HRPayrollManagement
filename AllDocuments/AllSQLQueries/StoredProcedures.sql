USE Database_HRPayrollManagement;

CREATE PROCEDURE SPI_Registration
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @DateOfBirth DATE,
    @Gender VARCHAR(255),
    @PhoneNumber VARCHAR(20),
    @EmailAddress VARCHAR(255),
    @Address VARCHAR(MAX), 
    @State VARCHAR(255),
    @City VARCHAR(255),
    @Username VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    INSERT INTO Table_Registration(
        firstName,
        lastName,
        dateOfBirth,
        gender,
        phoneNumber,
        emailAddress,
        address,
        state,
        city,
        username,
        [password]
    )
    VALUES (
        @FirstName,
        @LastName,
        @DateOfBirth,
        @Gender,
        @PhoneNumber,
        @EmailAddress,
        @Address,
        @State,
        @City,
        @Username,
        @Password
    );
END;




CREATE PROCEDURE SPU_Registration
    @Id INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @DateOfBirth DATE,
    @Gender VARCHAR(255),
    @PhoneNumber VARCHAR(20),
    @EmailAddress VARCHAR(255),
    @Address VARCHAR(MAX), 
    @State VARCHAR(255),
    @City VARCHAR(255),
    @Username VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    UPDATE Table_Registration
    SET
        firstName = @FirstName,
        lastName = @LastName,
        dateOfBirth = @DateOfBirth,
        gender = @Gender,
        phoneNumber = @PhoneNumber,
        emailAddress = @EmailAddress,
        address = @Address,
        state = @State,
        city = @City,
        username = @Username,
        [password] = @Password
    WHERE id = @Id;
END;




CREATE PROCEDURE SPS_Registration
    @Username VARCHAR(255)
AS
BEGIN
    SELECT *
    FROM Table_Registration
    WHERE username = @Username;
END;


CREATE PROCEDURE SPD_Registration
    @Id INT
AS
BEGIN
    DELETE FROM Table_Registration
    WHERE id = @Id;
END;




CREATE PROCEDURE SPS_RegistrationByUsername
(
    @Username NVARCHAR(255)
)
AS
BEGIN
    SELECT *
    FROM Table_Users 
    WHERE Username = @Username;
END
