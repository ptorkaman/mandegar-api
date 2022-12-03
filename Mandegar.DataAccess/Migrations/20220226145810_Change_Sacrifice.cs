using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class Change_Sacrifice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacrifices_Relations_RelationId",
                table: "Sacrifices");

            migrationBuilder.AlterColumn<int>(
                name: "RelationId",
                table: "Sacrifices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BattlefieldPresenceDuration",
                table: "Sacrifices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 162, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 160, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 161, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 18, 28, 7, 161, DateTimeKind.Local).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 26, 18, 28, 7, 155, DateTimeKind.Local).AddTicks(8437), "PJA4MoQr4A4/7y/PekPVJ1xoszHYSlMpp2ei4gyLb-1/=/2-Od6IhX9ta4RAXzF-1/=/2-ou3kQX" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sacrifices_Relations_RelationId",
                table: "Sacrifices",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sacrifices_Relations_RelationId",
                table: "Sacrifices");

            migrationBuilder.AlterColumn<int>(
                name: "RelationId",
                table: "Sacrifices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BattlefieldPresenceDuration",
                table: "Sacrifices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 79, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 77, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 78, DateTimeKind.Local).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 15, 43, 54, 78, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 26, 15, 43, 54, 72, DateTimeKind.Local).AddTicks(3424), "ZYX5d0zMyIH9IEn48YGYm7htMTfDmoa4H3r7ZJ21DJCj9mxMFURYGWeTRlLt7gKB" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sacrifices_Relations_RelationId",
                table: "Sacrifices",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
