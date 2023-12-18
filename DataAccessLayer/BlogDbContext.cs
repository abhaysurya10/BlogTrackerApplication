using System.Data.Entity;

namespace DataAccessLayer
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext() : base("name = Blog")
        {
            Database.SetInitializer<BlogDbContext>(new DropCreateDatabaseIfModelChanges<BlogDbContext>());
        }
        public DbSet<AdminInfo> AdminInfo { get; set; }
        public DbSet<EmpInfo> EmpInfo { get; set; } 
        public DbSet<BlogInfo> BlogInfo { get; set; }
    }

    public class DALContextInit : DropCreateDatabaseIfModelChanges<BlogDbContext> 
    {
        protected override void Seed(BlogDbContext context)
        {
            context.AdminInfo.Add(new AdminInfo { EmailId = "demo", Password = "1234" });
            context.SaveChanges();
            base.Seed(context);

        }
    }
    
}
