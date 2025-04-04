using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NestPix.Migrations
{
    /// <inheritdoc />
    public partial class M5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionShortcuts");

            migrationBuilder.AlterColumn<string>(
                name: "Folder",
                table: "Sessions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Folder",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SessionShortcuts",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortcutID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionShortcuts", x => new { x.SessionID, x.ShortcutID });
                    table.ForeignKey(
                        name: "FK_SessionShortcuts_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionShortcuts_Shortcuts_ShortcutID",
                        column: x => x.ShortcutID,
                        principalTable: "Shortcuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionShortcuts_ShortcutID",
                table: "SessionShortcuts",
                column: "ShortcutID");
        }
    }
}
