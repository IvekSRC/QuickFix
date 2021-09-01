using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickFix.Models
{
    public class Usluga 
    {
        [Key]
        public int UslugaId { get; set; }

        [Required(ErrorMessage = "Naziv usluge je obavezno polje")]
        [StringLength(60, MinimumLength = 2,ErrorMessage = "Nziv usluge mora da ima bar 2, a maksimalno 60 karaktera")]
        public string NazivUsluge { get; set; }
        public int CenaUsluge { get; set; }
        public Majstor Majstor { get; set; }
    }
}