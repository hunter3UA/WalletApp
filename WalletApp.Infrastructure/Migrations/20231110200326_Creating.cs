using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Creating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Sum = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Pending = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizedUser = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ExecutedDay = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2023, 11, 10, 20, 3, 26, 181, DateTimeKind.Unspecified).AddTicks(9344), new TimeSpan(0, 0, 0, 0, 0))),
                    IconUrl = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.CheckConstraint("CK_Type_Range", "\"Type\">=0 or \"Type\"<=1");
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AuthorizedUser", "Description", "ExecutedDay", "IconUrl", "Name", "Pending", "Sum", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d07e6ad-78a5-4044-a5fd-11373dc50595"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", false, 318.14m, 1, 1 },
                    { new Guid("186a852d-6260-412a-97ca-61264d495321"), null, "Morning transaction", new DateTimeOffset(new DateTime(2023, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "Discord", false, 318m, 1, 1 },
                    { new Guid("3d80b86d-b4e3-426a-8ff8-70c5bf28eece"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", false, 100m, 1, 1 },
                    { new Guid("52d059dc-56ac-473a-b8c8-4d12b8545cdc"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", false, 300m, 1, 1 },
                    { new Guid("6237c5d2-c58d-4666-bd0a-c2af5a37defa"), "User1", null, new DateTimeOffset(new DateTime(2023, 11, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "Netflix", false, 115.52m, 0, 1 },
                    { new Guid("9a8cb430-bbf7-40eb-8552-3c47530d89c3"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", true, 250m, 0, 1 },
                    { new Guid("9ff1eb67-c34c-4bdc-813f-afd671d2ede0"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 3, 3, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", false, 415.82m, 1, 1 },
                    { new Guid("d0f3b8b4-eab1-4e98-8813-5c3dfa16aeb7"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", true, 500m, 1, 1 },
                    { new Guid("d8dec4cd-6de4-4711-ae9e-09e268a0ec1e"), "Oleg", null, new DateTimeOffset(new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "Spotify", false, 200.4m, 1, 1 },
                    { new Guid("f085a327-9fd5-4cf8-a878-6ed60eae28c9"), "Oleksandr", null, new DateTimeOffset(new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "Apple", true, 300m, 0, 1 },
                    { new Guid("f1f8bde8-c0b6-4b02-8445-aef65a86eac6"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 3, 4, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", true, 400.51m, 1, 1 },
                    { new Guid("f3a67c4e-2c36-4581-9c92-03e9694c82b4"), null, null, new DateTimeOffset(new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "Steam", false, 400m, 1, 1 },
                    { new Guid("f6fb8e09-f67a-49bd-b121-6c05651a9740"), null, null, new DateTimeOffset(new DateTime(2023, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "YouTube", false, 200.34m, 0, 1 },
                    { new Guid("f82c3e96-7e4e-406e-a248-96866249a786"), null, "For goods", new DateTimeOffset(new DateTime(2023, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "https://defaultImage.jpg", "IKEA", false, 599.12m, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
