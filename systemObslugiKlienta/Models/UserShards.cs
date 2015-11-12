namespace systemObslugiKlienta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserShards
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string ShardName { get; set; }

        public int ServerId { get; set; }

        public int UserId { get; set; }

        public virtual Servers Servers { get; set; }

        public virtual User User { get; set; }
    }
}
