using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveViewCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5783), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5783) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5810), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5811) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5812), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5813) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5814), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5814) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5817), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5819), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5820), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5822), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5823) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5824), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5834), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5842), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5844), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5846) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5847), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5849), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5850) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5851), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5859), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5861), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5861) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5863), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5863) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5865), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5865) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5867), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5867) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5869), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5869) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5871) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5873), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5875) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5885), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5897), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5899), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5901), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5901) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5903), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5903) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5904), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5905) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5907) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5910), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5910) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5912), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5914), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5923) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5924), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5925) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5926), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5928), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5930), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5932), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5932) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5934), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5936), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5938), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5940), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5949), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5951), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5953) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5955), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5955) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5957), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5957) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5959), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5959) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5961), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5962), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5964), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5973), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5975), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5976) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5977), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5977) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5979), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5983), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5983) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5985), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5987), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5987) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5989), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5997), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5997) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5999), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6001), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6003), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6003) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6010), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6012), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6012) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6013), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6014) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6015), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6016) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6017), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6019), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6019) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6028), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6028) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6032), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6035), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6036) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6037) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6039), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6039) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6041), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6041) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6043), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6043) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6045), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6045) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6053), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6053) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6055), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6055) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6057), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6059), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6061), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6063), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6065), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6065) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6067), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6067) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6068), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6080), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6082), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6084), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6085), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6086) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6087), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6089), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6091), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6091) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6093), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6093) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6095), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6095) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6103), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6104) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6105), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6107), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6107) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6109), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6111), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6111) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6113), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6113) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6115), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6117), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6119), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6128), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6128) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6131), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6131) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6133), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6133) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6135), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6137), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6139), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6146), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6148), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6148) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6152), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6161), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6161) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6163), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6163) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6165), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6166), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6167) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6168), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6169) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6172), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6172) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6174), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6174) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6176), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6176) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6178), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6185), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6187), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6187) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6189), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6189) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6191), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6191) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6193), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6193) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6195), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6197), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(6197) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(8702), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(8714) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9034), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9034) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9037), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9037), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9038), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9039), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9040), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9041), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9041) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9042), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9042), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9044), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9045), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9045) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9045), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9046), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9047), new DateTime(2026, 2, 7, 11, 18, 54, 490, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3490), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3625), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3625) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3626), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3627), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3628), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3628) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3629), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3629) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3649), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3664), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3664) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3664), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3665) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3665), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3665) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3666), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3666) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3667), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3667) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3668), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3669), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3669), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3671), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3671) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3672), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3673), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3674), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3674) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3675), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3675) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3675), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3676), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3677), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3678), new DateTime(2026, 2, 7, 11, 18, 54, 491, DateTimeKind.Utc).AddTicks(3678) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(7235), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(7235) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8547), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8547) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8550), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8552), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8552) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8553), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8557), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8558) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8559), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8561), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8563), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8563) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8565), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8581), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8582) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8583), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8585), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8585) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8588), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8591), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8591) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8593), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8595), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8597), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8609), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8611), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8611) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8620), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8622), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8624), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8626), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8626) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8628), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8630), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8632), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8634), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8634) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8635), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8637), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8647), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8649), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8651), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8654), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8656), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8656) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8657), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8658) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8659), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8661), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8661) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8663), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8665), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8665) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8674), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8674) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8676), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8678), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8678) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8680), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8682), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8684), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8686), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8687), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8689), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8690) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8691), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8700), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8702), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8704), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8704) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8706), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8706) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8708), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8708) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8710), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8711), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8713), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8714) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8715), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8717), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8717) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8726), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8726) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8728), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8729), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8731), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8732) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8733), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8733) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8741), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8741) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8743), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8743) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8745), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8745) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8747), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8747) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8757), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8759), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8761), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8763), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8765), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8767), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8768) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8769), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8771), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8772) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8773), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8774) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8775), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8785), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8787), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8789), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8791), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8792), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8793) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8794), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8795) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8796), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8798), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8798) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8800), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8802), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8802) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8810), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8812), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8812) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8814), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8814) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8816), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8816) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8818), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8818) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8820), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8822), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8824), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8825), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8827), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8835), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8837), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8837) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8839), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8839) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8841), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8841) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8842), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8844), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8846), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8846) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8848), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8848) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8850), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8852), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8862), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8862) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8864), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8866), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8866) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8868), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8868) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8870), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8870) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8871), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8872) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8873), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8880), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8880) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8881), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8882) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8883), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8893), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8895), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8895) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8897), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8899), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8899) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8901), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8901) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8902), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8903) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8904), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8908), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8920), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8922), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8923) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8924), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8926), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8928), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8928) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8930), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8932), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8934), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8934) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8935), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8937), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8946), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8946) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8948), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8948) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8950), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8952), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8953), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8954) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8955), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8957), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8959), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8961), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8970), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8972), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(8972) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(1743), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(1749) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2012) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2014), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2014) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2040), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2043) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2044), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2044) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2044), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2045), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2057), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2057) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2058), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2058) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2059), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2059), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2060) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2060), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2061), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6642), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6643) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6776), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6776) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6777), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6777) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6779), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6780), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6780) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6782), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6783), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6783) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6783), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6784) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6784), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6784) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6785), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6785) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6786), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6786) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6787), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6787) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6788), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6788) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6788), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6789), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6791), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6791) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6792), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6793), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6793), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6794) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6794), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6795) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6795), new DateTime(2026, 2, 7, 11, 4, 59, 738, DateTimeKind.Utc).AddTicks(6795) });
        }
    }
}
