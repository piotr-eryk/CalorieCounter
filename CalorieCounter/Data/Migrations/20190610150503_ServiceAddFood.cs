using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalorieCounter.Data.Migrations
{
    public partial class ServiceAddFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_ServiceAddFood_FoodId",
                table: "ServiceAddFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAddFood_FoodTypeId",
                table: "ServiceAddFood",
                column: "FoodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceAddFood");
        }
    }
}
