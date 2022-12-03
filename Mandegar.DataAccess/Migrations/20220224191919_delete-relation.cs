using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class deleterelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_DepartmentMeetings_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_DepartmentMembers_DepartmentMemberId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMemberId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPlaceName",
                table: "Resumes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "DepartmentMeetingAttendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 723, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 723, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 723, DateTimeKind.Local).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 723, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 723, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 724, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 714, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 719, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 22, 49, 16, 719, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 24, 22, 49, 16, 698, DateTimeKind.Local).AddTicks(2722), "1gMfEWbxmQgLoVjfXozlHKBT5rb82zqoMVYC7ycvxrrDWnlZcATMGevL7kbVgEUR" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_CreatedById",
                table: "DepartmentMeetingAttendees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_ModifiedById",
                table: "DepartmentMeetingAttendees",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_CreatedBy",
                table: "DepartmentMeetingAttendees",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_ModifiedBy",
                table: "DepartmentMeetingAttendees",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_CreatedBy",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_Users_ModifiedBy",
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
                name: "ModifiedById",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPlaceName",
                table: "Resumes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 851, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 852, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 24, 20, 16, 40, 852, DateTimeKind.Local).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 24, 20, 16, 40, 844, DateTimeKind.Local).AddTicks(8289), "Jk9F4Muz3N2tGeWaXiDZfONsTVfhHi3RxWzvYRGdj80eJIPAysCTj7jHJxH7305W" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees",
                column: "DepartmentMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMemberId",
                table: "DepartmentMeetingAttendees",
                column: "DepartmentMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMeetingAttendees_DepartmentMeetings_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees",
                column: "DepartmentMeetingId",
                principalTable: "DepartmentMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMeetingAttendees_DepartmentMembers_DepartmentMemberId",
                table: "DepartmentMeetingAttendees",
                column: "DepartmentMemberId",
                principalTable: "DepartmentMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
