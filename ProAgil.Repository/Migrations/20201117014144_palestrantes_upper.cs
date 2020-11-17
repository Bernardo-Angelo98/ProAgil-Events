using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.Repository.Migrations
{
    public partial class palestrantes_upper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PalestranteEventos_palestrantes_PalestranteId",
                table: "PalestranteEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_palestrantes_PalestranteId",
                table: "RedeSociais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_palestrantes",
                table: "palestrantes");

            migrationBuilder.RenameTable(
                name: "palestrantes",
                newName: "Palestrantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Palestrantes",
                table: "Palestrantes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PalestranteEventos_Palestrantes_PalestranteId",
                table: "PalestranteEventos",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PalestranteEventos_Palestrantes_PalestranteId",
                table: "PalestranteEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Palestrantes",
                table: "Palestrantes");

            migrationBuilder.RenameTable(
                name: "Palestrantes",
                newName: "palestrantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_palestrantes",
                table: "palestrantes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PalestranteEventos_palestrantes_PalestranteId",
                table: "PalestranteEventos",
                column: "PalestranteId",
                principalTable: "palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_palestrantes_PalestranteId",
                table: "RedeSociais",
                column: "PalestranteId",
                principalTable: "palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
