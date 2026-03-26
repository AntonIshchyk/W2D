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
                    Username = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 160, nullable: true),
                    ProfilePhotoUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ProfileSetupComplete = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    PlaceId = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
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
                    { 1, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7529), "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills.", "Football", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7530) },
                    { 2, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7988), "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games.", "Basketball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7988) },
                    { 3, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7990), "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment.", "Volleyball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7991) },
                    { 4, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7992), "America's pastime - bat, pitch, and field in this strategic team sport.", "Baseball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7992) },
                    { 5, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7994), "A high-intensity contact sport requiring strength, speed, and teamwork.", "Rugby", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7994) },
                    { 6, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(7999), "Fast-paced indoor sport combining elements of basketball and soccer.", "Handball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8000) },
                    { 7, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8001), "Throw, dodge, and catch in this exciting and energetic team game.", "Dodgeball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8001) },
                    { 8, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8003), "Tackle football with strategic plays and intense physicality.", "American Football", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8003) },
                    { 9, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8004), "A fun, accessible game similar to baseball but played with a large rubber ball.", "Kickball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8005) },
                    { 10, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8007), "Roll strikes and spares at your local bowling alley. Great social community for all ages.", "Bowling", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8008) },
                    { 11, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8009), "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness.", "Tennis", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8010) },
                    { 12, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8011), "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility.", "Badminton", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8011) },
                    { 13, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8013), "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun.", "Table Tennis (Ping Pong)", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8013) },
                    { 14, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8014), "Intense racket sport played in a four-walled court. Excellent cardio workout.", "Squash", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8015) },
                    { 15, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8016), "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social.", "Pickleball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8017) },
                    { 16, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8018), "High-energy racket sport played in an enclosed court with a hollow rubber ball.", "Racquetball", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8018) },
                    { 17, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8020), "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise.", "Walking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8020) },
                    { 18, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8022), "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone.", "Hiking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8023) },
                    { 19, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8024), "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise.", "Running/Jogging", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8025) },
                    { 20, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8026), "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout.", "Cycling", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8026) },
                    { 21, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8028), "Observe and identify birds in their natural habitat. A peaceful outdoor community that connects you with nature.", "Bird Watching", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8028) },
                    { 22, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8029), "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing.", "Picnicking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8030) },
                    { 23, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8072), "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring community.", "Stargazing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8072) },
                    { 24, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8073), "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee.", "Frisbee", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8074) },
                    { 25, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8075), "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio.", "Yoga", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8076) },
                    { 26, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8077), "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment.", "Weight Training", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8077) },
                    { 27, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8079), "Low-impact exercise focusing on core strength, flexibility, and body awareness. Great for all fitness levels.", "Pilates", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8079) },
                    { 28, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8080), "High-intensity functional fitness program combining weightlifting, cardio, and gymnastics.", "CrossFit", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8081) },
                    { 29, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8082), "Dance-based fitness class with energetic Latin and international music.", "Zumba", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8083) },
                    { 30, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8084), "High-energy stationary bike workout often done in group classes.", "Spinning/Indoor Cycling", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8084) },
                    { 31, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8086), "Cardiovascular exercise routine performed to music, often in a group setting.", "Aerobics", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8086) },
                    { 32, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8087), "Ballet-inspired workout focusing on low-impact, high-intensity movements.", "Barre", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8088) },
                    { 33, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8089), "Improve flexibility and reduce muscle tension through dedicated stretching routines.", "Stretching", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8089) },
                    { 34, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8092), "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed.", "Calisthenics", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8092) },
                    { 35, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8094), "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints.", "Swimming", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8094) },
                    { 36, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8095), "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance.", "Surfing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8096) },
                    { 37, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8097), "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength.", "Kayaking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8097) },
                    { 38, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8099), "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore.", "Paddleboarding (SUP)", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8099) },
                    { 39, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8100), "Intense team water sport combining swimming, ball handling, and strategy.", "Water Polo", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8101) },
                    { 40, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8102), "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences.", "Scuba Diving", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8103) },
                    { 41, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8104), "Swim on the water surface while viewing underwater attractions through a snorkel mask.", "Snorkeling", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8104) },
                    { 42, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8106), "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration.", "Canoeing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8106) },
                    { 43, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8107), "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping.", "Jet Skiing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8108) },
                    { 44, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8109), "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature.", "Sailing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8110) },
                    { 45, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8111), "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity.", "Painting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8111) },
                    { 46, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8113), "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet.", "Drawing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8113) },
                    { 47, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8114), "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera.", "Photography", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8115) },
                    { 48, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8116), "Create three-dimensional art with clay, stone, metal, or other materials.", "Sculpting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8117) },
                    { 49, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8118), "Create functional or decorative ceramic pieces. A hands-on art form that's both creative and meditative.", "Pottery", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8118) },
                    { 50, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8120), "Create art using digital tools like tablets and software. Modern artistic expression.", "Digital Art", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8120) },
                    { 51, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8121), "The art of beautiful handwriting. Practice various lettering styles with pens and brushes.", "Calligraphy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8122) },
                    { 52, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8123), "Japanese paper folding art. Create intricate designs from simple paper squares.", "Origami", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8123) },
                    { 53, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8125), "Create visual content for digital and print media. Combine art and communication.", "Graphic Design", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8125) },
                    { 54, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8143), "Bring drawings and characters to life through frame-by-frame or digital animation.", "Animation", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8144) },
                    { 55, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8145), "Design and create jewelry pieces using various materials and techniques.", "Jewelry Making", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8146) },
                    { 56, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8147), "Create custom candles with different scents, colors, and designs.", "Candle Making", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8147) },
                    { 57, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8149), "Craft handmade soaps with natural ingredients and custom fragrances.", "Soap Making", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8149) },
                    { 58, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8150), "Build furniture, decorations, or art pieces from wood. Satisfying hands-on craft.", "Woodworking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8151) },
                    { 59, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8216), "Craft items from leather including wallets, bags, and belts.", "Leatherworking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8216) },
                    { 60, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8218), "Learn to play acoustic or electric guitar. Great for self-expression and can be enjoyed solo or in a band.", "Guitar", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8218) },
                    { 61, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8220), "Learn classical pieces or contemporary songs on the piano. A versatile instrument suitable for all ages.", "Piano", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8220) },
                    { 62, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8221), "Practice singing alone or join a choir. Express yourself through music and improve your vocal skills.", "Singing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8222) },
                    { 63, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8223), "Learn rhythm and coordination through drumming. Great stress relief and physical workout.", "Drums", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8223) },
                    { 64, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8225), "Master this elegant string instrument. Requires dedication but offers beautiful musical expression.", "Violin", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8225) },
                    { 65, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8226), "Mix and create music using turntables or digital equipment. Perfect for music enthusiasts.", "DJing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8227) },
                    { 66, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8229), "Create original music using digital audio workstations and software.", "Music Production", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8230) },
                    { 67, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8231), "Provide the rhythmic foundation in bands or practice solo. Essential in many music genres.", "Bass Guitar", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8231) },
                    { 68, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8233), "Learn this expressive wind instrument popular in jazz, classical, and contemporary music.", "Saxophone", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8233) },
                    { 69, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8234), "Create percussion sounds and music with your mouth. No equipment needed, just practice.", "Beatboxing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8235) },
                    { 70, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8236), "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills.", "Chess", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8237) },
                    { 71, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8238), "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone.", "Board Games", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8238) },
                    { 72, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8240), "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports.", "Video Gaming", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8240) },
                    { 73, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8241), "Play poker, bridge, magic the gathering, or casual card games with friends.", "Card Games", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8242) },
                    { 74, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8243), "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers.", "Puzzle Solving", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8244) },
                    { 75, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8245), "Master the classic 3D combination puzzle. Great for developing spatial reasoning.", "Rubik's Cube", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8245) },
                    { 76, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8246), "Throw darts at a target board. Fun pub game that improves focus and precision.", "Darts", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8247) },
                    { 77, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8248), "Play pool, snooker, or other cue sports at a table. Strategic and social community.", "Pool/Billiards", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8249) },
                    { 78, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8250), "Test your knowledge in trivia nights or quiz games. Great for groups and learning.", "Trivia/Quiz Games", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8250) },
                    { 79, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8252), "Solve puzzles and riddles to 'escape' from a themed room within a time limit.", "Escape Rooms", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8252) },
                    { 80, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8253), "Experiment in the kitchen with new recipes. Cook meals for yourself or loved ones.", "Cooking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8254) },
                    { 81, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8255), "Bake bread, cakes, cookies, and pastries. A precise and rewarding culinary art.", "Baking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8255) },
                    { 82, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8257), "Explore different coffee beans, roasts, and brewing methods. Develop your palate.", "Coffee Tasting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8257) },
                    { 83, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8258), "Sample and appreciate different wines. Learn about varieties, regions, and pairing.", "Wine Tasting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8259) },
                    { 84, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8260), "Brew your own beer, cider, or kombucha. A fascinating blend of science and art.", "Homebrewing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8261) },
                    { 85, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8276), "Learn various dance styles from salsa to hip-hop. Great exercise and a fun social community.", "Dancing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8277) },
                    { 86, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8278), "Give back to your community through volunteer work. A rewarding way to make a positive impact.", "Volunteering", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8278) },
                    { 87, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8280), "Join a group to read and discuss books. Combine reading with social interaction.", "Book Club", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8280) },
                    { 88, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8281), "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination.", "Reading", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8282) },
                    { 89, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8283), "Study a new language through apps, courses, or tutors. Expand your communication skills and cultural understanding.", "Learning a Language", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8284) },
                    { 90, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8285), "Learn to code in various programming languages. Build apps, websites, or automate tasks.", "Coding/Programming", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8285) },
                    { 91, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8287), "Creative writing, journaling, or blogging. Express thoughts and develop storytelling skills.", "Writing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8287) },
                    { 92, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8288), "Create and share audio content on communities you're passionate about. Express ideas and connect with audiences.", "Podcasting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8289) },
                    { 93, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8290), "Share your thoughts, experiences, or expertise through written or video blogs.", "Blogging/Vlogging", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8291) },
                    { 94, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8292), "Take structured online courses on platforms like Coursera, Udemy, or edX. Learn anything from anywhere.", "Online Courses", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8292) },
                    { 95, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8294), "Study celestial objects and phenomena. Combine observation with scientific learning.", "Astronomy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8294) },
                    { 96, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8295), "Explore philosophical texts and ideas. Develop critical thinking and question fundamental concepts.", "Philosophy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8296) },
                    { 97, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8297), "Deep dive into historical periods, events, or figures. Understand the past to inform the present.", "History Research", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8297) },
                    { 98, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8299), "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere.", "Meditation", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8299) },
                    { 99, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8300), "Grow plants, flowers, or vegetables. A relaxing hobby that connects you with nature.", "Gardening", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8301) },
                    { 100, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8302), "Practice this gentle martial art focused on slow, flowing movements and breath control.", "Tai Chi", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8303) },
                    { 101, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8304), "Learn massage techniques or receive professional massages for relaxation and muscle relief.", "Massage Therapy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8304) },
                    { 102, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8306), "Use essential oils for therapeutic benefits. Promote relaxation and well-being.", "Aromatherapy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8306) },
                    { 103, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8307), "Write daily thoughts, gratitude, or reflections. Great for mental health and self-awareness.", "Journaling", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8308) },
                    { 104, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8309), "Immerse yourself in nature to reduce stress and improve well-being. Simply be present in natural settings.", "Nature Bathing (Shinrin-Yoku)", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8309) },
                    { 105, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8311), "Practice controlled breathing techniques to reduce stress and improve focus.", "Breathing Exercises", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8311) },
                    { 106, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8312), "Relax in hot water or steam rooms. Great for muscle recovery and stress relief.", "Hot Tub/Sauna", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8313) },
                    { 107, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8314), "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres.", "Listening to Music", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8315) },
                    { 108, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8316), "Traditional Japanese martial art focusing on striking techniques and kata forms.", "Karate", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8316) },
                    { 109, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8318), "Train in the sweet science. Great cardio workout and learn self-defense.", "Boxing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8318) },
                    { 110, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8319), "Japanese martial art focused on throws and grappling techniques.", "Judo", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8320) },
                    { 111, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8321), "Korean martial art known for dynamic kicking techniques and discipline.", "Taekwondo", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8322) },
                    { 112, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8323), "Ground-fighting martial art focused on submissions and positional control.", "Brazilian Jiu-Jitsu", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8323) },
                    { 113, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8325), "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts.", "Skiing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8325) },
                    { 114, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8326), "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport.", "Snowboarding", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8327) },
                    { 115, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8328), "Glide on ice at a rink. Fun winter community that builds balance and leg strength.", "Ice Skating", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8329) },
                    { 116, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8330), "Fast-paced team sport played on ice. Requires skating ability and competitive spirit.", "Ice Hockey", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8330) },
                    { 117, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8344), "Slide down snowy hills on sleds. Simple, fun winter community for all ages.", "Sledding/Tobogganing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8344) },
                    { 118, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8345), "Perform in plays or take acting classes. Express emotions and stories through performance.", "Acting/Theater", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8346) },
                    { 119, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8347), "Write and perform comedy routines. Make people laugh while expressing your unique voice.", "Stand-up Comedy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8347) },
                    { 120, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8349), "Perform unscripted comedy based on audience suggestions. Develops quick thinking and creativity.", "Improv Comedy", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8349) },
                    { 121, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8350), "Learn and perform magic illusions. Entertain others with sleight of hand and misdirection.", "Magic Tricks", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8351) },
                    { 122, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8352), "Learn to juggle balls, clubs, or other objects. Impressive skill that improves coordination.", "Juggling", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8353) },
                    { 123, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8354), "The art of silent acting through exaggerated gestures and expressions.", "Mime", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8354) },
                    { 124, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8356), "Create garments and accessories with knitting needles and yarn. Relaxing and productive.", "Knitting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8356) },
                    { 125, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8357), "Create items using a crochet hook and yarn. Similar to knitting but with different techniques.", "Crocheting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8358) },
                    { 126, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8359), "Make or repair clothing and fabric items. Practical skill that allows for creative expression.", "Sewing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8360) },
                    { 127, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8361), "Decorate fabric with needle and thread designs. Detailed handwork that creates beautiful patterns.", "Embroidery", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8361) },
                    { 128, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8363), "Sew layers of fabric together to create quilts. Combines artistry with practical warmth.", "Quilting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8363) },
                    { 129, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8364), "Create fabric by interlacing threads on a loom. Ancient craft with modern applications.", "Weaving", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8365) },
                    { 130, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8419), "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence.", "Rock Climbing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8419) },
                    { 131, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8421), "Climb shorter walls without ropes, using crash pads. Great intro to climbing.", "Bouldering", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8421) },
                    { 132, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8423), "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination.", "Skateboarding", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8423) },
                    { 133, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8425), "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity.", "Parkour", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8425) },
                    { 134, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8426), "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports.", "BMX Biking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8427) },
                    { 135, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8428), "Ride bicycles off-road on rugged terrain. Adventurous and challenging.", "Mountain Biking", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8428) },
                    { 136, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8430), "Jump from heights while connected to an elastic cord. Ultimate adrenaline rush.", "Bungee Jumping", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8430) },
                    { 137, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8431), "Jump from aircraft and freefall before deploying a parachute. Unforgettable experience.", "Skydiving", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8432) },
                    { 138, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8433), "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines.", "Camping", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8434) },
                    { 139, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8435), "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary.", "Fishing", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8435) },
                    { 140, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8437), "Use GPS to find hidden containers (geocaches) placed by others. Modern treasure hunting.", "Geocaching", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8437) },
                    { 141, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8438), "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise.", "Horseback Riding", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8439) },
                    { 142, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8440), "Shoot arrows at targets with a bow. Ancient skill requiring focus and precision.", "Archery", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8440) },
                    { 143, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8442), "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy.", "Golf", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8442) },
                    { 144, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8443), "Like golf but with frisbees. Throw discs into baskets across a course. Low cost and accessible.", "Disc Golf", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8444) },
                    { 145, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8445), "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty.", "Foraging", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8446) },
                    { 146, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8447), "Navigate through terrain using a map and compass. Combines hiking with navigational challenges.", "Orienteering", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8447) },
                    { 147, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8449), "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors.", "Metal Detecting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8449) },
                    { 148, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8450), "Build scale models of vehicles, buildings, or figures. Detail-oriented hobby requiring patience.", "Model Building", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8451) },
                    { 149, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8452), "Collect stamps, coins, cards, or other items. Combines research with the thrill of the hunt.", "Collecting", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8452) },
                    { 150, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8454), "Fly drones and capture aerial footage. Modern hobby combining technology with creativity.", "Drone Flying", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(8454) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(32), "Team", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(39) },
                    { 2, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(521), "Individual", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(522) },
                    { 3, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(523), "Competitive", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(524) },
                    { 4, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(525), "Casual", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(525) },
                    { 5, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(526), "Cardio", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(527) },
                    { 6, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(528), "Strength", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(528) },
                    { 7, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(529), "Flexibility", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(530) },
                    { 8, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(531), "Artistic", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(531) },
                    { 9, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(532), "Mindful", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(533) },
                    { 10, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(534), "Adventure", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(534) },
                    { 11, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(536), "Nature", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(536) },
                    { 12, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(537), "Indoor", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(538) },
                    { 13, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(539), "Outdoor", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(539) },
                    { 14, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(540), "Family-Friendly", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(541) },
                    { 15, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(542), "Beginner-Friendly", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(542) },
                    { 16, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(543), "Water", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(544) },
                    { 17, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(571), "Ball Sports", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(571) },
                    { 18, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(572), "Racket Sports", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(573) },
                    { 19, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(635), "Winter", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(636) },
                    { 20, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(637), "Summer", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(637) },
                    { 21, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(638), "Creative", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(639) },
                    { 22, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(640), "Technical", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(640) },
                    { 23, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(641), "Social", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(642) },
                    { 24, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(643), "Extreme", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(643) },
                    { 25, new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(644), "Educational", new DateTime(2026, 3, 25, 20, 44, 10, 824, DateTimeKind.Utc).AddTicks(645) }
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
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
