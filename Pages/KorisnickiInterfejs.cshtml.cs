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
    public class KorisnickiInterfejsModel : PageModel
    {
        public ContextKlasa dbContext;

        public KorisnickiInterfejsModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Korisnik prijavljeniKorisnik { get; set; }

        [BindProperty]
        public List<Majstor> listaMajstora { get; set; }

        [BindProperty]
        public List<Servis> listaServisa { get; set; }

        [BindProperty]
        public Zahtev noviZahtev { get; set; }

        [BindProperty]
        public List<Zahtev> listaZahteva { get; set; }

        [BindProperty]
        public Korisnik korisnikZaPodatke { get; set; }

        [BindProperty]
        public Majstor majstorZaPodatke { get; set; }

        [BindProperty]
        public int oceniMajstora { get; set; }

        [BindProperty]
        public string noviKomentar { get; set; }

        [BindProperty]
        public string IzabranServis { get; set; }

        [BindProperty]
        public string IzabranaUsluga { get; set; }

        [BindProperty]
        public string IzabranoIme { get; set; }

        [BindProperty]
        public int PostojiMajstorBezServisa { get; set; }

        [BindProperty(SupportsGet=true)]
        public Boolean ImaMajstora{get;set;}

        [BindProperty(SupportsGet=true)]
        public Boolean ImaUslugu{get;set;}

        public void OnGet() {
            PostojiMajstorBezServisa = 0;
            prijavljeniKorisnik = dbContext.Korisnici.Where(x=>x.KorisnikPrijava == 1).FirstOrDefault();
            listaMajstora = dbContext.Majstori.ToList();
            listaServisa = dbContext.Servisi.Include(x=> x.ListaMajstora).ToList();
            listaZahteva = dbContext.Zahtevi.Where(x=>x.Korisnik == prijavljeniKorisnik).ToList();

            foreach(Servis s in listaServisa)
            {
                foreach(Majstor m in s.ListaMajstora)
                {
                    m.Usluge=new List<Usluga>();
                    m.Usluge=dbContext.Usluge.Where(x=>x.Majstor==m).ToList();
                }
            }

           foreach(Majstor m in listaMajstora)
            {
                m.Usluge=new List<Usluga>();
                m.Usluge=dbContext.Usluge.Where(x=>x.Majstor==m).ToList();
            }
            
            foreach (var item in listaMajstora)
            {
                if (item.Servis == null)
                {
                    PostojiMajstorBezServisa = 1;
                }   
            }
        }

        public async Task<IActionResult> OnPostLogOutAsync() {
            Korisnik k = await dbContext.Korisnici.Where(x=>x.KorisnikPrijava == 1).FirstOrDefaultAsync();
            k.KorisnikPrijava = 0;
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/Prijava");
        }

        public void OnPostPretrazi() {
            PostojiMajstorBezServisa = 0;
            prijavljeniKorisnik = dbContext.Korisnici.Where(x=>x.KorisnikPrijava == 1).FirstOrDefault();
            listaMajstora = dbContext.Majstori.ToList();
            listaServisa = dbContext.Servisi.Include(x=> x.ListaMajstora).ToList();
            listaZahteva = dbContext.Zahtevi.Where(x=>x.Korisnik == prijavljeniKorisnik).ToList();

           foreach(Servis s in listaServisa)
            {
                foreach(Majstor m in s.ListaMajstora)
                {
                    m.Usluge=new List<Usluga>();
                    m.Usluge=dbContext.Usluge.Where(x=>x.Majstor==m).ToList();
                }
            }

           foreach(Majstor m in listaMajstora)
            {
                m.Usluge=new List<Usluga>();
                m.Usluge=dbContext.Usluge.Where(x=>x.Majstor==m).ToList();
            }
            
            foreach (var item in listaMajstora)
            {
                if (item.Servis == null)
                {
                    PostojiMajstorBezServisa = 1;
                }   
            }
        }

        public async Task<IActionResult> OnPostKomentarisiAsync(int id,int majstor) {
            if(noviKomentar != null)
            {
                Korisnik k = await dbContext.Korisnici.Where(x=>x.KorisnikPrijava == 1).FirstOrDefaultAsync();
                Zahtev z = await dbContext.Zahtevi.FindAsync(id);
                Majstor m = await dbContext.Majstori.FindAsync(majstor);

                Komentar nk = new Komentar();
                nk.SadrzajKomentara = noviKomentar;
                nk.Korisnik = k;
                nk.Majstor = z.Majstor;
                nk.NazivKorisnika = k.KorisnikIme + " " + k.KorisnikPrezime;
                nk.MejlKorisnika = k.KorisnikEmail;

                dbContext.Komentari.Add(nk);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("/KorisnickiInterfejs");
            }
            return RedirectToPage("/KorisnickiInterfejs");
        }

        public async Task<IActionResult> OnPostUkloniAsync(int id) {
            Zahtev zahtevZaBrisanje = await dbContext.Zahtevi.Where(x=>x.ZahtevId == id).FirstOrDefaultAsync();
            dbContext.Remove(zahtevZaBrisanje);
            await dbContext.SaveChangesAsync();

            await dbContext.SaveChangesAsync();
            return RedirectToPage("/KorisnickiInterfejs");
        }

        public async Task<IActionResult> OnPostOceniAsync(int id) {
            Zahtev odabranZahtev = await dbContext.Zahtevi.Where(x=>x.ZahtevId == id).FirstOrDefaultAsync();
            if(odabranZahtev.StanjeZahteva == "Popravljeno")
            {
                if (odabranZahtev.OcenjenZahtev != 1)
                {
                    Majstor odabranMajstor = await dbContext.Majstori.Where(y=>y.MajstorEmail == odabranZahtev.EmailMajstora).FirstOrDefaultAsync();
                    if (odabranMajstor.BrojOcena == 0)
                    {
                        odabranMajstor.BrojOcena = 1;
                        odabranZahtev.BrojOcenaMajstora = 1;
                        odabranMajstor.MajstorOcena = oceniMajstora;
                        odabranZahtev.OcenaMajstora = oceniMajstora;
                        odabranZahtev.OcenjenZahtev = 1;

                        await dbContext.SaveChangesAsync();
                        return RedirectToPage("/KorisnickiInterfejs");
                    }
                    else
                    {
                        odabranMajstor.BrojOcena++;
                        await dbContext.SaveChangesAsync();
                        odabranMajstor.MajstorOcena = (odabranMajstor.MajstorOcena + oceniMajstora) / 2;
                        odabranZahtev.BrojOcenaMajstora = odabranMajstor.BrojOcena;
                        odabranZahtev.OcenaMajstora = odabranMajstor.MajstorOcena;
                        odabranZahtev.OcenjenZahtev = 1;

                        await dbContext.SaveChangesAsync();
                        return RedirectToPage("/KorisnickiInterfejs");
                    }
                }
                else
                {
                    return RedirectToPage("/KorisnickiInterfejs");
                }                
            }
            else
            {
                return RedirectToPage("/KorisnickiInterfejs");
            }
        }
    }
}
