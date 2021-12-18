using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EO_S20_TestBooking.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("076e23be-191f-4405-9d94-57512ba9b112"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("0d9cd0ee-80a3-402c-b9b3-180557ff5ac9"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("2d68ac3c-ec9f-4bfe-b43c-301358e1ae83"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("3fe93d4f-e863-4a56-b172-5623eabe92ae"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("49353586-1124-4ab6-9c8e-d20724ee10c0"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("621132f3-699c-44aa-89ac-9e0a0a9a123d"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("6e8a3006-b3fd-48b5-9034-9efffcde3524"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("fc24f192-8d42-423e-bd3b-f987ffa67b4c"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { new Guid("7457c1b3-b667-4f09-abd4-f706c9c4493b"), "Paludan mullersvej 24, 8200 Aarhus N" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { new Guid("86cdb948-afe1-495a-841a-4b024583f730"), "Finlandsgade 67, 8200 Aarhus N" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address" },
                values: new object[] { new Guid("a89881fe-5a24-4875-bd70-3e5475e6f3fb"), "Møllegårdsvej 1, 8200 Aarhus N" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "LocationId", "Ssn" },
                values: new object[,]
                {
                    { new Guid("e9666c42-fa0d-4599-9662-bc04a8fcb747"), new DateTime(2021, 12, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("7457c1b3-b667-4f09-abd4-f706c9c4493b"), "1001001000" },
                    { new Guid("ae020899-f670-4552-8c57-0321a42b02d0"), new DateTime(2021, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new Guid("7457c1b3-b667-4f09-abd4-f706c9c4493b"), "1001001001" },
                    { new Guid("a40d6823-0bff-4775-9541-d74ba6880544"), new DateTime(2021, 12, 19, 12, 40, 0, 0, DateTimeKind.Unspecified), new Guid("7457c1b3-b667-4f09-abd4-f706c9c4493b"), "1001001002" },
                    { new Guid("ab159e72-d102-4d0d-8066-a1df11f036ec"), new DateTime(2021, 12, 19, 12, 50, 0, 0, DateTimeKind.Unspecified), new Guid("7457c1b3-b667-4f09-abd4-f706c9c4493b"), "1001001003" },
                    { new Guid("5d9aa45d-8ced-4811-945f-1bbf59760790"), new DateTime(2021, 12, 18, 12, 20, 0, 0, DateTimeKind.Unspecified), new Guid("86cdb948-afe1-495a-841a-4b024583f730"), "1001001000" },
                    { new Guid("ef7d992c-6cd5-4d02-9272-5a908bcf607f"), new DateTime(2021, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new Guid("86cdb948-afe1-495a-841a-4b024583f730"), "1001001001" },
                    { new Guid("527fb9ed-a4a3-4261-ab10-5e09408969af"), new DateTime(2021, 12, 18, 12, 40, 0, 0, DateTimeKind.Unspecified), new Guid("a89881fe-5a24-4875-bd70-3e5475e6f3fb"), "1001001002" },
                    { new Guid("e7225b00-a04f-43ea-bbff-a7667023bc39"), new DateTime(2021, 12, 19, 12, 50, 0, 0, DateTimeKind.Unspecified), new Guid("a89881fe-5a24-4875-bd70-3e5475e6f3fb"), "1001001003" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("527fb9ed-a4a3-4261-ab10-5e09408969af"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("5d9aa45d-8ced-4811-945f-1bbf59760790"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("a40d6823-0bff-4775-9541-d74ba6880544"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("ab159e72-d102-4d0d-8066-a1df11f036ec"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("ae020899-f670-4552-8c57-0321a42b02d0"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("e7225b00-a04f-43ea-bbff-a7667023bc39"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("e9666c42-fa0d-4599-9662-bc04a8fcb747"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("ef7d992c-6cd5-4d02-9272-5a908bcf607f"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("7457c1b3-b667-4f09-abd4-f706c9c4493b"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("86cdb948-afe1-495a-841a-4b024583f730"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("a89881fe-5a24-4875-bd70-3e5475e6f3fb"));

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
        }
    }
}
