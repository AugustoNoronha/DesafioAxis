using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DesafioAxis.WepApi.Migrations
{
    /// <inheritdoc />
    public partial class addfavoritos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PixType = table.Column<int>(type: "integer", nullable: false),
                    PixKey = table.Column<string>(type: "text", nullable: false),
                    CooperativasId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritos_Cooperativas_CooperativasId",
                        column: x => x.CooperativasId,
                        principalTable: "Cooperativas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_CooperativasId",
                table: "Favoritos",
                column: "CooperativasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");
        }
    }
}
