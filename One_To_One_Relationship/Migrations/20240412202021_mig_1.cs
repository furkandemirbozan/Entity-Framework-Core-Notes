using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_To_One_Relationship.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalisanAdresi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanId = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProperty1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyProperty1_MyProperty_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "MyProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyProperty1_CalisanId",
                table: "MyProperty1",
                column: "CalisanId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyProperty1");

            migrationBuilder.DropTable(
                name: "MyProperty");
        }
    }
}
