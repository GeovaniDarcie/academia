using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Data.Migrations
{
    public partial class Coluna_Academina_Aluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AcademiaId",
                table: "Usuarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AcademiaId",
                table: "Usuarios",
                column: "AcademiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Academias_AcademiaId",
                table: "Usuarios",
                column: "AcademiaId",
                principalTable: "Academias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Academias_AcademiaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AcademiaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AcademiaId",
                table: "Usuarios");
        }
    }
}
