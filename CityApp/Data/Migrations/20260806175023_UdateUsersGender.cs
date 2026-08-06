using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UdateUsersGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_UsersGenders_UsersGenderId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_GovernmentFacilities_FacilityTypes_TypeId",
                table: "GovernmentFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_GovernmentFacilityLicenses_UsersGenders_UsersGenderId",
                table: "GovernmentFacilityLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateFacilities_FacilityTypes_TypeId",
                table: "PrivateFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateFacilityLicenses_UsersGenders_UsersGenderId",
                table: "PrivateFacilityLicenses");

            migrationBuilder.DropIndex(
                name: "IX_PrivateFacilityLicenses_UsersGenderId",
                table: "PrivateFacilityLicenses");

            migrationBuilder.DropIndex(
                name: "IX_PrivateFacilities_TypeId",
                table: "PrivateFacilities");

            migrationBuilder.DropIndex(
                name: "IX_GovernmentFacilityLicenses_UsersGenderId",
                table: "GovernmentFacilityLicenses");

            migrationBuilder.DropIndex(
                name: "IX_GovernmentFacilities_TypeId",
                table: "GovernmentFacilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_UsersGenderId",
                table: "Facilities");

            migrationBuilder.RenameColumn(
                name: "UsersGenderId",
                table: "PrivateFacilityLicenses",
                newName: "UsersGender");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "PrivateFacilities",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UsersGenderId",
                table: "GovernmentFacilityLicenses",
                newName: "UsersGender");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "GovernmentFacilities",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "UsersGenderId",
                table: "Facilities",
                newName: "UsersGender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersGender",
                table: "PrivateFacilityLicenses",
                newName: "UsersGenderId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "PrivateFacilities",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "UsersGender",
                table: "GovernmentFacilityLicenses",
                newName: "UsersGenderId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "GovernmentFacilities",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "UsersGender",
                table: "Facilities",
                newName: "UsersGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFacilityLicenses_UsersGenderId",
                table: "PrivateFacilityLicenses",
                column: "UsersGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateFacilities_TypeId",
                table: "PrivateFacilities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentFacilityLicenses_UsersGenderId",
                table: "GovernmentFacilityLicenses",
                column: "UsersGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentFacilities_TypeId",
                table: "GovernmentFacilities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_UsersGenderId",
                table: "Facilities",
                column: "UsersGenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_UsersGenders_UsersGenderId",
                table: "Facilities",
                column: "UsersGenderId",
                principalTable: "UsersGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GovernmentFacilities_FacilityTypes_TypeId",
                table: "GovernmentFacilities",
                column: "TypeId",
                principalTable: "FacilityTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GovernmentFacilityLicenses_UsersGenders_UsersGenderId",
                table: "GovernmentFacilityLicenses",
                column: "UsersGenderId",
                principalTable: "UsersGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateFacilities_FacilityTypes_TypeId",
                table: "PrivateFacilities",
                column: "TypeId",
                principalTable: "FacilityTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateFacilityLicenses_UsersGenders_UsersGenderId",
                table: "PrivateFacilityLicenses",
                column: "UsersGenderId",
                principalTable: "UsersGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
