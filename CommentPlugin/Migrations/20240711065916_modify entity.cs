using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentPlugin.Migrations
{
    public partial class modifyentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Comments",
                newName: "AuthorName");

            migrationBuilder.AddColumn<string>(
                name: "AuthorImage",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorImage",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Comments",
                newName: "Author");
        }
    }
}
