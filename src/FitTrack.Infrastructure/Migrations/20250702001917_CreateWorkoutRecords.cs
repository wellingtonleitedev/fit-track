using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateWorkoutRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reps = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Weight = table.Column<double>(type: "REAL", nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRecords_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutRecords_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_ExerciseId",
                table: "WorkoutRecords",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_WorkoutId",
                table: "WorkoutRecords",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutRecords");
        }
    }
}
