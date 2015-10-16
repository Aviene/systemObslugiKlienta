using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Atrybuty

namespace systemObslugiKlienta.Models
{
    public class UserDataBaseViewModel
    {
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        public byte[] DataContent { get; set; }

    }
}
