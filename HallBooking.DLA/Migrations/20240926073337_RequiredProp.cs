using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallBooking.DLA.Migrations
{
    /// <inheritdoc />
    public partial class RequiredProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ConferenceRooms_ConferenceRoomId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ConferenceRoomId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ConferenceRoomId",
                table: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceRoomId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ConferenceRoomId",
                table: "Services",
                column: "ConferenceRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ConferenceRooms_ConferenceRoomId",
                table: "Services",
                column: "ConferenceRoomId",
                principalTable: "ConferenceRooms",
                principalColumn: "Id");
        }
    }
}
