using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhmCalcNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    UnitName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Toughness = table.Column<byte>(type: "INTEGER", maxLength: 3, nullable: false),
                    Save = table.Column<byte>(type: "INTEGER", maxLength: 1, nullable: false),
                    Wounds = table.Column<byte>(type: "INTEGER", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.UnitName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Targets");
        }
    }
}
