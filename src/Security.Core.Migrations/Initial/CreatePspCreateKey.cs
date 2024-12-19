using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreatePspCreateKey : BaseMigration
    {
        protected readonly string _PSP_CREATE_KEY = $"{_SCHEMA}.PSP_CREATE_KEY";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the stored procedure
            migrationBuilder.Sql(@$"
            CREATE PROCEDURE {_PSP_CREATE_KEY} (
                IN owner NVARCHAR(250)
            )
            BEGIN
                DECLARE @apiKey AS NVARCHAR(36);
                DECLARE @hashedKey AS NVARCHAR(64);

                SET @apiKey = (SELECT UUID() LIMIT 1);
                SET @hashedKey = (SELECT SHA2(@apiKey, 256) LIMIT 1);

                INSERT  INTO SECURITY.API_KEY (HASHED_API_KEY, OWNER, CREATED_DATE, UPDATED_DATE, IS_ACTIVE)
                VALUES  (@hashedKey, owner, CURRENT_TIMESTAMP(), NULL, 1);

                SELECT  @apiKey AS API_KEY;
            END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP PROCEDURE IF EXISTS {_PSP_CREATE_KEY};");
        }
    }
}
