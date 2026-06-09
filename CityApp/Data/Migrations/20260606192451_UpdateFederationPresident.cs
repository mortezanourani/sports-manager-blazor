using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFederationPresident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PresidentId",
                table: "LocalFederationPresidents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalFederationPresidents_PresidentId",
                table: "LocalFederationPresidents",
                column: "PresidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalFederationPresidents_AspNetUsers_PresidentId",
                table: "LocalFederationPresidents",
                column: "PresidentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalFederationPresidents_AspNetUsers_PresidentId",
                table: "LocalFederationPresidents");

            migrationBuilder.DropIndex(
                name: "IX_LocalFederationPresidents_PresidentId",
                table: "LocalFederationPresidents");

            migrationBuilder.DropColumn(
                name: "PresidentId",
                table: "LocalFederationPresidents");
        }
    }
}
