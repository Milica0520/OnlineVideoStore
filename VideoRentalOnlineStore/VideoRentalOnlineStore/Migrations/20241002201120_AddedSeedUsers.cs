using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoRentalOnlineStore.Migrations
{
    public partial class AddedSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentedOn", "ReturnedOn" },
                values: new object[] { new DateTime(2024, 10, 2, 22, 11, 20, 200, DateTimeKind.Local).AddTicks(5852), new DateTime(2024, 10, 9, 22, 11, 20, 200, DateTimeKind.Local).AddTicks(5921) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CardNumber", "CreatedOn", "FullName", "IsSubscriptionExpired", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 28, "1234-5678-9012-3456", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana Marković", false, 0 },
                    { 2, 35, "9876-5432-1098-7654", new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan Petrović", true, 1 },
                    { 3, 22, "4567-8901-2345-6789", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maja Nikolić", false, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RentedOn", "ReturnedOn" },
                values: new object[] { new DateTime(2024, 10, 2, 21, 46, 36, 522, DateTimeKind.Local).AddTicks(4378), new DateTime(2024, 10, 9, 21, 46, 36, 522, DateTimeKind.Local).AddTicks(4449) });
        }
    }
}
