using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P235FirstApi.Entities;

namespace P235FirstApi.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.ToTable("P235Category");
            //builder.HasKey(c => c.Id);
            //builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(b => b.CreatedBy).HasDefaultValue("System");
            builder.Property(b => b.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.Name)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(b=>b.Image)
                .IsRequired(false)
                .HasMaxLength(255);

            builder
                .HasOne(b=>b.Parent)
                .WithMany(b=>b.Children)
                .HasForeignKey(b=>b.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
