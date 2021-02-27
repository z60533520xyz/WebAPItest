using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPItest.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayIdInformation",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    Agency = table.Column<string>(maxLength: 50, nullable: false),
                    Medium = table.Column<string>(maxLength: 50, nullable: true),
                    InsType = table.Column<string>(maxLength: 5, nullable: false),
                    PayId = table.Column<string>(maxLength: 10, nullable: false),
                    PayIdName = table.Column<string>(maxLength: 50, nullable: false),
                    PayIdSex = table.Column<string>(maxLength: 1, nullable: false),
                    PayIdBirthday = table.Column<DateTime>(type: "date", nullable: false),
                    PayIdZipM = table.Column<string>(maxLength: 5, nullable: false),
                    PayIdCityM = table.Column<string>(maxLength: 3, nullable: false),
                    PayIdAreaM = table.Column<string>(maxLength: 4, nullable: false),
                    PayIdAddrM = table.Column<string>(maxLength: 50, nullable: false),
                    PayIdTelH = table.Column<string>(maxLength: 15, nullable: true),
                    PayIdTelMv = table.Column<string>(maxLength: 12, nullable: false),
                    PayIdEmail = table.Column<string>(maxLength: 50, nullable: false),
                    ApplyNo = table.Column<string>(maxLength: 12, nullable: false),
                    DueDt = table.Column<DateTime>(type: "date", nullable: false),
                    TotInv = table.Column<string>(maxLength: 12, nullable: false),
                    SendType = table.Column<string>(maxLength: 1, nullable: false),
                    Englishpolicy = table.Column<string>(maxLength: 1, nullable: true),
                    Location = table.Column<string>(maxLength: 1, nullable: false),
                    LocationCode = table.Column<string>(maxLength: 4, nullable: false),
                    TravelDateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    TravelDateEnd = table.Column<DateTime>(type: "date", nullable: false),
                    TravelDateHour = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayIdInformation", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "SendApiRequest",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    Agency = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(nullable: true),
                    InsType = table.Column<string>(nullable: true),
                    PayId = table.Column<string>(nullable: true),
                    PayIdName = table.Column<string>(nullable: true),
                    PayIdSex = table.Column<string>(nullable: true),
                    PayIdBirthday = table.Column<DateTime>(type: "date", nullable: false),
                    PayIdZipM = table.Column<string>(nullable: true),
                    PayIdCityM = table.Column<string>(nullable: true),
                    PayIdAreaM = table.Column<string>(nullable: true),
                    PayIdAddrM = table.Column<string>(nullable: true),
                    PayIdTelH = table.Column<string>(nullable: true),
                    PayIdTelMv = table.Column<string>(nullable: true),
                    PayIdEmail = table.Column<string>(nullable: true),
                    ApplyNo = table.Column<string>(nullable: true),
                    DueDt = table.Column<DateTime>(type: "date", nullable: false),
                    TotInv = table.Column<string>(nullable: true),
                    SendType = table.Column<string>(nullable: true),
                    Englishpolicy = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LocationCode = table.Column<string>(nullable: true),
                    TravelDateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    TravelDateEnd = table.Column<DateTime>(type: "date", nullable: false),
                    TravelDateHour = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    EngName = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    Idname = table.Column<string>(nullable: true),
                    IdSex = table.Column<string>(nullable: true),
                    IdBirthday = table.Column<DateTime>(type: "date", nullable: false),
                    IdCityM = table.Column<string>(nullable: true),
                    IdAreaM = table.Column<string>(nullable: true),
                    IdZipM = table.Column<string>(nullable: true),
                    IdaddrM = table.Column<string>(nullable: true),
                    IdtelH = table.Column<string>(nullable: true),
                    IdtelMv = table.Column<string>(nullable: true),
                    IdEmail = table.Column<string>(nullable: true),
                    Relation = table.Column<string>(nullable: true),
                    IdDeclarationOFGuardian = table.Column<string>(nullable: true),
                    IdJobClass = table.Column<int>(nullable: false),
                    PolicyPregnancy = table.Column<string>(nullable: true),
                    PolicyOtherMM = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    BenId = table.Column<string>(nullable: true),
                    BenName = table.Column<string>(nullable: true),
                    BenPhone = table.Column<string>(nullable: true),
                    BenZipM = table.Column<string>(nullable: true),
                    BenAddrM = table.Column<string>(nullable: true),
                    BenProportion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BenSeq = table.Column<int>(nullable: false),
                    ProdCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendApiRequest", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "BenIdInformation",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    Relationship = table.Column<string>(maxLength: 1, nullable: false),
                    BenId = table.Column<string>(maxLength: 10, nullable: true),
                    BenName = table.Column<string>(maxLength: 50, nullable: true),
                    BenPhone = table.Column<string>(maxLength: 12, nullable: true),
                    BenZipM = table.Column<string>(maxLength: 5, nullable: true),
                    BenAddrM = table.Column<string>(maxLength: 50, nullable: true),
                    BenProportion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BenSeq = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenIdInformation", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_BenIdInformation_PayIdInformation_Guid",
                        column: x => x.Guid,
                        principalTable: "PayIdInformation",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdInformation",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    Id = table.Column<string>(maxLength: 10, nullable: true),
                    EngName = table.Column<string>(maxLength: 50, nullable: true),
                    Passport = table.Column<string>(maxLength: 50, nullable: true),
                    Idname = table.Column<string>(maxLength: 50, nullable: false),
                    IdSex = table.Column<string>(maxLength: 1, nullable: false),
                    IdBirthday = table.Column<DateTime>(type: "date", nullable: false),
                    IdCityM = table.Column<string>(maxLength: 3, nullable: false),
                    IdAreaM = table.Column<string>(maxLength: 4, nullable: false),
                    IdZipM = table.Column<string>(maxLength: 5, nullable: false),
                    IdaddrM = table.Column<string>(maxLength: 50, nullable: false),
                    IdtelH = table.Column<string>(maxLength: 13, nullable: true),
                    IdtelMv = table.Column<string>(maxLength: 12, nullable: false),
                    IdEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Relation = table.Column<string>(maxLength: 1, nullable: true),
                    IdDeclarationOFGuardian = table.Column<string>(maxLength: 1, nullable: false),
                    IdJobClass = table.Column<int>(nullable: false),
                    PolicyPregnancy = table.Column<string>(maxLength: 1, nullable: true),
                    PolicyOtherMM = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdInformation", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_IdInformation_PayIdInformation_Guid",
                        column: x => x.Guid,
                        principalTable: "PayIdInformation",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    ProdCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Product_PayIdInformation_Guid",
                        column: x => x.Guid,
                        principalTable: "PayIdInformation",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenIdInformation");

            migrationBuilder.DropTable(
                name: "IdInformation");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SendApiRequest");

            migrationBuilder.DropTable(
                name: "PayIdInformation");
        }
    }
}
