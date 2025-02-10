using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inf03.Solver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CorrectAnswerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "exam",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "exam");
        }
    }
}
