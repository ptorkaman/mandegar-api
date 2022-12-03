using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class Change_Staff_Family_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffFamilyInformation_Educations_EducationId",
                table: "StaffFamilyInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffFamilyInformation_MaritalStatuses_MaritalStatusId",
                table: "StaffFamilyInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "StaffFamilyInformation",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "StaffFamilyInformation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "StaffFamilyInformation",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "StaffFamilyInformation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EducationId",
                table: "StaffFamilyInformation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "StaffFamilyInformation",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 761, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 759, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 760, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2022, 2, 26, 14, 26, 43, 760, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "RequestCode" },
                values: new object[] { new DateTime(2022, 2, 26, 14, 26, 43, 754, DateTimeKind.Local).AddTicks(3349), "VnCeAqrdDxUwBeLStCEZQcoTBK9u9Bn7uZrKZ5WHjbPQ/uFyeMEPFiPaLNGJXLqc" });

            migrationBuilder.AddForeignKey(
                name: "FK_StaffFamilyInformation_Educations_EducationId",
                table: "StaffFamilyInformation",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffFamilyInformation_MaritalStatuses_MaritalStatusId",
                table: "StaffFamilyInformation",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffFamilyInformation_Educations_EducationId",
                table: "StaffFamilyInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffFamilyInformation_MaritalStatuses_MaritalStatusId",
                table: "StaffFamilyInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "StaffFamilyInformation",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "StaffFamilyInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "StaffFamilyInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "StaffFamilyInformation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EducationId",
                table: "StaffFamilyInformation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "StaffFamilyInformation",
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

            migrationBuilder.AddForeignKey(
                name: "FK_StaffFamilyInformation_Educations_EducationId",
                table: "StaffFamilyInformation",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffFamilyInformation_MaritalStatuses_MaritalStatusId",
                table: "StaffFamilyInformation",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
