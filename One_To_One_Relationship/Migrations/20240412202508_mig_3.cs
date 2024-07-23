using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_To_One_Relationship.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty1_MyProperty_CalisanId",
                table: "MyProperty1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty1",
                table: "MyProperty1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty1",
                newName: "CalisanAdresleri");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Calisanlar");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty1_CalisanId",
                table: "CalisanAdresleri",
                newName: "IX_CalisanAdresleri_CalisanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalisanAdresleri",
                table: "CalisanAdresleri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanAdresleri_Calisanlar_CalisanId",
                table: "CalisanAdresleri",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanAdresleri_Calisanlar_CalisanId",
                table: "CalisanAdresleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalisanAdresleri",
                table: "CalisanAdresleri");

            migrationBuilder.RenameTable(
                name: "Calisanlar",
                newName: "MyProperty");

            migrationBuilder.RenameTable(
                name: "CalisanAdresleri",
                newName: "MyProperty1");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanAdresleri_CalisanId",
                table: "MyProperty1",
                newName: "IX_MyProperty1_CalisanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty1",
                table: "MyProperty1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty1_MyProperty_CalisanId",
                table: "MyProperty1",
                column: "CalisanId",
                principalTable: "MyProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
