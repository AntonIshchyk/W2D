using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
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
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    OrganizerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpaceId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_Events_Communities_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Communities",
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
                    SpaceId = table.Column<int>(type: "INTEGER", nullable: false),
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
                    CommunityId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Communities_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Communities",
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
                table: "Communities",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(872), "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills.", "Football (Soccer)", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(875) },
                    { 2, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1493), "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games.", "Basketball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1494) },
                    { 3, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1497), "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment.", "Volleyball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1497) },
                    { 4, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1499), "America's pastime - bat, pitch, and field in this strategic team sport.", "Baseball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1499) },
                    { 5, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1501), "A high-intensity contact sport requiring strength, speed, and teamwork.", "Rugby", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1501) },
                    { 6, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1506), "Fast-paced indoor sport combining elements of basketball and soccer.", "Handball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1506) },
                    { 7, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1508), "Throw, dodge, and catch in this exciting and energetic team game.", "Dodgeball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1508) },
                    { 8, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1510), "Tackle football with strategic plays and intense physicality.", "American Football", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1510) },
                    { 9, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1512), "A fun, accessible game similar to baseball but played with a large rubber ball.", "Kickball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1512) },
                    { 10, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1515), "Roll strikes and spares at your local bowling alley. Great social community for all ages.", "Bowling", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1516) },
                    { 11, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1517), "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness.", "Tennis", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1518) },
                    { 12, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1519), "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility.", "Badminton", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1519) },
                    { 13, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1521), "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun.", "Table Tennis (Ping Pong)", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1521) },
                    { 14, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1523), "Intense racket sport played in a four-walled court. Excellent cardio workout.", "Squash", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1523) },
                    { 15, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1525), "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social.", "Pickleball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1525) },
                    { 16, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1528), "High-energy racket sport played in an enclosed court with a hollow rubber ball.", "Racquetball", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1528) },
                    { 17, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1530), "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise.", "Go for a Walk", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1530) },
                    { 18, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1533), "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone.", "Hiking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1533) },
                    { 19, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1535), "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise.", "Running/Jogging", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1535) },
                    { 20, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1536), "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout.", "Cycling", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1537) },
                    { 21, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1538), "Observe and identify birds in their natural habitat. A peaceful outdoor community that connects you with nature.", "Bird Watching", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1539) },
                    { 22, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1540), "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing.", "Picnicking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1540) },
                    { 23, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1542), "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring community.", "Stargazing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1542) },
                    { 24, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1544), "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee.", "Frisbee", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1544) },
                    { 25, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1545), "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio.", "Yoga", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1546) },
                    { 26, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1599), "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment.", "Weight Training", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1600) },
                    { 27, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1601), "Low-impact exercise focusing on core strength, flexibility, and body awareness. Great for all fitness levels.", "Pilates", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1602) },
                    { 28, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1603), "High-intensity functional fitness program combining weightlifting, cardio, and gymnastics.", "CrossFit", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1604) },
                    { 29, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1605), "Dance-based fitness class with energetic Latin and international music.", "Zumba", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1606) },
                    { 30, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1607), "High-energy stationary bike workout often done in group classes.", "Spinning/Indoor Cycling", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1608) },
                    { 31, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1609), "Cardiovascular exercise routine performed to music, often in a group setting.", "Aerobics", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1609) },
                    { 32, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1611), "Ballet-inspired workout focusing on low-impact, high-intensity movements.", "Barre", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1611) },
                    { 33, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1613), "Improve flexibility and reduce muscle tension through dedicated stretching routines.", "Stretching", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1613) },
                    { 34, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1617), "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed.", "Calisthenics", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1617) },
                    { 35, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1618), "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints.", "Swimming", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1619) },
                    { 36, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1620), "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance.", "Surfing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1621) },
                    { 37, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1622), "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength.", "Kayaking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1623) },
                    { 38, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1624), "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore.", "Paddleboarding (SUP)", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1625) },
                    { 39, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1627), "Intense team water sport combining swimming, ball handling, and strategy.", "Water Polo", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1627) },
                    { 40, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1629), "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences.", "Scuba Diving", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1629) },
                    { 41, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1631), "Swim on the water surface while viewing underwater attractions through a snorkel mask.", "Snorkeling", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1631) },
                    { 42, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1633), "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration.", "Canoeing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1633) },
                    { 43, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1635), "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping.", "Jet Skiing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1635) },
                    { 44, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1637), "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature.", "Sailing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1638) },
                    { 45, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1639), "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity.", "Painting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1640) },
                    { 46, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1641), "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet.", "Drawing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1642) },
                    { 47, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1643), "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera.", "Photography", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1644) },
                    { 48, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1645), "Create three-dimensional art with clay, stone, metal, or other materials.", "Sculpting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1646) },
                    { 49, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1648), "Create functional or decorative ceramic pieces. A hands-on art form that's both creative and meditative.", "Pottery", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1648) },
                    { 50, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1650), "Create art using digital tools like tablets and software. Modern artistic expression.", "Digital Art", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1650) },
                    { 51, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1795), "The art of beautiful handwriting. Practice various lettering styles with pens and brushes.", "Calligraphy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1796) },
                    { 52, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1798), "Japanese paper folding art. Create intricate designs from simple paper squares.", "Origami", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1798) },
                    { 53, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1800), "Create visual content for digital and print media. Combine art and communication.", "Graphic Design", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1800) },
                    { 54, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1802), "Bring drawings and characters to life through frame-by-frame or digital animation.", "Animation", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1802) },
                    { 55, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1804), "Design and create jewelry pieces using various materials and techniques.", "Jewelry Making", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1804) },
                    { 56, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1807), "Create custom candles with different scents, colors, and designs.", "Candle Making", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1807) },
                    { 57, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1830), "Craft handmade soaps with natural ingredients and custom fragrances.", "Soap Making", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1831) },
                    { 58, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1832), "Build furniture, decorations, or art pieces from wood. Satisfying hands-on craft.", "Woodworking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1833) },
                    { 59, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1834), "Craft items from leather including wallets, bags, and belts.", "Leatherworking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1835) },
                    { 60, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1836), "Learn to play acoustic or electric guitar. Great for self-expression and can be enjoyed solo or in a band.", "Playing Guitar", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1837) },
                    { 61, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1838), "Learn classical pieces or contemporary songs on the piano. A versatile instrument suitable for all ages.", "Playing Piano", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1838) },
                    { 62, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1840), "Practice singing alone or join a choir. Express yourself through music and improve your vocal skills.", "Singing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1840) },
                    { 63, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1842), "Learn rhythm and coordination through drumming. Great stress relief and physical workout.", "Playing Drums", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1842) },
                    { 64, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1844), "Master this elegant string instrument. Requires dedication but offers beautiful musical expression.", "Playing Violin", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1844) },
                    { 65, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1846), "Mix and create music using turntables or digital equipment. Perfect for music enthusiasts.", "DJing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1846) },
                    { 66, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1851), "Create original music using digital audio workstations and software.", "Music Production", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1851) },
                    { 67, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1853), "Provide the rhythmic foundation in bands or practice solo. Essential in many music genres.", "Playing Bass Guitar", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1853) },
                    { 68, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1855), "Learn this expressive wind instrument popular in jazz, classical, and contemporary music.", "Playing Saxophone", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1855) },
                    { 69, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1857), "Create percussion sounds and music with your mouth. No equipment needed, just practice.", "Beatboxing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1857) },
                    { 70, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1858), "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills.", "Chess", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1859) },
                    { 71, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1860), "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone.", "Board Games", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1861) },
                    { 72, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1862), "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports.", "Video Gaming", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1863) },
                    { 73, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1864), "Play poker, bridge, magic the gathering, or casual card games with friends.", "Card Games", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1865) },
                    { 74, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1866), "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers.", "Puzzle Solving", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1867) },
                    { 75, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1868), "Master the classic 3D combination puzzle. Great for developing spatial reasoning.", "Rubik's Cube", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1869) },
                    { 76, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1870), "Throw darts at a target board. Fun pub game that improves focus and precision.", "Darts", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1871) },
                    { 77, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1872), "Play pool, snooker, or other cue sports at a table. Strategic and social community.", "Pool/Billiards", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1873) },
                    { 78, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1874), "Test your knowledge in trivia nights or quiz games. Great for groups and learning.", "Trivia/Quiz Games", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1875) },
                    { 79, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1876), "Solve puzzles and riddles to 'escape' from a themed room within a time limit.", "Escape Rooms", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1877) },
                    { 80, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1878), "Experiment in the kitchen with new recipes. Cook meals for yourself or loved ones.", "Cooking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1878) },
                    { 81, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1880), "Bake bread, cakes, cookies, and pastries. A precise and rewarding culinary art.", "Baking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1880) },
                    { 82, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1882), "Explore different coffee beans, roasts, and brewing methods. Develop your palate.", "Coffee Tasting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1882) },
                    { 83, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1884), "Sample and appreciate different wines. Learn about varieties, regions, and pairing.", "Wine Tasting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1884) },
                    { 84, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1886), "Brew your own beer, cider, or kombucha. A fascinating blend of science and art.", "Homebrewing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1886) },
                    { 85, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1888), "Learn various dance styles from salsa to hip-hop. Great exercise and a fun social community.", "Dancing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1888) },
                    { 86, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1890), "Give back to your community through volunteer work. A rewarding way to make a positive impact.", "Volunteering", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1890) },
                    { 87, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1892), "Join a group to read and discuss books. Combine reading with social interaction.", "Book Club", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1892) },
                    { 88, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1916), "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination.", "Reading", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1917) },
                    { 89, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1918), "Study a new language through apps, courses, or tutors. Expand your communication skills and cultural understanding.", "Learning a Language", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1919) },
                    { 90, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1921), "Learn to code in various programming languages. Build apps, websites, or automate tasks.", "Coding/Programming", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1921) },
                    { 91, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1923), "Creative writing, journaling, or blogging. Express thoughts and develop storytelling skills.", "Writing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1923) },
                    { 92, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1925), "Create and share audio content on communities you're passionate about. Express ideas and connect with audiences.", "Podcasting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1925) },
                    { 93, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1926), "Share your thoughts, experiences, or expertise through written or video blogs.", "Blogging/Vlogging", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1927) },
                    { 94, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1928), "Take structured online courses on platforms like Coursera, Udemy, or edX. Learn anything from anywhere.", "Online Courses", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1929) },
                    { 95, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1933), "Study celestial objects and phenomena. Combine observation with scientific learning.", "Astronomy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1933) },
                    { 96, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1935), "Explore philosophical texts and ideas. Develop critical thinking and question fundamental concepts.", "Philosophy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1935) },
                    { 97, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1937), "Deep dive into historical periods, events, or figures. Understand the past to inform the present.", "History Research", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1937) },
                    { 98, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1939), "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere.", "Meditation", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1939) },
                    { 99, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1941), "Grow plants, flowers, or vegetables. A relaxing hobby that connects you with nature.", "Gardening", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1941) },
                    { 100, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1943), "Practice this gentle martial art focused on slow, flowing movements and breath control.", "Tai Chi", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1943) },
                    { 101, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1945), "Learn massage techniques or receive professional massages for relaxation and muscle relief.", "Massage Therapy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1945) },
                    { 102, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1947), "Use essential oils for therapeutic benefits. Promote relaxation and well-being.", "Aromatherapy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1947) },
                    { 103, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1949), "Write daily thoughts, gratitude, or reflections. Great for mental health and self-awareness.", "Journaling", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1949) },
                    { 104, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1951), "Immerse yourself in nature to reduce stress and improve well-being. Simply be present in natural settings.", "Nature Bathing (Shinrin-Yoku)", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1951) },
                    { 105, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1953), "Practice controlled breathing techniques to reduce stress and improve focus.", "Breathing Exercises", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1953) },
                    { 106, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1955), "Relax in hot water or steam rooms. Great for muscle recovery and stress relief.", "Hot Tub/Sauna", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1955) },
                    { 107, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1957), "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres.", "Listening to Music", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1957) },
                    { 108, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1959), "Traditional Japanese martial art focusing on striking techniques and kata forms.", "Karate", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1959) },
                    { 109, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1961), "Train in the sweet science. Great cardio workout and learn self-defense.", "Boxing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1961) },
                    { 110, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1963), "Japanese martial art focused on throws and grappling techniques.", "Judo", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1963) },
                    { 111, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1965), "Korean martial art known for dynamic kicking techniques and discipline.", "Taekwondo", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1965) },
                    { 112, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1967), "Ground-fighting martial art focused on submissions and positional control.", "Brazilian Jiu-Jitsu", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1967) },
                    { 113, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1969), "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts.", "Skiing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1969) },
                    { 114, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1971), "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport.", "Snowboarding", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1971) },
                    { 115, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1972), "Glide on ice at a rink. Fun winter community that builds balance and leg strength.", "Ice Skating", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1973) },
                    { 116, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1974), "Fast-paced team sport played on ice. Requires skating ability and competitive spirit.", "Ice Hockey", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1975) },
                    { 117, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1976), "Slide down snowy hills on sleds. Simple, fun winter community for all ages.", "Sledding/Tobogganing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1977) },
                    { 118, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1978), "Perform in plays or take acting classes. Express emotions and stories through performance.", "Acting/Theater", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1979) },
                    { 119, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1980), "Write and perform comedy routines. Make people laugh while expressing your unique voice.", "Stand-up Comedy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(1981) },
                    { 120, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2005), "Perform unscripted comedy based on audience suggestions. Develops quick thinking and creativity.", "Improv Comedy", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2005) },
                    { 121, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2006), "Learn and perform magic illusions. Entertain others with sleight of hand and misdirection.", "Magic Tricks", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2007) },
                    { 122, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2008), "Learn to juggle balls, clubs, or other objects. Impressive skill that improves coordination.", "Juggling", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2009) },
                    { 123, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2010), "The art of silent acting through exaggerated gestures and expressions.", "Mime", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2011) },
                    { 124, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2012), "Create garments and accessories with knitting needles and yarn. Relaxing and productive.", "Knitting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2013) },
                    { 125, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2014), "Create items using a crochet hook and yarn. Similar to knitting but with different techniques.", "Crocheting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2014) },
                    { 126, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2074), "Make or repair clothing and fabric items. Practical skill that allows for creative expression.", "Sewing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2075) },
                    { 127, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2076), "Decorate fabric with needle and thread designs. Detailed handwork that creates beautiful patterns.", "Embroidery", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2077) },
                    { 128, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2078), "Sew layers of fabric together to create quilts. Combines artistry with practical warmth.", "Quilting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2079) },
                    { 129, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2080), "Create fabric by interlacing threads on a loom. Ancient craft with modern applications.", "Weaving", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2081) },
                    { 130, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2086), "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence.", "Rock Climbing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2086) },
                    { 131, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2088), "Climb shorter walls without ropes, using crash pads. Great intro to climbing.", "Bouldering", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2088) },
                    { 132, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2090), "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination.", "Skateboarding", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2090) },
                    { 133, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2092), "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity.", "Parkour", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2092) },
                    { 134, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2094), "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports.", "BMX Biking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2094) },
                    { 135, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2096), "Ride bicycles off-road on rugged terrain. Adventurous and challenging.", "Mountain Biking", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2096) },
                    { 136, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2098), "Jump from heights while connected to an elastic cord. Ultimate adrenaline rush.", "Bungee Jumping", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2098) },
                    { 137, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2100), "Jump from aircraft and freefall before deploying a parachute. Unforgettable experience.", "Skydiving", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2100) },
                    { 138, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2102), "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines.", "Camping", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2102) },
                    { 139, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2104), "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary.", "Fishing", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2104) },
                    { 140, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2106), "Use GPS to find hidden containers (geocaches) placed by others. Modern treasure hunting.", "Geocaching", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2106) },
                    { 141, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2108), "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise.", "Horseback Riding", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2108) },
                    { 142, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2110), "Shoot arrows at targets with a bow. Ancient skill requiring focus and precision.", "Archery", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2110) },
                    { 143, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2112), "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy.", "Golf", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2112) },
                    { 144, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2113), "Like golf but with frisbees. Throw discs into baskets across a course. Low cost and accessible.", "Disc Golf", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2114) },
                    { 145, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2115), "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty.", "Foraging", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2116) },
                    { 146, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2117), "Navigate through terrain using a map and compass. Combines hiking with navigational challenges.", "Orienteering", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2118) },
                    { 147, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2119), "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors.", "Metal Detecting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2120) },
                    { 148, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2121), "Build scale models of vehicles, buildings, or figures. Detail-oriented hobby requiring patience.", "Model Building", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2122) },
                    { 149, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2123), "Collect stamps, coins, cards, or other items. Combines research with the thrill of the hunt.", "Collecting", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2124) },
                    { 150, new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2125), "Fly drones and capture aerial footage. Modern hobby combining technology with creativity.", "Drone Flying", new DateTime(2026, 3, 19, 21, 12, 1, 877, DateTimeKind.Utc).AddTicks(2126) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(593), "Team", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(599) },
                    { 2, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1178), "Individual", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1178) },
                    { 3, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1180), "Competitive", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1180) },
                    { 4, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1182), "Casual", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1182) },
                    { 5, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1184), "Cardio", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1184) },
                    { 6, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1185), "Strength", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1186) },
                    { 7, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1187), "Flexibility", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1187) },
                    { 8, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1188), "Artistic", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1189) },
                    { 9, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1190), "Mindful", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1190) },
                    { 10, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1272), "Adventure", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1273) },
                    { 11, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1274), "Nature", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1275) },
                    { 12, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1276), "Indoor", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1276) },
                    { 13, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1277), "Outdoor", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1278) },
                    { 14, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1279), "Family-Friendly", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1279) },
                    { 15, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1281), "Beginner-Friendly", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1281) },
                    { 16, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1282), "Water", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1283) },
                    { 17, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1284), "Ball Sports", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1284) },
                    { 18, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1285), "Racket Sports", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1286) },
                    { 19, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1287), "Winter", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1287) },
                    { 20, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1311), "Summer", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1312) },
                    { 21, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1313), "Creative", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1313) },
                    { 22, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1315), "Technical", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1315) },
                    { 23, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1316), "Social", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1317) },
                    { 24, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1318), "Extreme", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1318) },
                    { 25, new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1319), "Educational", new DateTime(2026, 3, 19, 21, 12, 1, 876, DateTimeKind.Utc).AddTicks(1320) }
                });

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
                name: "IX_Communities_Name",
                table: "Communities",
                column: "Name",
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
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ScheduledAt",
                table: "Events",
                column: "ScheduledAt");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SpaceId",
                table: "Events",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Status",
                table: "Events",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_TagsId",
                table: "EventTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommunityId",
                table: "Posts",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedAt",
                table: "Posts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Score",
                table: "Posts",
                column: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SpaceId",
                table: "Posts",
                column: "SpaceId");

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
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
