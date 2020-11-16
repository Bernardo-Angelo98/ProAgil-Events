using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.WebApi.Migrations
{
    public partial class edit_dataevento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataEvento",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEvento",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
