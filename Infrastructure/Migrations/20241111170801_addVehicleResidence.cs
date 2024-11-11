using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVehicleResidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResidenceId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "CategoryType",
                table: "Category",
                type: "TinyInt",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Residence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    Star = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residence_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comapany = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    Origin = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    VehicleName = table.Column<string>(type: "NVarChar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ResidenceId",
                table: "Ticket",
                column: "ResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_VehicleId",
                table: "Ticket",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Residence_CategoryId",
                table: "Residence",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CategoryId",
                table: "Vehicle",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Residence_ResidenceId",
                table: "Ticket",
                column: "ResidenceId",
                principalTable: "Residence",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Vehicle_VehicleId",
                table: "Ticket",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Residence_ResidenceId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Vehicle_VehicleId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Residence");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ResidenceId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_VehicleId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ResidenceId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Category");
        }
    }
}
