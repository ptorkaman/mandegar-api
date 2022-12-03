using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class addprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Positions_PositionId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_WorkExperienceTypes_WorkExperienceTypeId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_InsuranceTypes_InsuranceTypeId",
                table: "StaffComplementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_MaritalStatuses_MaritalStatusId",
                table: "StaffComplementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_MilitaryServiceStatuses_MilitaryServiceStatusId",
                table: "StaffComplementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_Religions_ReligionId",
                table: "StaffComplementaries");

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "Staffs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                table: "StaffComplementaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MilitaryServiceStatusId",
                table: "StaffComplementaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "StaffComplementaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceTypeId",
                table: "StaffComplementaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceNumber",
                table: "StaffComplementaries",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "StaffAddresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile1",
                table: "StaffAddresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "StaffAddresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StaffAddresses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkExperienceTypeId",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Resumes",
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
                value: new DateTime(2022, 2, 25, 17, 26, 18, 614, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 615, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 612, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 613, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 25, 17, 26, 18, 613, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 25, 17, 26, 18, 605, DateTimeKind.Local).AddTicks(3155), "XRdIRymC9ZaY/uuEFuahFMWA0SO4ELh7PnWGRM8rPDTDRXIkeuQ78E0qpmern6kM" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Positions_PositionId",
                table: "Resumes",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_WorkExperienceTypes_WorkExperienceTypeId",
                table: "Resumes",
                column: "WorkExperienceTypeId",
                principalTable: "WorkExperienceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_InsuranceTypes_InsuranceTypeId",
                table: "StaffComplementaries",
                column: "InsuranceTypeId",
                principalTable: "InsuranceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_MaritalStatuses_MaritalStatusId",
                table: "StaffComplementaries",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_MilitaryServiceStatuses_MilitaryServiceStatusId",
                table: "StaffComplementaries",
                column: "MilitaryServiceStatusId",
                principalTable: "MilitaryServiceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_Religions_ReligionId",
                table: "StaffComplementaries",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_DepartmentMeetings_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMeetingAttendees_DepartmentMembers_DepartmentMemberId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Positions_PositionId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_WorkExperienceTypes_WorkExperienceTypeId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_InsuranceTypes_InsuranceTypeId",
                table: "StaffComplementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_MaritalStatuses_MaritalStatusId",
                table: "StaffComplementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_MilitaryServiceStatuses_MilitaryServiceStatusId",
                table: "StaffComplementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffComplementaries_Religions_ReligionId",
                table: "StaffComplementaries");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMemberId",
                table: "DepartmentMeetingAttendees");

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "Staffs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                table: "StaffComplementaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MilitaryServiceStatusId",
                table: "StaffComplementaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "StaffComplementaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceTypeId",
                table: "StaffComplementaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "InsuranceNumber",
                table: "StaffComplementaries",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "StaffAddresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile1",
                table: "StaffAddresses",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "StaffAddresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StaffAddresses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "WorkExperienceTypeId",
                table: "Resumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Resumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Positions_PositionId",
                table: "Resumes",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_WorkExperienceTypes_WorkExperienceTypeId",
                table: "Resumes",
                column: "WorkExperienceTypeId",
                principalTable: "WorkExperienceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_InsuranceTypes_InsuranceTypeId",
                table: "StaffComplementaries",
                column: "InsuranceTypeId",
                principalTable: "InsuranceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_MaritalStatuses_MaritalStatusId",
                table: "StaffComplementaries",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_MilitaryServiceStatuses_MilitaryServiceStatusId",
                table: "StaffComplementaries",
                column: "MilitaryServiceStatusId",
                principalTable: "MilitaryServiceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffComplementaries_Religions_ReligionId",
                table: "StaffComplementaries",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
