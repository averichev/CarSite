using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSite.Migrations
{
    /// <inheritdoc />
    public partial class Relations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyId",
                table: "Car",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandId",
                table: "Car",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Body_BodyId",
                table: "Car",
                column: "BodyId",
                principalTable: "Body",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Brand_BrandId",
                table: "Car",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Body_BodyId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Brand_BrandId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_BodyId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_BrandId",
                table: "Car");
        }
    }
}
