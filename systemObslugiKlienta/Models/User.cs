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

    public class User : IdentityUser
    {
        public User()
        {
            this.DataBases = new HashSet<UserDataBase>();
        }

        //klucz glowny odziedziczony po klasie IdentityUser


        //User Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public long REGON { get; set; }
        public long NIP { get; set; }

        //System Info
        public UserAccountType AccountType { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BlockDate { get; set; }
        public int IfBlocked { get; set; }

#region dodatkowe pole NotMapped
        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
#endregion

        public virtual ICollection<UserDataBase> DataBases { get;  set; }

        //kod domyslny
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
