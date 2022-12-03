using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandegar.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInList = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicYear_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicYear_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_ActivityCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityCase_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityCase_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_ActivityFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityField_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityField_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bank_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_BloodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CooperationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_CooperationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CooperationType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CooperationType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentActivityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_DepartmentActivityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentActivityType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentActivityType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentEvaluationGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_DepartmentEvaluationGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentEvaluationGroup_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentEvaluationGroup_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Department_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Specific = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Education_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EvaluationCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationCourse_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationCourse_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_InsuranceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_LessonTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaritalStatus_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaritalStatus_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryServiceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_MilitaryServiceStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryServiceStatus_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MilitaryServiceStatus_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nationality_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nationality_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Position_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Positions_Positions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Family = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relation_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relation_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Religions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Religion_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Religion_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInList = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_StudyDegrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyDegree_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyDegree_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_TaskGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskGroup_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskGroup_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperienceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_WorkExperienceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperienceType_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkExperienceType_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExecutiveCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ExecutiveCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutiveCalendar_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExecutiveCalendar_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExecutiveCalendars_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AttachmentFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DepartmentActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentActivities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentActivity_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentActivity_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyDefreeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_StudyFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyField_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyField_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyFields_StudyDegrees_StudyDefreeId",
                        column: x => x.StudyDefreeId,
                        principalTable: "StudyDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskGroupId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_TaskGroup",
                        column: x => x.TaskGroupId,
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutiveCalendarId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DepartmentSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentSchedule_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentSchedule_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentSchedules_ExecutiveCalendars_ExecutiveCalendarId",
                        column: x => x.ExecutiveCalendarId,
                        principalTable: "ExecutiveCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutiveCalendarId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_ExecutiveCalendars_ExecutiveCalendarId",
                        column: x => x.ExecutiveCalendarId,
                        principalTable: "ExecutiveCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_City_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyFieldId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EducationBasicCode = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_StudyGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyGrade_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyGrade_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyGrades_StudyFields_StudyFieldId",
                        column: x => x.StudyFieldId,
                        principalTable: "StudyFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignTasks",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignTasks", x => new { x.TaskId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_AssignTasks_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentScheduleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_DepartmentMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMeeting_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMeeting_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetings_DepartmentSchedules_DepartmentScheduleId",
                        column: x => x.DepartmentScheduleId,
                        principalTable: "DepartmentSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BirthCityId = table.Column<int>(type: "int", nullable: true),
                    IdentityIssueCityId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityIssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonneliCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Cities_BirthCityId",
                        column: x => x.BirthCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Cities_IdentityIssueCityId",
                        column: x => x.IdentityIssueCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyGradeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_StudyGrades_StudyGradeId",
                        column: x => x.StudyGradeId,
                        principalTable: "StudyGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyGradeId = table.Column<int>(type: "int", nullable: false),
                    LessonTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EducationCourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonTypes_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "LessonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_StudyGrades_StudyGradeId",
                        column: x => x.StudyGradeId,
                        principalTable: "StudyGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProceedingsDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentMeetingId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Programs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ProceedingsDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProceedingsDepartment_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProceedingsDepartment_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProceedingsDepartments_DepartmentMeetings_DepartmentMeetingId",
                        column: x => x.DepartmentMeetingId,
                        principalTable: "DepartmentMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublicationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    ActivityCaseId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityCases_ActivityCaseId",
                        column: x => x.ActivityCaseId,
                        principalTable: "ActivityCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignPositions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignPositions", x => new { x.StaffId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_AssignPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignPositions_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cooperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    CooperationTypeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CooperationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CooperationEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Cooperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooperation_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cooperation_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cooperations_CooperationTypes_CooperationTypeId",
                        column: x => x.CooperationTypeId,
                        principalTable: "CooperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooperations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooperations_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DepartmentMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMember_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMember_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    WorkExperienceTypeId = table.Column<int>(type: "int", nullable: true),
                    AcademicYearId = table.Column<int>(type: "int", nullable: true),
                    CooperationTypeId = table.Column<int>(type: "int", nullable: true),
                    ActivityFieldId = table.Column<int>(type: "int", nullable: true),
                    WorkPlaceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActivityDuration = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resume_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_ActivityFields_ActivityFieldId",
                        column: x => x.ActivityFieldId,
                        principalTable: "ActivityFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_CooperationTypes_CooperationTypeId",
                        column: x => x.CooperationTypeId,
                        principalTable: "CooperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resumes_WorkExperienceTypes_WorkExperienceTypeId",
                        column: x => x.WorkExperienceTypeId,
                        principalTable: "WorkExperienceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sacrifices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    IsMartyrFamily = table.Column<bool>(type: "bit", nullable: false),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    IsFreedMan = table.Column<bool>(type: "bit", nullable: false),
                    CaptivityDuration = table.Column<int>(type: "int", nullable: true),
                    IsVeteran = table.Column<bool>(type: "bit", nullable: false),
                    VeteranPercentage = table.Column<int>(type: "int", nullable: true),
                    IsSacrificer = table.Column<bool>(type: "bit", nullable: false),
                    BattlefieldPresenceDuration = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Sacrifices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sacrifice_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sacrifice_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sacrifices_Relations_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sacrifices_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Mobile1 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Mobile2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AddressTypeId = table.Column<int>(type: "int", nullable: true),
                    OtherWorkName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OtherWorkPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_StaffAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAddress_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAddresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffAddresses_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffComplementaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    BloodTypeId = table.Column<int>(type: "int", nullable: true),
                    IdentitySerialNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: true),
                    MilitaryServiceStatusId = table.Column<int>(type: "int", nullable: true),
                    MilitaryServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceTypeId = table.Column<int>(type: "int", nullable: true),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_StaffComplementaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_BloodTypes_BloodTypeId",
                        column: x => x.BloodTypeId,
                        principalTable: "BloodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_InsuranceTypes_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "InsuranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_MilitaryServiceStatuses_MilitaryServiceStatusId",
                        column: x => x.MilitaryServiceStatusId,
                        principalTable: "MilitaryServiceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementaries_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffComplementary_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffComplementary_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_StaffDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffDocument_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffDocument_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffDocuments_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffFamilyInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    StudyField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
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
                    table.PrimaryKey("PK_StaffFamilyInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffFamilyInformation_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffFamilyInformation_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffFamilyInformation_Relations_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffFamilyInformation_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffFamilyInformation_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffFamilyInformation_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffFinancials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sheba = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
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
                    table.PrimaryKey("PK_StaffFinancials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffFinancial_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffFinancial_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffFinancials_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffFinancials_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYeardId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_YearClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearClass_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YearClass_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YearClasses_AcademicYears_AcademicYeardId",
                        column: x => x.AcademicYeardId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YearClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentLessons_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TopicCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topic_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentActivityMembers",
                columns: table => new
                {
                    DepartmentActivityId = table.Column<int>(type: "int", nullable: false),
                    DepartmentMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentActivityMembers", x => new { x.DepartmentMemberId, x.DepartmentActivityId });
                    table.ForeignKey(
                        name: "FK_DepartmentActivityMembers_DepartmentActivities_DepartmentActivityId",
                        column: x => x.DepartmentActivityId,
                        principalTable: "DepartmentActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentActivityMembers_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMeetingAttendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentMeetingId = table.Column<int>(type: "int", nullable: false),
                    DepartmentMemberId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMeetingAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingAttendees_DepartmentMeetings_DepartmentMeetingId",
                        column: x => x.DepartmentMeetingId,
                        principalTable: "DepartmentMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingAttendees_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMeetingMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentMeetingId = table.Column<int>(type: "int", nullable: false),
                    DepartmentMemberId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DepartmentMeetingMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingMember_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingMember_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingMembers_DepartmentMeetings_DepartmentMeetingId",
                        column: x => x.DepartmentMeetingId,
                        principalTable: "DepartmentMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingMembers_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingMembers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecretaryEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentMemberId = table.Column<int>(type: "int", nullable: false),
                    DepartmentEvaluationGroupId = table.Column<int>(type: "int", nullable: false),
                    EvaluationCourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretaryEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretaryEvaluation_DepartmentEvaluationGroup_DepartmentEvaluationGroupId",
                        column: x => x.DepartmentEvaluationGroupId,
                        principalTable: "DepartmentEvaluationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecretaryEvaluation_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecretaryEvaluation_EvaluationCourses_EvaluationCourseId",
                        column: x => x.EvaluationCourseId,
                        principalTable: "EvaluationCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DegreeReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_EducationalQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalQualification_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalQualification_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalQualifications_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalQualifications_StaffDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "StaffDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalQualifications_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentEvaluationGroupId = table.Column<int>(type: "int", nullable: false),
                    DepartmentLessonId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ScoreCeiling = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EvaluationIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationIndicators_DepartmentEvaluationGroup_DepartmentEvaluationGroupId",
                        column: x => x.DepartmentEvaluationGroupId,
                        principalTable: "DepartmentEvaluationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationIndicators_DepartmentLessons_DepartmentLessonId",
                        column: x => x.DepartmentLessonId,
                        principalTable: "DepartmentLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationIndicators_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationIndicators_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentMeetingMemberId = table.Column<int>(type: "int", nullable: false),
                    DepartmentMemberId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_MeetingMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingMember_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingMember_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingMembers_DepartmentMeetingMembers_DepartmentMeetingMemberId",
                        column: x => x.DepartmentMeetingMemberId,
                        principalTable: "DepartmentMeetingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingMembers_DepartmentMembers_DepartmentMemberId",
                        column: x => x.DepartmentMemberId,
                        principalTable: "DepartmentMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentMeetingId = table.Column<int>(type: "int", nullable: false),
                    DepartmentMeetingMemberId = table.Column<int>(type: "int", nullable: false),
                    Test = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_SessionApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionApprovals_DepartmentMeetingMembers_DepartmentMeetingMemberId",
                        column: x => x.DepartmentMeetingMemberId,
                        principalTable: "DepartmentMeetingMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionApprovals_DepartmentMeetings_DepartmentMeetingId",
                        column: x => x.DepartmentMeetingId,
                        principalTable: "DepartmentMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionApprovals_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionApprovals_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecretaryScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    SecretaryEvaluationId = table.Column<int>(type: "int", nullable: true),
                    EvaluationIndicatorsId = table.Column<int>(type: "int", nullable: true),
                    EvaluationCourseId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SecretaryScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretaryScore_Users_CreatedBy",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecretaryScore_Users_ModifiedBy",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecretaryScores_EvaluationCourses_EvaluationCourseId",
                        column: x => x.EvaluationCourseId,
                        principalTable: "EvaluationCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecretaryScores_EvaluationIndicators_EvaluationIndicatorsId",
                        column: x => x.EvaluationIndicatorsId,
                        principalTable: "EvaluationIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecretaryScores_SecretaryEvaluation_SecretaryEvaluationId",
                        column: x => x.SecretaryEvaluationId,
                        principalTable: "SecretaryEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedOn", "Index", "IsActive", "IsDeleted", "Name", "ParentId", "ShowInList" },
                values: new object[,]
                {
                    { -1, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(5108), 0, true, false, "کاربر عادی", null, false },
                    { 1, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6250), 0, true, false, "مدیر ارشد", null, false },
                    { 2, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6266), 0, true, false, "مدیر", null, true },
                    { 3, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6270), 0, true, false, "پنل مدیریت", null, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "IsActive", "IsDeleted", "ModifiedById", "ModifiedOn", "Password", "RequestCode", "Username" },
                values: new object[] { 1, new DateTime(2022, 2, 24, 20, 16, 40, 844, DateTimeKind.Local).AddTicks(8289), true, false, null, null, "aUMRrPiiPVPyDld0loRhog==", "Jk9F4Muz3N2tGeWaXiDZfONsTVfhHi3RxWzvYRGdj80eJIPAysCTj7jHJxH7305W", "mandegar" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedOn", "Index", "IsActive", "IsDeleted", "Name", "ParentId", "ShowInList" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6272), 1, true, false, "مدیریت کاربران", 3, true },
                    { 5, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6602), 1, true, false, "افزودن کاربر", 3, true },
                    { 6, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6615), 1, true, false, "ویرایش کاربر", 3, true },
                    { 7, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6618), 1, true, false, "حذف کاربر", 3, true },
                    { 27, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6621), 2, true, false, "مدیریت نقش‌ها", 3, true },
                    { 28, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6623), 2, true, false, "افزودن نقش", 3, true },
                    { 29, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6627), 2, true, false, "ویرایش نقش", 3, true },
                    { 30, new DateTime(2022, 2, 24, 20, 16, 40, 853, DateTimeKind.Local).AddTicks(6630), 2, true, false, "حذف نقش", 3, true }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Avatar", "BirthDate", "CreatedOn", "Email", "Family", "Gender", "IsActive", "IsDeleted", "LastLogin", "Mobile", "Name", "NationalCode", "UserId" },
                values: new object[] { 1, "/Images/UserAvatar/Default.jpg", null, new DateTime(2022, 2, 24, 20, 16, 40, 851, DateTimeKind.Local).AddTicks(9519), "-", "سیستم", true, true, false, null, null, "ادمین", "", 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "IsActive", "IsDeleted", "ModifiedById", "ModifiedOn", "Name", "ShowInList" },
                values: new object[,]
                {
                    { -1, 1, new DateTime(2022, 2, 24, 20, 16, 40, 852, DateTimeKind.Local).AddTicks(7916), true, false, null, null, "کاربران عادی", false },
                    { 1, 1, new DateTime(2022, 2, 24, 20, 16, 40, 852, DateTimeKind.Local).AddTicks(8996), true, false, null, null, "مدیر ارشد", false }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { -1, -1 });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_CreatedById",
                table: "AcademicYears",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_ModifiedById",
                table: "AcademicYears",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityCaseId",
                table: "Activities",
                column: "ActivityCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatedById",
                table: "Activities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ModifiedById",
                table: "Activities",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StaffId",
                table: "Activities",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCases_CreatedById",
                table: "ActivityCases",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCases_ModifiedById",
                table: "ActivityCases",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFields_CreatedById",
                table: "ActivityFields",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFields_ModifiedById",
                table: "ActivityFields",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTypes_CreatedById",
                table: "ActivityTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTypes_ModifiedById",
                table: "ActivityTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_CreatedById",
                table: "AddressTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_ModifiedById",
                table: "AddressTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AssignPositions_PositionId",
                table: "AssignPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_PositionId",
                table: "AssignTasks",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CreatedById",
                table: "Banks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_ModifiedById",
                table: "Banks",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTypes_CreatedById",
                table: "BloodTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTypes_ModifiedById",
                table: "BloodTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedById",
                table: "Cities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ModifiedById",
                table: "Cities",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CreatedById",
                table: "Classes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ModifiedById",
                table: "Classes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StudyGradeId",
                table: "Classes",
                column: "StudyGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperations_CooperationTypeId",
                table: "Cooperations",
                column: "CooperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperations_CreatedById",
                table: "Cooperations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperations_DepartmentId",
                table: "Cooperations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperations_ModifiedById",
                table: "Cooperations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperations_StaffId",
                table: "Cooperations",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CooperationTypes_CreatedById",
                table: "CooperationTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CooperationTypes_ModifiedById",
                table: "CooperationTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ModifiedById",
                table: "Countries",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivities_CreatedById",
                table: "DepartmentActivities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivities_DepartmentId",
                table: "DepartmentActivities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivities_ModifiedById",
                table: "DepartmentActivities",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivityMembers_DepartmentActivityId",
                table: "DepartmentActivityMembers",
                column: "DepartmentActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivityTypes_CreatedById",
                table: "DepartmentActivityTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentActivityTypes_ModifiedById",
                table: "DepartmentActivityTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEvaluationGroup_CreatedById",
                table: "DepartmentEvaluationGroup",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEvaluationGroup_ModifiedById",
                table: "DepartmentEvaluationGroup",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLessons_DepartmentId",
                table: "DepartmentLessons",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLessons_LessonId",
                table: "DepartmentLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMeetingId",
                table: "DepartmentMeetingAttendees",
                column: "DepartmentMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingAttendees_DepartmentMemberId",
                table: "DepartmentMeetingAttendees",
                column: "DepartmentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingMembers_CreatedById",
                table: "DepartmentMeetingMembers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingMembers_DepartmentId",
                table: "DepartmentMeetingMembers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingMembers_DepartmentMeetingId",
                table: "DepartmentMeetingMembers",
                column: "DepartmentMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingMembers_DepartmentMemberId",
                table: "DepartmentMeetingMembers",
                column: "DepartmentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingMembers_ModifiedById",
                table: "DepartmentMeetingMembers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetings_CreatedById",
                table: "DepartmentMeetings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetings_DepartmentScheduleId",
                table: "DepartmentMeetings",
                column: "DepartmentScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetings_ModifiedById",
                table: "DepartmentMeetings",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_CreatedById",
                table: "DepartmentMembers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_DepartmentId",
                table: "DepartmentMembers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_ModifiedById",
                table: "DepartmentMembers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_PositionId",
                table: "DepartmentMembers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_StaffId",
                table: "DepartmentMembers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifiedById",
                table: "Departments",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSchedules_CreatedById",
                table: "DepartmentSchedules",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSchedules_ExecutiveCalendarId",
                table: "DepartmentSchedules",
                column: "ExecutiveCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSchedules_ModifiedById",
                table: "DepartmentSchedules",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatedById",
                table: "Documents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ModifiedById",
                table: "Documents",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualifications_CreatedById",
                table: "EducationalQualifications",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualifications_DocumentId",
                table: "EducationalQualifications",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualifications_EducationId",
                table: "EducationalQualifications",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualifications_ModifiedById",
                table: "EducationalQualifications",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalQualifications_StaffId",
                table: "EducationalQualifications",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CreatedById",
                table: "Educations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ModifiedById",
                table: "Educations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCourses_CreatedById",
                table: "EvaluationCourses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationCourses_ModifiedById",
                table: "EvaluationCourses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationIndicators_CreatedById",
                table: "EvaluationIndicators",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationIndicators_DepartmentEvaluationGroupId",
                table: "EvaluationIndicators",
                column: "DepartmentEvaluationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationIndicators_DepartmentLessonId",
                table: "EvaluationIndicators",
                column: "DepartmentLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationIndicators_ModifiedById",
                table: "EvaluationIndicators",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedById",
                table: "Events",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ExecutiveCalendarId",
                table: "Events",
                column: "ExecutiveCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ModifiedById",
                table: "Events",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_CreatedById",
                table: "EventTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_ModifiedById",
                table: "EventTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCalendars_AcademicYearId",
                table: "ExecutiveCalendars",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCalendars_CreatedById",
                table: "ExecutiveCalendars",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutiveCalendars_ModifiedById",
                table: "ExecutiveCalendars",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypes_CreatedById",
                table: "InsuranceTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypes_ModifiedById",
                table: "InsuranceTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CreatedById",
                table: "Lessons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonTypeId",
                table: "Lessons",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModifiedById",
                table: "Lessons",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudyGradeId",
                table: "Lessons",
                column: "StudyGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTypes_CreatedById",
                table: "LessonTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTypes_ModifiedById",
                table: "LessonTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatuses_CreatedById",
                table: "MaritalStatuses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatuses_ModifiedById",
                table: "MaritalStatuses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMembers_CreatedById",
                table: "MeetingMembers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMembers_DepartmentMeetingMemberId",
                table: "MeetingMembers",
                column: "DepartmentMeetingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMembers_DepartmentMemberId",
                table: "MeetingMembers",
                column: "DepartmentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMembers_ModifiedById",
                table: "MeetingMembers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryServiceStatuses_CreatedById",
                table: "MilitaryServiceStatuses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryServiceStatuses_ModifiedById",
                table: "MilitaryServiceStatuses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_CreatedById",
                table: "Nationalities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Nationalities_ModifiedById",
                table: "Nationalities",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatedById",
                table: "Positions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ModifiedById",
                table: "Positions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ParentId",
                table: "Positions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProceedingsDepartments_CreatedById",
                table: "ProceedingsDepartments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProceedingsDepartments_DepartmentMeetingId",
                table: "ProceedingsDepartments",
                column: "DepartmentMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProceedingsDepartments_ModifiedById",
                table: "ProceedingsDepartments",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CreatedById",
                table: "Provinces",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_ModifiedById",
                table: "Provinces",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_CreatedById",
                table: "Relations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ModifiedById",
                table: "Relations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_CreatedById",
                table: "Religions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Religions_ModifiedById",
                table: "Religions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_AcademicYearId",
                table: "Resumes",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ActivityFieldId",
                table: "Resumes",
                column: "ActivityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_CooperationTypeId",
                table: "Resumes",
                column: "CooperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_CreatedById",
                table: "Resumes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ModifiedById",
                table: "Resumes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_PositionId",
                table: "Resumes",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_StaffId",
                table: "Resumes",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_WorkExperienceTypeId",
                table: "Resumes",
                column: "WorkExperienceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                table: "Roles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedById",
                table: "Roles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sacrifices_CreatedById",
                table: "Sacrifices",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sacrifices_ModifiedById",
                table: "Sacrifices",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sacrifices_RelationId",
                table: "Sacrifices",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacrifices_StaffId",
                table: "Sacrifices",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryEvaluation_DepartmentEvaluationGroupId",
                table: "SecretaryEvaluation",
                column: "DepartmentEvaluationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryEvaluation_DepartmentMemberId",
                table: "SecretaryEvaluation",
                column: "DepartmentMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryEvaluation_EvaluationCourseId",
                table: "SecretaryEvaluation",
                column: "EvaluationCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryScores_CreatedById",
                table: "SecretaryScores",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryScores_EvaluationCourseId",
                table: "SecretaryScores",
                column: "EvaluationCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryScores_EvaluationIndicatorsId",
                table: "SecretaryScores",
                column: "EvaluationIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryScores_ModifiedById",
                table: "SecretaryScores",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_SecretaryScores_SecretaryEvaluationId",
                table: "SecretaryScores",
                column: "SecretaryEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovals_CreatedById",
                table: "SessionApprovals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovals_DepartmentMeetingId",
                table: "SessionApprovals",
                column: "DepartmentMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovals_DepartmentMeetingMemberId",
                table: "SessionApprovals",
                column: "DepartmentMeetingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionApprovals_ModifiedById",
                table: "SessionApprovals",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddresses_AddressTypeId",
                table: "StaffAddresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddresses_CreatedById",
                table: "StaffAddresses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddresses_ModifiedById",
                table: "StaffAddresses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffAddresses_StaffId",
                table: "StaffAddresses",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_BloodTypeId",
                table: "StaffComplementaries",
                column: "BloodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_CreatedById",
                table: "StaffComplementaries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_InsuranceTypeId",
                table: "StaffComplementaries",
                column: "InsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_MaritalStatusId",
                table: "StaffComplementaries",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_MilitaryServiceStatusId",
                table: "StaffComplementaries",
                column: "MilitaryServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_ModifiedById",
                table: "StaffComplementaries",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_NationalityId",
                table: "StaffComplementaries",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_ReligionId",
                table: "StaffComplementaries",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffComplementaries_StaffId",
                table: "StaffComplementaries",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffDocuments_CreatedById",
                table: "StaffDocuments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffDocuments_ModifiedById",
                table: "StaffDocuments",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffDocuments_StaffId",
                table: "StaffDocuments",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFamilyInformation_CreatedById",
                table: "StaffFamilyInformation",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFamilyInformation_EducationId",
                table: "StaffFamilyInformation",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFamilyInformation_MaritalStatusId",
                table: "StaffFamilyInformation",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFamilyInformation_ModifiedById",
                table: "StaffFamilyInformation",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFamilyInformation_RelationId",
                table: "StaffFamilyInformation",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFamilyInformation_StaffId",
                table: "StaffFamilyInformation",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFinancials_BankId",
                table: "StaffFinancials",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFinancials_CreatedById",
                table: "StaffFinancials",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFinancials_ModifiedById",
                table: "StaffFinancials",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffFinancials_StaffId",
                table: "StaffFinancials",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_BirthCityId",
                table: "Staffs",
                column: "BirthCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CreatedById",
                table: "Staffs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_IdentityIssueCityId",
                table: "Staffs",
                column: "IdentityIssueCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ModifiedById",
                table: "Staffs",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyDegrees_CreatedById",
                table: "StudyDegrees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyDegrees_ModifiedById",
                table: "StudyDegrees",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyFields_CreatedById",
                table: "StudyFields",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyFields_ModifiedById",
                table: "StudyFields",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyFields_StudyDefreeId",
                table: "StudyFields",
                column: "StudyDefreeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyGrades_CreatedById",
                table: "StudyGrades",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyGrades_ModifiedById",
                table: "StudyGrades",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudyGrades_StudyFieldId",
                table: "StudyGrades",
                column: "StudyFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_CreatedById",
                table: "TaskGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_ModifiedById",
                table: "TaskGroups",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedById",
                table: "Tasks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ModifiedById",
                table: "Tasks",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskGroupId",
                table: "Tasks",
                column: "TaskGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CreatedById",
                table: "Topics",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_LessonId",
                table: "Topics",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ModifiedById",
                table: "Topics",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperienceTypes_CreatedById",
                table: "WorkExperienceTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperienceTypes_ModifiedById",
                table: "WorkExperienceTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_YearClasses_AcademicYeardId",
                table: "YearClasses",
                column: "AcademicYeardId");

            migrationBuilder.CreateIndex(
                name: "IX_YearClasses_ClassId",
                table: "YearClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_YearClasses_CreatedById",
                table: "YearClasses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_YearClasses_ModifiedById",
                table: "YearClasses",
                column: "ModifiedById");

            #region sql

            var sql = @"
GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetSpParametersName'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetSpParametersName]
GO

CREATE PROC [dbo].[GetSpParametersName](
@SpName nvarchar(max)
)
AS
BEGIN
	select REPLACE(PARAMETER_NAME,'@','') as PARAMETER_NAME from information_schema.parameters
	where specific_name=@SpName
END

GO

IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetUserLogin'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetUserLogin]
GO
CREATE PROC [dbo].[GetUserLogin](
@Username varchar(100),
@Password nvarchar(max)
)
AS
BEGIN
	SELECT DISTINCT U.Id AS UserId,
		   PR.[Name],
		   PR.Family,
		   PR.Email,
		   U.Username,
		   PR.Avatar,
		   P.Id PermissionId,
		   P.Name AS PermissionName,
		   R.Name AS RoleName,
		   R.Id AS RoleId,
		   P.IsActive IsActivePermission
	FROM [dbo].Users U
		INNER JOIN [dbo].Profiles PR ON U.Id = PR.UserId
		INNER JOIN [dbo].UserRoles UR ON U.Id=UR.UserId
		INNER JOIN [dbo].Roles R ON UR.RoleId = R.Id
		INNER JOIN [dbo].RolePermissions RP ON RP.RoleId = R.Id
		INNER JOIN [dbo].[Permissions] P ON RP.PermissionId = P.Id
	WHERE Username = @Username
		AND Password = @Password
		AND U.IsActive = 1
		AND U.IsDeleted = 0

	UPDATE [dbo].Profiles
	SET LastLogin = GETDATE()
	FROM dbo.Users U
		INNER JOIN dbo.Profiles P ON U.Id = P.UserId
	WHERE U.Username = @Username
		AND U.Password = @Password
