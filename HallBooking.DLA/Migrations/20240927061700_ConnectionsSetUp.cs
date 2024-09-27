using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallBooking.DLA.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionsSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Bookings");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceHour",
                table: "ConferenceRooms",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "ConferenceRooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceHour",
                table: "ConferenceRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "ConferenceRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
