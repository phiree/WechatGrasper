using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TourInfo.Domain.Base;
using TourInfo.Domain;
using System.Linq;
using TourInfo.Domain.TourNews;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class TourInfoDbContext:DbContext
    {
        protected TourInfoDbContext() { }
        public TourInfoDbContext(DbContextOptions<TourInfoDbContext> options)
                : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
            
            modelBuilder.Entity<Activity>()
                .Property(x => x.pictureKeys)
              .HasConversion(v => string.Join(";", v), v => v.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<CompanyVenue>()
               .Property(x => x.pictureKeys)
             .HasConversion(v => string.Join(";", v), v => v.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<CompanyVenue>()
                .Property(x => x.location)
              .HasConversion(v => string.Join(";", v)
              , v => v.Split(new char[] { ';' } , StringSplitOptions.RemoveEmptyEntries)
                    .Select(x=>Convert.ToDouble(x)).ToArray()
              );
        }
        public DbSet<Entity<string>> Entities { get; set; }
        public DbSet<VersionedEntity>  VersionedEntities { get; set; }
        public DbSet<EWQYEntity> EWQYEntities{ get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<CompanyVenue> CompanyVenues{ get; set; }

        public DbSet<ZbtaNews> ZbtaNews { get; set; }


    }
}
