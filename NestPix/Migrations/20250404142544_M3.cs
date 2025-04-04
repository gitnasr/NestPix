using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NestPix.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Hashes_HashID",
                table: "Caches");

            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Sessions_SessionID",
                table: "Caches");

            migrationBuilder.RenameColumn(
                name: "isSkipped",
                table: "Caches",
                newName: "IsSkipped");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Caches",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "SessionID",
                table: "Caches",
                newName: "SessionId");

            migrationBuilder.RenameColumn(
                name: "HashID",
                table: "Caches",
                newName: "HashId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Caches",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Caches_SessionID",
                table: "Caches",
                newName: "IX_Caches_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Caches_HashID",
                table: "Caches",
                newName: "IX_Caches_HashId");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Caches",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "Caches",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Hashes_HashId",
                table: "Caches");

            migrationBuilder.DropForeignKey(
                name: "FK_Caches_Sessions_SessionId",
                table: "Caches");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Caches",
                newName: "SessionID");

            migrationBuilder.RenameColumn(
                name: "IsSkipped",
                table: "Caches",
                newName: "isSkipped");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Caches",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "HashId",
                table: "Caches",
                newName: "HashID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Caches",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Caches_SessionId",
                table: "Caches",
                newName: "IX_Caches_SessionID");

            migrationBuilder.RenameIndex(
                name: "IX_Caches_HashId",
                table: "Caches",
                newName: "IX_Caches_HashID");

            migrationBuilder.AlterColumn<int>(
                name: "SessionID",
                table: "Caches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileSize",
                table: "Caches",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Caches_Hashes_HashID",
                table: "Caches",
                column: "HashID",
                principalTable: "Hashes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Caches_Sessions_SessionID",
                table: "Caches",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
