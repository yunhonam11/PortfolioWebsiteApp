using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioWebsiteApp.Migrations
{
    /// <inheritdoc />
    public partial class registrationmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logos_About_AboutId",
                table: "Logos");

            migrationBuilder.DropIndex(
                name: "IX_Logos_AboutId",
                table: "Logos");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Logos");

            migrationBuilder.CreateTable(
                name: "RegistrationMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationMessage", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationMessage");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Logos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logos_AboutId",
                table: "Logos",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logos_About_AboutId",
                table: "Logos",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id");
        }
    }
}
