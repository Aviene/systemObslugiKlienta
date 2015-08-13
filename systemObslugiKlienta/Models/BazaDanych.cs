using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Atrybuty

namespace systemObslugiKlienta.Models
{
    public class BazaDanych
    {
        [Key]
        public int IdPliku { get; set; }

        [StringLength(255)]
        public string NazwaPliku { get; set; }

        [StringLength(100)]
        public string TypZawartosci { get; set; }

        public byte[] Zawartosc { get; set; }
        public TypPliku TypPliku { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public System.DateTime DataDodania { get; set; }

        //Czy da się jakoś na int?
        public string UzytkownikId { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}
