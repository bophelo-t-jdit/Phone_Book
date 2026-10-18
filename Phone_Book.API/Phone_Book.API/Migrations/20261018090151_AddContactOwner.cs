using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phone_Book.API.Migrations
{
    /// <inheritdoc />
    public partial class AddContactOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerId",
                table: "Contacts",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_OwnerId",
                table: "Contacts",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_OwnerId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OwnerId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Contacts");
        }
    }
}
