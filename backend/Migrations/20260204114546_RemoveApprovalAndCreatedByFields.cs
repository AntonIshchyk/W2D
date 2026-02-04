using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveApprovalAndCreatedByFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_ApprovedByUserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_CreatedByUserId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ApprovedByUserId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CreatedByUserId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3955), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5236), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5237) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5239), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5241), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5243), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5243) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5246), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5246) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5261), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5261) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5263), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5265), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5265) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5267), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5267) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5269), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5271), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5271) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5273), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5273) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5275), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5277), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5277) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5279), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5279) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5287), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5289), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5291), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5291) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5293), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5293) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5295), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5297), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5299), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5300), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5301) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5302), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5302) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5304), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5304) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5312), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5313) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5314), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5315) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5316), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5318), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5318) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5320), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5320) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5322), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5322) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5324), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5326), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5328), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5328) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5330), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5330) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5346), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5346) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5348), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5350), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5350) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5352), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5353), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5355), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5355) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5357), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5357) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5359), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5361), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5361) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5369), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5369) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5371), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5371) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5372), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5373) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5374), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5375) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5376), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5377) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5378), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5378) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5380), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5382), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5382) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5384), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5384) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5385), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5386) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5394), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5395), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5396) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5397), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5399), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5399) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5401), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5401) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5403), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5403) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5405), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5405) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5407), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5407) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5408), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5409) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5410), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5419), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5419) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5421), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5423), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5423) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5424), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5425) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5426), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5428), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5432), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5432) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5434), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5436), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5436) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5443), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5444) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5445), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5445) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5447), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5447) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5449), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5449) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5451), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5451) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5453), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5453) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5455), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5455) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5456), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5457) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5463), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5464) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5465), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5465) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5474), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5476), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5476) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5478), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5482), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5482) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5483), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5485), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5487), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5489), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5489) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5491), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5491) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5500), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5502), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5503), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5505), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5507), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5509), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5509) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5511), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5513), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5515), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5515) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5517), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5517) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5525), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5525) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5526), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5527) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5528), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5529) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5530), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5532), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5532) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5534), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5534) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5536), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5536) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5538), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5540), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5541), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5542) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5550), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5552), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5552) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5553), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5554) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5555), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5555) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5557), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5557) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5559), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5559) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5561), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5561) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5563), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5563) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5565), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5565) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5573), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5573) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5575), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5577), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5577) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5578), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5580), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5581) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5588), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5588) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5590), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5591), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5593), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5594) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5595), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5595) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5604), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5606), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5606) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5607), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5609), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5609) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5611), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5611) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5613), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5613) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5615), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5615) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5617), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5618), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5619) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5620), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5629), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5629) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5630), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5632), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5634), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5635) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5636), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5638), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(5638) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(8694), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(8698) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9082), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9083), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9083) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9084), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9085), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9086), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9087), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9087), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9088), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9089), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9089) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9090), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9091), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9091), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9093), new DateTime(2026, 2, 4, 11, 45, 45, 678, DateTimeKind.Utc).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3317), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3453), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3453) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3454), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3454), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3456), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3456) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3457), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3459), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3461), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3461) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3462), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3462) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3478), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3479), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3479) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3504), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3505) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3506), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3507), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3507) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3508), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3508), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3509), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3511), new DateTime(2026, 2, 4, 11, 45, 45, 679, DateTimeKind.Utc).AddTicks(3511) });
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
                name: "CreatedByUserId",
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
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(1135), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(1135) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(3994), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4000), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4001) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4032), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4036), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4067), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4072), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4076), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4080), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4084), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4088), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4091), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4110), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4114), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4118), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4121), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4125), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4129), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4133), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4137), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4140), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4158), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4162), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4166), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4170), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4173), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4177), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4181), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4184), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4188), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4192), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4209), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4213), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4218), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4223), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4226), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4230), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4234), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4237), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4241), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4257), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4261), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4278), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4286), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4296), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4299), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4303), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4307), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4310), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4327), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4328) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4331), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4335), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4338), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4342), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4346), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4349), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4353), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4357), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4357) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4360), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4376), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4376) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4380), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4383), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4384) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4387), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4390), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4394), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4399), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4402), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4403) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4406), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4421), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4421) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4425), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4428), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4432), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4433) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4436), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4439), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4443), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4444) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4447), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4450), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4454), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4454) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4470), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4471) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4474), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4485), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4489), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4492), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4493) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4496), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4500), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4503), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4504) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4507), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4524), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4524) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4527), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4528) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4531), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4534), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4535) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4538), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4539) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4542), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4545), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4546) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4549), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4553), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4556), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4557) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4573), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4576), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4580), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4584), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4587), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4591), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4595), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4598), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4602), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4603) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4619), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4619) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4622), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4626), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4630), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4633), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4637), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4637) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4641), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4644), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4648), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4648) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4664), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4668), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4672), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4675), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4679), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4679) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4683), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4686), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4702), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4703) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4706), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4710), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4726), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4730), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4733), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4737), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4742), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4743) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4746), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4750), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4753), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4757), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4774), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4778), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4778) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4786), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4787) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4790), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4794), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4797), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4798) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4801), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4801) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4805), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4805) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4808), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4825), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4829), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4832), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4836), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4840), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4844), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "ApprovedByUserId", "CreatedAt", "CreatedByUserId", "Status", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4847), null, 1, new DateTime(2026, 1, 30, 16, 21, 4, 326, DateTimeKind.Utc).AddTicks(4848) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatedByUserId",
                table: "Activities",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_ApprovedByUserId",
                table: "Activities",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_CreatedByUserId",
                table: "Activities",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
