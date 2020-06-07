using Microsoft.EntityFrameworkCore.Migrations;

namespace Nethereum.Metamask.Blazor.Server.Migrations
{
    public partial class searchCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "searchCode",
                table: "pdfInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "searchCode",
                table: "pdfInfos");
        }
    }
}
