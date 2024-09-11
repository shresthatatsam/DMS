using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Management_system.Migrations
{
    public partial class addedpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "victims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "victims");
        }
    }
}
