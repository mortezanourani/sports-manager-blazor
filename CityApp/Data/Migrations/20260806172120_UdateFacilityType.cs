using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UdateFacilityType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_FacilityTypes_TypeId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_TypeId",
                table: "Facilities");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Facilities",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Facilities",
                newName: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_TypeId",
                table: "Facilities",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_FacilityTypes_TypeId",
                table: "Facilities",
                column: "TypeId",
                principalTable: "FacilityTypes",
                principalColumn: "Id");
        }
    }
}
