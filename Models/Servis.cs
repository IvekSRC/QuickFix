using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickFix.Models
{
    public class Servis
    {
        [Key]
        public int ServisId { get; set; }

        [Required(ErrorMessage = "Naziv servisa je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Naziv servisa mora da ima bar 3, a maksimalno 60 karaktera")]
        public string ServisIme { get; set; }

        [Required(ErrorMessage = "Lokacija servisa je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Lokacija mora da ima bar 2, a maksimalno 60 karaktera")]
        public string ServisLokacija { get; set; }

        [Required(ErrorMessage = "Email je obavezno polje")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "Lozinka mora da ima bar 3, a maksimalno 60 karaktera")]
        [DisplayFormat(NullDisplayText = "Lozinka")]
        public string AdminLozinka { get; set; }
        [Required(ErrorMessage = "Ime Vlasnika je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Ime Vlasnika mora da ima bar 3, a maksimalno 60 karaktera")]
        public string ServisAdminIme { get; set; }
        [Required(ErrorMessage = "Prezime Vlasnika je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Prezime Vlasnika mora da ima bar 3, a maksimalno 60 karaktera")]
        public string ServisAdminPrezime { get; set; }

        [Display(Name = "Broj godina")]
        [Required(ErrorMessage = "Broj godina je obavezno polje")]
        public string ServisAdminGod { get; set; }

        [Required(ErrorMessage = "Iskustvo sa servisima je obavezno polje")]
        [Display(Name = "Iskustvo")]
        public string ServisAdminIskustvo { get; set; }

        public int AdminPrijava { get; set; }

        public List<Majstor> ListaMajstora { get; set; }
        public List<ZahtevServis> ListaZahtevaZaServis { get; set; }
    }
}