using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoCampoIdDeEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Enderecos");

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Tb_Clientes",
                type: "varchar(48)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Tb_Clientes",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(48)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
