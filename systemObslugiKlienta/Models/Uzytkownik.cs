using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace systemObslugiKlienta.Models
{

    public class Uzytkownik : IdentityUser
    {
        public Uzytkownik()
        {
            this.BazyDanych = new HashSet<BazaDanych>();
        }

        //klucz glowny odziedziczony po klasie IdentityUser


        //Trzeba w kontrolerze dodać te pola
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

#region dodatkowe pole NotMapped
        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string PelneNazwisko
        {
            get { return Imie + " " + Nazwisko; }
        }
#endregion

        public virtual ICollection<BazaDanych> BazyDanych { get; private set; }

        //kod domyslny
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
