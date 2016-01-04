using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Retro_Indie_Spiel_Webserver.Models
{
    /// <summary>
    /// Model des Users, welches vom IdentityUser erbt, hier wird noch das HighscoreModel verzahnt.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public List<HighscoreModel> Highscores { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    /// <summary>
    /// Datenbankcontext, hier werden die einzelnen Tabellen und deren zusammenhang definiert,
    /// erbt von dem IdentityDbContext mit dem ApplicationUser.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HighscoreModel> Highscores { get; set; }

        /// <summary>
        /// md5HashKey für das Verhashen der Werte.
        /// </summary>
        public static string md5HashKey = "$%)TVJUFQ§evwio$%34sgg94kre";

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Wenn das Model erstellt wird, wird dies aufgerufen.
        /// </summary>
        /// <param name="modelBuilder">Ein DbModelBuilder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HighscoreModel>()
                .HasRequired(e => e.User)
                .WithMany(e => e.Highscores)
                .HasForeignKey(e => e.UserId);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Erstellt einen md5Hash aus einem String.
        /// </summary>
        /// <param name="md5Hash">MD5 aus dem der Hash gezogen wird.</param>
        /// <param name="input">String der gehasht werden soll.</param>
        /// <returns>Den md5Hash als String.</returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}