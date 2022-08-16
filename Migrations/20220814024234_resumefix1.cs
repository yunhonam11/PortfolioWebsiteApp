using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsiteApp.Migrations
{
    /// <inheritdoc />
    public partial class resumefix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Resume_ResumeId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Resume_ResumeId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Resume_ResumeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ResumeId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_ResumeId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_ResumeId",
                table: "Educations");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Educations");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "Experiences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResumeId",
                table: "Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ResumeId",
                table: "Skills",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ResumeId",
                table: "Experiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ResumeId",
                table: "Educations",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Resume_ResumeId",
                table: "Educations",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Resume_ResumeId",
                table: "Experiences",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Resume_ResumeId",
                table: "Skills",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id");
        }
    }
}
