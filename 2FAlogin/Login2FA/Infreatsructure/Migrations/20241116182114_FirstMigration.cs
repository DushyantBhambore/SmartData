using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infreatsructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTP",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Otp");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Otp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Otp");

            migrationBuilder.AddColumn<int>(
                name: "OTP",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Otp",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
