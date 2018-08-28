using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EntityTypeConfigurationExampleApp.Models;

namespace EntityTypeConfigurationExampleApp
{
    public class LibraryContext : DbContext
    {
        static LibraryContext()
        {
            Database.SetInitializer(new LibraryContextInitializer());
        }

        public LibraryContext()
            : base("Name=LibraryContext")
        {
        }
        
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

        internal class LibraryContextInitializer : IDatabaseInitializer<LibraryContext>
        {
            public void InitializeDatabase(LibraryContext context)
            {
                context.Database.CreateIfNotExists();
                
                context.Authors.AddOrUpdate(m => m.Id,
                    Enumerable.Range(1, 10).Select(i => CreateAuthor(i)).ToArray());

                context.SaveChanges();
            }

            private Author CreateAuthor(long id) => new Author
            {
                Id = id,
                Name = Faker.Name.FullName(Faker.NameFormats.Standard),
                DateOfBirth = CreateRandomDate(),
                Books = Enumerable.Range(1, Faker.RandomNumber.Next(1, 10)).Select(i => CreateBook(i, id)).ToList()
            };

            private Book CreateBook(long id, long authorId) => new Book
            {
                Id = id,
                AuthorId = authorId,
                Name = Faker.Company.CatchPhrase(),
                PublishedOn = CreateRandomDate()
            };

            private DateTime CreateRandomDate() => DateTime.Now.Date
                .Subtract(TimeSpan.FromDays(365 * 18))
                .Subtract(TimeSpan.FromDays(Faker.RandomNumber.Next(365 * 50)));
        }
    }
}