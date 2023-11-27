using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.mvc.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inscrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveId = table.Column<int>(type: "int", nullable: true),
                    InscricaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscrito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Live",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrutorId = table.Column<int>(type: "int", nullable: false),
                    InscritoId = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoMin = table.Column<int>(type: "int", nullable: false),
                    ValorInscricao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Live", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Live_Inscrito_InscritoId",
                        column: x => x.InscritoId,
                        principalTable: "Inscrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Live_Instrutor_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "Instrutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiveId = table.Column<int>(type: "int", nullable: false),
                    ValorInscricaoId = table.Column<int>(type: "int", nullable: true),
                    InscritoId = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscricao_Inscrito_InscritoId",
                        column: x => x.InscritoId,
                        principalTable: "Inscrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscricao_Live_LiveId",
                        column: x => x.LiveId,
                        principalTable: "Live",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscricao_Live_ValorInscricaoId",
                        column: x => x.ValorInscricaoId,
                        principalTable: "Live",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_InscritoId",
                table: "Inscricao",
                column: "InscritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_LiveId",
                table: "Inscricao",
                column: "LiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_ValorInscricaoId",
                table: "Inscricao",
                column: "ValorInscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrito_InscricaoId",
                table: "Inscrito",
                column: "InscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrito_LiveId",
                table: "Inscrito",
                column: "LiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Live_InscritoId",
                table: "Live",
                column: "InscritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Live_InstrutorId",
                table: "Live",
                column: "InstrutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscrito_Inscricao_InscricaoId",
                table: "Inscrito",
                column: "InscricaoId",
                principalTable: "Inscricao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscrito_Live_LiveId",
                table: "Inscrito",
                column: "LiveId",
                principalTable: "Live",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricao_Inscrito_InscritoId",
                table: "Inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Live_Inscrito_InscritoId",
                table: "Live");

            migrationBuilder.DropTable(
                name: "Inscrito");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.DropTable(
                name: "Live");

            migrationBuilder.DropTable(
                name: "Instrutor");
        }
    }
}
