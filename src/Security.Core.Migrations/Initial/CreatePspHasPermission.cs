using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreatePspHasPermission : BaseMigration
    {
        protected readonly string _PSP_HAS_PERMISSION = $"{_SCHEMA}.PSP_HAS_PERMISSION";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the stored procedure
            migrationBuilder.Sql(@$"
            CREATE PROCEDURE {_PSP_HAS_PERMISSION} (
                IN hashedApiKey VARCHAR(64),
                IN permission VARCHAR(255)
            )
            BEGIN
                SELECT EXISTS (
                    SELECT  1
                    FROM    SECURITY.API_KEY k
                            INNER JOIN SECURITY.KEY_ROLE kr
                                ON kr.API_KEY_ID = k.API_KEY_ID
                            INNER JOIN SECURITY.ROLE r
                                ON r.ROLE_ID = kr.ROLE_ID
                            INNER JOIN SECURITY.ROLE_PERMISSION rp
                                ON rp.ROLE_ID = r.ROLE_ID
                            INNER JOIN SECURITY.PERMISSION p
                                ON p.PERMISSION_ID = rp.PERMISSION_ID
                    WHERE   k.HASHED_API_KEY = hashedApiKey
                            AND p.PERMISSION_NAME = permission
                            AND k.IS_ACTIVE = 1
                            AND r.IS_ACTIVE = 1
                            AND p.IS_ACTIVE = 1
                ) AS HAS_PERMISSION;
            END;
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the stored procedure
            migrationBuilder.Sql($"DROP PROCEDURE IF EXISTS {_PSP_HAS_PERMISSION};");
        }
    }
}
