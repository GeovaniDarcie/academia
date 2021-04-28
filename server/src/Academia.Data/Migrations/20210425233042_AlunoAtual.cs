using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Data.Migrations
{
    public partial class AlunoAtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDePagamento",
                table: "Alunos",
                newName: "Celular");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Alunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioDeMatricula",
                table: "Alunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InicioDeMatricula",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Alunos",
                newName: "DataDePagamento");

            migrationBuilder.AlterColumn<string>(
                name: "DataDeNascimento",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
