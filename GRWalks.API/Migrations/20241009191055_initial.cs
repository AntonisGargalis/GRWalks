using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DifficultyId",
                table: "Walks",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UUID");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Difficulties",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "UUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "DifficultyId",
                table: "Walks",
                type: "UUID",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Difficulties",
                type: "UUID",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
