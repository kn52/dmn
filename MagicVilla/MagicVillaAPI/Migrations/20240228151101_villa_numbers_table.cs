using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class villa_numbers_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("2966d545-4f58-4ad7-8716-98eb3308879a"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("2ba5a5c2-4925-4354-a2fb-1430ef0fe1a6"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("4e7ab7da-12d2-44ef-b1df-ba0ced85bf5c"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("86e7e350-994b-4981-ac75-7b8e9835eafb"));

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: new Guid("df3f4c89-9183-40f9-83fe-f6cf545c1e77"));

            migrationBuilder.CreateTable(
                name: "villa_numbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDateTime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedDateTime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villa_numbers", x => x.VillaNo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "villa_numbers");

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

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "Amenity", "CreatedDateTime", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("2966d545-4f58-4ad7-8716-98eb3308879a"), "", "28-02-2024 02:40:51", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200, 550, "28-02-2024 02:40:51" },
                    { new Guid("2ba5a5c2-4925-4354-a2fb-1430ef0fe1a6"), "", "28-02-2024 02:40:51", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400, 750, "28-02-2024 02:40:51" },
                    { new Guid("4e7ab7da-12d2-44ef-b1df-ba0ced85bf5c"), "", "28-02-2024 02:40:51", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300, 550, "28-02-2024 02:40:51" },
                    { new Guid("86e7e350-994b-4981-ac75-7b8e9835eafb"), "", "28-02-2024 02:40:51", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600, 1100, "28-02-2024 02:40:51" },
                    { new Guid("df3f4c89-9183-40f9-83fe-f6cf545c1e77"), "", "28-02-2024 02:40:51", "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550, 900, "28-02-2024 02:40:51" }
                });
        }
    }
}
