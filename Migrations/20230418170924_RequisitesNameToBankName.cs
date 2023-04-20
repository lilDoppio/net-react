using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_react.Migrations
{
    /// <inheritdoc />
    public partial class RequisitesNameToBankName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorresponndentAccount",
                table: "Requisites");

            migrationBuilder.RenameColumn(
                name: "bic",
                table: "Requisites",
                newName: "Bic");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Requisites",
                newName: "BankName");

            migrationBuilder.AddColumn<int>(
                name: "CorrespondentAccount",
                table: "Requisites",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrespondentAccount",
                table: "Requisites");

            migrationBuilder.RenameColumn(
                name: "Bic",
                table: "Requisites",
                newName: "bic");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "Requisites",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "CorresponndentAccount",
                table: "Requisites",
                type: "INTEGER",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);
        }
    }
}
