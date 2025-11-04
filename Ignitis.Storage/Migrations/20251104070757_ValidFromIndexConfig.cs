using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ignitis.Storage.Migrations
{
    /// <inheritdoc />
    public partial class ValidFromIndexConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PowerPlants_ValidFrom",
                table: "PowerPlants",
                column: "ValidFrom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PowerPlants_ValidFrom",
                table: "PowerPlants");
        }
    }
}
