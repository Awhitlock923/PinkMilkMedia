using Microsoft.EntityFrameworkCore.Migrations;

namespace PinkMilkMedia.Migrations
{
    public partial class ai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Album_AlbumId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AlbumId",
                table: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "AlbumId",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbumId1",
                table: "Photo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AlbumId1",
                table: "Photo",
                column: "AlbumId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Album_AlbumId1",
                table: "Photo",
                column: "AlbumId1",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Album_AlbumId1",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_AlbumId1",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "AlbumId1",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AlbumId",
                table: "Photo",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Album_AlbumId",
                table: "Photo",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
