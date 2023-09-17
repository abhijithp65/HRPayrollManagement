USE Database_HRPayrollManagement;
select * from Table_Users;
select * from Table_Registration;
select * from Table_contactForms;


CREATE PROCEDURE SPU_ChangePassword
    @Username NVARCHAR(255),
    @NewPassword NVARCHAR(255)
AS
BEGIN
    -- Update the password in the Table_Users table
    UPDATE Table_Users
    SET passwordHash = @NewPassword
    WHERE username = @Username;

    -- Update the password in the Table_Registration table
    UPDATE Table_Registration
    SET [password] = @NewPassword
    WHERE username = @Username;
END;
