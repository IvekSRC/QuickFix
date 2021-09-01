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
    public class RegistracijaModel : PageModel
    {
        public ContextKlasa dbContext;

        public RegistracijaModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Lozinka { get; set; }

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

            List<Servis> sviServisi = dbContext.Servisi.ToList();
            foreach (var s in sviServisi)
            {
                if (s.AdminPrijava == 1)
                {
                    s.AdminPrijava = 0;
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
