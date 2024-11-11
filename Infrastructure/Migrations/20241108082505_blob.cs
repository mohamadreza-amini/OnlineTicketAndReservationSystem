using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class blob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlobId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Blob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileAddress = table.Column<string>(type: "NVarChar(500)", maxLength: 500, nullable: false),
                    MimeType = table.Column<string>(type: "NVarChar(500)", maxLength: 500, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blob", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BlobId",
                table: "AspNetUsers",
                column: "BlobId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Blob_BlobId",
                table: "AspNetUsers",
                column: "BlobId",
                principalTable: "Blob",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Blob_BlobId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Blob");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BlobId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BlobId",
                table: "AspNetUsers");
        }
    }
}
