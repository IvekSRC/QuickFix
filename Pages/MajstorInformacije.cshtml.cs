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
    public class MajstorInformacijeModel : PageModel
    {
        public ContextKlasa dbContext;

        public MajstorInformacijeModel(ContextKlasa db) {
            dbContext = db;
        }

        [BindProperty(SupportsGet=true)]
        public Majstor odabraniMajstor { get; set; }

        [BindProperty]
        public List<Usluga> listaUsluga { get; set; }

        [BindProperty(SupportsGet=true)]
        public List<Komentar> listaKomentara { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {
            odabraniMajstor = await dbContext.Majstori.FindAsync(id);
            listaUsluga = dbContext.Usluge.Where(x=>x.Majstor == odabraniMajstor).ToList();   
            listaKomentara = dbContext.Komentari.Where(x=>x.Majstor == odabraniMajstor).ToList();
            return Page();
        }
    }
}
