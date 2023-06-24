using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PreeceTechnology.Migrations
{
    /// <inheritdoc />
    public partial class NewDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Inventory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { "AC", "Accessories" },
                    { "DM", "Displays / Monitors" },
                    { "OA", "All-in-one Desktops" },
                    { "PT", "PC Towers" },
                    { "RR", "Routers" },
                    { "SS", "Software" }
                });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentId",
                value: "RR");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentId",
                value: "AC");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentId",
                value: "DM");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_DepartmentId",
                table: "Inventory",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Departments_DepartmentId",
                table: "Inventory",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Departments_DepartmentId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_DepartmentId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Inventory");
        }
    }
}
