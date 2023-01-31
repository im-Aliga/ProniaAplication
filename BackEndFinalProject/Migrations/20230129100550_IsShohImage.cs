using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndFinalProject.Migrations
{
    public partial class IsShohImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowImage",
                table: "BlogFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowVideo",
                table: "BlogFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowImage",
                table: "BlogFiles");

            migrationBuilder.DropColumn(
                name: "IsShowVideo",
                table: "BlogFiles");
        }
    }
}
