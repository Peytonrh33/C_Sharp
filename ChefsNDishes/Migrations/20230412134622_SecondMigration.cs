using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefsNDishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefUserId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefUserId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefUserId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Dishes",
                newName: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "ChefId",
                table: "Dishes",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ChefUserId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefUserId",
                table: "Dishes",
                column: "ChefUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefUserId",
                table: "Dishes",
                column: "ChefUserId",
                principalTable: "Chefs",
                principalColumn: "UserId");
        }
    }
}
