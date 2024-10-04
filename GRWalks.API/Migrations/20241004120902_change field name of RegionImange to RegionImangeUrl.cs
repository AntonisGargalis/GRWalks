using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class changefieldnameofRegionImangetoRegionImangeUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionImage",
                table: "Regions",
                newName: "RegionImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegionImageUrl",
                table: "Regions",
                newName: "RegionImage");
        }
    }
}
