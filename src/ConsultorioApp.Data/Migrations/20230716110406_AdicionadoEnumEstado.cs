using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoEnumEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Tb_Clientes",
                type: "varchar(48)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Enderecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
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

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Enderecos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
