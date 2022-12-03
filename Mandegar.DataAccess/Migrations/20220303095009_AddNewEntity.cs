using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class AddNewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentActivities_DepartmentActivityTypes_DepartmentActivityTypeId",
                table: "DepartmentActivities");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentActivityTypeId",
                table: "DepartmentActivities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SessionApprovalMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionApprovalMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionApprovalMembers_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionApprovalMembers_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_SessionApprovalMembers_CreatedById",
                table: "SessionApprovalMembers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovalMembers_ModifiedById",
                table: "SessionApprovalMembers",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentActivities_DepartmentActivityTypes_DepartmentActivityTypeId",
                table: "DepartmentActivities",
                column: "DepartmentActivityTypeId",
                principalTable: "DepartmentActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentActivities_DepartmentActivityTypes_DepartmentActivityTypeId",
                table: "DepartmentActivities");

            migrationBuilder.DropTable(
                name: "SessionApprovalMembers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentActivityTypeId",
                table: "DepartmentActivities",
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

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentActivities_DepartmentActivityTypes_DepartmentActivityTypeId",
                table: "DepartmentActivities",
                column: "DepartmentActivityTypeId",
                principalTable: "DepartmentActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
