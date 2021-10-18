using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TourInfo.Domain.Base;
using TourInfo.Domain;
using System.Linq;
using TourInfo.Domain.TourNews;
using TourInfo.Domain.DomainModel.Rapi;
using TourInfo.Domain.DomainModel.EWQY;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourInfo.Domain.DomainModel.Video;
using static TourInfo.Domain.DomainModel.SDTA.LineDetail;
using System.Security.Cryptography.X509Certificates;
using TourInfo.Domain.ZBTA;
using TourInfo.Infrastracture.Migrations;
using TourInfo.Domain.DomainModel.ZiBoWechatNews;
using TourInfo.Domain.DomainModel.DataLog;

namespace TourInfo.Infrastracture.Repository.EFCore
{
    public class TourInfoDbContext : DbContext
    {
        protected TourInfoDbContext() { }
        public TourInfoDbContext(DbContextOptions<TourInfoDbContext> options)
                : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.DomainModel.WHY.WHYNews>()
     .OwnsOne(x => x.imagepath);

            modelBuilder.Entity<EWQYEntity>()
                .OwnsMany(x => x.pictureKeys, key =>
                {
                    key.HasForeignKey("id");
                    key.Property<string>("OriginalUrl");
                    key.HasKey("OriginalUrl", "id");
                })
                ;
            modelBuilder.Entity<EWQYEntity>()
            .OwnsOne(x => x.thumbnailKey);

            modelBuilder.Entity<CompanyVenue>()
                .OwnsOne(x => x.location).ToTable("CompanyVanueLocations");



            modelBuilder.Entity<ZbtaNews>()
                .OwnsOne(x => x.image);
            modelBuilder.Entity<ZbtaNews>()
               .OwnsOne(x => x.details);




            modelBuilder.Entity<Video>()
          .Property(x => x.id).ValueGeneratedNever();

            modelBuilder.Entity<Domain.DomainModel.WHY.WhyModel>()
         .OwnsOne(x => x.hposter);

            modelBuilder.Entity<Domain.DomainModel.WHY.WhyModel>()
         .OwnsOne(x => x.location);


            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetail>()
           .OwnsOne(x => x.thumb);

            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetail>()
            .Property(e => e.tags)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                );

            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetail>()
           .Property(e => e.city)
           .HasConversion(
               v => string.Join(",", v),
               v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
               );


            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetail>()
                .ToTable("SDTALineDetail")
         .OwnsMany(e => e.days, c =>
         {
             c.ToTable("SDTALineDetailDay");
             c.HasForeignKey("LineId");
             c.Property("name");
             c.HasKey("LineId", "name");
             c.OwnsMany(
                 e => e.place, g =>
                 {
                     g.ToTable("SDTALineDetailDayPlace");
                     g.HasForeignKey("LineId", "name");
                     g.Property("id");
                     g.HasKey("LineId", "name", "id");
                 }
                 );
         });

            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetailScenic.Doc.Source>()
                .OwnsOne(x => x.default_photo)

            ;
            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetailScenic.Doc.Source>()
                            .Property(x => x.location).HasConversion(
                                                           v => string.Join(",", v),
                                                           v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToList()
                                                       );
            modelBuilder.Entity<Domain.DomainModel.SDTA.LineDetailScenic.Doc.Source>()
             .ToTable("SDTALineDetailScenicDocSource")
            .OwnsMany(x => x.eletype, d =>
            {
                d.ToTable("SDTALineDetailScenicDocSourceEletype");
                d.HasForeignKey("sourceid");
                d.HasKey("sourceid", "id");
                d.Property(x => x.ancestors).HasConversion(
                                                v => string.Join(",", v),
                                                v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            );
            })
          ;

            modelBuilder.Entity<Domain.DomainModel.SDTA.CityGuide>()
             .ToTable("SDTACityGuide") 
           
             .OwnsMany(x=>x.category,d=>{
                 d.ToTable("SDTACityGuideCategory");
                 d.HasForeignKey("GuideId");
                 d.Property("name");
                 d.HasKey("GuideId","name");
                 d.OwnsMany(x => x.list, e => {
                     e.ToTable("SDTACityGuideCategoryList");
               e.HasKey("id");
                 });
             })
             ;
              
           

            modelBuilder.Entity<Domain.DomainModel.SDTA.CityGuideDetail.Data>()
                .OwnsOne(e => e.image)
            ;
            modelBuilder.Entity<Domain.DomainModel.SDTA.CityGuideDetail.Data>()
             .OwnsOne(e => e.content)
         ;
            modelBuilder.Entity<Domain.DomainModel.SDTA.CityGuideDetail.Data>()
            .ToTable("SDTACityGuideDetail")
            .OwnsOne(e => e.pics, c =>
            {
                c.ToTable("SDTACityGuideDetailPics");
                c.OwnsMany(x => x.images, d =>
                {

                    d.ToTable("SDTACityGuideDetailPicImage");
                    d.HasForeignKey("GuideId");
                    d.Property(x => x.description);
                    d.HasKey("GuideId", "description");
                    d.OwnsOne(y => y.img);

                });
            });

