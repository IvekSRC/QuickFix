using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuickFix.Models;

namespace QuickFix.Pages
{
    public class MajstorModel : PageModel
    {
        public ContextKlasa dbContext;

        public MajstorModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty(SupportsGet=true)]
        public Majstor odabraniMajstor { get; set; }

        [BindProperty]
        public List<Usluga> listaUsluga { get; set; }

        [BindProperty(SupportsGet=true)]
        public List<Komentar> listaKomentara { get; set; }

        [BindProperty]
        public Zahtev noviZahtev { get; set; }

        [BindProperty]
        public Korisnik korisnikZaPodatke { get; set; }

        [BindProperty]
        public Majstor majstorZaPodatke { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {
            odabraniMajstor = await dbContext.Majstori.FindAsync(id);
            listaUsluga = dbContext.Usluge.Where(x=>x.Majstor == odabraniMajstor).ToList();   
            listaKomentara = dbContext.Komentari.Where(x=>x.Majstor == odabraniMajstor).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostZakaziAsync(int idd,int majstorId) {            
            noviZahtev.StanjeZahteva = "Na cekanju";

            korisnikZaPodatke = await dbContext.Korisnici.Where(x=>x.KorisnikPrijava == 1).FirstOrDefaultAsync();
            Usluga odabranaUsluga = await dbContext.Usluge.Where(x=>x.UslugaId == idd).FirstOrDefaultAsync();
            //majstorZaPodatke = await dbContext.Majstori.Where(y=>y.MajstorId == odabranaUsluga.Majstor.MajstorId).FirstOrDefaultAsync();
            majstorZaPodatke = await dbContext.Majstori.FindAsync(majstorId);

            noviZahtev.ImeKorisnika = korisnikZaPodatke.KorisnikIme;
            noviZahtev.PrezimeKorisnika = korisnikZaPodatke.KorisnikPrezime;
            noviZahtev.EmailKorisnika = korisnikZaPodatke.KorisnikEmail;

            noviZahtev.ImeMajstora = majstorZaPodatke.MajstorIme;
            noviZahtev.PrezimeMajstora = majstorZaPodatke.MajstorPrezime;
            noviZahtev.UslugaMajstora = odabranaUsluga.NazivUsluge;
            noviZahtev.EmailMajstora = majstorZaPodatke.MajstorEmail;
            noviZahtev.OcenaMajstora = majstorZaPodatke.MajstorOcena;
            noviZahtev.BrojOcenaMajstora = majstorZaPodatke.BrojOcena;

            noviZahtev.Korisnik = korisnikZaPodatke;
            noviZahtev.Majstor = majstorZaPodatke;

            dbContext.Zahtevi.Add(noviZahtev);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("/KorisnickiInterfejs");
        }
    }
}
