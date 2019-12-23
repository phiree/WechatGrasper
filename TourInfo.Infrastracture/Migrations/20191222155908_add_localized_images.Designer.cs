﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourInfo.Infrastracture.Repository.EFCore;

namespace TourInfo.Infrastracture.Migrations
{
    [DbContext(typeof(TourInfoDbContext))]
    [Migration("20191222155908_add_localized_images")]
    partial class add_localized_images
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TourInfo.Domain.Base.Entity<string>", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Entities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity<string>");
                });

            modelBuilder.Entity("TourInfo.Domain.Base.VersionedEntity", b =>
                {
                    b.HasBaseType("TourInfo.Domain.Base.Entity<string>");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.HasDiscriminator().HasValue("VersionedEntity");
                });

            modelBuilder.Entity("TourInfo.Domain.EWQYEntity", b =>
                {
                    b.HasBaseType("TourInfo.Domain.Base.VersionedEntity");

                    b.Property<int>("PlaceType");

                    b.Property<string>("localizedPictureKeys");

                    b.Property<string>("localizedThumbnailKey");

                    b.Property<string>("pictureKeys");

                    b.Property<string>("thumbnailKey");

                    b.HasDiscriminator().HasValue("EWQYEntity");
                });

            modelBuilder.Entity("TourInfo.Domain.TourNews.ZbtaNews", b =>
                {
                    b.HasBaseType("TourInfo.Domain.Base.VersionedEntity");

                    b.Property<string>("back1");

                    b.Property<string>("checkState");

                    b.Property<string>("createUser");

                    b.Property<string>("created");

                    b.Property<string>("details");

                    b.Property<string>("image");

                    b.Property<string>("releaseTime");

                    b.Property<string>("titles");

                    b.HasDiscriminator().HasValue("ZbtaNews");
                });

            modelBuilder.Entity("TourInfo.Domain.Activity", b =>
                {
                    b.HasBaseType("TourInfo.Domain.EWQYEntity");

                    b.Property<string>("address");

                    b.Property<string>("createTime");

                    b.Property<int>("credits");

                    b.Property<string>("detail");

                    b.Property<string>("endTime");

                    b.Property<bool>("isShared");

                    b.Property<string>("name");

                    b.Property<string>("startTime");

                    b.HasDiscriminator().HasValue("Activity");
                });

            modelBuilder.Entity("TourInfo.Domain.CompanyVenue", b =>
                {
                    b.HasBaseType("TourInfo.Domain.EWQYEntity");

                    b.Property<string>("address")
                        .HasColumnName("CompanyVenue_address");

                    b.Property<string>("introduction");

                    b.Property<string>("isFavorite");

                    b.Property<string>("location");

                    b.Property<string>("name")
                        .HasColumnName("CompanyVenue_name");

                    b.Property<string>("satisfactionScore");

                    b.Property<string>("serviceNote");

                    b.Property<string>("serviceTimeEnd");

                    b.Property<string>("serviceTimeStart");

                    b.Property<string>("telNumber");

                    b.Property<string>("typeId");

                    b.HasDiscriminator().HasValue("CompanyVenue");
                });
#pragma warning restore 612, 618
        }
    }
}
