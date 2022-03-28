using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider  serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "HerLand",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 07, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "HerLand",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2010, 11, 22)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
