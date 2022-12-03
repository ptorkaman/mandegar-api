using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class Department_Activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentActivityTypeId",
                table: "DepartmentActivities",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3459));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3839));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 721, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 719, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 720, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 17, 53, 0, 720, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 1, 17, 53, 0, 714, DateTimeKind.Local).AddTicks(801), "I366hcZvj2g1zwGCet8YxBNOmmsmvqMnWKMwyV68D8ZislWGoOTheVd-1/=/2-bf/-1/=/2-Oov8" });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivities_DepartmentActivityTypeId",
                table: "DepartmentActivities",
                column: "DepartmentActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentActivities_DepartmentActivityTypes_DepartmentActivityTypeId",
                table: "DepartmentActivities",
                column: "DepartmentActivityTypeId",
                principalTable: "DepartmentActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentActivities_DepartmentActivityTypes_DepartmentActivityTypeId",
                table: "DepartmentActivities");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentActivities_DepartmentActivityTypeId",
                table: "DepartmentActivities");

            migrationBuilder.DropColumn(
                name: "DepartmentActivityTypeId",
                table: "DepartmentActivities");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 15, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 13, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 14, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 1, 16, 35, 17, 14, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 1, 16, 35, 17, 8, DateTimeKind.Local).AddTicks(9878), "iwN7XBj04fFVDYgOYhpB9KXYKNrLWs8AiHZmkOjrm4GXIqI4zcvkcxKQC3SsSZ2p" });
        }
    }
}
