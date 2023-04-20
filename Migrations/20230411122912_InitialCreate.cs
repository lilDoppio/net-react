using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_react.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    Inn = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    Ogrnip = table.Column<int>(type: "INTEGER", maxLength: 15, nullable: false),
                    Ogrn = table.Column<int>(type: "INTEGER", maxLength: 13, nullable: false),
                    RegistartionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    InnSkan = table.Column<bool>(type: "INTEGER", nullable: false),
                    OgrnSkan = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrgnipSkan = table.Column<bool>(type: "INTEGER", nullable: false),
                    Egrip = table.Column<bool>(type: "INTEGER", nullable: false),
                    OfficeRentSkan = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bic = table.Column<int>(type: "INTEGER", maxLength: 11, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentAccount = table.Column<int>(type: "INTEGER", maxLength: 20, nullable: false),
                    CorresponndentAccount = table.Column<int>(type: "INTEGER", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationsRequisites",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequisitesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationsRequisites", x => new { x.OrganizationId, x.RequisitesId });
                    table.ForeignKey(
                        name: "FK_OrganizationsRequisites_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationsRequisites_Requisites_RequisitesId",
                        column: x => x.RequisitesId,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsRequisites_RequisitesId",
                table: "OrganizationsRequisites",
                column: "RequisitesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationsRequisites");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Requisites");
        }
    }
}
