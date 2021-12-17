using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EO_S20_TestBooking.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"), "Paludan mullersvej 24, 8200 Aarhus N" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"), "Finlandsgade 67, 8200 Aarhus N" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"), "Møllegårdsvej 1, 8200 Aarhus N" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "LocationId", "Ssn" },
                values: new object[,]
                {
                    { new Guid("621132f3-699c-44aa-89ac-9e0a0a9a123d"), new DateTime(2021, 12, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"), "1001001000" },
                    { new Guid("2d68ac3c-ec9f-4bfe-b43c-301358e1ae83"), new DateTime(2021, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"), "1001001001" },
                    { new Guid("3fe93d4f-e863-4a56-b172-5623eabe92ae"), new DateTime(2021, 12, 19, 12, 40, 0, 0, DateTimeKind.Unspecified), new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"), "1001001002" },
                    { new Guid("076e23be-191f-4405-9d94-57512ba9b112"), new DateTime(2021, 12, 19, 12, 50, 0, 0, DateTimeKind.Unspecified), new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"), "1001001003" },
                    { new Guid("0d9cd0ee-80a3-402c-b9b3-180557ff5ac9"), new DateTime(2021, 12, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"), "1001001000" },
                    { new Guid("fc24f192-8d42-423e-bd3b-f987ffa67b4c"), new DateTime(2021, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"), "1001001001" },
                    { new Guid("49353586-1124-4ab6-9c8e-d20724ee10c0"), new DateTime(2021, 12, 18, 12, 40, 0, 0, DateTimeKind.Unspecified), new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"), "1001001002" },
                    { new Guid("6e8a3006-b3fd-48b5-9034-9efffcde3524"), new DateTime(2021, 12, 19, 12, 50, 0, 0, DateTimeKind.Unspecified), new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"), "1001001003" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
