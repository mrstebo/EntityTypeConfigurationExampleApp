using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EntityTypeConfigurationExampleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "App_Data"));

            using (var context = new LibraryContext())
            {
                context.Database.Initialize(true);
                
                var test = context.Authors.ToArray();

                foreach(var author in context.Authors.ToArray())
                {
                    Console.WriteLine($"[{author.Id}] {author.Name} ({author.DateOfBirth:yyyy-MM-dd})");
                    
                    foreach(var book in author.Books)
                    {
                        Console.WriteLine($"- [{book.Id}] {book.Name} ({book.PublishedOn:yyyy-MM-dd})");
                    }
                }
            }

            Console.WriteLine("Complete!");
            Console.ReadKey();
        }
    }
}