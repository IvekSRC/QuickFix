using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class Majstor
    {
        [Key]
        public int MajstorId { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Ime mora da ima 2-60 karaktera")]
        public string MajstorIme { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Prezime mora da ima 2-60 karaktera")]
        public string MajstorPrezime { get; set; }

        public List<Usluga> Usluge { get; set; }

        [Required(ErrorMessage = "Email je obavezno polje")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string MajstorEmail { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "Lozinka mora da ima 3-60 karaktera")]
        [DisplayFormat(NullDisplayText = "Lozinka")]
        public string MajstorLozinka { get; set; }
        public float MajstorOcena { get; set; }

        public int BrojOcena { get; set; }

        public int MajstorPrijava { get; set; }

        public Servis Servis { get; set; } 

        public List<Zahtev> ListaZahtevaKorisnika { get; set; }
        public List<ZahtevServis> ListaZahtevaZaServis { get; set; }
    }
}