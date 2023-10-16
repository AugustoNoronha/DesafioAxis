using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioAxis.WepApi.Migrations
{
    /// <inheritdoc />
    public partial class changefavoritoslist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favoritos_Cooperativas_CooperativasId",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_CooperativasId",
                table: "Favoritos");

            migrationBuilder.DropColumn(
                name: "CooperativasId",
                table: "Favoritos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CooperativasId",
                table: "Favoritos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_CooperativasId",
                table: "Favoritos",
                column: "CooperativasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favoritos_Cooperativas_CooperativasId",
                table: "Favoritos",
                column: "CooperativasId",
                principalTable: "Cooperativas",
                principalColumn: "Id");
        }
    }
}
