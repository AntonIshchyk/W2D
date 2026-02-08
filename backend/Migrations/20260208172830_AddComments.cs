using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentVotes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentVotes_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVotes_CommentId",
                table: "CommentVotes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVotes_UserId_CommentId",
                table: "CommentVotes",
                columns: new[] { "UserId", "CommentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentVotes");

            migrationBuilder.DropTable(
                name: "Comments");

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
    }
}
