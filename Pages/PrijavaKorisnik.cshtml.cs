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
    public class PrijavaKorisnikModel : PageModel
    {
        public ContextKlasa dbContext;

        public PrijavaKorisnikModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Korisnik prijavljeniKorisnik { get; set; }

        public void OnGet() {
            List<Korisnik> Korisnici = dbContext.Korisnici.ToList();
            foreach (var korisnik in Korisnici)
            {
                if (korisnik.KorisnikPrijava == 1)
                {
                    korisnik.KorisnikPrijava = 0;
                    dbContext.SaveChanges();
                }
            }

            List<Majstor> Majstori = dbContext.Majstori.ToList();
            foreach (var majstor in Majstori)
            {
                if (majstor.MajstorPrijava == 1)
                {
                    majstor.MajstorPrijava = 0;
                    dbContext.SaveChanges();
                }
            }

            List<Servis> sviServisi = dbContext.Servisi.ToList();
            foreach (var ser in sviServisi)
            {
                if (ser.AdminPrijava == 1)
                {
                    ser.AdminPrijava = 0;
                    dbContext.SaveChanges();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync() {            
            Korisnik k = await dbContext.Korisnici.Where(x=>x.KorisnikEmail == prijavljeniKorisnik.KorisnikEmail).FirstOrDefaultAsync();

            Servis s = await dbContext.Servisi.Where(x=>x.AdminEmail == prijavljeniKorisnik.KorisnikEmail).FirstOrDefaultAsync();
            if(s != null)
            {
                if(s.AdminLozinka == prijavljeniKorisnik.KorisnikLozinka)
                {
                    s.AdminPrijava = 1;
                    await dbContext.SaveChangesAsync();
                    return RedirectToPage("/AdminServisaInterfejs");
                }
                else
                {
                    return RedirectToPage("/PrijavaKorisnik");
                }
            }

            if (k != null)
            {
                if(k.KorisnikEmail == "admin.admin@elfak.rs")
                {
                    if(k.KorisnikLozinka == "adminadmin")
                    {
                        k.KorisnikPrijava = 1;
                        await dbContext.SaveChangesAsync();
                        return RedirectToPage("/AdminInterfejs");
                    }
                    else
                    {
                        return RedirectToPage("/PrijavaKorisnik");
                    }
                }
                else
                {
                    if (k.KorisnikLozinka == prijavljeniKorisnik.KorisnikLozinka)
                    {
                        k.KorisnikPrijava = 1;
                        await dbContext.SaveChangesAsync();
                        return RedirectToPage("/KorisnickiInterfejs");
                    }
                    else
                    {
                        return RedirectToPage("/PrijavaKorisnik");
                    }
                }
            }
            else
            {
                return RedirectToPage("/PrijavaKorisnik");
            }
        }
    }
}
