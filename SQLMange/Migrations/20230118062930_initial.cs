using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQLMange.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        /// 
        private readonly string sp_GetUsers = @"CREATE OR ALTER PROCEDURE sp_GetUsers
AS
BEGIN
	SELECT * FROM StudentsDB.dbo.[User];
END";
        private readonly string sp_UpsertUser = @"CREATE OR ALTER PROCEDURE sp_UpsertUser(@UserId int,
	@Username nvarchar(50),
	@Adderss nvarchar(50),
	@PhoneNumber int,
	@Email nvarchar(50))
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
END";
        private readonly string sp_DeleteUser = @"CREATE OR ALTER PROCEDURE sp_DeleteUser(
	@UserID int)
AS
BEGIN
	DELETE FROM StudentsDB.dbo.[User] WHERE userId = @UserID
END";
        private readonly string sp_GetUserById = @"CREATE OR ALTER PROCEDURE sp_GetUserById(
@UserId int)
AS
BEGIN
	SELECT * FROM StudentsDB.dbo.[User] WHERE userId = @UserId;
END";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adderss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
            migrationBuilder.Sql(sp_GetUsers);
            migrationBuilder.Sql(sp_UpsertUser);
            migrationBuilder.Sql(sp_DeleteUser);
            migrationBuilder.Sql(sp_GetUserById);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
