using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SabeNaoSabe.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addImageUrllist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrlList",
                table: "Questionarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrlList",
                table: "Questionarios");
        }
    }
}
