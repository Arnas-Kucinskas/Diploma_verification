using Microsoft.EntityFrameworkCore.Migrations;

namespace Nethereum.Metamask.Blazor.Server.Migrations
{
    public partial class pdfbase64storage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pdfInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diplomaID = table.Column<int>(nullable: false),
                    pdfBase64Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdfInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pdfInfos_Diploma_diplomaID",
                        column: x => x.diplomaID,
                        principalTable: "Diploma",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdfInfos_diplomaID",
                table: "pdfInfos",
                column: "diplomaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdfInfos");
        }
    }
}
