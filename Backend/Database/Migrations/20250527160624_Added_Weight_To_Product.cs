using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class Added_Weight_To_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");
        }
    }
}
