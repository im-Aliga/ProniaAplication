using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndFinalProject.Migrations
{
    public partial class BlogFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageNameInFileSystem",
                table: "BlogImages",
                newName: "FileNameInFileSystem");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "BlogImages",
                newName: "FileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileNameInFileSystem",
                table: "BlogImages",
                newName: "ImageNameInFileSystem");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "BlogImages",
                newName: "ImageName");
        }
    }
}
