using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActivityApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_ApprovedByUserId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ApprovedByUserId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(2906), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(2908) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7964), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7966) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7973), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7998), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8003), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8015), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8019), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8019) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8023), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8027), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8033), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8037), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8065), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8069), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8073), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8073) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8077), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8081) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8085), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8086) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8115), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8115) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8119), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8122), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8126), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8127) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8152), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8156), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8156) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8160), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8163), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8167), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8171), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8174), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8175) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8178), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8182), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8208), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8215), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8215) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8219), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8222), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8223) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8226), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8227) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8230), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8231) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8234), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8238), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8238) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8242), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8245), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8271), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8275), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8278), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8282), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8286), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8290), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8294), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8298), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8301), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8302) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8305), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8329), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8333), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8337), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8345), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8349), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8364), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8385), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8388), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8402), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8413), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8417), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8424), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8428), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8429) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8451), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8455), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8455) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8458), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8459) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8462), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8466), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8474), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8478), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8482), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8486), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8507), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8510), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8511) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8514), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8518), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8522), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8526), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8530), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8530) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8533), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8537), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8541), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8542) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8561), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8564), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8568), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8569) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8572), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8573) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8576), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8580), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8584), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8588), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8591), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8592) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8595), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8620), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8624), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8628), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8632), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8636), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8637) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8650), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8654), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8658), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8662), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8666), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8666) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8691), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8695), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8699), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8703), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8704) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8707), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8707) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8711), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8715), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8719), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8723), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8727), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8727) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8749), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8749) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8753), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8753) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8757), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8764), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8765) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8768), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8769) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8772), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8776), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8782), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8787), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8811), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8814), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8815) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8818), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8822), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8826), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8830), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8834), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8837), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8841), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8845), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8865), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8866) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8869), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8884), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8888), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8889) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8892), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8896), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8899), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8903), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8904) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8907), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(7369), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8182) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8184), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8186), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8186) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8187), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8188) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8189), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8238), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8241), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8243), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8245), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8246), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8249), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8251), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8252), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8254), new DateTime(2026, 2, 4, 10, 11, 19, 272, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(569), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1008), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1010), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1012), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1014), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1016), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1019), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1021), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1023), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1025), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1025) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1027), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1028), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1037), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1039), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1041) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1042), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1044), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1047), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1049), new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(1049) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Activities",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Activities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(1135), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(1135) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(3994), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4000), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4001) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4032), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4036), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4067), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4072), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4076), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4080), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4084), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4088), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4091), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4110), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4114), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4118), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4121), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4125), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4129), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4133), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4137), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4140), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4158), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4162), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4166), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4170), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4173), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4177), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4181), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4184), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4188), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4192), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4209), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4213), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4218), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4223), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4226), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4230), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4234), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4237), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4241), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4257), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4261), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4278), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4286), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4296), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4299), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4303), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4307), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4310), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4327), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4328) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4331), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4335), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4338), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4342), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4346), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4349), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4353), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4357), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4357) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4360), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4376), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4376) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4380), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4383), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4384) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4387), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4390), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4394), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4399), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4402), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4406), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4421), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4421) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4425), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4428), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4432), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4433) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4436), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4439), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4443), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4444) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4447), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4450), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4454), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4454) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4470), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4471) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4474), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4485), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4489), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4492), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4493) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4496), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4500), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4503), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4504) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4507), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4524), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4524) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4527), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4528) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4531), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4534), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4535) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4538), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4539) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4542), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4545), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4546) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4549), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4553), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4556), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4573), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4576), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4580), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4584), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4587), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4591), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4595), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4598), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4602), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4603) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4619), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4619) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4622), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4626), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4630), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4633), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4637), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4637) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4641), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4644), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4648), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4648) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4664), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4668), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4672), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4675), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4679), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4679) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4683), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4686), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4702), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4703) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4706), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4710), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4726), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4730), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4733), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4737), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4742), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4743) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4746), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4750), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4753), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4757), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4774), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4778), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4778) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4786), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4787) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4790), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4794), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4797), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4798) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4801), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4801) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4805), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4805) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4808), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4825), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4829), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4832), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4836), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4840), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4844), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4847), 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2402), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2402) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2404), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2404) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2405), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2406) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2407), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2407) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2409), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2409) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2410), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2411) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2412), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2412) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2413), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2414) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2415), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2415) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2416), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2418), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2419), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2421), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2422) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2423), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(2423) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(9918), new DateTime(2026, 1, 30, 16, 21, 4, 325, DateTimeKind.Utc).AddTicks(9919) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(224), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(225), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(226) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(227), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(227) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(229), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(229) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(231) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(232), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(233) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(234), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(234) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(235), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(236) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(237), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(238), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(239) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(242), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(242) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(243), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(245), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(246), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(248), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(248) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(249), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(251), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(251) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(252), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(253) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(254), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(255), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(256) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(257), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(257) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(259), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(259) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(260), new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(261) });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ApprovedByUserId",
                table: "Activities",
                column: "ApprovedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_ApprovedByUserId",
                table: "Activities",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
