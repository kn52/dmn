using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class villaforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("2eb83924-dd11-474b-a9cb-28a8e57aa7a4"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("4606beb6-95b4-4cdd-9b81-1f31d56f7971"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("68f1b833-1bae-44d7-8152-e82fe7bc539d"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("789dbb16-5363-44fc-9395-6d56f39950f4"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("9eefe2b1-a0cb-4a25-b959-018ae2f2c7a9"));

            migrationBuilder.AddColumn<Guid>(
                name: "VillaId",
                table: "villa_numbers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("048ea2b2-5bd2-4537-b098-11034e29693e"), "", "28-02-2024 23:57:34", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "28-02-2024 23:57:34" },
                    { new Guid("1527385c-290d-4635-9216-52b18704bdb8"), "", "28-02-2024 23:57:34", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "28-02-2024 23:57:34" },
                    { new Guid("279b0ce2-0166-4845-9231-6250e98dffb9"), "", "28-02-2024 23:57:34", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "28-02-2024 23:57:34" },
                    { new Guid("92d48d8c-0494-4350-afa1-342a720f3348"), "", "28-02-2024 23:57:34", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "28-02-2024 23:57:34" },
                    { new Guid("bd4bdc2f-07b1-4207-a070-5e94ba331abc"), "", "28-02-2024 23:57:34", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "28-02-2024 23:57:34" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_villa_numbers_VillaId",
                table: "villa_numbers",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_villa_numbers_Villa_VillaId",
                table: "villa_numbers",
                column: "VillaId",
                principalTable: "Villa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villa_numbers_Villa_VillaId",
                table: "villa_numbers");

            migrationBuilder.DropIndex(
                name: "IX_villa_numbers_VillaId",
                table: "villa_numbers");

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("048ea2b2-5bd2-4537-b098-11034e29693e"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("1527385c-290d-4635-9216-52b18704bdb8"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("279b0ce2-0166-4845-9231-6250e98dffb9"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("92d48d8c-0494-4350-afa1-342a720f3348"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("bd4bdc2f-07b1-4207-a070-5e94ba331abc"));

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "villa_numbers");

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("2eb83924-dd11-474b-a9cb-28a8e57aa7a4"), "", "28-02-2024 22:37:09", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "28-02-2024 22:37:09" },
                    { new Guid("4606beb6-95b4-4cdd-9b81-1f31d56f7971"), "", "28-02-2024 22:37:09", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "28-02-2024 22:37:09" },
                    { new Guid("68f1b833-1bae-44d7-8152-e82fe7bc539d"), "", "28-02-2024 22:37:09", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "28-02-2024 22:37:09" },
                    { new Guid("789dbb16-5363-44fc-9395-6d56f39950f4"), "", "28-02-2024 22:37:09", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "28-02-2024 22:37:09" },
                    { new Guid("9eefe2b1-a0cb-4a25-b959-018ae2f2c7a9"), "", "28-02-2024 22:37:09", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "28-02-2024 22:37:09" }
                });
        }
    }
}
