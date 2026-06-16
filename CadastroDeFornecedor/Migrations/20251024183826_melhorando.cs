using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estagio.Migrations
{
    /// <inheritdoc />
    public partial class melhorando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPath",
                table: "Fornecedores",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPath",
                table: "Fornecedores");
        }
    }
}
