using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantityMeasurement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "ConversionHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ConversionHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operation",
                table: "ConversionHistory");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ConversionHistory");
        }
    }
}
