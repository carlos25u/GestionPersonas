using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPersonas.Migrations
{
    public partial class AgregandoAportesyAportesDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AportesDetalle_Personas_PersonaId",
                table: "AportesDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "AportesDetalle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalle_TipoAporteId",
                table: "AportesDetalle",
                column: "TipoAporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AportesDetalle_Personas_PersonaId",
                table: "AportesDetalle",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AportesDetalle_tiposAportes_TipoAporteId",
                table: "AportesDetalle",
                column: "TipoAporteId",
                principalTable: "tiposAportes",
                principalColumn: "TipoAporteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AportesDetalle_Personas_PersonaId",
                table: "AportesDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_AportesDetalle_tiposAportes_TipoAporteId",
                table: "AportesDetalle");

            migrationBuilder.DropIndex(
                name: "IX_AportesDetalle_TipoAporteId",
                table: "AportesDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "AportesDetalle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AportesDetalle_Personas_PersonaId",
                table: "AportesDetalle",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
