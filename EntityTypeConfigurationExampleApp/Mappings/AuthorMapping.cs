using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityTypeConfigurationExampleApp.Models;

namespace EntityTypeConfigurationExampleApp.Mappings
{
    internal class AuthorMapping : EntityTypeConfiguration<Author>
    {
        public AuthorMapping()
        {
            ToTable("authors");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id")
                .IsRequired();
            Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();
            Property(m => m.DateOfBirth)
                .HasColumnName("date_of_birth")
                .IsRequired();

            HasMany(m => m.Books)
                .WithRequired(m => m.Author);
        }
    }
}