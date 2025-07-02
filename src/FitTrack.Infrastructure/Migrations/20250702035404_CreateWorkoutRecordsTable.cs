using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateWorkoutRecordsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workout_records",
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
                    table.PrimaryKey("PK_workout_records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workout_records_exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workout_records_workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workout_records_ExerciseId",
                table: "workout_records",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_workout_records_WorkoutId",
                table: "workout_records",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workout_records");
        }
    }
}
