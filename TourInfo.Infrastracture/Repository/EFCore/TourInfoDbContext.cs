using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TourInfo.Domain.Base;
using TourInfo.Domain;
using System.Linq;
using TourInfo.Domain.TourNews;
using TourInfo.Domain.DomainModel.Rapi;

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

          
            
            modelBuilder.Entity<EWQYEntity>()
                .Property(x => x.pictureKeys)
              .HasConversion(v => string.Join(";", v), v => v.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<EWQYEntity>()
               .Property(x => x. localizedPictureKeys)
             .HasConversion(v => string.Join(";", v), v => v.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<CompanyVenue>()
                .Property(x => x.location)
              .HasConversion(v => string.Join(";", v)
              , v => v.Split(new char[] { ';' } , StringSplitOptions.RemoveEmptyEntries)
                    .Select(x=>Convert.ToDouble(x)).ToArray()
              );


            modelBuilder.Entity<Projectinfo>()
              .HasKey(x => x.pid);
            modelBuilder.Entity<Projectinfo>()
            .Property(x => x.pid).ValueGeneratedNever();

            modelBuilder.Entity<Typeinfo>()
             .HasKey(x => x.typeid);
            modelBuilder.Entity<Typeinfo>()
            .Property(x => x.typeid).ValueGeneratedNever();

            modelBuilder.Entity<Typefield>()
             .HasKey(x => x.id);
            modelBuilder.Entity<Typefield>()
            .Property(x => x.id).ValueGeneratedNever();

            modelBuilder.Entity<Typetag>()
             .HasKey(x => x.id);
            modelBuilder.Entity<Typetag>()
            .Property(x => x.id).ValueGeneratedNever();

            modelBuilder.Entity<Typepic>()
             .HasKey(x => x.id);
            modelBuilder.Entity<Typepic>()
            .Property(x => x.id).ValueGeneratedNever();

            modelBuilder.Entity<Pubinfounit>()
             .HasKey(x => x.unitid);
            modelBuilder.Entity<Pubinfounit>()
            .Property(x => x.unitid).ValueGeneratedNever();

            modelBuilder.Entity<Pubunittag>()
             .HasKey(x => x.tagid);
            modelBuilder.Entity<Pubunittag>()
            .Property(x => x.tagid).ValueGeneratedNever();

            modelBuilder.Entity<Pubmediainfo>()
             .HasKey(x => x.mediaid);
            modelBuilder.Entity<Pubmediainfo>()
            .Property(x => x.mediaid).ValueGeneratedNever();
            //modelBuilder.Entity<Pubmediainfo>()
            //.HasIndex(x => x.mediaid).ForSqlServerIsClustered(false);

            modelBuilder.Entity<Pubinfounitchild>()
             .HasKey(x => x.childid);
            modelBuilder.Entity<Pubinfounitchild>()
            .Property(x => x.childid).ValueGeneratedNever() ;
            modelBuilder.Entity<Pubinfounitchild>()
                .HasIndex(x => x.childid);



        }
        // public DbSet<Entity<string>> Entities { get; set; }
        //public DbSet<VersionedEntity>  VersionedEntities { get; set; }
        // public DbSet<EWQYEntity> EWQYEntities{ get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<CompanyVenue> CompanyVenues{ get; set; }
        public DbSet<ZbtaNews> ZbtaNews { get; set; }
        public DbSet<Projectinfo> Projectinfos { get; set; }
        public DbSet<Typeinfo> Typeinfos { get; set; }
        public DbSet<Typefield> Typefields { get; set; }
        public DbSet<Typetag> Typetags { get; set; }
        public DbSet<Typepic> Typepics { get; set; }
        public DbSet<Pubinfounit> Pubinfounits { get; set; }
        public DbSet<Pubunittag> Pubunittags { get; set; }
        public DbSet<Pubmediainfo> Pubmediainfos { get; set; }
        public DbSet<Pubinfounitchild> Pubinfounitchilds { get; set; }
 

    }
}