            //美食
            /* 
            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
             .ToTable("SDTAFoodDetail");

            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
             .OwnsOne(e => e.snack_food_type);

            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
             .OwnsOne(e => e.defaultphoto);

            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
                .Property(a => a.id).ValueGeneratedNever();

            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
           .OwnsMany(e => e.pictures, c =>
           {
               c.ToTable("SDTAFoodDetailPictures");
               c.HasForeignKey("FoodId");
               c.Property(x => x.id);
               c.HasKey("FoodId", "id");
               c.OwnsOne(x => x.pho_path);
           });
            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
                .OwnsMany(e => e.filter_pictures, c =>
          {
              c.ToTable("SDTAFoodDetailFilterPictures");
              c.HasForeignKey("FoodId");
              c.Property(x => x.id);
              c.HasKey("FoodId", "id");
              c.OwnsOne(x => x.pho_path);
          });

            modelBuilder.Entity<Domain.DomainModel.SDTA.FoodDetail.Data>()
                .OwnsOne(e => e.destination, c =>
                {
                    c.ToTable("SDTAFoodDetailDestination");
                    c.HasForeignKey("FoodId");
                    c.Property(x => x.id);
                    c.HasKey("FoodId", "id");
                    c.OwnsOne(x => x.defaultphoto);
                });
             */
            //特产 

          
            modelBuilder.Entity<Domain.DomainModel.SDTA.SpecialLocalProductDetail.Data>()
         .ToTable("SDTASpecialLocalProductDetail")
          .OwnsOne(x => x.defaultphoto);
            

            modelBuilder.Entity<Domain.DomainModel.SDTA.SpecialLocalProductDetail.Data>()
              .OwnsOne(x => x.destination, c =>
              {
                  c.OwnsOne(x => x.defaultphoto);
              });
           

           
            modelBuilder.Entity<Domain.DomainModel.SDTA.SpecialLocalProductDetail.Data>()
               .OwnsMany(e => e.pictures, c =>
               {
                   c.ToTable("SDTASpecialLocalProductDetailPictures");
                   c.HasForeignKey("SpecialLocalProducId");
                   c.Property(x => x.id);
                   c.HasKey("SpecialLocalProducId", "id");
                   c.OwnsOne(x => x.pho_path);
               });
            modelBuilder.Entity<ZiBoWechatNews>()
         .OwnsOne(x => x.img);

            modelBuilder.Entity<ZiBoWechatNews>()
       //  .OwnsOne(x => x.content);
       ;
            modelBuilder.Entity<TourInfo.Domain.DomainModel.WHY.WhyActivity>()
                .OwnsOne(x=>x.hPoster);


            #region rapi 已弃用
            /* 
            modelBuilder.Entity<Projectinfo>()
              .HasKey(x => x.pid);
            modelBuilder.Entity<Projectinfo>()
            .Property(x => x.pid).ValueGeneratedNever();


            modelBuilder.Entity<Typeinfo>()
             .HasKey(x => x.typeid);
            modelBuilder.Entity<Typeinfo>()
            .Property(x => x.typeid).ValueGeneratedNever();

            modelBuilder.Entity<Typeinfo>()
          .OwnsOne(x => x.wapshowimg);


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

            modelBuilder.Entity<Pubinfounit>()
       .OwnsOne(x => x.flagpic);

            modelBuilder.Entity<Pubinfounit>()
                .OwnsOne(x => x.gps);
            modelBuilder.Entity<Pubinfounit>()
               .OwnsOne(x => x.gpsbd);
            modelBuilder.Entity<Pubinfounit>()
               .OwnsOne(x => x.gpsgd);




            modelBuilder.Entity<Pubinfounitchild>()
        .OwnsOne(x => x.flagurl);
            modelBuilder.Entity<Pubinfounitchild>()
              .OwnsOne(x => x.gps);
            modelBuilder.Entity<Pubinfounitchild>()
               .OwnsOne(x => x.gpsbd);
            modelBuilder.Entity<Pubinfounitchild>()
               .OwnsOne(x => x.gpsgd);



            modelBuilder.Entity<Pubunittag>()
             .HasKey(x => x.unittagid);
            modelBuilder.Entity<Pubunittag>()
            .Property(x => x.unittagid).ValueGeneratedNever();

            modelBuilder.Entity<Pubmediainfo>()
             .HasKey(x => x.mediaid);
            modelBuilder.Entity<Pubmediainfo>()
            .Property(x => x.mediaid).ValueGeneratedNever();

            modelBuilder.Entity<Pubmediainfo>()
                .OwnsOne(x => x.mediaurl);
            //modelBuilder.Entity<Pubmediainfo>()
            //      .Property(x => x.mediaurl)
            //  .HasConversion(v => v.ToString()
            //  , v => new ImageUrl(v)
            //  ) ;


            modelBuilder.Entity<Pubinfounitchild>()
             .HasKey(x => x.childid);
            modelBuilder.Entity<Pubinfounitchild>()
            .Property(x => x.childid).ValueGeneratedNever();
            modelBuilder.Entity<Pubinfounitchild>()
                .HasIndex(x => x.childid);
            */
            #endregion

