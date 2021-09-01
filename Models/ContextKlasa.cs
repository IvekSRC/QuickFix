using Microsoft.EntityFrameworkCore;

namespace QuickFix.Models
{
    public class ContextKlasa : DbContext
    {
        public ContextKlasa(DbContextOptions options) : base(options) { }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Majstor> Majstori { get; set; }
        public DbSet<Servis> Servisi { get; set; }
        public DbSet<Zahtev> Zahtevi { get; set; }
        public DbSet<ZahtevServis> ZahteviZaServise { get; set; }
        public DbSet<ZahtevNovServis> ZahtevZaNovServis { get; set; }
        public DbSet<Usluga> Usluge { get; set;}
        public DbSet<Komentar> Komentari { get; set; }
    }
}