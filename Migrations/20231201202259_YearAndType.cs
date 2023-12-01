using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment5_Voglewede_Woods.Migrations
{
    /// <inheritdoc />
    public partial class YearAndType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Music_Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Music_Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Music_Inventory");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Music_Inventory");
        }
    }
}
