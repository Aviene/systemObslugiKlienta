using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Atrybuty

namespace systemObslugiKlienta.Models
{
    public class BazaDanychViewModel
    {
        [Required]
        [StringLength(255)]
        public string NazwaPliku { get; set; }

        [Required]
        public byte[] Zawartosc { get; set; }

    }
}
