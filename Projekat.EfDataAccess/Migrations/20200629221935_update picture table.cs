using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.EfDataAccess.Migrations
{
    public partial class updatepicturetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Picture_PictureId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PictureId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdPicture",
                table: "Posts",
                column: "IdPicture");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Pictures_IdPicture",
                table: "Posts",
                column: "IdPicture",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Pictures_IdPicture",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_IdPicture",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PictureId",
                table: "Posts",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Picture_PictureId",
                table: "Posts",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
