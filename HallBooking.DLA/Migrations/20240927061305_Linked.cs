using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallBooking.DLA.Migrations
{
    /// <inheritdoc />
    public partial class Linked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServicesId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Bookings");
        }
    }
}
