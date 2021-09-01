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
    public class RegistracijaMajstorModel : PageModel
    {
        public ContextKlasa dbContext;

        public RegistracijaMajstorModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public Majstor noviMajstor { get; set; }

        [BindProperty]
        public string UslugaJedan { get; set; }

        [BindProperty]
        public int UslugaJedanCena { get; set; }

        [BindProperty]
        public string UslugaDva { get; set; }

        [BindProperty]
        public int UslugaDvaCena { get; set; }

        [BindProperty]
        public string UslugaTri { get; set; }

        [BindProperty]
        public int UslugaTriCena { get; set; }

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
                dbContext.Majstori.Add(noviMajstor);

                if(UslugaJedan != null)
                {
                    if(UslugaJedan.Length > 1)
                    {
                        if(UslugaJedanCena > -1)
                        {
                            Usluga novaUsluga1 = new Usluga();
                            novaUsluga1.NazivUsluge = UslugaJedan;
                            novaUsluga1.CenaUsluge = UslugaJedanCena;
                            novaUsluga1.Majstor = noviMajstor;
                            dbContext.Usluge.Add(novaUsluga1);
                        }
                        else
                        {
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }

                if(UslugaDva != null)
                {
                    if(UslugaDva.Length > 1)
                    {
                        if(UslugaDvaCena > -1)
                        {
                            Usluga novaUsluga2 = new Usluga();
                            novaUsluga2.NazivUsluge = UslugaDva;
                            novaUsluga2.CenaUsluge = UslugaDvaCena;
                            novaUsluga2.Majstor = noviMajstor;
                            dbContext.Usluge.Add(novaUsluga2);
                        }
                        else
                        {
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }

                if(UslugaTri != null)
                {
                    if(UslugaTri.Length > 1)
                    {
                        if(UslugaTriCena > -1)
                        {
                            Usluga novaUsluga3 = new Usluga();
                            novaUsluga3.NazivUsluge = UslugaTri;
                            novaUsluga3.CenaUsluge = UslugaTriCena;
                            novaUsluga3.Majstor = noviMajstor;
                            dbContext.Usluge.Add(novaUsluga3);
                        }
                        else
                        {
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }

                await dbContext.SaveChangesAsync();

                return RedirectToPage("/Index");
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
