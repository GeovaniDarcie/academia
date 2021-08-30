using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademiaEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademiaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademiaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_AcademiaEntity_AcademiaId",
                        column: x => x.AcademiaId,
                        principalTable: "AcademiaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InicioDeMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcademiaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_AcademiaEntity_AcademiaId",
                        column: x => x.AcademiaId,
                        principalTable: "AcademiaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademiaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_AcademiaEntity_AcademiaId",
                        column: x => x.AcademiaId,
                        principalTable: "AcademiaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitosGerais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sedentarismo = table.Column<int>(type: "int", nullable: false),
                    Cirurgias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlunoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamneses_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Antropometrias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    IMC = table.Column<int>(type: "int", nullable: false),
                    PercentualDeGordura = table.Column<int>(type: "int", nullable: false),
                    MassaMuscular = table.Column<double>(type: "float", nullable: false),
                    AlunoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antropometrias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antropometrias_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DobrasCutaneas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Triciptal = table.Column<double>(type: "float", nullable: false),
                    Subescapular = table.Column<double>(type: "float", nullable: false),
                    Biciptal = table.Column<double>(type: "float", nullable: false),
                    AxilarMedia = table.Column<double>(type: "float", nullable: false),
                    SupraIliaca = table.Column<double>(type: "float", nullable: false),
                    Toracica = table.Column<double>(type: "float", nullable: false),
                    Coxa = table.Column<double>(type: "float", nullable: false),
                    Abdominal = table.Column<double>(type: "float", nullable: false),
                    PanturrilhaMedial = table.Column<double>(type: "float", nullable: false),
                    AlunoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobrasCutaneas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DobrasCutaneas_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AcademiaId",
                table: "Admin",
                column: "AcademiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_AcademiaId",
                table: "Aluno",
                column: "AcademiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_AlunoId",
                table: "Anamneses",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Antropometrias_AlunoId",
                table: "Antropometrias",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_DobrasCutaneas_AlunoId",
                table: "DobrasCutaneas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_AcademiaId",
                table: "Professores",
                column: "AcademiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropTable(
                name: "Antropometrias");

            migrationBuilder.DropTable(
                name: "DobrasCutaneas");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "AcademiaEntity");
        }
    }
}
