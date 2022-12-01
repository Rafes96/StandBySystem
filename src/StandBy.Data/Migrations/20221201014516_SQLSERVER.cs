using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StandBy.Data.Migrations
{
    public partial class SQLSERVER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CLIENTE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    varchar60 = table.Column<string>(name: "varchar(60)", type: "nvarchar(max)", nullable: false),
                    DATA_FUNDACAO = table.Column<DateTime>(type: "DATE", nullable: false),
                    DATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DECIMAL182 = table.Column<decimal>(name: "DECIMAL(18,2)", type: "decimal(18,2)", nullable: false),
                    QUARENTENA = table.Column<bool>(type: "bit", nullable: false),
                    STATUS_CLIENTE = table.Column<bool>(type: "bit", nullable: false),
                    CLASSIFICACAO = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CLIENTE_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
