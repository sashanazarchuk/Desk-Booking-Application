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
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
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
                table: "Workspaces",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A vibrant shared area perfect for freelancers or small teams who enjoy a collaborative atmosphere. Choose any available desk and get to work with flexibility and ease.", "Open Space" },
                    { 2, "Ideal for focused work, video calls, or small team huddles. These fully enclosed rooms offer privacy and come in a variety of sizes to fit your needs.", "Private rooms" },
                    { 3, "Designed for productive meetings, workshops, or client presentations. Equipped with screens, whiteboards, and comfortable seating to keep your sessions running smoothly.", "Meeting rooms" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "RoomsCount", "WorkspaceId", "WorkspaceType" },
                values: new object[,]
                {
                    { 1, 24, 1, 1, 0 },
                    { 2, 1, 7, 2, 1 },
                    { 3, 2, 4, 2, 1 },
                    { 4, 5, 3, 2, 1 },
                    { 5, 10, 1, 2, 1 },
                    { 6, 10, 4, 3, 2 },
                    { 7, 20, 1, 3, 2 }
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
                    { 4, 3 },
                    { 6, 3 },
                    { 7, 3 }
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
                    { 5, "/images/private-room-1.png", 2 },
                    { 6, "/images/private-room-2.png", 2 },
                    { 7, "/images/private-room-3.png", 2 },
                    { 8, "/images/private-room-4.png", 2 },
                    { 9, "/images/meeting-room-1.png", 3 },
                    { 10, "/images/meeting-room-2.png", 3 },
                    { 11, "/images/meeting-room-3.png", 3 },
                    { 12, "/images/meeting-room-4.png", 3 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Email", "EndDate", "Name", "RoomId", "SeatsBooked", "StartDate" },
                values: new object[,]
                {
                    { 1, "alice@example.com", new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", 1, 1, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "bob@example.com", new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", 2, 1, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
        }
    }
}
