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
    public class PrijavaMajstorModel : PageModel
    {
        public ContextKlasa dbContext;

        public PrijavaMajstorModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Majstor prijavljeniMajstor { get; set; }

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

        public async Task<IActionResult> OnPostAsync() {
            Majstor m = await dbContext.Majstori.Where(x=>x.MajstorEmail == prijavljeniMajstor.MajstorEmail).FirstOrDefaultAsync();
            if (m != null)
            {
                if (m.MajstorLozinka == prijavljeniMajstor.MajstorLozinka)
                {
                    m.MajstorPrijava = 1;
                    await dbContext.SaveChangesAsync();
                    return RedirectToPage("/MajstorInterfejs");
                }
                else
                {
                    return RedirectToPage("/PrijavaMajstor");
                }
            }
            else
            {
                return RedirectToPage("/PrijavaMajstor");
            }
        }
    }
}
