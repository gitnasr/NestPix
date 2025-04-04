using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NestPix.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Hashes_HashId",
                table: "Caches");

            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Sessions_SessionId",
                table: "Caches");

            migrationBuilder.DropTable(
                name: "Hashes");

            migrationBuilder.DropIndex(
                name: "IX_Caches_HashId",
                table: "Caches");

            migrationBuilder.DropColumn(
                name: "HashId",
                table: "Caches");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Caches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParentFolder",
                table: "Caches",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Caches_Sessions_SessionId",
                table: "Caches",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Sessions_SessionId",
                table: "Caches");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Caches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "ParentFolder",
                table: "Caches",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HashId",
                table: "Caches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hashes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    HashValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caches_HashId",
                table: "Caches",
                column: "HashId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caches_Hashes_HashId",
                table: "Caches",
                column: "HashId",
                principalTable: "Hashes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Caches_Sessions_SessionId",
                table: "Caches",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "id");
        }
    }
}
