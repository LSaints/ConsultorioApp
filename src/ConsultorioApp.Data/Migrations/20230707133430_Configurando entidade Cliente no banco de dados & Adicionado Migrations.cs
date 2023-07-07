using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurandoentidadeClientenobancodedadosAdicionadoMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Tb_Clientes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tb_Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Tb_Clientes",
                newName: "DocumentoIndetificador");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Tb_Clientes",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "M",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Tb_Clientes",
                type: "varchar(48)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tb_Clientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_Clientes",
                table: "Tb_Clientes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Clientes_Nome_Sexo",
                table: "Tb_Clientes",
                columns: new[] { "Nome", "Sexo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_Clientes",
                table: "Tb_Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Clientes_Nome_Sexo",
                table: "Tb_Clientes");

            migrationBuilder.RenameTable(
                name: "Tb_Clientes",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Clientes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DocumentoIndetificador",
                table: "Clientes",
                newName: "Documento");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Clientes",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldDefaultValue: "M");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(48)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");
        }
    }
}
