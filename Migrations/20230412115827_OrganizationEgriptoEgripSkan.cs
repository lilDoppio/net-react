using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_react.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationEgriptoEgripSkan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Egrip",
                table: "Organizations",
                newName: "EgripSkan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EgripSkan",
                table: "Organizations",
                newName: "Egrip");
        }
    }
}
