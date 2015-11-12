namespace systemObslugiKlienta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserStorage")]
    public partial class UserStorage
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string StorageName { get; set; }

        [StringLength(150)]
        public string StoragePrimaryKey { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
