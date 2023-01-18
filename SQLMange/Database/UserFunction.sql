USE StudentsDB
GO
--Inital tage
CREATE PROCEDURE sp_GetUsers 
AS
BEGIN
	SELECT * FROM [StudentsDB].[dbo].[User];
END
GO
CREATE PROCEDURE sp_UpsertUser
	@UserId int,
	@Username nvarchar(50),
	@Adderss nvarchar(50),
	@PhoneNumber int,
	@Email nvarchar(50)
AS
BEGIN 
	IF(@UserId != 0) 
	BEGIN 
		UPDATE StudentsDB.dbo.[User] 
		SET username = @Username, adderss=@Adderss, phonenumber=@PhoneNumber, email=@Email
		where userId = @UserId;
	END
	ELSE
	BEGIN
		INSERT INTO StudentsDB.dbo.[User] (username, adderss, phonenumber, email) 
		VALUES(@Username, @Adderss, @PhoneNumber, @Email)		
	END
END
GO
CREATE PROCEDURE sp_DeleteUser
	@UserID int
AS
BEGIN
	DELETE FROM StudentsDB.dbo.[User] WHERE userId = @UserID
END
GO
CREATE PROCEDURE sp_GetUserById
	@UserId int 
AS
BEGIN
	SELECT * FROM StudentsDB.dbo.[User] WHERE userId = @UserId;
END
GO