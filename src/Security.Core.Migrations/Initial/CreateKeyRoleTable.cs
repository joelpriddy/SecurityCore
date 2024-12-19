using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreateKeyRoleTable : BaseMigration
    {
        protected readonly string _ROLE_TABLE_NAME = $"{_SCHEMA}.KEY_ROLE";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: _ROLE_TABLE_NAME,
                columns: table => new
                {
                    KEY_ROLE_ID = table.Column<long>(nullable:false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    API_KEY_ID = table.Column<long>(nullable: false),
                    ROLE_ID = table.Column<long>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KEY_ROLE_ID", x => x.KEY_ROLE_ID);
                    table.UniqueConstraint("UC_KEY_ID_ROLE_ID", x => new { x.API_KEY_ID, x.ROLE_ID });
                });
            /*
             SECURITY.API_KEY a
             INNER JOIN SECURITY.KEY_ROLE kr
                ON kr.API_KEY_ID = a.API_KEY_ID
             */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: _ROLE_TABLE_NAME);
        }
    }
}
