using Microsoft.EntityFrameworkCore.Migrations;

namespace Nethereum.Metamask.Blazor.Server.Migrations
{
    public partial class comfirmationcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComfirmationCount",
                table: "Diploma",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComfirmationCount",
                table: "Diploma");
        }
    }
}
