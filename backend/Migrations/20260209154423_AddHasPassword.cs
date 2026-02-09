using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddHasPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPassword",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5887), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7203), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7203) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7208), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7225), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7229), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7231), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7231) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7233), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7235), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7235) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7237), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7237) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7239), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7239) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7241), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7252), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7252) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7253), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7271), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7273), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7275), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7277), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7281), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7283), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7285), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7285) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7293), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7295), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7297), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7298) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7299), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7303), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7303) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7310), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7312), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7320), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7322), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7322) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7324), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7324) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7326), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7326) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7328), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7328) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7330), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7330) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7332), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7334), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7344) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7351), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7354) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7356) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7359), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7369), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7369) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7371), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7371) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7373), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7373) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7375), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7377), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7379), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7381), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7381) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7383), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7385), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7387), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7394), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7395) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7401), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7403), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7405), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7406) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7407), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7408) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7411), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7413), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7417), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7425), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7427), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7429), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7431), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7433), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7435), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7435) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7437), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7437) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7439), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7441), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7443), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7443) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7452), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7454), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7456) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7458), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7462), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7464), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7468), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7476), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7478), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7481) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7482), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7484), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7484) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7486), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7486) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7488), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7488) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7490), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7492), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7494), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7502), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7504), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7504) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7506), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7506) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7508), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7510), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7510) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7512), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7514), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7514) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7515), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7517), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7518) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7532), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7533) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7534), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7536), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7537) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7538), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7539) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7540), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7542), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7544), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7544) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7546), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7546) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7548), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7548) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7550), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7558), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7558) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7560), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7560) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7562), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7564), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7566), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7568), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7569) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7570), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7571) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7572), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7574), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7582), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7583) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7584), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7585) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7586), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7587) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7588), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7589) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7590), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7592), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7592) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7594), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7596), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7596) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7598), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7600), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7608), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7610), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7612), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7614), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7614) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7615), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7617), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7619), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(492), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(768), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(769) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(771) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(772), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(773), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(775), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(775) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(776), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(776), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(777) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(777), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(777) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5275), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5276) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5413), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5413) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5414), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5415), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5416), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5416) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5417), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5417) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5417), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5418), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5419) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5419), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5419) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5433), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5434), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5435), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5436), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5436) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5437), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5438), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5438) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5438), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5439), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5441), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5441) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5442), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5443), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5443) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5443), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5444), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5445), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5446), new DateTime(2026, 2, 9, 15, 44, 23, 259, DateTimeKind.Utc).AddTicks(5446) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPassword",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(1157), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(1158) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2504), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2505) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2508), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2511), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2511) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2513), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2516), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2518), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2518) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2532), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2532) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2534), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2534) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2537), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2537) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2539), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2539) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2540), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2541) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2542), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2544), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2545) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2562), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2565), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2567), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2579), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2579) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2581), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2581) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2583), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2585), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2585) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2587), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2587) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2589), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2589) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2590), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2592), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2594), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2595) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2596), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2596) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2605), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2605) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2607), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2607) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2609), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2609) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2611), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2611) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2613), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2613) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2615), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2615) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2617), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2619), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2621), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2623), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2623) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2631), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2631) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2633), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2635), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2635) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2637), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2637) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2639), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2641), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2643), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2643) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2645), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2647), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2647) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2655), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2655) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2657), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2657) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2659), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2659) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2661), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2661) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2663), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2663) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2665), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2667), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2667) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2669), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2669) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2671), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2671) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2672), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2673) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2681), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2681) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2683), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2683) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2685), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2685) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2687), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2687) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2689), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2689) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2692), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2692) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2693), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2694) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2702), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2702) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2704), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2705) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2713), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2713) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2715), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2717), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2719), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2719) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2721), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2723), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2723) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2725), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2725) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2727), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2727) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2729), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2729) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2731), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2731) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2739), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2739) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2741), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2741) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2743), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2743) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2745), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2745) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2747), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2747) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2749), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2749) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2751), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2751) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2753), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2753) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2755), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2757), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2757) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2766), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2766) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2768), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2768) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2772), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2772) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2774), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2774) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2776) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2778), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2778) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2781), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2782) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2783), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2784) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2793), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2793) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2795), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2795) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2797), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2799), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2801), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2803), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2803) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2805), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2805) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2807), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2809), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2809) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2811), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2822), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2824), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2824) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2826), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2826) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2831), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2833), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2835), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2837), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2837) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2839), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2839) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2841), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2852), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2854), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2854) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2856), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2856) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2858), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2858) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2862), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2862) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2864), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2864) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2873), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2876), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2888), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2888) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2890), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2892), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2900), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2902), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2904), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2906), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2906) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2908), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2908) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2912), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2912) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2914), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2914) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2916), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2918), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2925), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2926) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2927), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2929), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2931), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2932) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2933), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(2933) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5557), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5834), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5836), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5838), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5839), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5841), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5842), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5842), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5844), new DateTime(2026, 2, 8, 17, 28, 29, 668, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(455), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(654), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(655), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(656), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(657), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(659), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(659) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(659), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(662), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(664), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(672), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(673), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(673) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(674), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(675), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(677), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(678), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 2, 8, 17, 28, 29, 669, DateTimeKind.Utc).AddTicks(679) });
        }
    }
}
