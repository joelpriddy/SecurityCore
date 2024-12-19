using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreateRolePermissionTable : BaseMigration
    {
        protected string _ROLE_PERM_TABLE_NAME = $"{_SCHEMA}.ROLE_PERMISSION";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: _ROLE_PERM_TABLE_NAME,
                columns: table => new
                {
                    ROLE_PERMISSION_ID = table.Column<long>(nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ROLE_ID = table.Column<long>(nullable:false),
                    PERMISSION_ID = table.Column<long>(nullable:false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSION_ID", x => x.ROLE_PERMISSION_ID);
                    table.UniqueConstraint("UC_ROLE_ID_PERMISSION_ID", x => new { x.ROLE_ID, x.PERMISSION_ID });
                });
            /*
            SECURITY.API_KEY a
            INNER JOIN SECURITY.KEY_ROLE kr
                ON kr.API_KEY_ID = a.API_KEY_ID
            INNER JOIN SECURITY.ROLE r
                ON r.ROLE_ID = kr.ROLE_ID
            INNER JOIN SECURITY.ROLE_PERMISSION rp
                ON rp.ROLE_ID = r.ROLE_ID
             */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: _ROLE_PERM_TABLE_NAME);
        }
    }
}
