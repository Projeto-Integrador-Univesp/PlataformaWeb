using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pi.PlataformaWeb.Enchente.Data.Migrations
{
    public partial class migrationDadosVolumetricos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosVolumetricos",
                columns: table => new
                {
                    DadoVolumetricoId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosVolumetricos", x => x.DadoVolumetricoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosVolumetricos");
        }
    }
}
