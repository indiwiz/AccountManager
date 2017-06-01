using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManager.DataAccess.Migrations
{
    public partial class AddedUniqueIndexToCompanyIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Companies_Identifier",
                table: "Companies",
                column: "Identifier",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_Identifier",
                table: "Companies");
        }
    }
}
