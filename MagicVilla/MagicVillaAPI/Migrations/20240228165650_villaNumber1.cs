using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class villaNumber1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_villa_numbers",
                table: "villa_numbers");

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("7c6d56ad-5f5f-4210-808a-47099cbf6c81"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("c7e8eba4-196c-4598-95ad-cab683a63620"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("ce9c324d-419d-4525-9e14-862f921d1f04"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("ef463a38-fa6d-4ff7-b8a4-ba4fb65ca56c"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("f216ff5a-4b8e-4869-9ab2-6ee08675158c"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "villa_numbers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_villa_numbers",
                table: "villa_numbers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("01eea309-3290-406c-855a-fbe60a2d3eba"), "", "28-02-2024 22:26:49", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "28-02-2024 22:26:49" },
                    { new Guid("0bf62bab-5246-4944-a77d-2e27e79b7c7a"), "", "28-02-2024 22:26:49", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "28-02-2024 22:26:49" },
                    { new Guid("0c195fcc-b4c6-4079-8019-8524f37876c3"), "", "28-02-2024 22:26:49", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "28-02-2024 22:26:49" },
                    { new Guid("7528e527-8513-4902-9ab2-e4fd46f08ad6"), "", "28-02-2024 22:26:49", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "28-02-2024 22:26:49" },
                    { new Guid("c0e6199a-f07f-44c3-9aff-f1b275f3b3f9"), "", "28-02-2024 22:26:49", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "28-02-2024 22:26:49" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_villa_numbers",
                table: "villa_numbers");

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("01eea309-3290-406c-855a-fbe60a2d3eba"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("0bf62bab-5246-4944-a77d-2e27e79b7c7a"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("0c195fcc-b4c6-4079-8019-8524f37876c3"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("7528e527-8513-4902-9ab2-e4fd46f08ad6"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("c0e6199a-f07f-44c3-9aff-f1b275f3b3f9"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "villa_numbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_villa_numbers",
                table: "villa_numbers",
                column: "VillaNo");

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("7c6d56ad-5f5f-4210-808a-47099cbf6c81"), "", "28-02-2024 20:41:01", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "28-02-2024 20:41:01" },
                    { new Guid("c7e8eba4-196c-4598-95ad-cab683a63620"), "", "28-02-2024 20:41:01", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "28-02-2024 20:41:01" },
                    { new Guid("ce9c324d-419d-4525-9e14-862f921d1f04"), "", "28-02-2024 20:41:01", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "28-02-2024 20:41:01" },
                    { new Guid("ef463a38-fa6d-4ff7-b8a4-ba4fb65ca56c"), "", "28-02-2024 20:41:01", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "28-02-2024 20:41:01" },
                    { new Guid("f216ff5a-4b8e-4869-9ab2-6ee08675158c"), "", "28-02-2024 20:41:01", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "28-02-2024 20:41:01" }
                });
        }
    }
}
