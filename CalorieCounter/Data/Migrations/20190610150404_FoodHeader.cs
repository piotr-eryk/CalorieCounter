using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounter.Data.Migrations
{
    public partial class FoodHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodCalories = table.Column<int>(nullable: false),
                    FoodHeaderId = table.Column<int>(nullable: false),
                    FoodName = table.Column<string>(nullable: true),
                    FoodTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDetails_FoodHeader_FoodHeaderId",
                        column: x => x.FoodHeaderId,
                        principalTable: "FoodHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodDetails_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAddFood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodId = table.Column<int>(nullable: false),
                    FoodTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAddFood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAddFood_DailyFood_FoodId",
                        column: x => x.FoodId,
                        principalTable: "DailyFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceAddFood_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodDetails_FoodHeaderId",
                table: "FoodDetails",
                column: "FoodHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDetails_FoodTypeId",
                table: "FoodDetails",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddFood_FoodId",
                table: "ServiceAddFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddFood_FoodTypeId",
                table: "ServiceAddFood",
                column: "FoodTypeId");
        }
    }
}
