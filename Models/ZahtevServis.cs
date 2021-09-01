using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class ZahtevServis
    {
        [Key]
        public int ZahtevServisId { get; set; }
        public string StanjeZahteva { get; set; }
        public Majstor Majstor { get; set; }
        public string ImeMajstora { get; set; }
        public string PrezimeMajstora { get; set; }
        public string UslugaMajstora { get; set; }
        public string EmailMajstora { get; set; }
        public float OcenaMajstora { get; set; }
        public int BrojOcenaMajstora { get; set; }
        public Servis Servis { get; set; }
        public string ImeServisa { get; set; }
        public string LokacijaServisa { get; set; }
    }
}