END


GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'InsertExceptionLog'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[InsertExceptionLog]
GO
CREATE PROC [dbo].[InsertExceptionLog](
@Request NVARCHAR(MAX),
@Message NVARCHAR(MAX),
@Exception NVARCHAR(MAX),
@Source NVARCHAR(MAX),
@StackTrace NVARCHAR(MAX),
@Url NVARCHAR(MAX)
)
AS
BEGIN
	INSERT INTO [ExceptionLogs]
                                                               ([Request]
                                                               ,[Message]
                                                               ,[Exception]
                                                               ,[Source]
                                                               ,[StackTrace]
                                                               ,[Url]
                                                               ,[CreatedOn]
                                                               ,[IsActive])
                                                         VALUES
                                                               (@Request
                                                               ,@Message
                                                               ,@Exception
                                                               ,@Source
                                                               ,@StackTrace
                                                               ,@Url
                                                               ,getdate()
                                                               ,1)
END

GO
DROP FUNCTION IF EXISTS dbo.fn_GetReportPaging;
GO

CREATE FUNCTION dbo.fn_GetReportPaging
(
	@PageIndex INT,
	@PageCount INT,
	@OrderBy TINYINT,
	@OrderAsc BIT
)
RETURNS VARCHAR(256)
AS BEGIN

	RETURN CONCAT(
		' ORDER BY ', @OrderBy,
		CASE WHEN @OrderAsc = 0 THEN ' DESC ' END,
		' OFFSET ', @PageIndex * @PageCount, ' ROWS ',
		' FETCH NEXT ', @PageCount, ' ROWS ONLY '
	)

