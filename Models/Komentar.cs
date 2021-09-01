using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class Komentar
    {
        [Key]
        public int KomentarId { get; set; }

        [Required(ErrorMessage = "Komentar je obavezno polje")]
        [StringLength(100, MinimumLength = 2,ErrorMessage = "Komentar mora da ima bar 10, a maksimalno 100 karaktera")]
        public string SadrzajKomentara { get; set; }
        
        public Majstor Majstor { get; set; }
        
        public Korisnik Korisnik { get; set; }

        public string NazivKorisnika { get; set; }

        public string MejlKorisnika { get; set; }
    }
}