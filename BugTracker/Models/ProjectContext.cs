using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<BugContext> options) : base(options)
        {

        }

        public DbSet<Project> project { get; set; }
    }
}
