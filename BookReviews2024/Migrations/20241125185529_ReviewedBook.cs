using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReviews2024.Migrations
{
    public partial class ReviewedBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Reviews",
                newName: "ReviewedBookBookId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewedBookBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_ReviewedBookBookId",
                table: "Reviews",
                column: "ReviewedBookBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_ReviewedBookBookId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewedBookBookId",
                table: "Reviews",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewedBookBookId",
                table: "Reviews",
                newName: "IX_Reviews_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                table: "Reviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
