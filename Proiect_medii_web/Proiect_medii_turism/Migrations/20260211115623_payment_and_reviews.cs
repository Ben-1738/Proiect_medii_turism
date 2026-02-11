using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_medii_turism.Migrations
{
    /// <inheritdoc />
    public partial class payment_and_reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "TourPackages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    TourPackagePackageId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_TourPackages_TourPackagePackageId",
                        column: x => x.TourPackagePackageId,
                        principalTable: "TourPackages",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourPackages_AgentId",
                table: "TourPackages",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AgentId",
                table: "Bookings",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TourPackagePackageId",
                table: "Reviews",
                column: "TourPackagePackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Agents_AgentId",
                table: "Bookings",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_Agents_AgentId",
                table: "TourPackages",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "AgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Agents_AgentId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_Agents_AgentId",
                table: "TourPackages");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_TourPackages_AgentId",
                table: "TourPackages");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AgentId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "TourPackages");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }
    }
}
