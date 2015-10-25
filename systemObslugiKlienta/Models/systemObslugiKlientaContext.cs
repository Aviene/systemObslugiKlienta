using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace systemObslugiKlienta.Models
{
    public class SystemObslugiKlientaContext : IdentityDbContext
    {

        public SystemObslugiKlientaContext()
            : base("DefaultConnection")
        {
        }
        public static SystemObslugiKlientaContext Create()
        {
            return new SystemObslugiKlientaContext();
        }

        public DbSet<UserDataBase> UserDataBases { get; set; }

        public DbSet<User> User { get; set; }

        #region Usunięcie domyślnej konwencji zamieniającej na liczby mnogie
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            /*
            //Wyłącza konwencję, która automatycznie tworzy liczbę mnogą dla nazw tabel w bazie danych
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //Wyłącza konwencję CascadeDelete, zostanie wyłączone za pomocą Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Używa się Fluent API aby ustalić powiązane pomiędzy tabelami i włączyć CascadeDelete tego powiązania
            modelBuilder.Entity<UserDataBase>().HasRequired(x => x.User).WithMany(x => x.UserDataBases).HasForeignKey(x => x.UserId).WillCascadeOnDelete(true);
             */
        }
        #endregion
    }
}