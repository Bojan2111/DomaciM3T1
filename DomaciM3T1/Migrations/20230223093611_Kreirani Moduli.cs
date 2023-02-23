using Microsoft.EntityFrameworkCore.Migrations;

namespace DomaciM3T1.Migrations
{
    public partial class KreiraniModuli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIB = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjacs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvodjacs_Salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodinaProizvodnje = table.Column<int>(type: "int", nullable: false),
                    Kubikaza = table.Column<int>(type: "int", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProizvodjacId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automobils_Proizvodjacs_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobils_Salon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Salon",
                columns: new[] { "Id", "Adresa", "Drzava", "Grad", "Naziv", "PIB" },
                values: new object[] { 1, "Neka Adresa 1", "Neka drzava", "Neki grad", "Salon1", 1234 });

            migrationBuilder.InsertData(
                table: "Salon",
                columns: new[] { "Id", "Adresa", "Drzava", "Grad", "Naziv", "PIB" },
                values: new object[] { 2, "Neka Adresa 2", "Nova drzava", "Novi grad", "Salon2", 1235 });

            migrationBuilder.InsertData(
                table: "Salon",
                columns: new[] { "Id", "Adresa", "Drzava", "Grad", "Naziv", "PIB" },
                values: new object[] { 3, "Neka Adresa 3", "Moja drzava", "Prvi grad", "Salon3", 1236 });

            migrationBuilder.InsertData(
                table: "Proizvodjacs",
                columns: new[] { "Id", "Drzava", "Grad", "Naziv", "SalonId" },
                values: new object[] { 2, "Nova drzava", "Novi grad", "NovAuto", 1 });

            migrationBuilder.InsertData(
                table: "Proizvodjacs",
                columns: new[] { "Id", "Drzava", "Grad", "Naziv", "SalonId" },
                values: new object[] { 3, "Moja drzava", "Prvi grad", "MojAuto", 2 });

            migrationBuilder.InsertData(
                table: "Proizvodjacs",
                columns: new[] { "Id", "Drzava", "Grad", "Naziv", "SalonId" },
                values: new object[] { 1, "Neka drzava", "Neki grad", "NajAuto", 3 });

            migrationBuilder.InsertData(
                table: "Automobils",
                columns: new[] { "Id", "Boja", "GodinaProizvodnje", "Kubikaza", "Model", "ProizvodjacId", "SalonId" },
                values: new object[,]
                {
                    { 1, "Sarena", 2002, 1680, "Brmm", 2, 1 },
                    { 2, "Crvena", 2003, 1780, "Vrmm", 3, 2 },
                    { 3, "Zelena", 2004, 1880, "Kvrc", 3, 2 },
                    { 4, "Purple", 2005, 1980, "Brrr", 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_ProizvodjacId",
                table: "Automobils",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_SalonId",
                table: "Automobils",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodjacs_SalonId",
                table: "Proizvodjacs",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobils");

            migrationBuilder.DropTable(
                name: "Proizvodjacs");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
