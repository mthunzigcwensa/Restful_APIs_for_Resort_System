using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestfulAPIs.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokensToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtTokenId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refresh_Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 12, 26, 54, 59, DateTimeKind.Local).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 12, 26, 54, 59, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 12, 26, 54, 59, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 12, 26, 54, 59, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 13, 12, 26, 54, 59, DateTimeKind.Local).AddTicks(6409));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 0, 18, 41, 978, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 0, 18, 41, 978, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 0, 18, 41, 978, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 0, 18, 41, 978, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 0, 18, 41, 978, DateTimeKind.Local).AddTicks(825));
        }
    }
}
