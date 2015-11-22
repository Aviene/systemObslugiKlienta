namespace systemObslugiKlienta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Servers
    {
        public Servers()
        {
            UserShards = new HashSet<UserShards>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Login { get; set; }

        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        public int? ActiveShards { get; set; }  // ? mo¿e byæ nullem (domyœln¹ wartoœci¹ jest NULL, a bez ? 0)

        public virtual ICollection<UserShards> UserShards { get; set; }
    }
}
