using Microsoft.EntityFrameworkCore;

namespace NotMappedAttributeListObject.Model
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FArticle> FArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FArticle.ConfigureModelBuilder(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
