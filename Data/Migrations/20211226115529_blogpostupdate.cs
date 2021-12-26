using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class blogpostupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BlogPosts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BlogPosts");
        }
    }
}
