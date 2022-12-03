using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class addentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "DepartmentMeetingAttendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DepartmentMeetingAttendees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DepartmentMeetingAttendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DepartmentMeetingAttendees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DepartmentMeetingAttendees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "DepartmentMeetingAttendees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "DepartmentMeetingAttendees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "DepartmentMeetingAttendees",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 448, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 443, DateTimeKind.Local).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 444, DateTimeKind.Local).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 10, 25, 2, 445, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 24, 10, 25, 2, 436, DateTimeKind.Local).AddTicks(2241), "7IAFcntDVurH0rZ5oI9PdLQksrXbHkFPU50j5-1/=/2-TKfhzW5xs4x59QQJhZluNNiaEq" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_CreatedById",
                table: "DepartmentMeetingAttendees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_ModifiedById",
                table: "DepartmentMeetingAttendees",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_CreatedById",
                table: "DepartmentMeetingAttendees",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_ModifiedById",
                table: "DepartmentMeetingAttendees",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_CreatedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_ModifiedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentMeetingAttendees_CreatedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentMeetingAttendees_ModifiedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 501, DateTimeKind.Local).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 500, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 500, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 21, 18, 49, 39, 500, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 21, 18, 49, 39, 494, DateTimeKind.Local).AddTicks(9629), "MQuD8tW1N-1/=/2-ihyr3BVJj8ZasvA95saP9/IGJUug4BoMcuZ-1/=/2-66NumRCGwmL5gdo2sq" });
        }
    }
}
