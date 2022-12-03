using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class removerstudydegreeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyFields_StudyDegrees_StudyDefreeId",
                table: "StudyFields");

            migrationBuilder.DropIndex(
                name: "IX_StudyFields_StudyDefreeId",
                table: "StudyFields");

            migrationBuilder.DropColumn(
                name: "StudyDefreeId",
                table: "StudyFields");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "EducationalQualifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DegreeReceiptDate",
                table: "EducationalQualifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 487, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 484, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 485, DateTimeKind.Local).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 8, 19, 54, 15, 486, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 8, 19, 54, 15, 473, DateTimeKind.Local).AddTicks(3405), "jgMg0QNimHVOxGyi1Q9plP9S1CqU/BfKMFeLzGEhkOdlCzjOv2R8oEy4zOIiod9r" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyDefreeId",
                table: "StudyFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "EducationalQualifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DegreeReceiptDate",
                table: "EducationalQualifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 163, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 160, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 161, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 3, 3, 20, 49, 5, 162, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 3, 3, 20, 49, 5, 152, DateTimeKind.Local).AddTicks(1102), "timIumIGQvcBzPPPZWGcW1ShZMQrdk1vbVtIKSTLh77ybco5SPJcetzxJ-1/=/2-QS0AkQ" });

            migrationBuilder.CreateIndex(
                name: "IX_StudyFields_StudyDefreeId",
                table: "StudyFields",
                column: "StudyDefreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyFields_StudyDegrees_StudyDefreeId",
                table: "StudyFields",
                column: "StudyDefreeId",
                principalTable: "StudyDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
