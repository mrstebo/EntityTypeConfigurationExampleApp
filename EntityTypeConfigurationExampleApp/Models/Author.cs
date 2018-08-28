using System;
using System.Collections.Generic;

namespace EntityTypeConfigurationExampleApp.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public virtual IList<Book> Books { get; set; }
    }
}