            //日志
            modelBuilder.Entity<DataSource>().HasData(
                new DataSource { id= "528a3ebc-775c-4fca-b125-f2b3389eca34", Name="淄博文化云",BaseUrl="zbwhy.com", Status="正常" },
                new DataSource { id= "e255daf9-3188-4e73-9849-5f510e265fad", Name="E文齐韵",BaseUrl= "w.culturedata.com.cn", Status="许可过期,已停用" },
                new DataSource { id= "15da55b8-511f-402a-9d42-637cd87a6405", Name="存档资源",BaseUrl="rapi.zjwist.com", Status="正常" },
                new DataSource { id= "64afbfcf-62a8-40c5-9815-ad660288108f", Name="淄博旅游资讯网",BaseUrl="zbta.net", Status="正常" },
                new DataSource { id= "db1ea02d-1031-440c-bcae-036027e96001", Name="淄博新闻公众号",BaseUrl="----", Status="正常" }
                );
            modelBuilder.Entity<Client>().HasData(
              new Client { id = "528a3ebc-775c-4fca-b125-f2b3389eca34", Name = "大厅迎宾屏",  AppId="appid001", AppSecret = "********" },
              new Client { id = "e255daf9-3188-4e73-9849-5f510e265fad", Name = "安卓客户端",  AppId="appid002", AppSecret = "********" },
              new Client { id = "15da55b8-511f-402a-9d42-637cd87a6405", Name = "一号大屏", AppId = "appid003", AppSecret = "********" },
              new Client { id = "64afbfcf-62a8-40c5-9815-ad660288108f", Name = "二号大屏", AppId = "appid004", AppSecret = "********" },
              new Client { id = "db1ea02d-1031-440c-bcae-036027e96001", Name = "三号大屏", AppId = "appid005", AppSecret = "********" }

              );
        }
        // public DbSet<Entity<string>> Entities { get; set; }
        //public DbSet<VersionedEntity>  VersionedEntities { get; set; }
        // public DbSet<EWQYEntity> EWQYEntities{ get; set; }
        public DbSet<EWQYPlaceTypeEntity> EWQYPlaceTypeEntities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<CompanyVenue> CompanyVenues { get; set; }
        public DbSet<CompanyVenueType> CompanyVenueTypes { get; set; }
        public DbSet<ZbtaNews> ZbtaNews { get; set; }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Domain.DomainModel.WHY.WhyModel> WHYDetailOrganizations { get; set; }

        public DbSet<Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews> ZiBoWechatNews { get; set; }

        //路线
        public DbSet<Domain.DomainModel.SDTA.LineDetail> LineDetails { get; set; }
        public DbSet<Domain.DomainModel.SDTA.LineDetailScenic.Doc.Source> LineDetailScenics { get; set; }
        /// <summary>
        /// 城市锦囊
        /// </summary>
         public DbSet<Domain.DomainModel.SDTA.CityGuide> CityGuides { get; set; }
        public DbSet<Domain.DomainModel.SDTA.CityGuideDetail.Data> CityGuideDetails { get; set; }

        //美食
        //  public DbSet<Domain.DomainModel.SDTA.FoodDetail.Data> FoodDetails { get; set; }
        //特产
        public DbSet<Domain.DomainModel.SDTA.SpecialLocalProductDetail.Data> SpecialLocalProductDetails { get; set; }

        public DbSet<Domain.DomainModel.WHY.WHYNews> WhyNews { get; set; }
        //文化云活动
        public DbSet<Domain.DomainModel.WHY.WhyActivity> WhyActivities { get; set; }

        //抓取-分发 日志
        public DbSet< Client> Clients{ get; set; }
        public DbSet<Domain.DomainModel.DataLog.DataSource> DataSources{ get; set; }
      
        public DbSet<Domain.DomainModel.DataLog.FetchLog> FetchLogs{ get; set; }
        public DbSet<Domain.DomainModel.DataLog.DistributeLog> DistributeLogs{ get; set; }

    }
}
