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
    public class RegistracijaKorisnikModel : PageModel
    {
        public ContextKlasa dbContext;

        public RegistracijaKorisnikModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Korisnik noviKorisnik { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                            .Where(y=>y.Count>0)
                            .ToList();
                return Page();
            }
            else
            {
                dbContext.Korisnici.Add(noviKorisnik);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("/PrijavaKorisnik");
            }
        }

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
        }
    }
}
