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
                    ProfileSetupComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommunityId = table.Column<int>(type: "INTEGER", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    PhotoUrls = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Places_Users_UserId",
                        column: x => x.UserId,
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
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommunityId = table.Column<int>(type: "INTEGER", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    PhotoUrls = table.Column<string>(type: "TEXT", nullable: false),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: false),
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
                name: "PlaceVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceVotes_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceVotes_Users_UserId",
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
                    Content = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: true),
                    PlaceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
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
                        name: "FK_Comments_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
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
                    { 1, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6354), "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills.", "Football", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6362) },
                    { 2, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6750), "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games.", "Basketball", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6750) },
                    { 3, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6751), "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment.", "Volleyball", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6752) },
                    { 4, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6752), "America's pastime - bat, pitch, and field in this strategic team sport.", "Baseball", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6753) },
                    { 5, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6754), "A high-intensity contact sport requiring strength, speed, and teamwork.", "Rugby", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6754) },
                    { 6, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6759), "Fast-paced indoor sport combining elements of basketball and soccer.", "Handball", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6759) },
                    { 7, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6760), "Throw, dodge, and catch in this exciting and energetic team game.", "Dodgeball", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6760) },
                    { 8, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6761), "Tackle football with strategic plays and intense physicality.", "American Football", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6761) },
                    { 11, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6762), "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness.", "Tennis", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6762) },
                    { 12, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6764), "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility.", "Badminton", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6764) },
                    { 13, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6765), "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun.", "Table Tennis (Ping Pong)", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6765) },
                    { 15, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6766), "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social.", "Padel", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6766) },
                    { 17, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6767), "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise.", "Walking", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6767) },
                    { 18, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6768), "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone.", "Hiking", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6768) },
                    { 19, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6769), "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise.", "Running/Jogging", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6769) },
                    { 20, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6770), "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout.", "Cycling", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6770) },
                    { 21, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6771), "Observe and identify birds in their natural habitat. A peaceful outdoor community that connects you with nature.", "Bird Watching", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6771) },
                    { 22, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6772), "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing.", "Picnicking", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6773) },
                    { 23, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6773), "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring community.", "Stargazing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6774) },
                    { 24, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6790), "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee.", "Frisbee", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6790) },
                    { 25, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6791), "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio.", "Yoga", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6791) },
                    { 26, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6792), "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment.", "Weight Training", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6792) },
                    { 30, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6793), "High-energy stationary bike workout often done in group classes.", "Spinning/Indoor Cycling", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6793) },
                    { 31, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6794), "Cardiovascular exercise routine performed to music, often in a group setting.", "Aerobics", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6794) },
                    { 33, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6808), "Improve flexibility and reduce muscle tension through dedicated stretching routines.", "Stretching", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6808) },
                    { 34, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6809), "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed.", "Calisthenics", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6809) },
                    { 35, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6810), "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints.", "Swimming", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6810) },
                    { 36, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6811), "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance.", "Surfing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6811) },
                    { 37, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6812), "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength.", "Kayaking", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6812) },
                    { 38, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6813), "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore.", "Paddleboarding (SUP)", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6813) },
                    { 39, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6814), "Intense team water sport combining swimming, ball handling, and strategy.", "Water Polo", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6814) },
                    { 40, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6815), "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences.", "Scuba Diving", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6815) },
                    { 41, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6816), "Swim on the water surface while viewing underwater attractions through a snorkel mask.", "Snorkeling", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6816) },
                    { 42, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6817), "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration.", "Canoeing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6817) },
                    { 43, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6818), "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping.", "Jet Skiing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6819) },
                    { 44, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6819), "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature.", "Sailing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6820) },
                    { 45, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6820), "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity.", "Painting", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6821) },
                    { 46, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6821), "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet.", "Drawing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6822) },
                    { 47, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6822), "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera.", "Photography", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6823) },
                    { 70, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6823), "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills.", "Chess", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6824) },
                    { 71, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6824), "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone.", "Board Games", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6825) },
                    { 72, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6825), "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports.", "Video Gaming", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6826) },
                    { 73, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6826), "Play poker, bridge, magic the gathering, or casual card games with friends.", "Card Games", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6827) },
                    { 74, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6827), "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers.", "Puzzle Solving", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6828) },
                    { 76, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6828), "Throw darts at a target board. Fun pub game that improves focus and precision.", "Darts", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6829) },
                    { 77, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6829), "Play pool, snooker, or other cue sports at a table. Strategic and social community.", "Pool/Billiards", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6830) },
                    { 78, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6830), "Test your knowledge in trivia nights or quiz games. Great for groups and learning.", "Trivia/Quiz Games", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6831) },
                    { 79, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6831), "Solve puzzles and riddles to 'escape' from a themed room within a time limit.", "Escape Rooms", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6832) },
                    { 86, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6832), "Give back to your community through volunteer work. A rewarding way to make a positive impact.", "Volunteering", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6833) },
                    { 88, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6833), "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination.", "Reading", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6834) },
                    { 95, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6834), "Study celestial objects and phenomena. Combine observation with scientific learning.", "Astronomy", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6835) },
                    { 98, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6835), "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere.", "Meditation", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6836) },
                    { 107, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6836), "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres.", "Listening to Music", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6837) },
                    { 113, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6837), "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts.", "Skiing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6838) },
                    { 114, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6838), "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport.", "Snowboarding", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6839) },
                    { 115, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6839), "Glide on ice at a rink. Fun winter community that builds balance and leg strength.", "Ice Skating", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6840) },
                    { 116, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6840), "Fast-paced team sport played on ice. Requires skating ability and competitive spirit.", "Ice Hockey", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6841) },
                    { 130, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6842), "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence.", "Rock Climbing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6842) },
                    { 132, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6842), "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination.", "Skateboarding", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6843) },
                    { 133, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6843), "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity.", "Parkour", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6844) },
                    { 134, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6845), "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports.", "BMX Biking", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6845) },
                    { 135, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6846), "Ride bicycles off-road on rugged terrain. Adventurous and challenging.", "Mountain Biking", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6846) },
                    { 138, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6847), "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines.", "Camping", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6847) },
                    { 139, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6848), "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary.", "Fishing", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6848) },
                    { 141, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6849), "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise.", "Horseback Riding", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6849) },
                    { 143, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6850), "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy.", "Golf", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6850) },
                    { 145, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6851), "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty.", "Foraging", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6851) },
                    { 146, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6852), "Navigate through terrain using a map and compass. Combines hiking with navigational challenges.", "Orienteering", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6853) },
                    { 147, new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6853), "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors.", "Metal Detecting", new DateTime(2026, 6, 29, 18, 21, 35, 406, DateTimeKind.Utc).AddTicks(6854) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PlaceId_ParentCommentId",
                table: "Comments",
                columns: new[] { "PlaceId", "ParentCommentId" });

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
                name: "IX_Places_CommunityId",
                table: "Places",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CreatedAt",
                table: "Places",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Places_Score",
                table: "Places",
                column: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_Places_UserId",
                table: "Places",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceVotes_PlaceId",
                table: "PlaceVotes",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceVotes_UserId_PlaceId",
                table: "PlaceVotes",
                columns: new[] { "UserId", "PlaceId" },
                unique: true);

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
                name: "PlaceVotes");

            migrationBuilder.DropTable(
                name: "PostVotes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
