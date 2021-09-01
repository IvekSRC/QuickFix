using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuickFix.Models;

namespace QuickFix.Pages
{
    public class IndexModel : PageModel
    {
        public ContextKlasa dbContext;

        public IndexModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty]
        public List<Servis> Servisi { get; set; }

        [BindProperty]
        public List<Majstor> Majstori { get; set; }

        [BindProperty]
        public int PostojiMajstorBezServisa { get; set; }
        [BindProperty]
        public SelectList SelektLista { get; private set; }

        [BindProperty(SupportsGet=true)]
        public string IzabranaUsluga { get; set; }

        [BindProperty(SupportsGet=true)]
        public string IzabranServis { get; set; }
        
        [BindProperty(SupportsGet=true)]
        public string IzabranoIme { get; set; }

        [BindProperty(SupportsGet=true)]
        public Boolean ImaMajstora{get;set;}

        [BindProperty(SupportsGet=true)]
        public Boolean ImaUslugu{get;set;}

        public void SetUsluga(string x) {
            IzabranaUsluga = x;
        }

        public string GetUsluga() {
            return IzabranaUsluga;
        }

        public void OnGet() {
            PostojiMajstorBezServisa = 0;
            List<Korisnik> Korisnici = dbContext.Korisnici.ToList();
            foreach (var korisnik in Korisnici)
            {
                if (korisnik.KorisnikPrijava == 1)
                {
                    korisnik.KorisnikPrijava = 0;
                    dbContext.SaveChanges();
                }
            }

            IList<string> lista = dbContext.Usluge.Select(x=>x.NazivUsluge).Distinct().ToList();
            SelektLista = new SelectList(lista);

            List<Servis> sviServisi = dbContext.Servisi.ToList();
            foreach (var s in sviServisi)
            {
                if (s.AdminPrijava == 1)
                {
                    s.AdminPrijava = 0;
                    dbContext.SaveChanges();
                }
            }
            
            List<Majstor> sviMajstori = dbContext.Majstori.ToList();
            foreach (var majstor in sviMajstori)
            {
                if (majstor.MajstorPrijava == 1)
                {
                    majstor.MajstorPrijava = 0;
                    dbContext.SaveChanges();
                }
            }

            Servisi = dbContext.Servisi.Include(x=> x.ListaMajstora).ToList();
            foreach(Servis s in Servisi){
                foreach(Majstor m in s.ListaMajstora)
                {
                    m.Usluge=new List<Usluga>();
                    m.Usluge=dbContext.Usluge.Where(x=>x.Majstor==m).ToList();
                }
            }

            Majstori = dbContext.Majstori.ToList();
            foreach(Majstor m in Majstori)
                {
                    m.Usluge=new List<Usluga>();
                    m.Usluge=dbContext.Usluge.Where(x=>x.Majstor==m).ToList();
                }
            foreach (var item in Majstori)
            {
                if (item.Servis == null)
                {
                    PostojiMajstorBezServisa = 1;
                }   
            }
        }
    }
}
