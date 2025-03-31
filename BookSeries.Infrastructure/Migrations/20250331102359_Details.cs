using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSeries.Infrastructure.Migrations
{
    public partial class Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderDetails");
        }
    }
}
