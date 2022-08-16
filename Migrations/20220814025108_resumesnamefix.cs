using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsiteApp.Migrations
{
    /// <inheritdoc />
    public partial class resumesnamefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Resume",
                table: "Resume");

            migrationBuilder.RenameTable(
                name: "Resume",
                newName: "Resumes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes");

            migrationBuilder.RenameTable(
                name: "Resumes",
                newName: "Resume");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resume",
                table: "Resume",
                column: "Id");
        }
    }
}
