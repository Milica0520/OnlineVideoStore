using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoRentalOnlineStore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRestriction", "Genre", "IsAvailable", "Language", "Length", "Quantity", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 13, 4, true, 0, new TimeSpan(0, 2, 28, 0, 0), 5, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, 15, 2, true, 4, new TimeSpan(0, 2, 12, 0, 0), 3, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parasite" },
                    { 3, 13, 0, false, 0, new TimeSpan(0, 2, 32, 0, 0), 0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "MovieId", "RentedOn", "ReturnedOn", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 9, 24, 18, 16, 38, 828, DateTimeKind.Local).AddTicks(7179), new DateTime(2024, 10, 1, 18, 16, 38, 828, DateTimeKind.Local).AddTicks(7226), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
