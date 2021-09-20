using Microsoft.EntityFrameworkCore.Migrations;

namespace API1809.Migrations
{
    public partial class updatealquiler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquiler_Cliente_clienteId",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Alquiler");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Alquiler",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Alquiler_clienteId",
                table: "Alquiler",
                newName: "IX_Alquiler_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Alquiler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alquiler_Cliente_ClienteId",
                table: "Alquiler",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquiler_Cliente_ClienteId",
                table: "Alquiler");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Alquiler",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Alquiler_ClienteId",
                table: "Alquiler",
                newName: "IX_Alquiler_clienteId");

            migrationBuilder.AlterColumn<int>(
                name: "clienteId",
                table: "Alquiler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Alquiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Alquiler_Cliente_clienteId",
                table: "Alquiler",
                column: "clienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
