using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationType = table.Column<int>(type: "INTEGER", nullable: false),
                    CostLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    PhysicalActivityLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    Sociability = table.Column<int>(type: "INTEGER", nullable: true),
                    EquipmentLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    EntryLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTags",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTags", x => new { x.ActivitiesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ActivityTags_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    OrganizerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaxAttendees = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Events_Users_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    PlaceId = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: true),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: true),
                    CurrencyCode = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PhotoUrls = table.Column<string>(type: "TEXT", nullable: false),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAttendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAttendees_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAttendees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTags",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTags", x => new { x.EventsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventTags_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<uint>(type: "INTEGER", nullable: false),
                    ParentCommentId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PostVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostVotes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostVotes_Users_UserId",
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 19, 21, 28, 408, DateTimeKind.Utc).AddTicks(9960), "Sports", new DateTime(2026, 3, 6, 19, 21, 28, 408, DateTimeKind.Utc).AddTicks(9965) },
                    { 2, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(432), "Fitness", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(433) },
                    { 3, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(434), "Creative", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(435) },
                    { 4, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(436), "Outdoor", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(436) },
                    { 5, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(437), "Music", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(438) },
                    { 6, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(439), "Games", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(439) },
                    { 7, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(441), "Social", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(441) },
                    { 8, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(442), "Learning", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(443) },
                    { 9, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(444), "Relaxation", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(444) },
                    { 10, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(445), "Water Sports", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(446) },
                    { 11, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(447), "Winter Sports", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(447) },
                    { 12, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(448), "Performing Arts", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(449) },
                    { 13, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(450), "Crafts", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(450) },
                    { 14, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(452), "Food & Drink", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(452) },
                    { 15, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(453), "Wellness", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(454) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(7902), "Team", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(7903) },
                    { 2, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8162), "Individual", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8163) },
                    { 3, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8164), "Competitive", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8165) },
                    { 4, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8166), "Casual", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8167) },
                    { 5, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8168), "Cardio", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8168) },
                    { 6, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8169), "Strength", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8170) },
                    { 7, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8171), "Flexibility", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8171) },
                    { 8, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8173), "Artistic", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8173) },
                    { 9, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8174), "Mindful", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8175) },
                    { 10, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8176), "Adventure", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8176) },
                    { 11, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8178), "Nature", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8178) },
                    { 12, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8179), "Indoor", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8180) },
                    { 13, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8207), "Outdoor", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8208) },
                    { 14, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8209), "Family-Friendly", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8209) },
                    { 15, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8210), "Beginner-Friendly", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8211) },
                    { 16, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8212), "Water", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8213) },
                    { 17, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8214), "Ball Sports", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8214) },
                    { 18, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8215), "Racket Sports", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8216) },
                    { 19, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8217), "Winter", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8218) },
                    { 20, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8219), "Summer", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8219) },
                    { 21, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8220), "Creative", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8221) },
                    { 22, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8222), "Technical", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8223) },
                    { 23, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8224), "Social", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8224) },
                    { 24, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8226), "Extreme", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8226) },
                    { 25, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8227), "Educational", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(8228) }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "CostLevel", "CreatedAt", "Description", "EntryLevel", "EquipmentLevel", "LocationType", "PhysicalActivityLevel", "Sociability", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(9037), "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills.", 0, 1, 2, 2, 1, "Football (Soccer)", new DateTime(2026, 3, 6, 19, 21, 28, 409, DateTimeKind.Utc).AddTicks(9037) },
                    { 2, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1412), "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games.", 0, 1, 0, 2, 2, "Basketball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1413) },
                    { 3, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1417), "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment.", 0, 1, 0, 1, 1, "Volleyball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1418) },
                    { 4, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1421), "America's pastime - bat, pitch, and field in this strategic team sport.", 1, 2, 2, 1, 1, "Baseball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1421) },
                    { 5, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1424), "A high-intensity contact sport requiring strength, speed, and teamwork.", 1, 1, 2, 2, 1, "Rugby", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1425) },
                    { 6, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1430), "Fast-paced indoor sport combining elements of basketball and soccer.", 0, 1, 1, 2, 1, "Handball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1431) },
                    { 7, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1455), "Throw, dodge, and catch in this exciting and energetic team game.", 0, 1, 1, 1, 1, "Dodgeball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1456) },
                    { 8, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1459), "Tackle football with strategic plays and intense physicality.", 1, 3, 2, 2, 1, "American Football", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1460) },
                    { 9, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1463), "A fun, accessible game similar to baseball but played with a large rubber ball.", 0, 1, 2, 1, 1, "Kickball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1463) },
                    { 10, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1533), "Roll strikes and spares at your local bowling alley. Great social activity for all ages.", 0, 0, 1, 0, 2, "Bowling", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1533) },
                    { 11, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1537), "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness.", 1, 2, 2, 2, 2, "Tennis", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1537) },
                    { 12, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1541), "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility.", 0, 1, 0, 1, 2, "Badminton", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1541) },
                    { 13, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1544), "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun.", 0, 1, 1, 1, 2, "Table Tennis (Ping Pong)", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1545) },
                    { 14, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1548), "Intense racket sport played in a four-walled court. Excellent cardio workout.", 1, 2, 1, 2, 2, "Squash", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1548) },
                    { 15, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1551), "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social.", 0, 1, 0, 1, 2, "Pickleball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1552) },
                    { 16, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1555), "High-energy racket sport played in an enclosed court with a hollow rubber ball.", 1, 2, 1, 2, 2, "Racquetball", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1555) },
                    { 17, 4, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1574), "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise.", 0, 0, 2, 0, 2, "Go for a Walk", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1574) },
                    { 18, 4, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1579), "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone.", 0, 1, 2, 1, 2, "Hiking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1580) },
                    { 19, 2, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1583), "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise.", 0, 1, 2, 2, 2, "Running/Jogging", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1583) },
                    { 20, 2, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1587), "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout.", 0, 2, 2, 1, 2, "Cycling", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1587) },
                    { 21, 4, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1590), "Observe and identify birds in their natural habitat. A peaceful outdoor activity that connects you with nature.", 0, 1, 2, 0, 2, "Bird Watching", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1590) },
                    { 22, 7, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1593), "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing.", 0, 1, 2, 0, 2, "Picnicking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1594) },
                    { 23, 9, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1597), "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring activity.", 0, 0, 2, 0, 2, "Stargazing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1597) },
                    { 24, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1601), "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee.", 0, 1, 2, 1, 2, "Frisbee", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1601) },
                    { 25, 2, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1604), "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio.", 0, 1, 0, 0, 2, "Yoga", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1605) },
                    { 26, 2, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1608), "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment.", 1, 3, 1, 2, 2, "Weight Training", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1608) },
                    { 27, 2, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1623), "Low-impact exercise focusing on core strength, flexibility, and body awareness. Great for all fitness levels.", 0, 1, 0, 1, 2, "Pilates", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1624) },
                    { 28, 2, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1627), "High-intensity functional fitness program combining weightlifting, cardio, and gymnastics.", 1, 3, 1, 2, 1, "CrossFit", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1627) },
                    { 29, 2, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1631), "Dance-based fitness class with energetic Latin and international music.", 0, 0, 1, 2, 1, "Zumba", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1631) },
                    { 30, 2, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1634), "High-energy stationary bike workout often done in group classes.", 0, 3, 1, 2, 1, "Spinning/Indoor Cycling", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1635) },
                    { 31, 2, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1638), "Cardiovascular exercise routine performed to music, often in a group setting.", 0, 0, 1, 2, 1, "Aerobics", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1638) },
                    { 32, 2, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1641), "Ballet-inspired workout focusing on low-impact, high-intensity movements.", 0, 1, 1, 1, 1, "Barre", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1642) },
                    { 33, 2, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1645), "Improve flexibility and reduce muscle tension through dedicated stretching routines.", 0, 0, 0, 0, 0, "Stretching", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1645) },
                    { 34, 2, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1650), "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed.", 1, 0, 0, 2, 2, "Calisthenics", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1651) },
                    { 35, 10, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1654), "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints.", 1, 1, 0, 1, 2, "Swimming", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1654) },
                    { 36, 10, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1657), "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance.", 2, 3, 2, 2, 2, "Surfing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1658) },
                    { 37, 10, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1672), "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength.", 1, 3, 2, 1, 2, "Kayaking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1672) },
                    { 38, 10, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1675), "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore.", 0, 2, 2, 1, 2, "Paddleboarding (SUP)", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1676) },
                    { 39, 10, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1679), "Intense team water sport combining swimming, ball handling, and strategy.", 1, 1, 1, 2, 1, "Water Polo", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1679) },
                    { 40, 10, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1682), "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences.", 2, 3, 2, 1, 2, "Scuba Diving", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1683) },
                    { 41, 10, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1686), "Swim on the water surface while viewing underwater attractions through a snorkel mask.", 0, 1, 2, 0, 2, "Snorkeling", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1686) },
                    { 42, 10, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1690), "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration.", 0, 3, 2, 1, 2, "Canoeing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1690) },
                    { 43, 10, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1693), "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping.", 0, 3, 2, 1, 2, "Jet Skiing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1694) },
                    { 44, 10, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1697), "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature.", 2, 3, 2, 1, 2, "Sailing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1697) },
                    { 45, 3, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1700), "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity.", 0, 2, 1, 0, 0, "Painting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1701) },
                    { 46, 3, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1715), "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet.", 0, 1, 0, 0, 0, "Drawing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1715) },
                    { 47, 3, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1718), "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera.", 0, 2, 0, 0, 2, "Photography", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1719) },
                    { 48, 3, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1722), "Create three-dimensional art with clay, stone, metal, or other materials.", 1, 2, 1, 0, 0, "Sculpting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1722) },
                    { 49, 3, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1725), "Create functional or decorative ceramic pieces. A hands-on art form that's both creative and meditative.", 1, 3, 1, 0, 2, "Pottery", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1726) },
                    { 50, 3, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1729), "Create art using digital tools like tablets and software. Modern artistic expression.", 1, 2, 1, 0, 0, "Digital Art", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1729) },
                    { 51, 3, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1732), "The art of beautiful handwriting. Practice various lettering styles with pens and brushes.", 0, 1, 0, 0, 0, "Calligraphy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1733) },
                    { 52, 3, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1736), "Japanese paper folding art. Create intricate designs from simple paper squares.", 0, 1, 0, 0, 0, "Origami", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1736) },
                    { 53, 3, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1740), "Create visual content for digital and print media. Combine art and communication.", 1, 1, 1, 0, 0, "Graphic Design", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1740) },
                    { 54, 3, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1743), "Bring drawings and characters to life through frame-by-frame or digital animation.", 2, 2, 1, 0, 0, "Animation", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1744) },
                    { 55, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1747), "Design and create jewelry pieces using various materials and techniques.", 0, 2, 1, 0, 0, "Jewelry Making", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1747) },
                    { 56, 13, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1761), "Create custom candles with different scents, colors, and designs.", 0, 2, 1, 0, 2, "Candle Making", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1761) },
                    { 57, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1764), "Craft handmade soaps with natural ingredients and custom fragrances.", 1, 2, 1, 0, 0, "Soap Making", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1765) },
                    { 58, 13, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1768), "Build furniture, decorations, or art pieces from wood. Satisfying hands-on craft.", 1, 3, 1, 1, 0, "Woodworking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1768) },
                    { 59, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1810), "Craft items from leather including wallets, bags, and belts.", 1, 2, 1, 0, 0, "Leatherworking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1810) },
                    { 60, 5, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1814), "Learn to play acoustic or electric guitar. Great for self-expression and can be enjoyed solo or in a band.", 1, 2, 0, 0, 2, "Playing Guitar", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1814) },
                    { 61, 5, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1817), "Learn classical pieces or contemporary songs on the piano. A versatile instrument suitable for all ages.", 1, 3, 1, 0, 0, "Playing Piano", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1818) },
                    { 62, 5, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1821), "Practice singing alone or join a choir. Express yourself through music and improve your vocal skills.", 0, 0, 0, 0, 2, "Singing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1822) },
                    { 63, 5, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1825), "Learn rhythm and coordination through drumming. Great stress relief and physical workout.", 1, 3, 1, 1, 2, "Playing Drums", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1825) },
                    { 64, 5, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1829), "Master this elegant string instrument. Requires dedication but offers beautiful musical expression.", 2, 2, 0, 0, 2, "Playing Violin", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1829) },
                    { 65, 5, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1832), "Mix and create music using turntables or digital equipment. Perfect for music enthusiasts.", 1, 3, 1, 0, 2, "DJing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1833) },
                    { 66, 5, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1850), "Create original music using digital audio workstations and software.", 1, 2, 1, 0, 0, "Music Production", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1850) },
                    { 67, 5, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1854), "Provide the rhythmic foundation in bands or practice solo. Essential in many music genres.", 1, 2, 0, 0, 2, "Playing Bass Guitar", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1854) },
                    { 68, 5, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1857), "Learn this expressive wind instrument popular in jazz, classical, and contemporary music.", 1, 2, 0, 0, 2, "Playing Saxophone", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1858) },
                    { 69, 5, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1861), "Create percussion sounds and music with your mouth. No equipment needed, just practice.", 0, 0, 0, 0, 0, "Beatboxing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1862) },
                    { 70, 6, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1865), "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills.", 0, 1, 0, 0, 2, "Chess", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1865) },
                    { 71, 6, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1869), "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone.", 0, 2, 1, 0, 1, "Board Games", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1869) },
                    { 72, 6, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1872), "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports.", 0, 3, 1, 0, 2, "Video Gaming", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1873) },
                    { 73, 6, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1876), "Play poker, bridge, magic the gathering, or casual card games with friends.", 0, 1, 0, 0, 2, "Card Games", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1876) },
                    { 74, 6, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1880), "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers.", 0, 1, 0, 0, 2, "Puzzle Solving", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1880) },
                    { 75, 6, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1883), "Master the classic 3D combination puzzle. Great for developing spatial reasoning.", 1, 1, 0, 0, 0, "Rubik's Cube", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1884) },
                    { 76, 6, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1898), "Throw darts at a target board. Fun pub game that improves focus and precision.", 0, 1, 1, 0, 2, "Darts", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1899) },
                    { 77, 6, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1902), "Play pool, snooker, or other cue sports at a table. Strategic and social activity.", 0, 0, 1, 0, 2, "Pool/Billiards", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1902) },
                    { 78, 6, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1906), "Test your knowledge in trivia nights or quiz games. Great for groups and learning.", 0, 0, 0, 0, 1, "Trivia/Quiz Games", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1906) },
                    { 79, 6, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1909), "Solve puzzles and riddles to 'escape' from a themed room within a time limit.", 0, 0, 1, 0, 1, "Escape Rooms", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1910) },
                    { 80, 14, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1913), "Experiment in the kitchen with new recipes. Cook meals for yourself or loved ones.", 0, 2, 1, 0, 2, "Cooking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1914) },
                    { 81, 14, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1917), "Bake bread, cakes, cookies, and pastries. A precise and rewarding culinary art.", 0, 2, 1, 0, 2, "Baking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1917) },
                    { 82, 14, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1920), "Explore different coffee beans, roasts, and brewing methods. Develop your palate.", 0, 2, 0, 0, 2, "Coffee Tasting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1921) },
                    { 83, 14, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1924), "Sample and appreciate different wines. Learn about varieties, regions, and pairing.", 0, 0, 0, 0, 2, "Wine Tasting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1924) },
                    { 84, 14, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1928), "Brew your own beer, cider, or kombucha. A fascinating blend of science and art.", 1, 2, 1, 0, 0, "Homebrewing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1928) },
                    { 85, 7, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1931), "Learn various dance styles from salsa to hip-hop. Great exercise and a fun social activity.", 0, 0, 0, 2, 2, "Dancing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1931) },
                    { 86, 7, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1945), "Give back to your community through volunteer work. A rewarding way to make a positive impact.", 0, 0, 0, 0, 1, "Volunteering", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1946) },
                    { 87, 7, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1949), "Join a group to read and discuss books. Combine reading with social interaction.", 0, 0, 0, 0, 1, "Book Club", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1949) },
                    { 88, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1952), "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination.", 0, 0, 0, 0, 0, "Reading", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1953) },
                    { 89, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1956), "Study a new language through apps, courses, or tutors. Expand your communication skills and cultural understanding.", 0, 0, 0, 0, 2, "Learning a Language", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1956) },
                    { 90, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1960), "Learn to code in various programming languages. Build apps, websites, or automate tasks.", 1, 1, 0, 0, 2, "Coding/Programming", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1960) },
                    { 91, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1963), "Creative writing, journaling, or blogging. Express thoughts and develop storytelling skills.", 0, 1, 0, 0, 0, "Writing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1964) },
                    { 92, 8, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1967), "Create and share audio content on topics you're passionate about. Express ideas and connect with audiences.", 1, 2, 0, 0, 2, "Podcasting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1967) },
                    { 93, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1970), "Share your thoughts, experiences, or expertise through written or video blogs.", 0, 1, 0, 0, 0, "Blogging/Vlogging", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1971) },
                    { 94, 8, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1974), "Take structured online courses on platforms like Coursera, Udemy, or edX. Learn anything from anywhere.", 0, 1, 3, 0, 0, "Online Courses", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1974) },
                    { 95, 8, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1977), "Study celestial objects and phenomena. Combine observation with scientific learning.", 0, 2, 2, 0, 2, "Astronomy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1978) },
                    { 96, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1991), "Explore philosophical texts and ideas. Develop critical thinking and question fundamental concepts.", 1, 0, 0, 0, 2, "Philosophy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1992) },
                    { 97, 8, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1995), "Deep dive into historical periods, events, or figures. Understand the past to inform the present.", 0, 0, 0, 0, 0, "History Research", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1995) },
                    { 98, 15, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1999), "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere.", 0, 0, 0, 0, 2, "Meditation", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(1999) },
                    { 99, 9, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2002), "Grow plants, flowers, or vegetables. A relaxing hobby that connects you with nature.", 0, 1, 2, 0, 0, "Gardening", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2003) },
                    { 100, 15, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2006), "Practice this gentle martial art focused on slow, flowing movements and breath control.", 0, 0, 0, 0, 2, "Tai Chi", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2006) },
                    { 101, 15, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2009), "Learn massage techniques or receive professional massages for relaxation and muscle relief.", 0, 1, 1, 0, 2, "Massage Therapy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2010) },
                    { 102, 15, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2013), "Use essential oils for therapeutic benefits. Promote relaxation and well-being.", 0, 2, 1, 0, 0, "Aromatherapy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2013) },
                    { 103, 9, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2017), "Write daily thoughts, gratitude, or reflections. Great for mental health and self-awareness.", 0, 1, 0, 0, 0, "Journaling", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2017) },
                    { 104, 9, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2020), "Immerse yourself in nature to reduce stress and improve well-being. Simply be present in natural settings.", 0, 0, 2, 0, 2, "Nature Bathing (Shinrin-Yoku)", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2021) },
                    { 105, 15, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2024), "Practice controlled breathing techniques to reduce stress and improve focus.", 0, 0, 0, 0, 0, "Breathing Exercises", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2024) },
                    { 106, 15, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2073), "Relax in hot water or steam rooms. Great for muscle recovery and stress relief.", 0, 3, 1, 0, 2, "Hot Tub/Sauna", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2074) },
                    { 107, 9, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2077), "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres.", 0, 0, 0, 0, 2, "Listening to Music", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2078) },
                    { 108, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2081), "Traditional Japanese martial art focusing on striking techniques and kata forms.", 0, 1, 1, 2, 1, "Karate", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2082) },
                    { 109, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2085), "Train in the sweet science. Great cardio workout and learn self-defense.", 0, 2, 1, 2, 2, "Boxing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2085) },
                    { 110, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2088), "Japanese martial art focused on throws and grappling techniques.", 1, 1, 1, 2, 1, "Judo", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2089) },
                    { 111, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2092), "Korean martial art known for dynamic kicking techniques and discipline.", 0, 1, 1, 2, 1, "Taekwondo", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2092) },
                    { 112, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2095), "Ground-fighting martial art focused on submissions and positional control.", 1, 1, 1, 2, 1, "Brazilian Jiu-Jitsu", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2096) },
                    { 113, 11, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2099), "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts.", 1, 3, 2, 2, 2, "Skiing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2100) },
                    { 114, 11, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2103), "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport.", 1, 3, 2, 2, 2, "Snowboarding", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2103) },
                    { 115, 11, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2106), "Glide on ice at a rink. Fun winter activity that builds balance and leg strength.", 0, 1, 1, 1, 2, "Ice Skating", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2107) },
                    { 116, 11, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2121), "Fast-paced team sport played on ice. Requires skating ability and competitive spirit.", 2, 3, 1, 2, 1, "Ice Hockey", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2122) },
                    { 117, 11, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2125), "Slide down snowy hills on sleds. Simple, fun winter activity for all ages.", 0, 1, 2, 0, 2, "Sledding/Tobogganing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2125) },
                    { 118, 12, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2129), "Perform in plays or take acting classes. Express emotions and stories through performance.", 0, 1, 1, 1, 1, "Acting/Theater", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2129) },
                    { 119, 12, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2132), "Write and perform comedy routines. Make people laugh while expressing your unique voice.", 1, 0, 1, 0, 1, "Stand-up Comedy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2133) },
                    { 120, 12, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2136), "Perform unscripted comedy based on audience suggestions. Develops quick thinking and creativity.", 0, 0, 1, 1, 1, "Improv Comedy", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2136) },
                    { 121, 12, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2139), "Learn and perform magic illusions. Entertain others with sleight of hand and misdirection.", 1, 1, 0, 0, 2, "Magic Tricks", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2140) },
                    { 122, 12, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2143), "Learn to juggle balls, clubs, or other objects. Impressive skill that improves coordination.", 1, 1, 0, 0, 0, "Juggling", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2143) },
                    { 123, 12, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2146), "The art of silent acting through exaggerated gestures and expressions.", 0, 0, 0, 1, 2, "Mime", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2147) },
                    { 124, 13, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2150), "Create garments and accessories with knitting needles and yarn. Relaxing and productive.", 0, 1, 0, 0, 2, "Knitting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2150) },
                    { 125, 13, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2153), "Create items using a crochet hook and yarn. Similar to knitting but with different techniques.", 0, 1, 0, 0, 2, "Crocheting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2154) },
                    { 126, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2168), "Make or repair clothing and fabric items. Practical skill that allows for creative expression.", 1, 2, 1, 0, 0, "Sewing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2169) },
                    { 127, 13, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2172), "Decorate fabric with needle and thread designs. Detailed handwork that creates beautiful patterns.", 0, 1, 0, 0, 0, "Embroidery", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2172) },
                    { 128, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2175), "Sew layers of fabric together to create quilts. Combines artistry with practical warmth.", 1, 2, 1, 0, 2, "Quilting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2176) },
                    { 129, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2179), "Create fabric by interlacing threads on a loom. Ancient craft with modern applications.", 1, 3, 1, 0, 0, "Weaving", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2179) },
                    { 130, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2184), "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence.", 1, 3, 0, 2, 2, "Rock Climbing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2185) },
                    { 131, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2188), "Climb shorter walls without ropes, using crash pads. Great intro to climbing.", 0, 2, 0, 2, 2, "Bouldering", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2188) },
                    { 132, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2191), "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination.", 1, 2, 2, 1, 2, "Skateboarding", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2192) },
                    { 133, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2195), "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity.", 1, 0, 2, 2, 2, "Parkour", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2195) },
                    { 134, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2198), "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports.", 1, 2, 2, 2, 2, "BMX Biking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2199) },
                    { 135, 4, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2213), "Ride bicycles off-road on rugged terrain. Adventurous and challenging.", 1, 3, 2, 2, 2, "Mountain Biking", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2213) },
                    { 136, 1, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2216), "Jump from heights while connected to an elastic cord. Ultimate adrenaline rush.", 0, 0, 2, 1, 0, "Bungee Jumping", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2217) },
                    { 137, 1, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2220), "Jump from aircraft and freefall before deploying a parachute. Unforgettable experience.", 1, 0, 2, 1, 2, "Skydiving", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2221) },
                    { 138, 4, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2224), "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines.", 0, 2, 2, 0, 2, "Camping", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2224) },
                    { 139, 4, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2227), "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary.", 0, 2, 2, 0, 2, "Fishing", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2228) },
                    { 140, 4, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2231), "Use GPS to find hidden containers (geocaches) placed by others. Modern treasure hunting.", 0, 1, 2, 1, 2, "Geocaching", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2231) },
                    { 141, 4, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2234), "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise.", 1, 0, 2, 1, 2, "Horseback Riding", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2235) },
                    { 142, 1, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2238), "Shoot arrows at targets with a bow. Ancient skill requiring focus and precision.", 0, 2, 0, 0, 2, "Archery", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2238) },
                    { 143, 1, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2241), "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy.", 1, 3, 2, 0, 2, "Golf", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2242) },
                    { 144, 1, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2245), "Like golf but with frisbees. Throw discs into baskets across a course. Low cost and accessible.", 0, 1, 2, 0, 2, "Disc Golf", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2245) },
                    { 145, 4, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2260), "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty.", 1, 1, 2, 0, 2, "Foraging", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2260) },
                    { 146, 4, 0, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2299), "Navigate through terrain using a map and compass. Combines hiking with navigational challenges.", 1, 1, 2, 1, 2, "Orienteering", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2300) },
                    { 147, 4, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2303), "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors.", 0, 2, 2, 0, 2, "Metal Detecting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2304) },
                    { 148, 13, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2307), "Build scale models of vehicles, buildings, or figures. Detail-oriented hobby requiring patience.", 1, 2, 1, 0, 0, "Model Building", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2307) },
                    { 149, 9, 1, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2310), "Collect stamps, coins, cards, or other items. Combines research with the thrill of the hunt.", 0, 0, 0, 0, 2, "Collecting", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2311) },
                    { 150, 3, 2, new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2314), "Fly drones and capture aerial footage. Modern hobby combining technology with creativity.", 1, 3, 2, 0, 2, "Drone Flying", new DateTime(2026, 3, 6, 19, 21, 28, 410, DateTimeKind.Utc).AddTicks(2314) }
                });

            migrationBuilder.InsertData(
                table: "ActivityTags",
                columns: new[] { "ActivitiesId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 1, 13 },
                    { 1, 17 },
                    { 1, 23 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 5 },
                    { 2, 17 },
                    { 2, 23 },
                    { 3, 1 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 14 },
                    { 3, 17 },
                    { 3, 20 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 13 },
                    { 4, 17 },
                    { 4, 20 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 13 },
                    { 5, 17 },
                    { 6, 1 },
                    { 6, 3 },
                    { 6, 5 },
                    { 6, 12 },
                    { 6, 17 },
                    { 7, 1 },
                    { 7, 4 },
                    { 7, 12 },
                    { 7, 14 },
                    { 7, 17 },
                    { 8, 1 },
                    { 8, 3 },
                    { 8, 5 },
                    { 8, 13 },
                    { 8, 17 },
                    { 9, 1 },
                    { 9, 4 },
                    { 9, 13 },
                    { 9, 14 },
                    { 9, 15 },
                    { 9, 17 },
                    { 10, 2 },
                    { 10, 4 },
                    { 10, 12 },
                    { 10, 14 },
                    { 10, 17 },
                    { 10, 23 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 5 },
                    { 11, 13 },
                    { 11, 18 },
                    { 12, 2 },
                    { 12, 4 },
                    { 12, 15 },
                    { 12, 18 },
                    { 13, 2 },
                    { 13, 4 },
                    { 13, 12 },
                    { 13, 15 },
                    { 13, 18 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 5 },
                    { 14, 12 },
                    { 14, 18 },
                    { 15, 2 },
                    { 15, 4 },
                    { 15, 15 },
                    { 15, 18 },
                    { 15, 23 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 5 },
                    { 16, 12 },
                    { 16, 18 },
                    { 17, 2 },
                    { 17, 4 },
                    { 17, 11 },
                    { 17, 13 },
                    { 17, 14 },
                    { 17, 15 },
                    { 18, 2 },
                    { 18, 10 },
                    { 18, 11 },
                    { 18, 13 },
                    { 18, 15 },
                    { 19, 2 },
                    { 19, 5 },
                    { 19, 13 },
                    { 19, 15 },
                    { 20, 2 },
                    { 20, 5 },
                    { 20, 13 },
                    { 21, 2 },
                    { 21, 4 },
                    { 21, 9 },
                    { 21, 11 },
                    { 21, 13 },
                    { 21, 15 },
                    { 22, 4 },
                    { 22, 11 },
                    { 22, 13 },
                    { 22, 14 },
                    { 22, 23 },
                    { 23, 2 },
                    { 23, 9 },
                    { 23, 11 },
                    { 23, 13 },
                    { 23, 15 },
                    { 24, 2 },
                    { 24, 4 },
                    { 24, 13 },
                    { 24, 15 },
                    { 25, 2 },
                    { 25, 7 },
                    { 25, 9 },
                    { 25, 15 },
                    { 26, 2 },
                    { 26, 6 },
                    { 26, 12 },
                    { 27, 2 },
                    { 27, 6 },
                    { 27, 7 },
                    { 27, 15 },
                    { 28, 1 },
                    { 28, 3 },
                    { 28, 5 },
                    { 28, 6 },
                    { 28, 12 },
                    { 29, 1 },
                    { 29, 5 },
                    { 29, 12 },
                    { 29, 15 },
                    { 30, 1 },
                    { 30, 5 },
                    { 30, 12 },
                    { 31, 1 },
                    { 31, 5 },
                    { 31, 12 },
                    { 31, 15 },
                    { 32, 1 },
                    { 32, 6 },
                    { 32, 7 },
                    { 32, 12 },
                    { 33, 2 },
                    { 33, 7 },
                    { 33, 9 },
                    { 33, 15 },
                    { 34, 2 },
                    { 34, 6 },
                    { 34, 15 },
                    { 35, 2 },
                    { 35, 5 },
                    { 35, 15 },
                    { 35, 16 },
                    { 35, 20 },
                    { 36, 2 },
                    { 36, 10 },
                    { 36, 16 },
                    { 36, 20 },
                    { 36, 24 },
                    { 37, 2 },
                    { 37, 10 },
                    { 37, 11 },
                    { 37, 16 },
                    { 38, 2 },
                    { 38, 15 },
                    { 38, 16 },
                    { 38, 20 },
                    { 39, 1 },
                    { 39, 3 },
                    { 39, 5 },
                    { 39, 12 },
                    { 39, 16 },
                    { 40, 2 },
                    { 40, 10 },
                    { 40, 16 },
                    { 40, 24 },
                    { 41, 2 },
                    { 41, 15 },
                    { 41, 16 },
                    { 41, 20 },
                    { 42, 2 },
                    { 42, 11 },
                    { 42, 15 },
                    { 42, 16 },
                    { 43, 2 },
                    { 43, 16 },
                    { 43, 20 },
                    { 43, 24 },
                    { 44, 2 },
                    { 44, 16 },
                    { 44, 22 },
                    { 45, 2 },
                    { 45, 8 },
                    { 45, 9 },
                    { 45, 12 },
                    { 45, 21 },
                    { 46, 2 },
                    { 46, 8 },
                    { 46, 15 },
                    { 46, 21 },
                    { 47, 2 },
                    { 47, 4 },
                    { 47, 8 },
                    { 47, 21 },
                    { 48, 2 },
                    { 48, 8 },
                    { 48, 12 },
                    { 48, 21 },
                    { 49, 2 },
                    { 49, 8 },
                    { 49, 9 },
                    { 49, 12 },
                    { 49, 21 },
                    { 50, 2 },
                    { 50, 8 },
                    { 50, 12 },
                    { 50, 21 },
                    { 50, 22 },
                    { 51, 2 },
                    { 51, 8 },
                    { 51, 9 },
                    { 51, 15 },
                    { 51, 21 },
                    { 52, 2 },
                    { 52, 8 },
                    { 52, 15 },
                    { 52, 21 },
                    { 53, 2 },
                    { 53, 8 },
                    { 53, 12 },
                    { 53, 21 },
                    { 53, 22 },
                    { 54, 2 },
                    { 54, 8 },
                    { 54, 12 },
                    { 54, 21 },
                    { 54, 22 },
                    { 55, 2 },
                    { 55, 8 },
                    { 55, 12 },
                    { 55, 15 },
                    { 55, 21 },
                    { 56, 2 },
                    { 56, 12 },
                    { 56, 15 },
                    { 56, 21 },
                    { 57, 2 },
                    { 57, 12 },
                    { 57, 21 },
                    { 58, 2 },
                    { 58, 12 },
                    { 58, 21 },
                    { 59, 2 },
                    { 59, 12 },
                    { 59, 21 },
                    { 60, 2 },
                    { 60, 8 },
                    { 60, 21 },
                    { 61, 2 },
                    { 61, 8 },
                    { 61, 12 },
                    { 61, 21 },
                    { 62, 2 },
                    { 62, 8 },
                    { 62, 15 },
                    { 62, 21 },
                    { 63, 2 },
                    { 63, 8 },
                    { 63, 12 },
                    { 63, 21 },
                    { 64, 2 },
                    { 64, 8 },
                    { 64, 21 },
                    { 65, 2 },
                    { 65, 8 },
                    { 65, 12 },
                    { 65, 21 },
                    { 65, 22 },
                    { 66, 2 },
                    { 66, 8 },
                    { 66, 12 },
                    { 66, 21 },
                    { 66, 22 },
                    { 67, 2 },
                    { 67, 8 },
                    { 67, 21 },
                    { 68, 2 },
                    { 68, 8 },
                    { 68, 21 },
                    { 69, 2 },
                    { 69, 8 },
                    { 69, 15 },
                    { 69, 21 },
                    { 70, 2 },
                    { 70, 3 },
                    { 70, 15 },
                    { 70, 25 },
                    { 71, 1 },
                    { 71, 4 },
                    { 71, 12 },
                    { 71, 14 },
                    { 71, 23 },
                    { 72, 2 },
                    { 72, 3 },
                    { 72, 12 },
                    { 72, 22 },
                    { 73, 2 },
                    { 73, 4 },
                    { 73, 14 },
                    { 73, 15 },
                    { 73, 23 },
                    { 74, 2 },
                    { 74, 4 },
                    { 74, 15 },
                    { 74, 25 },
                    { 75, 2 },
                    { 75, 25 },
                    { 76, 2 },
                    { 76, 4 },
                    { 76, 12 },
                    { 76, 23 },
                    { 77, 2 },
                    { 77, 4 },
                    { 77, 12 },
                    { 77, 23 },
                    { 78, 1 },
                    { 78, 4 },
                    { 78, 23 },
                    { 78, 25 },
                    { 79, 1 },
                    { 79, 4 },
                    { 79, 12 },
                    { 79, 23 },
                    { 79, 25 },
                    { 80, 2 },
                    { 80, 12 },
                    { 80, 14 },
                    { 80, 15 },
                    { 80, 21 },
                    { 81, 2 },
                    { 81, 12 },
                    { 81, 14 },
                    { 81, 15 },
                    { 81, 21 },
                    { 82, 2 },
                    { 82, 23 },
                    { 82, 25 },
                    { 83, 2 },
                    { 83, 23 },
                    { 83, 25 },
                    { 84, 2 },
                    { 84, 12 },
                    { 84, 21 },
                    { 84, 22 },
                    { 85, 1 },
                    { 85, 5 },
                    { 85, 8 },
                    { 85, 21 },
                    { 85, 23 },
                    { 86, 1 },
                    { 86, 14 },
                    { 86, 23 },
                    { 87, 1 },
                    { 87, 23 },
                    { 87, 25 },
                    { 88, 2 },
                    { 88, 9 },
                    { 88, 15 },
                    { 88, 25 },
                    { 89, 2 },
                    { 89, 15 },
                    { 89, 25 },
                    { 90, 2 },
                    { 90, 12 },
                    { 90, 22 },
                    { 90, 25 },
                    { 91, 2 },
                    { 91, 8 },
                    { 91, 9 },
                    { 91, 15 },
                    { 91, 21 },
                    { 92, 2 },
                    { 92, 21 },
                    { 92, 25 },
                    { 93, 2 },
                    { 93, 21 },
                    { 93, 22 },
                    { 93, 25 },
                    { 94, 2 },
                    { 94, 15 },
                    { 94, 25 },
                    { 95, 2 },
                    { 95, 11 },
                    { 95, 13 },
                    { 95, 25 },
                    { 96, 2 },
                    { 96, 9 },
                    { 96, 25 },
                    { 97, 2 },
                    { 97, 25 },
                    { 98, 2 },
                    { 98, 9 },
                    { 98, 15 },
                    { 99, 2 },
                    { 99, 9 },
                    { 99, 11 },
                    { 99, 13 },
                    { 99, 15 },
                    { 100, 2 },
                    { 100, 7 },
                    { 100, 9 },
                    { 100, 15 },
                    { 101, 2 },
                    { 101, 9 },
                    { 102, 2 },
                    { 102, 9 },
                    { 102, 12 },
                    { 103, 2 },
                    { 103, 9 },
                    { 103, 15 },
                    { 104, 2 },
                    { 104, 9 },
                    { 104, 11 },
                    { 104, 13 },
                    { 104, 15 },
                    { 105, 2 },
                    { 105, 9 },
                    { 105, 15 },
                    { 106, 2 },
                    { 106, 9 },
                    { 106, 12 },
                    { 107, 2 },
                    { 107, 4 },
                    { 107, 9 },
                    { 107, 15 },
                    { 108, 1 },
                    { 108, 3 },
                    { 108, 5 },
                    { 108, 6 },
                    { 108, 12 },
                    { 109, 2 },
                    { 109, 3 },
                    { 109, 5 },
                    { 109, 6 },
                    { 109, 12 },
                    { 110, 1 },
                    { 110, 3 },
                    { 110, 5 },
                    { 110, 6 },
                    { 110, 12 },
                    { 111, 1 },
                    { 111, 3 },
                    { 111, 5 },
                    { 111, 6 },
                    { 111, 12 },
                    { 112, 1 },
                    { 112, 3 },
                    { 112, 5 },
                    { 112, 6 },
                    { 112, 12 },
                    { 113, 2 },
                    { 113, 10 },
                    { 113, 13 },
                    { 113, 19 },
                    { 113, 24 },
                    { 114, 2 },
                    { 114, 10 },
                    { 114, 13 },
                    { 114, 19 },
                    { 114, 24 },
                    { 115, 2 },
                    { 115, 4 },
                    { 115, 12 },
                    { 115, 15 },
                    { 115, 19 },
                    { 116, 1 },
                    { 116, 3 },
                    { 116, 5 },
                    { 116, 12 },
                    { 116, 19 },
                    { 117, 2 },
                    { 117, 4 },
                    { 117, 13 },
                    { 117, 14 },
                    { 117, 15 },
                    { 117, 19 },
                    { 118, 1 },
                    { 118, 8 },
                    { 118, 12 },
                    { 118, 21 },
                    { 118, 23 },
                    { 119, 1 },
                    { 119, 8 },
                    { 119, 12 },
                    { 119, 21 },
                    { 119, 23 },
                    { 120, 1 },
                    { 120, 8 },
                    { 120, 12 },
                    { 120, 15 },
                    { 120, 21 },
                    { 120, 23 },
                    { 121, 2 },
                    { 121, 8 },
                    { 121, 21 },
                    { 121, 23 },
                    { 122, 2 },
                    { 122, 8 },
                    { 122, 15 },
                    { 122, 21 },
                    { 123, 2 },
                    { 123, 8 },
                    { 123, 15 },
                    { 123, 21 },
                    { 124, 2 },
                    { 124, 9 },
                    { 124, 15 },
                    { 124, 21 },
                    { 125, 2 },
                    { 125, 9 },
                    { 125, 15 },
                    { 125, 21 },
                    { 126, 2 },
                    { 126, 12 },
                    { 126, 21 },
                    { 127, 2 },
                    { 127, 9 },
                    { 127, 15 },
                    { 127, 21 },
                    { 128, 2 },
                    { 128, 9 },
                    { 128, 12 },
                    { 128, 21 },
                    { 129, 2 },
                    { 129, 12 },
                    { 129, 21 },
                    { 130, 2 },
                    { 130, 6 },
                    { 130, 10 },
                    { 130, 24 },
                    { 131, 2 },
                    { 131, 6 },
                    { 131, 10 },
                    { 131, 15 },
                    { 131, 24 },
                    { 132, 2 },
                    { 132, 4 },
                    { 132, 13 },
                    { 132, 24 },
                    { 133, 2 },
                    { 133, 5 },
                    { 133, 10 },
                    { 133, 13 },
                    { 133, 24 },
                    { 134, 2 },
                    { 134, 10 },
                    { 134, 13 },
                    { 134, 24 },
                    { 135, 2 },
                    { 135, 5 },
                    { 135, 10 },
                    { 135, 11 },
                    { 135, 13 },
                    { 135, 24 },
                    { 136, 2 },
                    { 136, 13 },
                    { 136, 24 },
                    { 137, 2 },
                    { 137, 10 },
                    { 137, 13 },
                    { 137, 24 },
                    { 138, 1 },
                    { 138, 10 },
                    { 138, 11 },
                    { 138, 13 },
                    { 138, 14 },
                    { 139, 2 },
                    { 139, 4 },
                    { 139, 11 },
                    { 139, 13 },
                    { 139, 16 },
                    { 140, 2 },
                    { 140, 10 },
                    { 140, 11 },
                    { 140, 13 },
                    { 140, 15 },
                    { 140, 25 },
                    { 141, 2 },
                    { 141, 11 },
                    { 141, 13 },
                    { 142, 2 },
                    { 142, 15 },
                    { 143, 2 },
                    { 143, 4 },
                    { 143, 13 },
                    { 143, 23 },
                    { 144, 2 },
                    { 144, 4 },
                    { 144, 13 },
                    { 144, 15 },
                    { 145, 2 },
                    { 145, 11 },
                    { 145, 13 },
                    { 145, 25 },
                    { 146, 2 },
                    { 146, 10 },
                    { 146, 11 },
                    { 146, 13 },
                    { 146, 25 },
                    { 147, 2 },
                    { 147, 4 },
                    { 147, 10 },
                    { 147, 13 },
                    { 148, 2 },
                    { 148, 12 },
                    { 148, 21 },
                    { 148, 22 },
                    { 149, 2 },
                    { 149, 4 },
                    { 149, 25 },
                    { 150, 2 },
                    { 150, 8 },
                    { 150, 13 },
                    { 150, 21 },
                    { 150, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTags_TagsId",
                table: "ActivityTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId_ParentCommentId",
                table: "Comments",
                columns: new[] { "PostId", "ParentCommentId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_EventId_UserId",
                table: "EventAttendees",
                columns: new[] { "EventId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_UserId",
                table: "EventAttendees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ActivityId",
                table: "Events",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ScheduledAt",
                table: "Events",
                column: "ScheduledAt");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Status",
                table: "Events",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_TagsId",
                table: "EventTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ActivityId",
                table: "Posts",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedAt",
                table: "Posts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Score",
                table: "Posts",
                column: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVotes_PostId",
                table: "PostVotes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVotes_UserId_PostId",
                table: "PostVotes",
                columns: new[] { "UserId", "PostId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTags");

            migrationBuilder.DropTable(
                name: "CommentVotes");

            migrationBuilder.DropTable(
                name: "EventAttendees");

            migrationBuilder.DropTable(
                name: "EventTags");

            migrationBuilder.DropTable(
                name: "PostVotes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
