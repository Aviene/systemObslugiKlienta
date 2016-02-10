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

    public class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim> 
    {
        public User()
        {
            this.UserDataBases = new HashSet<UserDataBase>();
            UserStorage = new HashSet<UserStorage>();
            UserShards = new HashSet<UserShards>();
        }

        //klucz glowny odziedziczony po klasie IdentityUser


        //User Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }

        //System Info
        public UserAccountType AccountType { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BlockDate { get; set; }

#region dodatkowe pole NotMapped
        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
#endregion

        public virtual ICollection<UserDataBase> UserDataBases { get;  set; }

        public virtual ICollection<UserStorage> UserStorage { get; set; }

        public virtual ICollection<UserShards> UserShards { get; set; }

        //kod domyslny
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<User, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(SystemObslugiKlientaContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(SystemObslugiKlientaContext context)
            : base(context)
        {
        }
    } 
}
