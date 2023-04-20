using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_react.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationsIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ogrnip",
                table: "Organizations",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Ogrn",
                table: "Organizations",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "Organizations",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ogrnip",
                table: "Organizations",
                type: "INTEGER",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "Ogrn",
                table: "Organizations",
                type: "INTEGER",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<int>(
                name: "Inn",
                table: "Organizations",
                type: "INTEGER",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);
        }
    }
}
