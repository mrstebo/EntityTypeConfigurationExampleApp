using System.Data.Entity.Migrations;

namespace EntityTypeConfigurationExampleApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryContext context)
        {
        }
    }
}
