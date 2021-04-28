using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Data.Migrations
{
    public partial class Aluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Alunos",
                newName: "Genero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Alunos",
                newName: "Sexo");
        }
    }
}
