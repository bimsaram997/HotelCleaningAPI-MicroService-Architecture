using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeCleaning.RoomService.Migrations
{
    /// <inheritdoc />
    public partial class AmenityFiledsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Amenities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Amenities",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Amenities");
        }
    }
}
