using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikId { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Ime mora da ima 2-60 karaktera")]
        public string KorisnikIme { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Prezime mora da ima 2-60 karaktera")]
        public string KorisnikPrezime { get; set; }

        [Required(ErrorMessage = "Email je obavezno polje")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string KorisnikEmail { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "Lozinka mora da ima 3-60 karaktera")]
        [DisplayFormat(NullDisplayText = "Lozinka")]
        public string KorisnikLozinka { get; set; }

        [Required(ErrorMessage = "Lokacija je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Lokacija mora da ima 2-60 karaktera")]
        public string KorisnikLokacija { get; set; }

        public int KorisnikPrijava { get; set; }

        public List<Zahtev> ListaZahtevaKorisnika { get; set; }
    }
}