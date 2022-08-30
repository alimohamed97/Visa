using Microsoft.EntityFrameworkCore;

using Visa.DAL.Entity;

namespace Visa.DAL.Database
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt){}
    }

    public partial class ApplicationContext : DbContext
    {
        public DbSet<Header> Header { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Steps> Steps { get; set; }
        public DbSet<HomeTestimonials> HomeTestimonials { get; set; }
        public DbSet<ContactBanner> ContactBanner{ get; set; }
        public DbSet<LookUp> LookUp { get; set; }
        public DbSet<LookUpValue> lookUpValues { get; set; }
        public DbSet<Landing> Landing { get; set; }
        public DbSet<FaQuestion> FaQuestion { get; set; }
        public DbSet<StampedVisa> StampedVisa { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
    }
}
      
    




