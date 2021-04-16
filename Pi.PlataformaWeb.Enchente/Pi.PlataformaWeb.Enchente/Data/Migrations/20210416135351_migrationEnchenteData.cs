using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pi.PlataformaWeb.Enchente.Data.Migrations
{
    public partial class migrationEnchenteData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enchentes",
                columns: table => new
                {
                    EnchenteDataId = table.Column<Guid>(nullable: false),
                    TeveEnchente = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enchentes", x => x.EnchenteDataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enchentes");
        }
    }
}
