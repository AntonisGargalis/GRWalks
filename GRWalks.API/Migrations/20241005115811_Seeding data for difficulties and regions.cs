using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GRWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("29584951-fab9-49b0-971b-5beb9dcb1fb2"), "Medium" },
                    { new Guid("a6f659ed-e040-42a9-80ca-60318dc9682f"), "Easy" },
                    { new Guid("cc3576f3-cc0b-4798-9075-39dd960b0e0b"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("30041b4f-0368-4b58-b48f-2bf3f374da17"), "AI", "Aegean Islands", "https://mice.gr/wp-content/uploads/2017/01/aegean_islands.jpg" },
                    { new Guid("4083319c-5aa3-4527-850f-9d65b1c08ea8"), "CG", "Central Greece", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Location_map_of_CentralGreece_%28Greece%29.svg/1200px-Location_map_of_CentralGreece_%28Greece%29.svg.png" },
                    { new Guid("56df7c1e-2f30-4de4-8996-972297a27d1d"), "TS", "Thessaly", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Location_map_of_Thessaly_%28Greece%29.svg/800px-Location_map_of_Thessaly_%28Greece%29.svg.png" },
                    { new Guid("9467927f-2dd2-401d-8489-9acec073d257"), "II", "Ionian Islands", "https://mice.gr/wp-content/uploads/2017/01/ionian.jpg" },
                    { new Guid("d4e17e88-7fcb-4001-8792-e1550bd67426"), "MD", "Macedonia", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRLZ5Ewoc38qb7ABx-22X_oA56vormcLrezGw&s" },
                    { new Guid("d9024e7f-1a6a-4c34-aa67-770b051e2b56"), "TH", "Thrace", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/Location_map_of_Thrace_%28Greece%29.svg/1200px-Location_map_of_Thrace_%28Greece%29.svg.png" },
                    { new Guid("ebc8cfba-8311-47db-a979-0ff008a48e3f"), "PL", "Peleponnese", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Location_map_of_Peloponnese_%28Greece%29.svg/1200px-Location_map_of_Peloponnese_%28Greece%29.svg.png" },
                    { new Guid("fbe553ae-2d46-46c0-a950-c8655988c403"), "EP", "Epirus", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDvkxKw7Y3e2kIe6tSPqLaE5cQ2qATwcfpfg&s" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("29584951-fab9-49b0-971b-5beb9dcb1fb2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a6f659ed-e040-42a9-80ca-60318dc9682f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc3576f3-cc0b-4798-9075-39dd960b0e0b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("30041b4f-0368-4b58-b48f-2bf3f374da17"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4083319c-5aa3-4527-850f-9d65b1c08ea8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("56df7c1e-2f30-4de4-8996-972297a27d1d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9467927f-2dd2-401d-8489-9acec073d257"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d4e17e88-7fcb-4001-8792-e1550bd67426"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d9024e7f-1a6a-4c34-aa67-770b051e2b56"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ebc8cfba-8311-47db-a979-0ff008a48e3f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fbe553ae-2d46-46c0-a950-c8655988c403"));
        }
    }
}
