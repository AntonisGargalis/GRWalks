using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangenameofDiff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_difficulties",
                table: "difficulties");

            migrationBuilder.RenameTable(
                name: "difficulties",
                newName: "Difficulties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties");

            migrationBuilder.RenameTable(
                name: "Difficulties",
                newName: "difficulties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_difficulties",
                table: "difficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
