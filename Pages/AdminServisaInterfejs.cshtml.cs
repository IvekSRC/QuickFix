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
    public class AdminServisaInterfejs : PageModel
    {
        public ContextKlasa dbContext;

        public AdminServisaInterfejs(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Servis servis { get; set; }

        [BindProperty]
        public string noviNaziv { get; set; }

        [BindProperty]
        public string novaLokacija { get; set; }

        [BindProperty]
        public string novoIme { get; set; }

        [BindProperty]
        public string novoPrezime { get; set; }

        [BindProperty]
        public string noviBrGod { get; set; }

        [BindProperty]
        public string novoIskustvo { get; set; }

        [BindProperty]
        public string novaLozinka { get; set; }

        [BindProperty]
        public List<Majstor> listaMajstora { get; set; }

        [BindProperty]
        public List<ZahtevServis> listaZahtevaZaServis { get; set; }

        [BindProperty]
        public Majstor majstorZaUklanjanje { get; set; }

        public void OnGet() {
            servis = dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefault(); 
            listaMajstora = dbContext.Majstori.Where(x=>x.Servis == servis).ToList();
            listaZahtevaZaServis = dbContext.ZahteviZaServise.Where(x=>x.StanjeZahteva == "Na cekanju").Where(y=>y.Servis == servis).ToList();
        }

        public async Task<IActionResult> OnPostLogOutAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.ServisId == 1).FirstOrDefaultAsync();
            s.AdminPrijava = 0;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/Prijava");
        }

        public async Task<IActionResult> OnPostPotvrdiAsync(int id) {
            ZahtevServis zahtev = await dbContext.ZahteviZaServise.Where(x=>x.ZahtevServisId == id).FirstOrDefaultAsync();
            zahtev.StanjeZahteva = "Potvrdjen";
            //Majstor podnosiocZahteva = await dbContext.Majstori.Where(x=>x.MajstorId == zahtev.Majstor.MajstorId).FirstOrDefaultAsync();
            //Servis trazeniServis = await dbContext.Servisi.Where(x=>x.ServisId == zahtev.Servis.ServisId).FirstOrDefaultAsync();
            Majstor podnosiocZahteva = await dbContext.Majstori.Where(y=>y.MajstorEmail == zahtev.EmailMajstora).FirstOrDefaultAsync();
            Servis trazeniServis = await dbContext.Servisi.Where(y=>y.ServisIme == zahtev.ImeServisa).FirstOrDefaultAsync();
            
            podnosiocZahteva.Servis = trazeniServis;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostOdbiAsync(int id) {
            ZahtevServis zahtev = await dbContext.ZahteviZaServise.Where(x=>x.ZahtevServisId == id).FirstOrDefaultAsync();
            zahtev.StanjeZahteva = "Odbijen";
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniNazivServisaAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();

            if(noviNaziv != null)
            {
                if(noviNaziv.Length > 2)
                {
                    s.ServisIme = noviNaziv;
                }
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniLokacijuServisaAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();
            
            if(novaLokacija != null)
            {
                if(novaLokacija.Length > 2)
                {
                    s.ServisLokacija = novaLokacija;
                }
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniImeVlasnikaAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();
            if(novoIme != null)
            {
                if(novoIme.Length > 1)
                {
                    s.ServisAdminIme = novoIme;
                }
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniPrezimeVlasnikaAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();
            if(novoPrezime != null)
            {
                if(novoPrezime.Length > 1)
                {
                    s.ServisAdminPrezime = novoPrezime;
                }
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniBrGodVlasnikaAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();
            
            if(noviBrGod != null)
            {
                var isNumeric2 = int.TryParse(noviBrGod, out _);
                if(isNumeric2 == true)
                {
                    s.ServisAdminGod = noviBrGod;
                }
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniIskustvoVlasnikaAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();
            if(novoIskustvo != null)
            {
                s.ServisAdminIskustvo = novoIskustvo;
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }

        public async Task<IActionResult> OnPostIzmeniAdAsync() {
            Servis s = await dbContext.Servisi.Where(x=>x.AdminPrijava == 1).FirstOrDefaultAsync();
            if(novaLozinka != null)
            {
                if(novaLozinka.Length > 2)
                {
                    s.AdminLozinka = novaLozinka;
                }
                else
                {
                    return RedirectToPage("/AdminServisaInterfejs");
                }
            }

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/AdminServisaInterfejs");
        }
    }
}
