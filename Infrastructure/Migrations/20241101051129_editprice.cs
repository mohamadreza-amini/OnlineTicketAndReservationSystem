using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Ticket",
                type: "Decimal(13,3)",
                precision: 13,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(3,0)",
                oldPrecision: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Ticket",
                type: "Decimal(3,0)",
                precision: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(13,3)",
                oldPrecision: 13,
                oldScale: 3);
        }
    }
}
