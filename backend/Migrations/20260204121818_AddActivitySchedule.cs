using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddActivitySchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlannedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySchedules_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivitySchedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(3978), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(3979) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6511), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6516), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6519), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6519) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6522), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6523) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6528), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6531), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6531) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6534), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6534) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6537), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6538) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6559), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6562), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6562) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6565), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6566) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6568), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6569) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6572), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6575), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6575) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6578), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6581), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6582) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6585), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6586) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6588), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6589) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6604), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6607), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6607) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6610), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6613), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6614) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6617), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6617) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6620), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6623), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6623) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6626), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6627) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6629), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6633), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6648), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6649) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6651), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6652) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6655), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6655) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6658), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6658) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6672), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6672) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6675), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6678), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6682), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6682) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6685), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6685) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6688), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6688) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6705), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6708), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6711), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6711) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6714), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6717), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6720), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6721) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6724), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6724) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6727), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6745), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6749), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6752), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6755), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6755) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6758), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6759) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6761), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6762) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6764), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6768), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6768) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6771), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6771) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6774), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6789), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6792), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6795), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6796) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6798), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6799) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6802), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6802) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6805), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6808), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6812), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6816), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6819), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6835), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6838), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6841), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6844), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6848), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6851), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6851) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6854), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6857), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6867), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6885), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6885) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6888), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6891), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6895), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6898), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6898) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6901), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6901) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6904), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6904) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6907), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6908) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6914), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6929), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6933), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6933) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6936), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6936) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6939), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6939) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6942), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6945), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6949), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6949) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6952), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6952) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6955), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6955) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6958), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6959) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6974), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6974) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6977), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6977) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6980), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6983), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6984) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6987), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6987) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6993), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6993) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6996), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(6999), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7003), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7003) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7019), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7019) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7022), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7025), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7025) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7028), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7028) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7031), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7032) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7034), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7035) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7038), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7038) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7041), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7041) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7044), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7045) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7047), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7062), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7062) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7065), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7066) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7068), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7072), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7075), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7078), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7081), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7082) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7084), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7088), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7088) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7103), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7106), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7116), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7119), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7122), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7126), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7129), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7132), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7135), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7154), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7157), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7158) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7161), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7164), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7164) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7167), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7167) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7173), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7177), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7199), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7202), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7205), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(497), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(780), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(781), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(782), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(782) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(784), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(784) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(784), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(785), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(786) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(787), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(788), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(788), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5676), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5823), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5823) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5824), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5824) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5825), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5825) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5825), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5826) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5826), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5826) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5827), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5827) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5828), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5828) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5830), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5832), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5832) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5852), new DateTime(2026, 2, 4, 12, 18, 17, 919, DateTimeKind.Utc).AddTicks(5852) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2274), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2276) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2283), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2284) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2285), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2300), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2300) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2301), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2301) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2303), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2303) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2304), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2307), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2308) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2309), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2310), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2311) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2362), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2376), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2376) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2377), new DateTime(2026, 2, 4, 12, 18, 17, 923, DateTimeKind.Utc).AddTicks(2378) });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySchedules_ActivityId",
                table: "ActivitySchedules",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySchedules_UserId",
                table: "ActivitySchedules",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySchedules");

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
    }
}
