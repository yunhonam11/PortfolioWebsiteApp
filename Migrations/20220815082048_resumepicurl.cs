using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsiteApp.Migrations
{
    /// <inheritdoc />
    public partial class resumepicurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicUrl",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicUrl",
                table: "Resumes");
        }
    }
}
