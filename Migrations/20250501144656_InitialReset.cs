using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netmvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MayTinh");

            migrationBuilder.DropTable(
                name: "SuDungMayTinh");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}
