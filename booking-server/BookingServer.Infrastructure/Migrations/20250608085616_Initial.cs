using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IconUrl = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coworkings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coworkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CoworkingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workspaces_Coworkings_CoworkingId",
                        column: x => x.CoworkingId,
                        principalTable: "Coworkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkspaceType = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    RoomsCount = table.Column<int>(type: "integer", nullable: false),
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkspaceAmenities",
                columns: table => new
                {
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false),
                    AmenityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspaceAmenities", x => new { x.WorkspaceId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_WorkspaceAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkspaceAmenities_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkspacePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspacePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkspacePhotos_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SeatsBooked = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 1, "/icons/wifi.svg", "Wi-Fi" },
                    { 2, "/icons/coffee.svg", "Coffee" },
                    { 3, "/icons/gamepad.svg", "Game Room" },
                    { 4, "/icons/air-conditioning.svg", "Air Conditioning" },
                    { 5, "/icons/armchair.svg", "Armchair" },
                    { 6, "/icons/headphones.svg", "Headphones" },
                    { 7, "/icons/microphone.svg", "Microphone" },
                    { 8, "/icons/user.svg", "User" }
                });

            migrationBuilder.InsertData(
                table: "Coworkings",
                columns: new[] { "Id", "Address", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "123 Yaroslaviv Val St, Kyiv", "Modern coworking in the heart of Pechersk with quiet rooms and coffee on tap.", "/images/coworking-1.jpg", "WorkClub Pechersk" },
                    { 2, "78 Naberezhno-Khreshchatytska St, Kyiv", "A creative riverside hub ideal for freelancers and small startups.", "/images/coworking-2.jpg", "UrbanSpace Podil" },
                    { 3, "12 Lvivska Square, Kyiv", "A compact, design-focused space with open desks and strong community vibes.", "/images/coworking-3.jpg", "Creative Hub Lvivska" },
                    { 4, "45 Velyka Vasylkivska St, Kyiv", "A high-tech space near Olimpiiska metro, perfect for team sprints and solo focus.", "/images/coworking-4.jpg", "TechNest Olimpiiska" },
                    { 5, "102 Zakrevskogo St, Kyiv", "A quiet, affordable option in the city's northeast—great for remote workers.", "/images/coworking-5.jpg", "Hive Station Troieshchyna" }
                });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "CoworkingId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A vibrant shared area perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease.", "Open Space" },
                    { 2, 1, "Ideal for focused work, video calls, or small team huddles. These fully enclosed rooms offer privacy and come in a variety of sizes to fit your needs.", "Private rooms" },
                    { 3, 2, "Creative and airy shared desks perfect for freelancers.", "Open Space" },
                    { 4, 2, "Well-equipped rooms for presentations and brainstorming sessions.", "Meeting rooms" },
                    { 5, 3, "Design-focused open desks with community-driven atmosphere.", "Open Space" },
                    { 6, 3, "Quiet zones ideal for focused work or video calls.", "Private rooms" },
                    { 7, 4, "Tech-equipped rooms with whiteboards and screens for workshops.", "Meeting rooms" },
                    { 8, 4, "Modern shared desks with fast Wi-Fi and natural light.", "Open Space" },
                    { 9, 5, "Affordable shared desks with essential amenities.", "Open Space" },
                    { 10, 5, "Comfortable and quiet rooms for individuals or small groups.", "Private rooms" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "RoomsCount", "WorkspaceId", "WorkspaceType" },
                values: new object[,]
                {
                    { 1, 24, 1, 1, 0 },
                    { 2, 1, 7, 2, 1 },
                    { 3, 3, 2, 2, 1 },
                    { 4, 16, 1, 3, 0 },
                    { 5, 8, 2, 4, 2 },
                    { 6, 14, 1, 4, 2 },
                    { 7, 10, 1, 5, 0 },
                    { 8, 2, 3, 6, 1 },
                    { 9, 12, 2, 7, 2 },
                    { 10, 20, 1, 8, 0 },
                    { 11, 15, 1, 9, 0 },
                    { 12, 2, 2, 10, 1 },
                    { 13, 4, 1, 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkspaceAmenities",
                columns: new[] { "AmenityId", "WorkspaceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 1, 6 },
                    { 4, 6 },
                    { 6, 6 },
                    { 1, 7 },
                    { 4, 7 },
                    { 6, 7 },
                    { 7, 7 },
                    { 1, 8 },
                    { 2, 8 },
                    { 3, 8 },
                    { 4, 8 },
                    { 1, 9 },
                    { 2, 9 },
                    { 3, 9 },
                    { 4, 9 },
                    { 1, 10 },
                    { 4, 10 },
                    { 6, 10 }
                });

            migrationBuilder.InsertData(
                table: "WorkspacePhotos",
                columns: new[] { "Id", "Url", "WorkspaceId" },
                values: new object[,]
                {
                    { 1, "/images/open-space-1.png", 1 },
                    { 2, "/images/open-space-2.png", 1 },
                    { 3, "/images/open-space-3.png", 1 },
                    { 4, "/images/open-space-4.png", 1 },
                    { 5, "/images/open-space-1.png", 3 },
                    { 6, "/images/open-space-2.png", 3 },
                    { 7, "/images/open-space-3.png", 3 },
                    { 8, "/images/open-space-4.png", 3 },
                    { 9, "/images/open-space-1.png", 5 },
                    { 10, "/images/open-space-2.png", 5 },
                    { 11, "/images/open-space-3.png", 5 },
                    { 12, "/images/open-space-4.png", 5 },
                    { 13, "/images/open-space-1.png", 8 },
                    { 14, "/images/open-space-2.png", 8 },
                    { 15, "/images/open-space-3.png", 8 },
                    { 16, "/images/open-space-4.png", 8 },
                    { 17, "/images/open-space-1.png", 9 },
                    { 18, "/images/open-space-2.png", 9 },
                    { 19, "/images/open-space-3.png", 9 },
                    { 20, "/images/open-space-4.png", 9 },
                    { 21, "/images/private-room-1.png", 2 },
                    { 22, "/images/private-room-2.png", 2 },
                    { 23, "/images/private-room-3.png", 2 },
                    { 24, "/images/private-room-4.png", 2 },
                    { 25, "/images/private-room-1.png", 6 },
                    { 26, "/images/private-room-2.png", 6 },
                    { 27, "/images/private-room-3.png", 6 },
                    { 28, "/images/private-room-4.png", 6 },
                    { 29, "/images/private-room-1.png", 10 },
                    { 30, "/images/private-room-2.png", 10 },
                    { 31, "/images/private-room-3.png", 10 },
                    { 32, "/images/private-room-4.png", 10 },
                    { 33, "/images/meeting-room-1.png", 4 },
                    { 34, "/images/meeting-room-2.png", 4 },
                    { 35, "/images/meeting-room-3.png", 4 },
                    { 36, "/images/meeting-room-4.png", 4 },
                    { 37, "/images/meeting-room-1.png", 7 },
                    { 38, "/images/meeting-room-2.png", 7 },
                    { 39, "/images/meeting-room-3.png", 7 },
                    { 40, "/images/meeting-room-4.png", 7 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Email", "EndDate", "Name", "RoomId", "SeatsBooked", "StartDate" },
                values: new object[,]
                {
                    { 1, "charlie@example.com", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie", 1, 1, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "diana@example.com", new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana", 3, 1, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "ethan@example.com", new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethan", 2, 1, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "fiona@example.com", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiona", 1, 1, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "george@example.com", new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", 4, 1, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "hannah@example.com", new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hannah", 3, 1, new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "ian@example.com", new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ian", 2, 1, new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "julia@example.com", new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julia", 1, 1, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "kevin@example.com", new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin", 5, 1, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "laura@example.com", new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", 4, 1, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "mike@example.com", new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mike", 5, 1, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "nina@example.com", new DateTime(2025, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nina", 3, 1, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "oscar@example.com", new DateTime(2025, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oscar", 2, 1, new DateTime(2025, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "paula@example.com", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paula", 4, 1, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "quinn@example.com", new DateTime(2025, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quinn", 1, 1, new DateTime(2025, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WorkspaceId",
                table: "Rooms",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkspaceAmenities_AmenityId",
                table: "WorkspaceAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkspacePhotos_WorkspaceId",
                table: "WorkspacePhotos",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_CoworkingId",
                table: "Workspaces",
                column: "CoworkingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "WorkspaceAmenities");

            migrationBuilder.DropTable(
                name: "WorkspacePhotos");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "Coworkings");
        }
    }
}
