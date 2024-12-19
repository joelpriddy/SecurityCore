using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Core.Migrations.Initial
{
    public partial class CreateApiKeyEndpointsTable : BaseMigration
    {
        protected readonly string _API_KEY_TABLE_NAME = $"{_SCHEMA}.API_KEY";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: _API_KEY_TABLE_NAME,
                columns: table => new
                {
                    API_KEY_ID = table.Column<long>(nullable: false).Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HASHED_API_KEY = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    OWNER = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_KEY", x => x.API_KEY_ID);
                    table.UniqueConstraint("UC_HASHED_KEY_VALUE", x => new { x.HASHED_API_KEY });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: _API_KEY_TABLE_NAME);
        }
    }
}
