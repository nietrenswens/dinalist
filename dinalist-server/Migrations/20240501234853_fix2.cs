using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dinalist_server.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DiningRooms_DiningRoomId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiningRoomId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DiningRooms_DiningRoomId",
                table: "Users",
                column: "DiningRoomId",
                principalTable: "DiningRooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DiningRooms_DiningRoomId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiningRoomId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DiningRooms_DiningRoomId",
                table: "Users",
                column: "DiningRoomId",
                principalTable: "DiningRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
