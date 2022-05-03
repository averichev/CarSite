using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSite.Migrations
{
    /// <inheritdoc />
    public partial class CarRowCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RowCreated",
                table: "Car",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowCreated",
                table: "Car");
        }
    }
}
