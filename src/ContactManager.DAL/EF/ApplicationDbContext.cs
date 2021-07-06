using ContactManager.DAL.Configuration;
using ContactManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.DAL.EF
{
    /// <summary>
    /// Data storage.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Class for creating data.
        /// </summary>
        /// <param name="builder">parameter for new model adding.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ContactConfiguration());
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
