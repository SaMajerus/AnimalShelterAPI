using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class GetRandomandAnimalsCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId1",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalId1",
                table: "Animals",
                column: "AnimalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Animals_AnimalId1",
                table: "Animals",
                column: "AnimalId1",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Animals_AnimalId1",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AnimalId1",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalId1",
                table: "Animals");
        }
    }
}
