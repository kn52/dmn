using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class villnum3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("07c027a4-3c1b-4abd-a77c-593744c50372"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("4191beec-5263-4c11-a8b8-abe62761abb5"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("43b92586-a884-4293-9e6a-ac1666e88a85"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("ceff7941-36ba-4213-af7b-419adca6e176"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("f4f1ab26-8633-4831-ab4c-208726b5049a"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("07c027a4-3c1b-4abd-a77c-593744c50372"), "", "28-02-2024 22:35:44", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "28-02-2024 22:35:44" },
                    { new Guid("4191beec-5263-4c11-a8b8-abe62761abb5"), "", "28-02-2024 22:35:44", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "28-02-2024 22:35:44" },
                    { new Guid("43b92586-a884-4293-9e6a-ac1666e88a85"), "", "28-02-2024 22:35:44", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "28-02-2024 22:35:44" },
                    { new Guid("ceff7941-36ba-4213-af7b-419adca6e176"), "", "28-02-2024 22:35:44", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "28-02-2024 22:35:44" },
                    { new Guid("f4f1ab26-8633-4831-ab4c-208726b5049a"), "", "28-02-2024 22:35:44", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "28-02-2024 22:35:44" }
                });
        }
    }
}
