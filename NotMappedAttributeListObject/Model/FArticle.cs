namespace NotMappedAttributeListObject.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public class FArticle
    {
        public int CbMarq { get; set; }

        [IsProjected(true)] public string ArRef { get; set; } = null!;

        [NotMapped] public IList<PriceDto>? Prices { get; set; }

        public static void ConfigureModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FArticle>(entity =>
            {
                entity.HasKey(e => e.CbMarq).HasName("PK_CBMARQ_F_ARTICLE");

                entity.HasIndex(e => e.ArRef, "UKA_F_ARTICLE_AR_Ref").IsUnique();
                entity.Property(e => e.ArRef)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("AR_Ref");

                entity.Ignore(e => e.Prices);
            });
        }
    }
}
