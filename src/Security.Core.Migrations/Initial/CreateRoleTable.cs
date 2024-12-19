using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreateRoleTable : BaseMigration
    {
        protected string _ROLE_TABLE_NAME = $"{_SCHEMA}.ROLE";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: _ROLE_TABLE_NAME,
                columns: table => new
                {
                    ROLE_ID = table.Column<long>(nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ROLE_NAME = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    ROLE_DESCRIPTION = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_ID", x => x.ROLE_ID);
                    table.UniqueConstraint("UC_ROLE_NAME", x => new { x.ROLE_NAME });
                });
            /*
            SECURITY.API_KEY a
            INNER JOIN SECURITY.KEY_ROLE kr
                ON kr.API_KEY_ID = a.API_KEY_ID
            INNER JOIN SECURITY.ROLE r
                ON r.ROLE_ID = kr.ROLE_ID
             */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: _ROLE_TABLE_NAME);
        }
    }
}
