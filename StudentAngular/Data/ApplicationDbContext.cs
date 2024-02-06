using Microsoft.EntityFrameworkCore;
using StudentAngular.Models;

namespace StudentAngular.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
