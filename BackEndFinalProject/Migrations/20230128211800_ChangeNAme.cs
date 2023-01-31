using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndFinalProject.Migrations
{
    public partial class ChangeNAme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogImages",
                table: "BlogImages");

            migrationBuilder.RenameTable(
                name: "BlogImages",
                newName: "BlogFiles");

            migrationBuilder.RenameIndex(
                name: "IX_BlogImages_BlogId",
                table: "BlogFiles",
                newName: "IX_BlogFiles_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogFiles",
                table: "BlogFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogFiles_Blogs_BlogId",
                table: "BlogFiles",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogFiles_Blogs_BlogId",
                table: "BlogFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogFiles",
                table: "BlogFiles");

            migrationBuilder.RenameTable(
                name: "BlogFiles",
                newName: "BlogImages");

            migrationBuilder.RenameIndex(
                name: "IX_BlogFiles_BlogId",
                table: "BlogImages",
                newName: "IX_BlogImages_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogImages",
                table: "BlogImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
