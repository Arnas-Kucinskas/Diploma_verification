using Microsoft.EntityFrameworkCore.Migrations;

namespace Nethereum.Metamask.Blazor.Server.Migrations
{
    public partial class moreorlesscompletediplomadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudiesProgram",
                table: "Diploma");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityNumber",
                table: "Diploma",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Diploma",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RectorsLastName",
                table: "Diploma",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RectorsName",
                table: "Diploma",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudiesProgramme",
                table: "Diploma",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudiesProgrammeGovermentCode",
                table: "Diploma",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Diploma");

            migrationBuilder.DropColumn(
                name: "RectorsLastName",
                table: "Diploma");

            migrationBuilder.DropColumn(
                name: "RectorsName",
                table: "Diploma");

            migrationBuilder.DropColumn(
                name: "StudiesProgramme",
                table: "Diploma");

            migrationBuilder.DropColumn(
                name: "StudiesProgrammeGovermentCode",
                table: "Diploma");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityNumber",
                table: "Diploma",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "StudiesProgram",
                table: "Diploma",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
