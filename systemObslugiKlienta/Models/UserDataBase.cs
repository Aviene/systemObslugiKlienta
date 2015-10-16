using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web; 

namespace systemObslugiKlienta.Models
{
    public class UserDataBase
    {
        [Key]
        public int FileId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string DataContentType { get; set; }

        public byte[] DataContent { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd")]
        public System.DateTime AddDate { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
