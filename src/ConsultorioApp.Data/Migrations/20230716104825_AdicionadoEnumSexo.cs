using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultorioApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoEnumSexo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Tb_Clientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldDefaultValue: "M");

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
                name: "Sexo",
                table: "Tb_Clientes",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "M",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Tb_Clientes",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(48)");
        }
    }
}
