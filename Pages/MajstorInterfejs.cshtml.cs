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
    public class MajstorInterfejsModel : PageModel
    {
        public ContextKlasa dbContext;

        public MajstorInterfejsModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public List<Komentar> listaKomentara { get; set; }

        [BindProperty]
        public Majstor prijavljeniMajstor { get; set; }

        [BindProperty]
        public List<Zahtev> listaZahteva { get; set; }

        [BindProperty]
        public List<Usluga> listaUsluga { get; set; }

        [BindProperty]
        public string novoStanje { get; set; }

        [BindProperty]
        public List<Servis> listaServisa { get; set; }

        [BindProperty]
        public ZahtevServis noviZahtevZaServis { get; set; }

        [BindProperty]
        public List<ZahtevServis> listaZahtevaZaServis { get; set; }

        [BindProperty]
        public Usluga novaUsluga { get; set; }

        public void OnGet() {
            prijavljeniMajstor = dbContext.Majstori.Where(x=>x.MajstorPrijava == 1).FirstOrDefault();
            listaZahteva = dbContext.Zahtevi.Where(y=>y.Majstor == prijavljeniMajstor).ToList();
            listaServisa = dbContext.Servisi.ToList();
            listaZahtevaZaServis = dbContext.ZahteviZaServise.ToList();
            Majstor m = dbContext.Majstori.Where(x=>x.MajstorPrijava == 1).FirstOrDefault();
            listaUsluga = dbContext.Usluge.Where(x=>x.Majstor == m).ToList();  
            listaKomentara = dbContext.Komentari.Where(x=>x.Majstor == m).ToList();          
        }

        public async Task<IActionResult> OnPostLogOutAsync() {
            Majstor m = await dbContext.Majstori.Where(x=>x.MajstorPrijava == 1).FirstOrDefaultAsync();
            m.MajstorPrijava = 0;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/Prijava");
        }

        public async Task<IActionResult> OnPostDodajAsync() {
            if(novaUsluga.NazivUsluge != null)
            {
                if (novaUsluga.CenaUsluge > -1)
                {
                    Majstor m = await dbContext.Majstori.Where(x=>x.MajstorPrijava == 1).FirstOrDefaultAsync();
                    novaUsluga.Majstor = m;
                    dbContext.Usluge.Add(novaUsluga);

                    await dbContext.SaveChangesAsync();
                    return RedirectToPage("/MajstorInterfejs");
                }
                return RedirectToPage("/MajstorInterfejs");
            }
            return RedirectToPage("/MajstorInterfejs");
        }

        public async Task<IActionResult> OnPostObrisiAsync(int id) {
            Usluga u = await dbContext.Usluge.Where(x=>x.UslugaId == id).FirstOrDefaultAsync();
            dbContext.Usluge.Remove(u);

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/MajstorInterfejs");
        }

        public async Task<IActionResult> OnPostUkloniAsync(int id) {
            Zahtev zahtev = await dbContext.Zahtevi.Where(x=>x.ZahtevId == id).FirstOrDefaultAsync();
            zahtev.StanjeZahteva = "Uklonjen";
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/MajstorInterfejs");
        }

        public async Task<IActionResult> OnPostOdobriZahtevAsync(int id) {
            Zahtev zahtev = await dbContext.Zahtevi.Where(x=>x.ZahtevId == id).FirstOrDefaultAsync();
            zahtev.StanjeZahteva = "Odobren";
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/MajstorInterfejs");
        }

        public async Task<IActionResult> OnPostOdbijZahtevAsync(int id) {
            Zahtev zahtev = await dbContext.Zahtevi.Where(x=>x.ZahtevId == id).FirstOrDefaultAsync();
            zahtev.StanjeZahteva = "Odbijen";
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/MajstorInterfejs");
        }

        public async Task<IActionResult> OnPostPopravljenoAsync(int id) {
            Zahtev zahtev = await dbContext.Zahtevi.Where(x=>x.ZahtevId == id).FirstOrDefaultAsync();
            zahtev.StanjeZahteva = "Popravljeno";
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/MajstorInterfejs");
        }
    
        public async Task<IActionResult> OnPostPodnesiZahtevAsync(int id) {  
            Servis odabranServis = await dbContext.Servisi.Where(x=>x.ServisId == id).FirstOrDefaultAsync();
            ZahtevServis daLiPostojiVecZahtev = await dbContext.ZahteviZaServise.Where(y=>y.ImeServisa == odabranServis.ServisIme).FirstOrDefaultAsync();
            if (daLiPostojiVecZahtev != null)
            {
                return RedirectToPage("/MajstorInterfejs");
            }
            else
            {
                Majstor odabranMajstor = await dbContext.Majstori.Where(x=>x.MajstorPrijava == 1).FirstOrDefaultAsync();

                noviZahtevZaServis.StanjeZahteva = "Na cekanju";

                noviZahtevZaServis.Majstor = await dbContext.Majstori.Where(x=>x.MajstorPrijava == 1).FirstOrDefaultAsync();
                noviZahtevZaServis.Servis = await dbContext.Servisi.Where(x=>x.ServisId == id).FirstOrDefaultAsync();

                noviZahtevZaServis.ImeMajstora = odabranMajstor.MajstorIme;
                noviZahtevZaServis.PrezimeMajstora = odabranMajstor.MajstorPrezime;
                noviZahtevZaServis.EmailMajstora = odabranMajstor.MajstorEmail;
                noviZahtevZaServis.OcenaMajstora = odabranMajstor.MajstorOcena;
                noviZahtevZaServis.BrojOcenaMajstora = odabranMajstor.BrojOcena;

                noviZahtevZaServis.ImeServisa = odabranServis.ServisIme;
                noviZahtevZaServis.LokacijaServisa = odabranServis.ServisLokacija;

                dbContext.ZahteviZaServise.Add(noviZahtevZaServis);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("/MajstorInterfejs");
            }
        }

        public async Task<IActionResult> OnPostPovuciZahtevAsync(int id) {
            ZahtevServis zahtevZaServis = await dbContext.ZahteviZaServise.Where(x=>x.ZahtevServisId == id).FirstOrDefaultAsync();
            dbContext.ZahteviZaServise.Remove(zahtevZaServis);            
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/MajstorInterfejs");
        }
    }
}