END
GO


GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'Staff_GetAll'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[Staff_GetAll]
GO
USE [MandegarDB]
GO
/****** Object:  StoredProcedure [dbo].[Staff_GetAll]    Script Date: 2/7/2022 5:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Staff_GetAll](
@Name NVARCHAR(100) = NULL,
@Family NVARCHAR(100) = NULL,
@NationalCode NVARCHAR(10) = NULL,
@Gender BIT = NULL,
@PersonneliCode NVARCHAR(32) = NULL,
@PositionId INT = NULL,
@DepartmentId INT = NULL,
@CooperationId INT = NULL,
@PageIndex INT = NULL,
@PageCount INT = NULL,
@OrderBy TINYINT = NULL,
@OrderAsc BIT = NULL,
@IsCount BIT
)
AS
BEGIN
	DECLARE @Query NVARCHAR(MAX)
	DECLARE @Where NVARCHAR(MAX) = 'WHERE S.IsDeleted = 0 '
	
	IF @Name IS NOT NULL SET @Where = @Where + ' AND S.Name LIKE CONCAT(''%'', @Name, ''%'')'
	IF @Family IS NOT NULL SET @Where = @Where + ' AND S.Family LIKE CONCAT(''%'', @Family, ''%'')'
	IF @NationalCode IS NOT NULL SET @Where = @Where + ' AND S.NationalCode LIKE CONCAT(''%'', @NationalCode, ''%'')'
	IF @Gender IS NOT NULL SET @Where = @Where + ' AND SC.Gender = @Gender'
	IF @PersonneliCode IS NOT NULL SET @Where = @Where + ' AND S.PersonneliCode LIKE CONCAT(''%'', @PersonneliCode, ''%'')'
	IF @PositionId IS NOT NULL SET @Where = @Where + ' AND P.Id = @PositionId'
	IF @DepartmentId IS NOT NULL SET @Where = @Where + ' AND D.Id = @DepartmentId'
	IF @CooperationId IS NOT NULL SET @Where = @Where + ' AND C.Id = @CooperationId'


	IF @IsCount = 1
	SET @Query = '
		SELECT COUNT(DISTINCT S.ID)
		FROM Staffs S 
			LEFT JOIN dbo.StaffComplementaries SC ON SC.StaffId = S.Id	
			LEFT JOIN dbo.Cooperations c ON c.StaffId = s.Id
			LEFT JOIN dbo.CooperationTypes CT ON CT.Id = C.CooperationTypeId
			LEFT JOIN dbo.AssignPositions AP ON AP.StaffId = S.Id
			LEFT JOIN dbo.Positions P ON AP.PositionId = P.Id
			LEFT JOIN dbo.DepartmentMembers DM ON DM.StaffId = s.Id
			LEFT JOIN dbo.Departments D ON D.Id = DM.DepartmentId
	' + @Where
	ELSE
	SET @Query = '
		SELECT DISTINCT Id = S.ID,
				Image = S.Image,
				Name = S.Name,
				Family = S.Family,
				NationalCode = S.NationalCode,
				PersonneliCode = S.PersonneliCode,
				PositionName = P.Name,
				CooperationTypeName = CT.Name,
				CooperationEndDate = C.CooperationEndDate,
				Status = S.IsActive
		FROM Staffs S 
			LEFT JOIN dbo.StaffComplementaries SC ON SC.StaffId = S.Id	
			LEFT JOIN dbo.Cooperations c ON c.StaffId = s.Id
			LEFT JOIN dbo.CooperationTypes CT ON CT.Id = C.CooperationTypeId
			LEFT JOIN dbo.AssignPositions AP ON AP.StaffId = S.Id
			LEFT JOIN dbo.Positions P ON AP.PositionId = P.Id
			LEFT JOIN dbo.DepartmentMembers DM ON DM.StaffId = s.Id
			LEFT JOIN dbo.Departments D ON D.Id = DM.DepartmentId
	' + @Where

	IF @IsCount = 0 SET @Query = @Query + dbo.fn_GetReportPaging(@PageIndex, @PageCount, @OrderBy, @OrderAsc)
		EXECUTE sp_executesql
		@Query,
		  N'@Name NVARCHAR(100),
			@Family NVARCHAR(100),
			@NationalCode NVARCHAR(10),
			@Gender BIT,
			@PersonneliCode NVARCHAR(32),
			@PositionId INT,
			@DepartmentId INT,
			@CooperationId INT
			',
			@Name,
			@Family,
			@NationalCode,
			@Gender,
			@PersonneliCode,
			@PositionId,
			@DepartmentId,
			@CooperationId
END
GO
IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetAllDepartmentMeetingAttendees'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetAllDepartmentMeetingAttendees]
GO
Create PROCEDURE [dbo].[GetAllDepartmentMeetingAttendees] 
	@DepartmentMeetingId INT = NULL,
	@PageIndex INT = NULL,
	@PageCount INT = NULL,
	@OrderBy TINYINT = NULL,
	@OrderAsc BIT = NULL,
	@IsCount BIT,
	@MemberIds [dbo].[MemberIds] READONLY
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @Query NVARCHAR(MAX)
	DECLARE @Where NVARCHAR(MAX) = 'WHERE dbo.DepartmentMeetingAttendees.IsDeleted = 0 '
	IF @DepartmentMeetingId IS NOT NULL SET @Where = @Where + ' AND dbo.DepartmentMeetingAttendees.DepartmentMeetingId = @DepartmentMeetingId'
	IF EXISTS (SELECT * FROM @MemberIds) SET @Where = @Where + ' AND EXISTS(SELECT * FROM @MemberIds AS M WHERE M.DepartmentMemberId = dbo.DepartmentMeetingAttendees.DepartmentMemberId)'
	IF @IsCount = 1
	SET @Query = '
		SELECT COUNT(DISTINCT dbo.DepartmentMeetingAttendees.Id)
		FROM dbo.DepartmentMeetings INNER JOIN dbo.DepartmentMeetingAttendees ON dbo.DepartmentMeetings.Id = dbo.DepartmentMeetingAttendees.DepartmentMeetingId INNER JOIN
             dbo.Staffs ON dbo.DepartmentMeetingAttendees.DepartmentMemberId = dbo.Staffs.Id
	' + @Where
	ELSE
	SET @Query = '
		SELECT (dbo.Staffs.Name + '' '' + dbo.Staffs.Family) as FullName, dbo.DepartmentMeetings.Name AS MeetingName, dbo.DepartmentMeetingAttendees.DepartmentMeetingId, dbo.DepartmentMeetingAttendees.DepartmentMemberId, 
        dbo.DepartmentMeetingAttendees.IsDeleted, dbo.DepartmentMeetingAttendees.Id
		FROM dbo.DepartmentMeetings INNER JOIN dbo.DepartmentMeetingAttendees ON dbo.DepartmentMeetings.Id = dbo.DepartmentMeetingAttendees.DepartmentMeetingId INNER JOIN
             dbo.Staffs ON dbo.DepartmentMeetingAttendees.DepartmentMemberId = dbo.Staffs.Id
	' + @Where
	IF @IsCount = 0 SET @Query = @Query + dbo.fn_GetReportPaging(@PageIndex, @PageCount, @OrderBy, @OrderAsc)
	EXECUTE sp_executesql
		@Query,
		  N'@DepartmentMeetingId INT,
			@MemberIds dbo.MemberIds READONLY
			',
			@DepartmentMeetingId,
			@MemberIds
END
GO

IF EXISTS (
	    SELECT type_desc, type
	    FROM sys.procedures WITH(NOLOCK)
	    WHERE NAME = 'GetAllMembersInMeeting'
	        AND type = 'P'
	    )
	    DROP PROCEDURE [dbo].[GetAllMembersInMeeting]
GO
CREATE PROCEDURE [dbo].[GetAllMembersInMeeting]

	@Id int = null
AS
BEGIN
	SELECT dbo.MeetingMembers.IsDeleted AS MeetingMemberDeleted, dbo.MeetingMembers.DepartmentMemberId, (dbo.Staffs.Name +' '+ dbo.Staffs.Family) AS FullName, dbo.Staffs.IsDeleted AS StaffDeleted, 
           dbo.MeetingMembers.DepartmentMeetingMemberId, dbo.DepartmentMeetingMembers.IsDeleted AS DepartmentMeetingMemberDeleted, dbo.DepartmentMeetingMembers.DepartmentId
	FROM dbo.MeetingMembers INNER JOIN dbo.Staffs ON dbo.MeetingMembers.DepartmentMemberId = dbo.Staffs.Id INNER JOIN dbo.DepartmentMeetingMembers ON dbo.MeetingMembers.DepartmentMeetingMemberId = dbo.DepartmentMeetingMembers.Id
	WHERE (dbo.MeetingMembers.IsDeleted = 0) AND (dbo.Staffs.IsDeleted = 0) AND (dbo.DepartmentMeetingMembers.IsDeleted = 0) AND (dbo.MeetingMembers.DepartmentMeetingMemberId = @Id)
END

CREATE TYPE [dbo].[MemberIds] AS TABLE(
	[DepartmentMemberId] [int] NULL
)
GO

IF type_id('[dbo].[MemberIds]') IS NOT NULL
DROP TYPE [dbo].[MemberIds];
		go
CREATE TYPE [dbo].[MemberIds] AS TABLE(
	[DepartmentMemberId] [int] NULL
)
GO

";

            migrationBuilder.Sql(sql);

            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AssignPositions");

            migrationBuilder.DropTable(
                name: "AssignTasks");

            migrationBuilder.DropTable(
                name: "Cooperations");

            migrationBuilder.DropTable(
                name: "DepartmentActivityMembers");

            migrationBuilder.DropTable(
                name: "DepartmentActivityTypes");

            migrationBuilder.DropTable(
                name: "DepartmentMeetingAttendees");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "EducationalQualifications");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MeetingMembers");

            migrationBuilder.DropTable(
                name: "ProceedingsDepartments");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Sacrifices");

            migrationBuilder.DropTable(
                name: "SecretaryScores");

            migrationBuilder.DropTable(
                name: "SessionApprovals");

            migrationBuilder.DropTable(
                name: "StaffAddresses");

            migrationBuilder.DropTable(
                name: "StaffComplementaries");

            migrationBuilder.DropTable(
                name: "StaffFamilyInformation");

            migrationBuilder.DropTable(
                name: "StaffFinancials");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "YearClasses");

            migrationBuilder.DropTable(
                name: "ActivityCases");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "DepartmentActivities");

            migrationBuilder.DropTable(
                name: "StaffDocuments");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "ActivityFields");

            migrationBuilder.DropTable(
                name: "CooperationTypes");

            migrationBuilder.DropTable(
                name: "WorkExperienceTypes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "EvaluationIndicators");

            migrationBuilder.DropTable(
                name: "SecretaryEvaluation");

            migrationBuilder.DropTable(
                name: "DepartmentMeetingMembers");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "BloodTypes");

            migrationBuilder.DropTable(
                name: "InsuranceTypes");

            migrationBuilder.DropTable(
                name: "MilitaryServiceStatuses");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "TaskGroups");

            migrationBuilder.DropTable(
                name: "DepartmentLessons");

            migrationBuilder.DropTable(
                name: "DepartmentEvaluationGroup");

            migrationBuilder.DropTable(
                name: "EvaluationCourses");

            migrationBuilder.DropTable(
                name: "DepartmentMeetings");

            migrationBuilder.DropTable(
                name: "DepartmentMembers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "DepartmentSchedules");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "LessonTypes");

            migrationBuilder.DropTable(
                name: "StudyGrades");

            migrationBuilder.DropTable(
                name: "ExecutiveCalendars");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "StudyFields");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "StudyDegrees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
