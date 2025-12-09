using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    JobType = table.Column<int>(type: "INTEGER", nullable: false),
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    CronExpression = table.Column<string>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    MaxRetries = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    RetryIntervalSeconds = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 30),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobScheduleExecution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TriggeredAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false),
                    RetryAttemptCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobScheduleExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobScheduleExecution_JobSchedule_JobScheduleId",
                        column: x => x.JobScheduleId,
                        principalTable: "JobSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobScheduleExecution_JobScheduleId",
                table: "JobScheduleExecution",
                column: "JobScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobScheduleExecution");

            migrationBuilder.DropTable(
                name: "JobSchedule");
        }
    }
}
