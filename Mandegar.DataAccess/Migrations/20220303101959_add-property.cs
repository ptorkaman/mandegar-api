using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class addproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionApprovals_DepartmentMeetingMembers_DepartmentMeetingMemberId",
                table: "SessionApprovals");

            migrationBuilder.DropIndex(
                name: "IX_SessionApprovals_DepartmentMeetingMemberId",
                table: "SessionApprovals");

            migrationBuilder.DropColumn(
                name: "DepartmentMeetingMemberId",
                table: "SessionApprovals");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentMeetingMemberId",
                table: "SessionApprovalMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionApprovalId",
                table: "SessionApprovalMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionApprovalsId",
                table: "SessionApprovalMembers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovalMembers_DepartmentMeetingMemberId",
                table: "SessionApprovalMembers",
                column: "DepartmentMeetingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovalMembers_SessionApprovalsId",
                table: "SessionApprovalMembers",
                column: "SessionApprovalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionApprovalMembers_DepartmentMeetingMembers_DepartmentMeetingMemberId",
                table: "SessionApprovalMembers",
                column: "DepartmentMeetingMemberId",
                principalTable: "DepartmentMeetingMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionApprovalMembers_SessionApprovals_SessionApprovalsId",
                table: "SessionApprovalMembers",
                column: "SessionApprovalsId",
                principalTable: "SessionApprovals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionApprovalMembers_DepartmentMeetingMembers_DepartmentMeetingMemberId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionApprovalMembers_SessionApprovals_SessionApprovalsId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropIndex(
                name: "IX_SessionApprovalMembers_DepartmentMeetingMemberId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropIndex(
                name: "IX_SessionApprovalMembers_SessionApprovalsId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropColumn(
                name: "DepartmentMeetingMemberId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropColumn(
                name: "SessionApprovalId",
                table: "SessionApprovalMembers");

            migrationBuilder.DropColumn(
                name: "SessionApprovalsId",
                table: "SessionApprovalMembers");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentMeetingMemberId",
                table: "SessionApprovals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 284, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 279, DateTimeKind.Local).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 282, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 13, 20, 5, 283, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 3, 13, 20, 5, 262, DateTimeKind.Local).AddTicks(3673), "KP39Irsx1qkr5Ca/JYfvLfo-1/=/2-198xl0QKbGz79mf9ao/Hr7Q0DgWAYreUfg3xKsAp" });

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovals_DepartmentMeetingMemberId",
                table: "SessionApprovals",
                column: "DepartmentMeetingMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionApprovals_DepartmentMeetingMembers_DepartmentMeetingMemberId",
                table: "SessionApprovals",
                column: "DepartmentMeetingMemberId",
                principalTable: "DepartmentMeetingMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
