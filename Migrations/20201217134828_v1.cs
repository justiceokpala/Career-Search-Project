using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Career_Search_Project.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FunctionalAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullTime = table.Column<string>(type: "TEXT", nullable: true),
                    PartTime = table.Column<string>(type: "TEXT", nullable: true),
                    Temporary = table.Column<string>(type: "TEXT", nullable: true),
                    Contract = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRegistrations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Tel = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegistrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FunctionalAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobLocation = table.Column<string>(type: "TEXT", nullable: true),
                    AgeLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    Qualification = table.Column<string>(type: "TEXT", nullable: true),
                    Requirements = table.Column<string>(type: "TEXT", nullable: true),
                    Responsibility = table.Column<string>(type: "TEXT", nullable: true),
                    JobSummary = table.Column<string>(type: "TEXT", nullable: true),
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Renumeration = table.Column<decimal>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopJobs_FunctionalAreas_FunctionalAreaId",
                        column: x => x.FunctionalAreaId,
                        principalTable: "FunctionalAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopJobs_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopJobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    ExperienceLevel = table.Column<string>(type: "TEXT", nullable: true),
                    Qualification = table.Column<string>(type: "TEXT", nullable: true),
                    Skills = table.Column<string>(type: "TEXT", nullable: true),
                    ContactInformation = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId1 = table.Column<string>(type: "TEXT", nullable: true),
                    FunctionalAreaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeekers_FunctionalAreas_FunctionalAreaId",
                        column: x => x.FunctionalAreaId,
                        principalTable: "FunctionalAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekers_UserRegistrations_UserId1",
                        column: x => x.UserId1,
                        principalTable: "UserRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobEmployers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    FoundedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId1 = table.Column<string>(type: "TEXT", nullable: true),
                    TopJobId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEmployers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobEmployers_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobEmployers_TopJobs_TopJobId",
                        column: x => x.TopJobId,
                        principalTable: "TopJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobEmployers_UserRegistrations_UserId1",
                        column: x => x.UserId1,
                        principalTable: "UserRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FunctionalAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobLocation = table.Column<string>(type: "TEXT", nullable: true),
                    AgeLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    Qualification = table.Column<string>(type: "TEXT", nullable: true),
                    Requirements = table.Column<string>(type: "TEXT", nullable: true),
                    Responsibility = table.Column<string>(type: "TEXT", nullable: true),
                    JobSummary = table.Column<string>(type: "TEXT", nullable: true),
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Renumeration = table.Column<decimal>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobEmployerId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobInformations_FunctionalAreas_FunctionalAreaId",
                        column: x => x.FunctionalAreaId,
                        principalTable: "FunctionalAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobInformations_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobInformations_JobEmployers_JobEmployerId",
                        column: x => x.JobEmployerId,
                        principalTable: "JobEmployers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobInformations_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalkIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobName = table.Column<string>(type: "TEXT", nullable: true),
                    FunctionalAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    InterviewLocation = table.Column<string>(type: "TEXT", nullable: true),
                    IndustryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobEmployerId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalkIns_FunctionalAreas_FunctionalAreaId",
                        column: x => x.FunctionalAreaId,
                        principalTable: "FunctionalAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkIns_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkIns_JobEmployers_JobEmployerId",
                        column: x => x.JobEmployerId,
                        principalTable: "JobEmployers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkIns_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobEmployers_IndustryId",
                table: "JobEmployers",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEmployers_TopJobId",
                table: "JobEmployers",
                column: "TopJobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEmployers_UserId1",
                table: "JobEmployers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_FunctionalAreaId",
                table: "JobInformations",
                column: "FunctionalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_IndustryId",
                table: "JobInformations",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_JobEmployerId",
                table: "JobInformations",
                column: "JobEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformations_JobTypeId",
                table: "JobInformations",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_FunctionalAreaId",
                table: "JobSeekers",
                column: "FunctionalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_UserId1",
                table: "JobSeekers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TopJobs_FunctionalAreaId",
                table: "TopJobs",
                column: "FunctionalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TopJobs_IndustryId",
                table: "TopJobs",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_TopJobs_JobTypeId",
                table: "TopJobs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkIns_FunctionalAreaId",
                table: "WalkIns",
                column: "FunctionalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkIns_IndustryId",
                table: "WalkIns",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkIns_JobEmployerId",
                table: "WalkIns",
                column: "JobEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkIns_JobTypeId",
                table: "WalkIns",
                column: "JobTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobInformations");

            migrationBuilder.DropTable(
                name: "JobSeekers");

            migrationBuilder.DropTable(
                name: "WalkIns");

            migrationBuilder.DropTable(
                name: "JobEmployers");

            migrationBuilder.DropTable(
                name: "TopJobs");

            migrationBuilder.DropTable(
                name: "UserRegistrations");

            migrationBuilder.DropTable(
                name: "FunctionalAreas");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "JobTypes");
        }
    }
}
