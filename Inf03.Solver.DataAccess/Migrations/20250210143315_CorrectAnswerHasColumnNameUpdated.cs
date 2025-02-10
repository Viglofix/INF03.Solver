using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inf03.Solver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CorrectAnswerHasColumnNameUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "exam",
                newName: "correct_answer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "correct_answer",
                table: "exam",
                newName: "CorrectAnswer");
        }
    }
}
