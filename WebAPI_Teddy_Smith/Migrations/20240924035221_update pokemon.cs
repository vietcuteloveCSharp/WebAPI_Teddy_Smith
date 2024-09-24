using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Teddy_Smith.Migrations
{
    /// <inheritdoc />
    public partial class updatepokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Pokemons");
        }
    }
}
