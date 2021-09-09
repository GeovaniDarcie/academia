using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Data.Migrations
{
    public partial class AlunoId_Treino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AlunoId",
                table: "Treinos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Treinos");
        }
    }
}
