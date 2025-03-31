using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSeries.Infrastructure.Migrations
{
    public partial class UpdateDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_OrderDetails_OrderDetailsId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_OrderDetailsId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OrderDetailsId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Books_BookId",
                table: "OrderDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Books_BookId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailsId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_OrderDetailsId",
                table: "Books",
                column: "OrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_OrderDetails_OrderDetailsId",
                table: "Books",
                column: "OrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "Id");
        }
    }
}
