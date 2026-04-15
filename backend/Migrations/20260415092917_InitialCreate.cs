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
                    CommunityId = table.Column<int>(type: "INTEGER", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    PlaceId = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Communities_CommunityId",
                        column: x => x.CommunityId,
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
                    { 1, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7355), "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills.", "Football", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7361) },
                    { 2, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7740), "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games.", "Basketball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7741) },
                    { 3, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7742), "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment.", "Volleyball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7742) },
                    { 4, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7743), "America's pastime - bat, pitch, and field in this strategic team sport.", "Baseball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7743) },
                    { 5, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7744), "A high-intensity contact sport requiring strength, speed, and teamwork.", "Rugby", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7744) },
                    { 6, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7755), "Fast-paced indoor sport combining elements of basketball and soccer.", "Handball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7755) },
                    { 7, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7756), "Throw, dodge, and catch in this exciting and energetic team game.", "Dodgeball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7756) },
                    { 8, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7757), "Tackle football with strategic plays and intense physicality.", "American Football", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7757) },
                    { 9, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7758), "A fun, accessible game similar to baseball but played with a large rubber ball.", "Kickball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7758) },
                    { 10, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7759), "Roll strikes and spares at your local bowling alley. Great social community for all ages.", "Bowling", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7759) },
                    { 11, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7778), "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness.", "Tennis", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7778) },
                    { 12, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7779), "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility.", "Badminton", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7779) },
                    { 13, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7780), "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun.", "Table Tennis (Ping Pong)", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7780) },
                    { 14, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7781), "Intense racket sport played in a four-walled court. Excellent cardio workout.", "Squash", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7781) },
                    { 15, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7782), "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social.", "Pickleball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7782) },
                    { 16, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7783), "High-energy racket sport played in an enclosed court with a hollow rubber ball.", "Racquetball", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7783) },
                    { 17, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7784), "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise.", "Walking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7784) },
                    { 18, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7785), "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone.", "Hiking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7785) },
                    { 19, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7786), "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise.", "Running/Jogging", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7786) },
                    { 20, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7787), "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout.", "Cycling", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7787) },
                    { 21, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7788), "Observe and identify birds in their natural habitat. A peaceful outdoor community that connects you with nature.", "Bird Watching", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7788) },
                    { 22, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7789), "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing.", "Picnicking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7789) },
                    { 23, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7790), "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring community.", "Stargazing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7790) },
                    { 24, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7791), "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee.", "Frisbee", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7791) },
                    { 25, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7792), "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio.", "Yoga", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7792) },
                    { 26, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7792), "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment.", "Weight Training", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7793) },
                    { 27, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7793), "Low-impact exercise focusing on core strength, flexibility, and body awareness. Great for all fitness levels.", "Pilates", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7794) },
                    { 28, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7794), "High-intensity functional fitness program combining weightlifting, cardio, and gymnastics.", "CrossFit", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7795) },
                    { 29, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7795), "Dance-based fitness class with energetic Latin and international music.", "Zumba", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7795) },
                    { 30, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7796), "High-energy stationary bike workout often done in group classes.", "Spinning/Indoor Cycling", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7796) },
                    { 31, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7797), "Cardiovascular exercise routine performed to music, often in a group setting.", "Aerobics", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7797) },
                    { 32, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7798), "Ballet-inspired workout focusing on low-impact, high-intensity movements.", "Barre", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7798) },
                    { 33, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7799), "Improve flexibility and reduce muscle tension through dedicated stretching routines.", "Stretching", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7799) },
                    { 34, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7801), "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed.", "Calisthenics", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7801) },
                    { 35, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7801), "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints.", "Swimming", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7802) },
                    { 36, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7802), "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance.", "Surfing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7803) },
                    { 37, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7803), "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength.", "Kayaking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7804) },
                    { 38, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7804), "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore.", "Paddleboarding (SUP)", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7804) },
                    { 39, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7805), "Intense team water sport combining swimming, ball handling, and strategy.", "Water Polo", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7805) },
                    { 40, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7806), "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences.", "Scuba Diving", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7806) },
                    { 41, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7807), "Swim on the water surface while viewing underwater attractions through a snorkel mask.", "Snorkeling", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7807) },
                    { 42, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7808), "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration.", "Canoeing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7808) },
                    { 43, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7809), "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping.", "Jet Skiing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7809) },
                    { 44, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7817), "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature.", "Sailing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7817) },
                    { 45, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7818), "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity.", "Painting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7818) },
                    { 46, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7819), "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet.", "Drawing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7819) },
                    { 47, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7819), "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera.", "Photography", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7820) },
                    { 48, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7820), "Create three-dimensional art with clay, stone, metal, or other materials.", "Sculpting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7821) },
                    { 49, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7821), "Create functional or decorative ceramic pieces. A hands-on art form that's both creative and meditative.", "Pottery", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7821) },
                    { 50, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7822), "Create art using digital tools like tablets and software. Modern artistic expression.", "Digital Art", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7822) },
                    { 51, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7823), "The art of beautiful handwriting. Practice various lettering styles with pens and brushes.", "Calligraphy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7823) },
                    { 52, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7824), "Japanese paper folding art. Create intricate designs from simple paper squares.", "Origami", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7824) },
                    { 53, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7825), "Create visual content for digital and print media. Combine art and communication.", "Graphic Design", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7825) },
                    { 54, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7826), "Bring drawings and characters to life through frame-by-frame or digital animation.", "Animation", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7826) },
                    { 55, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7827), "Design and create jewelry pieces using various materials and techniques.", "Jewelry Making", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7827) },
                    { 56, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7828), "Create custom candles with different scents, colors, and designs.", "Candle Making", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7828) },
                    { 57, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7829), "Craft handmade soaps with natural ingredients and custom fragrances.", "Soap Making", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7829) },
                    { 58, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7830), "Build furniture, decorations, or art pieces from wood. Satisfying hands-on craft.", "Woodworking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7830) },
                    { 59, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7830), "Craft items from leather including wallets, bags, and belts.", "Leatherworking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7831) },
                    { 60, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7831), "Learn to play acoustic or electric guitar. Great for self-expression and can be enjoyed solo or in a band.", "Guitar", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7832) },
                    { 61, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7832), "Learn classical pieces or contemporary songs on the piano. A versatile instrument suitable for all ages.", "Piano", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7833) },
                    { 62, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7833), "Practice singing alone or join a choir. Express yourself through music and improve your vocal skills.", "Singing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7833) },
                    { 63, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7834), "Learn rhythm and coordination through drumming. Great stress relief and physical workout.", "Drums", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7834) },
                    { 64, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7835), "Master this elegant string instrument. Requires dedication but offers beautiful musical expression.", "Violin", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7835) },
                    { 65, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7836), "Mix and create music using turntables or digital equipment. Perfect for music enthusiasts.", "DJing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7836) },
                    { 66, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7843), "Create original music using digital audio workstations and software.", "Music Production", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7843) },
                    { 67, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7844), "Provide the rhythmic foundation in bands or practice solo. Essential in many music genres.", "Bass Guitar", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7844) },
                    { 68, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7845), "Learn this expressive wind instrument popular in jazz, classical, and contemporary music.", "Saxophone", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7845) },
                    { 69, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7846), "Create percussion sounds and music with your mouth. No equipment needed, just practice.", "Beatboxing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7846) },
                    { 70, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7847), "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills.", "Chess", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7847) },
                    { 71, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7848), "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone.", "Board Games", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7848) },
                    { 72, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7849), "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports.", "Video Gaming", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7849) },
                    { 73, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7850), "Play poker, bridge, magic the gathering, or casual card games with friends.", "Card Games", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7850) },
                    { 74, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7850), "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers.", "Puzzle Solving", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7851) },
                    { 75, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7851), "Master the classic 3D combination puzzle. Great for developing spatial reasoning.", "Rubik's Cube", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7852) },
                    { 76, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7859), "Throw darts at a target board. Fun pub game that improves focus and precision.", "Darts", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7859) },
                    { 77, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7860), "Play pool, snooker, or other cue sports at a table. Strategic and social community.", "Pool/Billiards", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7860) },
                    { 78, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7861), "Test your knowledge in trivia nights or quiz games. Great for groups and learning.", "Trivia/Quiz Games", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7861) },
                    { 79, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7862), "Solve puzzles and riddles to 'escape' from a themed room within a time limit.", "Escape Rooms", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7862) },
                    { 80, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7863), "Experiment in the kitchen with new recipes. Cook meals for yourself or loved ones.", "Cooking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7863) },
                    { 81, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7864), "Bake bread, cakes, cookies, and pastries. A precise and rewarding culinary art.", "Baking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7864) },
                    { 82, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7864), "Explore different coffee beans, roasts, and brewing methods. Develop your palate.", "Coffee Tasting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7865) },
                    { 83, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7865), "Sample and appreciate different wines. Learn about varieties, regions, and pairing.", "Wine Tasting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7866) },
                    { 84, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7866), "Brew your own beer, cider, or kombucha. A fascinating blend of science and art.", "Homebrewing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7866) },
                    { 85, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7867), "Learn various dance styles from salsa to hip-hop. Great exercise and a fun social community.", "Dancing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7867) },
                    { 86, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7868), "Give back to your community through volunteer work. A rewarding way to make a positive impact.", "Volunteering", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7868) },
                    { 87, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7869), "Join a group to read and discuss books. Combine reading with social interaction.", "Book Club", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7869) },
                    { 88, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7870), "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination.", "Reading", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7870) },
                    { 89, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7871), "Study a new language through apps, courses, or tutors. Expand your communication skills and cultural understanding.", "Learning a Language", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7871) },
                    { 90, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7872), "Learn to code in various programming languages. Build apps, websites, or automate tasks.", "Coding/Programming", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7872) },
                    { 91, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7873), "Creative writing, journaling, or blogging. Express thoughts and develop storytelling skills.", "Writing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7873) },
                    { 92, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7874), "Create and share audio content on communities you're passionate about. Express ideas and connect with audiences.", "Podcasting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7874) },
                    { 93, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7874), "Share your thoughts, experiences, or expertise through written or video blogs.", "Blogging/Vlogging", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7875) },
                    { 94, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7875), "Take structured online courses on platforms like Coursera, Udemy, or edX. Learn anything from anywhere.", "Online Courses", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7876) },
                    { 95, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7876), "Study celestial objects and phenomena. Combine observation with scientific learning.", "Astronomy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7876) },
                    { 96, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7877), "Explore philosophical texts and ideas. Develop critical thinking and question fundamental concepts.", "Philosophy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7877) },
                    { 97, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7878), "Deep dive into historical periods, events, or figures. Understand the past to inform the present.", "History Research", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7878) },
                    { 98, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7879), "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere.", "Meditation", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7879) },
                    { 99, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7880), "Grow plants, flowers, or vegetables. A relaxing hobby that connects you with nature.", "Gardening", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7880) },
                    { 100, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7881), "Practice this gentle martial art focused on slow, flowing movements and breath control.", "Tai Chi", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7881) },
                    { 101, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7882), "Learn massage techniques or receive professional massages for relaxation and muscle relief.", "Massage Therapy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7882) },
                    { 102, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7883), "Use essential oils for therapeutic benefits. Promote relaxation and well-being.", "Aromatherapy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7883) },
                    { 103, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7884), "Write daily thoughts, gratitude, or reflections. Great for mental health and self-awareness.", "Journaling", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7884) },
                    { 104, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7884), "Immerse yourself in nature to reduce stress and improve well-being. Simply be present in natural settings.", "Nature Bathing (Shinrin-Yoku)", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7885) },
                    { 105, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7885), "Practice controlled breathing techniques to reduce stress and improve focus.", "Breathing Exercises", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7886) },
                    { 106, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7886), "Relax in hot water or steam rooms. Great for muscle recovery and stress relief.", "Hot Tub/Sauna", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7887) },
                    { 107, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7887), "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres.", "Listening to Music", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7887) },
                    { 108, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7894), "Traditional Japanese martial art focusing on striking techniques and kata forms.", "Karate", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7894) },
                    { 109, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7895), "Train in the sweet science. Great cardio workout and learn self-defense.", "Boxing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7895) },
                    { 110, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7896), "Japanese martial art focused on throws and grappling techniques.", "Judo", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7896) },
                    { 111, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7897), "Korean martial art known for dynamic kicking techniques and discipline.", "Taekwondo", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7897) },
                    { 112, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7898), "Ground-fighting martial art focused on submissions and positional control.", "Brazilian Jiu-Jitsu", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7898) },
                    { 113, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7899), "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts.", "Skiing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7899) },
                    { 114, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7899), "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport.", "Snowboarding", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7900) },
                    { 115, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7900), "Glide on ice at a rink. Fun winter community that builds balance and leg strength.", "Ice Skating", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7901) },
                    { 116, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7901), "Fast-paced team sport played on ice. Requires skating ability and competitive spirit.", "Ice Hockey", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7901) },
                    { 117, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7902), "Slide down snowy hills on sleds. Simple, fun winter community for all ages.", "Sledding/Tobogganing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7902) },
                    { 118, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7903), "Perform in plays or take acting classes. Express emotions and stories through performance.", "Acting/Theater", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7903) },
                    { 119, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7904), "Write and perform comedy routines. Make people laugh while expressing your unique voice.", "Stand-up Comedy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7904) },
                    { 120, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7905), "Perform unscripted comedy based on audience suggestions. Develops quick thinking and creativity.", "Improv Comedy", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7905) },
                    { 121, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7906), "Learn and perform magic illusions. Entertain others with sleight of hand and misdirection.", "Magic Tricks", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7906) },
                    { 122, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7907), "Learn to juggle balls, clubs, or other objects. Impressive skill that improves coordination.", "Juggling", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7907) },
                    { 123, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7908), "The art of silent acting through exaggerated gestures and expressions.", "Mime", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7908) },
                    { 124, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7909), "Create garments and accessories with knitting needles and yarn. Relaxing and productive.", "Knitting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7909) },
                    { 125, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7909), "Create items using a crochet hook and yarn. Similar to knitting but with different techniques.", "Crocheting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7910) },
                    { 126, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7910), "Make or repair clothing and fabric items. Practical skill that allows for creative expression.", "Sewing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7911) },
                    { 127, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7911), "Decorate fabric with needle and thread designs. Detailed handwork that creates beautiful patterns.", "Embroidery", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7912) },
                    { 128, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7912), "Sew layers of fabric together to create quilts. Combines artistry with practical warmth.", "Quilting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7912) },
                    { 129, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7913), "Create fabric by interlacing threads on a loom. Ancient craft with modern applications.", "Weaving", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7913) },
                    { 130, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7920), "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence.", "Rock Climbing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7920) },
                    { 131, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7921), "Climb shorter walls without ropes, using crash pads. Great intro to climbing.", "Bouldering", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7921) },
                    { 132, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7922), "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination.", "Skateboarding", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7922) },
                    { 133, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7923), "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity.", "Parkour", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7923) },
                    { 134, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7924), "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports.", "BMX Biking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7924) },
                    { 135, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7925), "Ride bicycles off-road on rugged terrain. Adventurous and challenging.", "Mountain Biking", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7925) },
                    { 136, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7925), "Jump from heights while connected to an elastic cord. Ultimate adrenaline rush.", "Bungee Jumping", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7926) },
                    { 137, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7926), "Jump from aircraft and freefall before deploying a parachute. Unforgettable experience.", "Skydiving", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7927) },
                    { 138, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7927), "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines.", "Camping", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7927) },
                    { 139, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7928), "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary.", "Fishing", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7928) },
                    { 140, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7929), "Use GPS to find hidden containers (geocaches) placed by others. Modern treasure hunting.", "Geocaching", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7929) },
                    { 141, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7930), "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise.", "Horseback Riding", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7930) },
                    { 142, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7931), "Shoot arrows at targets with a bow. Ancient skill requiring focus and precision.", "Archery", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7931) },
                    { 143, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7932), "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy.", "Golf", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7932) },
                    { 144, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7933), "Like golf but with frisbees. Throw discs into baskets across a course. Low cost and accessible.", "Disc Golf", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7933) },
                    { 145, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7934), "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty.", "Foraging", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7934) },
                    { 146, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7934), "Navigate through terrain using a map and compass. Combines hiking with navigational challenges.", "Orienteering", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7935) },
                    { 147, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7935), "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors.", "Metal Detecting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7936) },
                    { 148, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7936), "Build scale models of vehicles, buildings, or figures. Detail-oriented hobby requiring patience.", "Model Building", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7937) },
                    { 149, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7937), "Collect stamps, coins, cards, or other items. Combines research with the thrill of the hunt.", "Collecting", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7937) },
                    { 150, new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7938), "Fly drones and capture aerial footage. Modern hobby combining technology with creativity.", "Drone Flying", new DateTime(2026, 4, 15, 9, 29, 17, 462, DateTimeKind.Utc).AddTicks(7938) }
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
                name: "IX_Events_CommunityId",
                table: "Events",
                column: "CommunityId");

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
                name: "Events");

            migrationBuilder.DropTable(
                name: "PostVotes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
