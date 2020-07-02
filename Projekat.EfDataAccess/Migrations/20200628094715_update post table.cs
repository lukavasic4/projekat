using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.EfDataAccess.Migrations
{
    public partial class updateposttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Src",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
