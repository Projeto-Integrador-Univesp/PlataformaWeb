using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pi.PlataformaWeb.Enchente.Data.Migrations
{
    public partial class migrationInscritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscritos",
                columns: table => new
                {
                    InscritoID = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    PushEndpoint = table.Column<string>(nullable: true),
                    PushP256DH = table.Column<string>(nullable: true),
                    PushAuth = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscritos", x => x.InscritoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscritos");
        }
    }
}
