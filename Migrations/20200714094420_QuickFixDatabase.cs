using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickFix.Migrations
{
    public partial class QuickFixDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikIme = table.Column<string>(maxLength: 60, nullable: false),
                    KorisnikPrezime = table.Column<string>(maxLength: 60, nullable: false),
                    KorisnikEmail = table.Column<string>(nullable: false),
                    KorisnikLozinka = table.Column<string>(maxLength: 60, nullable: false),
                    KorisnikLokacija = table.Column<string>(maxLength: 60, nullable: false),
                    KorisnikPrijava = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Servisi",
                columns: table => new
                {
                    ServisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServisIme = table.Column<string>(maxLength: 60, nullable: false),
                    ServisLokacija = table.Column<string>(maxLength: 60, nullable: false),
                    AdminEmail = table.Column<string>(nullable: false),
                    AdminLozinka = table.Column<string>(maxLength: 60, nullable: false),
                    ServisAdminIme = table.Column<string>(maxLength: 60, nullable: false),
                    ServisAdminPrezime = table.Column<string>(maxLength: 60, nullable: false),
                    ServisAdminGod = table.Column<string>(nullable: false),
                    ServisAdminIskustvo = table.Column<string>(nullable: false),
                    AdminPrijava = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisi", x => x.ServisId);
                });

            migrationBuilder.CreateTable(
                name: "ZahtevZaNovServis",
                columns: table => new
                {
                    ZahtevNovServisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZahtevNovServisStanje = table.Column<string>(nullable: true),
                    ZahtevNovServisNaziv = table.Column<string>(maxLength: 60, nullable: false),
                    ZahtevNovServisLokacija = table.Column<string>(maxLength: 60, nullable: false),
                    ZahtevNovServisAdminEmail = table.Column<string>(nullable: false),
                    ZahtevNovServisAdminLozinka = table.Column<string>(maxLength: 60, nullable: false),
                    ZahtevNovServisAdminIme = table.Column<string>(maxLength: 60, nullable: false),
                    ZahtevNovServisAdminPrezime = table.Column<string>(maxLength: 60, nullable: false),
                    ZahtevNovServisAdminGod = table.Column<string>(nullable: false),
                    ZahtevNovServisAdminIskustvo = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtevZaNovServis", x => x.ZahtevNovServisId);
                });

            migrationBuilder.CreateTable(
                name: "Majstori",
                columns: table => new
                {
                    MajstorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajstorIme = table.Column<string>(maxLength: 60, nullable: false),
                    MajstorPrezime = table.Column<string>(maxLength: 60, nullable: false),
                    MajstorEmail = table.Column<string>(nullable: false),
                    MajstorLozinka = table.Column<string>(maxLength: 60, nullable: false),
                    MajstorOcena = table.Column<float>(nullable: false),
                    BrojOcena = table.Column<int>(nullable: false),
                    MajstorPrijava = table.Column<int>(nullable: false),
                    ServisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majstori", x => x.MajstorId);
                    table.ForeignKey(
                        name: "FK_Majstori_Servisi_ServisId",
                        column: x => x.ServisId,
                        principalTable: "Servisi",
                        principalColumn: "ServisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    KomentarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SadrzajKomentara = table.Column<string>(maxLength: 100, nullable: false),
                    MajstorId = table.Column<int>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: true),
                    NazivKorisnika = table.Column<string>(nullable: true),
                    MejlKorisnika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari", x => x.KomentarId);
                    table.ForeignKey(
                        name: "FK_Komentari_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komentari_Majstori_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Majstori",
                        principalColumn: "MajstorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    UslugaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUsluge = table.Column<string>(maxLength: 60, nullable: false),
                    CenaUsluge = table.Column<int>(nullable: false),
                    MajstorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.UslugaId);
                    table.ForeignKey(
                        name: "FK_Usluge_Majstori_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Majstori",
                        principalColumn: "MajstorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtevi",
                columns: table => new
                {
                    ZahtevId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanjeZahteva = table.Column<string>(nullable: true),
                    OcenjenZahtev = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: true),
                    ImeKorisnika = table.Column<string>(nullable: true),
                    PrezimeKorisnika = table.Column<string>(nullable: true),
                    EmailKorisnika = table.Column<string>(nullable: true),
                    MajstorId = table.Column<int>(nullable: true),
                    ImeMajstora = table.Column<string>(nullable: true),
                    PrezimeMajstora = table.Column<string>(nullable: true),
                    UslugaMajstora = table.Column<string>(nullable: true),
                    EmailMajstora = table.Column<string>(nullable: true),
                    OcenaMajstora = table.Column<float>(nullable: false),
                    BrojOcenaMajstora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtevi", x => x.ZahtevId);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zahtevi_Majstori_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Majstori",
                        principalColumn: "MajstorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZahteviZaServise",
                columns: table => new
                {
                    ZahtevServisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanjeZahteva = table.Column<string>(nullable: true),
                    MajstorId = table.Column<int>(nullable: true),
                    ImeMajstora = table.Column<string>(nullable: true),
                    PrezimeMajstora = table.Column<string>(nullable: true),
                    UslugaMajstora = table.Column<string>(nullable: true),
                    EmailMajstora = table.Column<string>(nullable: true),
                    OcenaMajstora = table.Column<float>(nullable: false),
                    BrojOcenaMajstora = table.Column<int>(nullable: false),
                    ServisId = table.Column<int>(nullable: true),
                    ImeServisa = table.Column<string>(nullable: true),
                    LokacijaServisa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahteviZaServise", x => x.ZahtevServisId);
                    table.ForeignKey(
                        name: "FK_ZahteviZaServise_Majstori_MajstorId",
                        column: x => x.MajstorId,
                        principalTable: "Majstori",
                        principalColumn: "MajstorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZahteviZaServise_Servisi_ServisId",
                        column: x => x.ServisId,
                        principalTable: "Servisi",
                        principalColumn: "ServisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_KorisnikId",
                table: "Komentari",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_MajstorId",
                table: "Komentari",
                column: "MajstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Majstori_ServisId",
                table: "Majstori",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_MajstorId",
                table: "Usluge",
                column: "MajstorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_KorisnikId",
                table: "Zahtevi",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtevi_MajstorId",
                table: "Zahtevi",
                column: "MajstorId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaServise_MajstorId",
                table: "ZahteviZaServise",
                column: "MajstorId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahteviZaServise_ServisId",
                table: "ZahteviZaServise",
                column: "ServisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "Zahtevi");

            migrationBuilder.DropTable(
                name: "ZahteviZaServise");

            migrationBuilder.DropTable(
                name: "ZahtevZaNovServis");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Majstori");

            migrationBuilder.DropTable(
                name: "Servisi");
        }
    }
}
