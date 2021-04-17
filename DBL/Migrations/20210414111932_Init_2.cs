using Microsoft.EntityFrameworkCore.Migrations;

namespace DBL.Migrations
{
    public partial class Init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "IsFavor",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "Long_desc",
                table: "cars");

            migrationBuilder.RenameColumn(
                name: "Short_desc",
                table: "cars",
                newName: "Desc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "cars",
                newName: "Short_desc");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavor",
                table: "cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Long_desc",
                table: "cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
