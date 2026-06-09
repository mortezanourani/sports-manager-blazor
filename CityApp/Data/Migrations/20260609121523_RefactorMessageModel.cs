using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMessageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RecieverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "LocalFederationPresidents");

            migrationBuilder.DropColumn(
                name: "EducationalMajor",
                table: "LocalFederationPresidents");

            migrationBuilder.DropColumn(
                name: "EducationalQualification",
                table: "LocalFederationPresidents");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LocalFederationPresidents");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "LocalFederationPresidents");

            migrationBuilder.DropColumn(
                name: "SeenCode",
                table: "LocalFederationPresidents");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "Messages",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RecieverId",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverFederationId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SenderFederationId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverFederationId",
                table: "Messages",
                column: "ReceiverFederationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderFederationId",
                table: "Messages",
                column: "SenderFederationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetRoles_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetRoles_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_LocalFederations_ReceiverFederationId",
                table: "Messages",
                column: "ReceiverFederationId",
                principalTable: "LocalFederations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_LocalFederations_SenderFederationId",
                table: "Messages",
                column: "SenderFederationId",
                principalTable: "LocalFederations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetRoles_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetRoles_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_LocalFederations_ReceiverFederationId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_LocalFederations_SenderFederationId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverFederationId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderFederationId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceiverFederationId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderFederationId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Messages",
                newName: "RecieverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                newName: "IX_Messages_RecieverId");

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "LocalFederationPresidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationalMajor",
                table: "LocalFederationPresidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationalQualification",
                table: "LocalFederationPresidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LocalFederationPresidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "LocalFederationPresidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeenCode",
                table: "LocalFederationPresidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RecieverId",
                table: "Messages",
                column: "RecieverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
