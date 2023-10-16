using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAxis.WepApi.Migrations
{
    /// <inheritdoc />
    public partial class addcooperadoresnew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cooperadores",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cooperadores");
        }
    }
}
