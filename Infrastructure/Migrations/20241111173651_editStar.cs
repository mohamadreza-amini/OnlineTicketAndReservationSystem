using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editStar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Star",
                table: "Residence",
                type: "TinyInt",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVarChar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Star",
                table: "Residence",
                type: "NVarChar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "TinyInt",
                oldMaxLength: 100);
        }
    }
}
