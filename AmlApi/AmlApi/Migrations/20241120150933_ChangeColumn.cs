using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmlApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Locations_LocationKey",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Branch_BranchKey",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "Branches",
                newName: "IsEnabled");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_LocationKey",
                table: "Branches",
                newName: "IX_Branches_LocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Locations_LocationKey",
                table: "Branches",
                column: "LocationKey",
                principalTable: "Locations",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Branches_BranchKey",
                table: "Inventories",
                column: "BranchKey",
                principalTable: "Branches",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Locations_LocationKey",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Branches_BranchKey",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameColumn(
                name: "IsEnabled",
                table: "Branch",
                newName: "Enabled");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_LocationKey",
                table: "Branch",
                newName: "IX_Branch_LocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Locations_LocationKey",
                table: "Branch",
                column: "LocationKey",
                principalTable: "Locations",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Branch_BranchKey",
                table: "Inventories",
                column: "BranchKey",
                principalTable: "Branch",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
