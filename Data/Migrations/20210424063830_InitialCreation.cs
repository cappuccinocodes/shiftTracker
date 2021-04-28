using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cappuccino.shifttracker.Data.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Rate = table.Column<decimal>(type: "TEXT", nullable: false),
                    Money = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nursing" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Yoga" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Dancing" });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CategoryId", "Duration", "End", "LocationId", "Money", "Rate", "Start" },
                values: new object[] { 1, 1, new TimeSpan(1, 12, 24, 2, 0), new DateTime(2008, 4, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 300m, 20m, new DateTime(2008, 4, 10, 6, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CategoryId", "Duration", "End", "LocationId", "Money", "Rate", "Start" },
                values: new object[] { 6, 1, new TimeSpan(1, 12, 24, 2, 0), new DateTime(2008, 4, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 100m, 40m, new DateTime(2008, 4, 15, 6, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CategoryId", "Duration", "End", "LocationId", "Money", "Rate", "Start" },
                values: new object[] { 2, 2, new TimeSpan(1, 12, 24, 2, 0), new DateTime(2008, 4, 11, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, 300m, 30m, new DateTime(2008, 4, 11, 6, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CategoryId", "Duration", "End", "LocationId", "Money", "Rate", "Start" },
                values: new object[] { 5, 2, new TimeSpan(1, 12, 24, 2, 0), new DateTime(2008, 4, 14, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, 100m, 40m, new DateTime(2008, 4, 14, 6, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CategoryId", "Duration", "End", "LocationId", "Money", "Rate", "Start" },
                values: new object[] { 3, 3, new TimeSpan(1, 12, 24, 2, 0), new DateTime(2008, 4, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), 3, 100m, 40m, new DateTime(2008, 4, 12, 6, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CategoryId", "Duration", "End", "LocationId", "Money", "Rate", "Start" },
                values: new object[] { 4, 3, new TimeSpan(1, 12, 24, 2, 0), new DateTime(2008, 4, 13, 8, 30, 0, 0, DateTimeKind.Unspecified), 3, 100m, 40m, new DateTime(2008, 4, 13, 6, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CategoryId",
                table: "Shifts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
