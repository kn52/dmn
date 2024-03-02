using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class nunalble2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("42fa1e57-8c3a-4a04-8406-961c371d12b8"), "", "03-03-2024 02:44:47", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "03-03-2024 02:44:47" },
                    { new Guid("59732f91-7c2b-4212-bf20-b75559ee5ed2"), "", "03-03-2024 02:44:47", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "03-03-2024 02:44:47" },
                    { new Guid("8cf35f3e-b1ab-45ba-aa37-991c5510ae3e"), "", "03-03-2024 02:44:47", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "03-03-2024 02:44:47" },
                    { new Guid("93c0e67b-e793-4c4a-871e-64ba34346442"), "", "03-03-2024 02:44:47", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "03-03-2024 02:44:47" },
                    { new Guid("f382c7b1-efdc-4c60-ad52-405d9a745568"), "", "03-03-2024 02:44:47", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "03-03-2024 02:44:47" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("42fa1e57-8c3a-4a04-8406-961c371d12b8"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("59732f91-7c2b-4212-bf20-b75559ee5ed2"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("8cf35f3e-b1ab-45ba-aa37-991c5510ae3e"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("93c0e67b-e793-4c4a-871e-64ba34346442"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("f382c7b1-efdc-4c60-ad52-405d9a745568"));
        }
    }
}
