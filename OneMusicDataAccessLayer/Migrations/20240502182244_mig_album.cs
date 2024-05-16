using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneMusic.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_album : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Albums_AlbumId1",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_AlbumId1",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "AlbumId1",
                table: "Albums");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumId1",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AlbumId1",
                table: "Albums",
                column: "AlbumId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Albums_AlbumId1",
                table: "Albums",
                column: "AlbumId1",
                principalTable: "Albums",
                principalColumn: "AlbumId");
        }
    }
}
