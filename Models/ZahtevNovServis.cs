using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class ZahtevNovServis
    {
        [Key]
        public int ZahtevNovServisId { get; set; }
        public string ZahtevNovServisStanje { get; set; }
        [Required(ErrorMessage = "Naziv servisa je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Naziv servisa mora da ima 3-60 karaktera")]
        public string ZahtevNovServisNaziv { get; set; }
        [Required(ErrorMessage = "Lokacija servisa je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Lokacija mora da ima 2-60 karaktera")]
        public string ZahtevNovServisLokacija { get; set; }  
        [Required(ErrorMessage = "Email je obavezno polje")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string ZahtevNovServisAdminEmail { get; set; }  
        [Required(ErrorMessage = "Lozinka je obavezno polje")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "Lozinka mora da ima 3-60 karaktera")]
        [DisplayFormat(NullDisplayText = "Lozinka")]
        public string ZahtevNovServisAdminLozinka { get; set; }     
        [Required(ErrorMessage = "Ime Vlasnika je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Ime mora da ima bar 3-60 karaktera")]
        public string ZahtevNovServisAdminIme { get; set; }
        [Required(ErrorMessage = "Prezime Vlasnika je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Prezime mora da ima 3-60 karaktera")]
        public string ZahtevNovServisAdminPrezime { get; set; }

        [Range(18, 60, ErrorMessage = "Godine moraju biti 18-60")]
        [Required(ErrorMessage = "Godine su obavezno polje")]
        public string ZahtevNovServisAdminGod { get; set; }
        
        [Required(ErrorMessage = "Iskustvo sa servisima je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Iskustvo mora da ima 2-60 karaktera")]
        public string ZahtevNovServisAdminIskustvo { get; set; }
    }
}