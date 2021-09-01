using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class Zahtev
    {
        [Key]
        public int ZahtevId { get; set; }
        public string StanjeZahteva { get; set; }
        public int OcenjenZahtev { get; set; }
        public Korisnik Korisnik { get; set; }
        public string ImeKorisnika { get; set; }
        public string PrezimeKorisnika { get; set; }
        public string EmailKorisnika { get; set; }
        public Majstor Majstor { get; set; }
        public string ImeMajstora { get; set; }
        public string PrezimeMajstora { get; set; }
        public string UslugaMajstora { get; set; }
        public string EmailMajstora { get; set; }
        public float OcenaMajstora { get; set; }
        public int BrojOcenaMajstora { get; set; }
    }
}