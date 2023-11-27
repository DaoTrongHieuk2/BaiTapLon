using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_KhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    IdKH = table.Column<string>(type: "TEXT", nullable: false),
                    NameKH = table.Column<string>(type: "TEXT", nullable: false),
                    AddressKH = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneKH = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IdKH);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IdNV = table.Column<string>(type: "TEXT", nullable: false),
                    NameNV = table.Column<string>(type: "TEXT", nullable: false),
                    AddressNV = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNV = table.Column<string>(type: "TEXT", nullable: false),
                    AgeNV = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IdNV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
