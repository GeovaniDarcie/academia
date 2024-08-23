using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academia.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationUserGym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InicioDeMatricula",
                table: "Alunos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Alunos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Academias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdApplicationUser",
                table: "Academias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Academias_ApplicationUserId",
                table: "Academias",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Academias_AspNetUsers_ApplicationUserId",
                table: "Academias",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academias_AspNetUsers_ApplicationUserId",
                table: "Academias");

            migrationBuilder.DropIndex(
                name: "IX_Academias_ApplicationUserId",
                table: "Academias");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Academias");

            migrationBuilder.DropColumn(
                name: "IdApplicationUser",
                table: "Academias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InicioDeMatricula",
                table: "Alunos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Alunos",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
