using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestAppNet.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SecondName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    DateOfBirt = table.Column<DateTime>(nullable: false),
                    SNILS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PfrStorages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PfrStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PfrStorages_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PfrStorages_PersonId",
                table: "PfrStorages",
                column: "PersonId");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "SecondName", "FirstName", "MiddleName", "DateOfBirt", "SNILS" },
                values: new object[] { 0, "Иванов", "Иван", "Иванович", new DateTime(1999, 1, 1), "123-456-789 10" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "SecondName", "FirstName", "MiddleName", "DateOfBirt", "SNILS" },
                values: new object[] { 1, "Петров", "Петр", "Петрович", new DateTime(2000, 2, 2), "111-222-333 44" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "SecondName", "FirstName", "MiddleName", "DateOfBirt", "SNILS" },
                values: new object[] { 2, "Сидоров", "Костик", "Алексеевич", new DateTime(1990, 12, 13), "111-111-111 22" });

            migrationBuilder.InsertData(
                table: "PfrStorages",
                columns: new[] { "Id", "FromDate", "ToDate", "Sum", "PersonId" },
                values: new object[] { 0, new DateTime(2005, 1, 1), new DateTime(2008, 1, 1), 100, "0" });

            migrationBuilder.InsertData(
                table: "PfrStorages",
                columns: new[] { "Id", "FromDate", "ToDate", "Sum", "PersonId" },
                values: new object[] { 1, new DateTime(2010, 1, 1), new DateTime(2015, 1, 1), 200, "0" });
            migrationBuilder.InsertData(
                table: "PfrStorages",
                columns: new[] { "Id", "FromDate", "ToDate", "Sum", "PersonId" },
                values: new object[] { 2, new DateTime(2017, 1, 1), new DateTime(2020, 1, 1), 300, "0" });

            migrationBuilder.InsertData(
                table: "PfrStorages",
                columns: new[] { "Id", "FromDate", "ToDate", "Sum", "PersonId" },
                values: new object[] { 3, new DateTime(2013, 1, 1), new DateTime(2018, 1, 1), 150, "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PfrStorages");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
