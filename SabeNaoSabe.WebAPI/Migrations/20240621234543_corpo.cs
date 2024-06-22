using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SabeNaoSabe.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class corpo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Corpo",
                table: "Questionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corpo",
                table: "Questionarios");
        }
    }
}
