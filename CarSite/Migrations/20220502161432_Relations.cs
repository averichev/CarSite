using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSite.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Car",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Car");
        }
    }
}
