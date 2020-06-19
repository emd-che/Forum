using Forum.Model;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data 
{
    public class ForumContext: DbContext 
    {
        public ForumContext(DbContextOptions<ForumContext> opt): base(opt){}

        public DbSet<Topic> topics {get; set;}
    }
}