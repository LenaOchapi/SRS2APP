using Microsoft.EntityFrameworkCore;
using SRS2APP.Models;



namespace SRS2APP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }

}
