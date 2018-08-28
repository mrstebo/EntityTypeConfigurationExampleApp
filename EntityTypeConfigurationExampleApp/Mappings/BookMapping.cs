using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityTypeConfigurationExampleApp.Models;

namespace EntityTypeConfigurationExampleApp.Mappings
{
    internal class BookMapping : EntityTypeConfiguration<Book>
    {
        public BookMapping()
        {
            ToTable("books");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id")
                .IsRequired();
            Property(m => m.AuthorId)
                .HasColumnName("author_id")
                .IsRequired();
            Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();
            Property(m => m.PublishedOn)
                .HasColumnName("published_on")
                .IsRequired();

            HasRequired(m => m.Author)
                .WithMany(m => m.Books);
        }
    }
}