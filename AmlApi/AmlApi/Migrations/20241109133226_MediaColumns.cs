using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmlApi.Migrations
{
    /// <inheritdoc />
    public partial class MediaColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Inventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Inventories",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Inventories");
        }
    }
}
