using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PinkMilkMedia.Models;

namespace PinkMilkMedia.Models
{
    public class PinkMilkMediaContext : IdentityDbContext<Owner>
    {
        public PinkMilkMediaContext (DbContextOptions<PinkMilkMediaContext> options)
            : base(options)
        {
        }

        public DbSet<PinkMilkMedia.Models.Album> Album { get; set; }

        public DbSet<PinkMilkMedia.Models.Photo> Photo { get; set; }

        //public DbSet<PinkMilkMedia.Models.Photo> Photo { get; set; }
    }
}
