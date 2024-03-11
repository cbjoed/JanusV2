using Microsoft.EntityFrameworkCore;
using shared.Model;

namespace Data
{
    public class Context : DbContext
    {
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Post> Posts => Set<Post>();


        public Context (DbContextOptions<Context> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}