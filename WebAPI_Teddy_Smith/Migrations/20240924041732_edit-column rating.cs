using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Teddy_Smith.Migrations
{
    /// <inheritdoc />
    public partial class editcolumnrating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
