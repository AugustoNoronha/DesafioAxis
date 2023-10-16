using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxis.WepApi.Migrations
{
    /// <inheritdoc />
    public partial class cooperativasmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cooperativas",
                table: "Cooperadores");

            migrationBuilder.CreateTable(
                name: "Cooperativas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperativas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cooperativas");

            migrationBuilder.AddColumn<int>(
                name: "Cooperativas",
                table: "Cooperadores",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
