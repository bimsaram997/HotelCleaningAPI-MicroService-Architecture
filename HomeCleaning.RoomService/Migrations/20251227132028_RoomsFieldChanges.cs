using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeCleaning.RoomService.Migrations
{
    /// <inheritdoc />
    public partial class RoomsFieldChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultBedCount",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "RoomAmenities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultBedCount",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RoomAmenities");
        }
    }
}
