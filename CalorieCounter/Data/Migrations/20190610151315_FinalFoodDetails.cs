using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounter.Data.Migrations
{
    public partial class FinalFoodDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodHeaderId = table.Column<int>(nullable: false),
                    FoodTypeId = table.Column<int>(nullable: false),
                    FoodCalories = table.Column<int>(nullable: false),
                    FoodName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_FoodHeader_FoodHeaderId",
                        column: x => x.FoodHeaderId,
                        principalTable: "FoodHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodHeaderId",
                table: "Food",
                column: "FoodHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodTypeId",
                table: "Food",
                column: "FoodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
