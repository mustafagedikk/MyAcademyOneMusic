using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Context
{
    /// <summary>
    /// Normalde db contextden miras alıyordu fakat identity ekledikten sonra IdentityDbContextten miras alıyor
    /// </summary>
    public class OneMusicContext : IdentityDbContext<AppUser, AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-C7ME16C; database=OneMusicDb;integrated security=true; trustServerCertificate=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }




    }
}
