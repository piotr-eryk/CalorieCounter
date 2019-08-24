using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounter.Data.Migrations
{
    public partial class FoodHeader2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<int>(nullable: false),
                    TotalCalories = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DailyFoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodHeader_DailyFood_DailyFoodId",
                        column: x => x.DailyFoodId,
                        principalTable: "DailyFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodHeader_DailyFoodId",
                table: "FoodHeader",
                column: "DailyFoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
