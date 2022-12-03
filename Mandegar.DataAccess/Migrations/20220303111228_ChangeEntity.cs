using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class ChangeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionApprovalMembers_SessionApprovals_SessionApprovalsId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropColumn(
                name: "SessionApprovalId",
                table: "SessionApprovalMembers");

            migrationBuilder.AlterColumn<int>(
                name: "SessionApprovalsId",
                table: "SessionApprovalMembers",
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
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 731, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 729, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 730, DateTimeKind.Local).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 14, 42, 24, 730, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 3, 14, 42, 24, 721, DateTimeKind.Local).AddTicks(8579), "nBf4WkASuRslyfpird30bjbOAOqZteFhetln423yHy-1/=/2-e-1/=/2-USfWeqjwRmGmA7yzH/S" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionApprovalMembers_SessionApprovals_SessionApprovalsId",
                table: "SessionApprovalMembers",
                column: "SessionApprovalsId",
                principalTable: "SessionApprovals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionApprovalMembers_SessionApprovals_SessionApprovalsId",
                table: "SessionApprovalMembers");

            migrationBuilder.AlterColumn<int>(
                name: "SessionApprovalsId",
                table: "SessionApprovalMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SessionApprovalId",
                table: "SessionApprovalMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 557, DateTimeKind.Local).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 555, DateTimeKind.Local).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 556, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 49, 55, 556, DateTimeKind.Local).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 3, 13, 49, 55, 547, DateTimeKind.Local).AddTicks(5439), "v4Uq24MXK-1/=/2-2Vjm0HdAVLVKHSwtcMGMA6oX5LnF-1/=/2-T8YdNCl3xqoZJErtSYcegMjSZ" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionApprovalMembers_SessionApprovals_SessionApprovalsId",
                table: "SessionApprovalMembers",
                column: "SessionApprovalsId",
                principalTable: "SessionApprovals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
