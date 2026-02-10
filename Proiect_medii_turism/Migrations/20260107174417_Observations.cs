using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_medii_turism.Migrations
{
    /// <inheritdoc />
    public partial class Observations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observations",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observations",
                table: "Bookings");
        }
    }
}
