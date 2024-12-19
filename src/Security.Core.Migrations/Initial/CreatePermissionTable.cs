using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreatePermissionTable : BaseMigration
    {
        protected readonly string _PERMISSION_TABLE_NAME = $"{_SCHEMA}.PERMISSION";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: _PERMISSION_TABLE_NAME,
                columns: table => new
                {
                    PERMISSION_ID = table.Column<long>(nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PERMISSION_NAME = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    PERMISSION_DESC = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION_ID", x => x.PERMISSION_ID);
                    table.UniqueConstraint("UC_PERMISSION_NAME", x => new { x.PERMISSION_NAME });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: _PERMISSION_TABLE_NAME);
        }
    }
}
