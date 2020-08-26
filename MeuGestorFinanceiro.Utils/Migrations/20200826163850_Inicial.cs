using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuGestorFinanceiro.Utils.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "despesa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    id_categoria = table.Column<int>(nullable: false),
                    Pago = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_despesa", x => x.id);
                    table.ForeignKey(
                        name: "FK_despesa_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receita",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    id_categoria = table.Column<int>(nullable: false),
                    Recebido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita", x => x.id);
                    table.ForeignKey(
                        name: "FK_receita_categoria_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_despesa_id_categoria",
                table: "despesa",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_receita_id_categoria",
                table: "receita",
                column: "id_categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "despesa");

            migrationBuilder.DropTable(
                name: "receita");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
