using Microsoft.EntityFrameworkCore.Migrations;

namespace STI.Data.Migrations
{
    public partial class Initial_STI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Region = table.Column<int>(nullable: false),
                    WarehouseTypeId = table.Column<int>(nullable: false),
                    ParentWarehouseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_WarehouseType_Id",
                        column: x => x.Id,
                        principalTable: "WarehouseType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "WarehouseType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Almacen Tipo 1" });

            migrationBuilder.InsertData(
                table: "WarehouseType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Almacen Tipo 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "WarehouseType");
        }
    }
}
