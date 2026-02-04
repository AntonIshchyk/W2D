using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_CreatedByUserId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_CreatedByUserId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Activities");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9486), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(863), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(865), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(888) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(892), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(894), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(902), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(902) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(903), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(904) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(906), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(914), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(916), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(917) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(922) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(924), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(926), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(928), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(931), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(939), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(941), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(943), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(945), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(947), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(959), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(963), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(974), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(976), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(976) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(978), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(982), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(982) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(984), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(984) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(986), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(986) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(988), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(988) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(999), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1005), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1009), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1009) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1011), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1012), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1014), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1028), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1038), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1048), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1054), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1056), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1059), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1061), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1082), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1084), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1086), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1088), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1088) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1091), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1092) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1093), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1094) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1095), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1096) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1097), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1097) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1105), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1105) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1107), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1109), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1109) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1111), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1111) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1113), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1114), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1115) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1116), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1117) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1119) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1122), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1122) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1132), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1132) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1134), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1134) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1135), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1136) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1137), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1138) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1139), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1141), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1143), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1143) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1145), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1145) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1147), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1147) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1155), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1156) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1157), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1158) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1159), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1161), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1163), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1165), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1165) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1167), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1167) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1171), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1173), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1186), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1186) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1192), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1192) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1196), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1198), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1198) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1208), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1209), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1219), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1219) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1221), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1221) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1222), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1223) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1224), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1225) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1226), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1241), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1242) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1243), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1245), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1245) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1249), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1253), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1253) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1255), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1257), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1257) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1259), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1267) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1269) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1271) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1272), new DateTime(2026, 2, 4, 11, 16, 18, 434, DateTimeKind.Utc).AddTicks(1272) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4507), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4507) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4509), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4509) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4510), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4510) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4511), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4511) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4512), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4512), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4513) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4513), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4514), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4515), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4515) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4516), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4516) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4517), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4518), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4519), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4519) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8854), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8854) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8985), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8986), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8987), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8988), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8989), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8990), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9009), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9011), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9012), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9013), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9013) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9014), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9014) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9014), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9015), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9016) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9016), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9016) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9017), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9017) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9018), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9019), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9019) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9020), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9020) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9021), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9037), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9038), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9038) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9038), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9039), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9040), new DateTime(2026, 2, 4, 11, 16, 18, 433, DateTimeKind.Utc).AddTicks(9040) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Activities",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(2906), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(2908) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7964), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7966) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7973), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7998), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8003), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8015), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8019), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8019) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8023), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8027), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8027) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8033), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8033) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8037), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8040), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8065), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8069), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8073), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8073) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8077), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8080), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8081) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8085), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8086) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8115), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8115) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8119), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8122), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8126), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8127) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8148), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8152), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8156), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8156) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8160), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8163), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8167), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8171), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8174), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8175) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8178), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8182), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8208), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8215), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8215) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8219), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8222), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8223) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8226), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8227) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8230), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8231) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8234), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8238), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8238) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8242), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8245), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8271), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8275), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8278), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8282), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8286), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8290), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8294), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8298), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8301), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8302) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8305), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8329), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8333), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8337), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8341), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8345), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8349), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8353), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8357), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8360), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8364), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8385), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8388), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8402), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8409), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8413), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8417), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8420), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8424), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8428), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8429) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8451), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8451) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8455), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8455) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8458), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8459) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8462), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8466), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8470), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8474), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8478), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8482), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8486), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8507), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8510), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8511) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8514), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8518), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8522), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8526), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8530), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8530) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8533), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8537), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8541), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8542) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8561), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8564), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8568), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8569) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8572), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8573) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8576), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8580), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8584), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8588), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8591), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8592) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8595), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8620), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8624), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8628), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8632), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8636), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8637) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8650), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8654), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8658), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8662), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8662) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8666), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8666) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8691), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8695), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8699), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8703), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8704) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8707), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8707) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8711), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8715), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8719), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8723), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8727), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8727) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8749), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8749) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8753), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8753) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8757), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8760), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8764), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8765) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8768), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8769) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8772), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8776), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8782), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8787), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8811), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8814), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8815) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8818), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8822), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8826), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8830), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8834), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8837), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8841), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8845), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8865), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8866) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8869), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8884), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8888), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8889) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8892), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8896), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8899), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8903), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8904) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "CreatedByUserId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8907), null, new DateTime(2026, 2, 4, 10, 11, 19, 274, DateTimeKind.Utc).AddTicks(8908) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatedByUserId",
                table: "Activities",
                column: "CreatedByUserId");

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
