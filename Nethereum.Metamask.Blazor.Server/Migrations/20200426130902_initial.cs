using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nethereum.Metamask.Blazor.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diploma",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SB_nr = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<int>(nullable: false),
                    StudiesProgram = table.Column<string>(nullable: true),
                    Studiesdirection = table.Column<string>(nullable: true),
                    RegistrationNr = table.Column<string>(nullable: true),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diploma", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diploma");
        }
    }
}
