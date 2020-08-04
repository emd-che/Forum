using Microsoft.EntityFrameworkCore;

namespace Forum.Models 
{
    public class DataContext: DbContext 
    {
        public DataContext(DbContextOptions<DataContext> opt): base(opt){}

        public DbSet<Topic> Topics {get; set;}
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}