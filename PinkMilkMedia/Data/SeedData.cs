using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PinkMilkMedia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PinkMilkMedia.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PinkMilkMediaContext(
                serviceProvider.GetRequiredService<DbContextOptions<PinkMilkMediaContext>>()))
            {
                if (!context.Album.Any())
                {
                    context.Album.Add(
                    new Album
                    {
                        link = @"https://shoesyourpath.com/wp-content/uploads/2015/12/cascades-kuang-si-luang-prabang-laos.jpg",
                        Id = 2
                    });
                }
                
                context.SaveChanges();
            }
        }
    }
}
