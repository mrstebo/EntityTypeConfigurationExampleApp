using System;

namespace EntityTypeConfigurationExampleApp.Models
{
    public class Book
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime PublishedOn { get; set; }
        
        public virtual Author Author { get; set; }
    }
}