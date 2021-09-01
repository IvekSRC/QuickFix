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
    public class AdminInterfejsModel : PageModel
    {
        public ContextKlasa dbContext;

        public AdminInterfejsModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Korisnik prijavljeniKorisnik { get; set; }

        [BindProperty]
        public List<Majstor> listaMajstora { get; set; }

        [BindProperty]
        public List<ZahtevServis> listaZahtevaZaServis { get; set; }

        [BindProperty]
        public List<ZahtevNovServis> listaZaRegistraciju { get; set; }

        [BindProperty]
        public Servis noviServis { get; set; }

        public void OnGet() {
            listaZaRegistraciju = dbContext.ZahtevZaNovServis.Where(x=>x.ZahtevNovServisStanje == "Na cekanju").ToList();
            listaMajstora = dbContext.Majstori.ToList();
            listaZahtevaZaServis = dbContext.ZahteviZaServise.Where(x=>x.StanjeZahteva == "Na cekanju").ToList();
        }

        public async Task<IActionResult> OnPostLogOutAsync() {
            Korisnik k = await dbContext.Korisnici.Where(x=>x.KorisnikPrijava == 1).FirstOrDefaultAsync();
            k.KorisnikPrijava = 0;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/Prijava");
        }

        public async Task<IActionResult> OnPostRegistrujAsync(int id) {
            ZahtevNovServis zahtev = await dbContext.ZahtevZaNovServis.Where(x=>x.ZahtevNovServisId == id).FirstOrDefaultAsync();
            zahtev.ZahtevNovServisStanje = "Registrovan";
            
            noviServis.ServisIme = zahtev.ZahtevNovServisNaziv;
            noviServis.ServisLokacija = zahtev.ZahtevNovServisLokacija;
            noviServis.AdminEmail = zahtev.ZahtevNovServisAdminEmail;
            noviServis.AdminLozinka = zahtev.ZahtevNovServisAdminLozinka;
            noviServis.ServisAdminIme = zahtev.ZahtevNovServisAdminIme;
            noviServis.ServisAdminPrezime = zahtev.ZahtevNovServisAdminPrezime;
            noviServis.ServisAdminGod = zahtev.ZahtevNovServisAdminGod;
            noviServis.ServisAdminIskustvo = zahtev.ZahtevNovServisAdminIskustvo;
            noviServis.AdminPrijava = 0;

            dbContext.Servisi.Add(noviServis);
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminInterfejs");
        }

        public async Task<IActionResult> OnPostNeRegistrujAsync(int id) {
            ZahtevNovServis zahtev = await dbContext.ZahtevZaNovServis.Where(x=>x.ZahtevNovServisId == id).FirstOrDefaultAsync();
            zahtev.ZahtevNovServisStanje = "Odbijen";
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminInterfejs");
        }
    }
}
