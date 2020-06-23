﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourInfo.Infrastracture.Repository.EFCore;

namespace TourInfo.Infrastracture.Migrations
{
    [DbContext(typeof(TourInfoDbContext))]
    [Migration("20200623095948_whyactivity")]
    partial class whyactivity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("author");

                    b.Property<string>("cms_user_id");

                    b.Property<int>("collectscount");

                    b.Property<int>("commentcount");

                    b.Property<string>("commentscore");

                    b.Property<string>("content");

                    b.Property<string>("created_at");

                    b.Property<string>("description");

                    b.Property<int>("detailid");

                    b.Property<int>("featured");

                    b.Property<int>("likescount");

                    b.Property<string>("name");

                    b.Property<int>("primary_category");

                    b.Property<int>("rank");

                    b.Property<string>("slug");

                    b.Property<int>("status");

                    b.Property<string>("updated_at");

                    b.Property<int>("user_id");

                    b.Property<int>("views");

                    b.HasKey("id");

                    b.ToTable("SDTACityGuideDetail");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.LineDetail", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("bestSeason");

                    b.Property<string>("city");

                    b.Property<string>("name");

                    b.Property<string>("tags");

                    b.HasKey("id");

                    b.ToTable("SDTALineDetail");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.LineDetailScenic+Doc+Source", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("address");

                    b.Property<string>("area");

                    b.Property<string>("buyable");

                    b.Property<int>("city");

                    b.Property<int>("city_order");

                    b.Property<string>("contact");

                    b.Property<int>("date_for_order");

                    b.Property<string>("description");

                    b.Property<string>("ele_id");

                    b.Property<string>("ele_type");

                    b.Property<string>("ele_type_name");

                    b.Property<string>("ele_type_name_en");

                    b.Property<int>("level");

                    b.Property<string>("level_name");

                    b.Property<string>("location");

                    b.Property<double>("lowest_price");

                    b.Property<string>("lvl1");

                    b.Property<string>("name_cn");

                    b.Property<int>("rank");

                    b.HasKey("id");

                    b.ToTable("SDTALineDetailScenicDocSource");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Video.Video", b =>
                {
                    b.Property<int>("id");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("attachment");

                    b.Property<string>("author");

                    b.Property<string>("checkname");

                    b.Property<int>("checkstate");

                    b.Property<DateTime?>("checktime");

                    b.Property<string>("checkuser");

                    b.Property<DateTime>("createtime");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("editname");

                    b.Property<string>("edituser");

                    b.Property<string>("img");

                    b.Property<bool>("iscycle");

                    b.Property<bool>("istop");

                    b.Property<string>("jumpurl");

                    b.Property<int>("mid");

                    b.Property<int>("orderno");

                    b.Property<int>("pid");

                    b.Property<DateTime>("pubtime");

                    b.Property<string>("subtitle");

                    b.Property<string>("summary");

                    b.Property<string>("title");

                    b.Property<DateTime>("updatetime");

                    b.HasKey("id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.WHY.WHYNews", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("area2");

                    b.Property<int>("areaCheckStatus");

                    b.Property<string>("areaId");

                    b.Property<string>("author");

                    b.Property<int>("cityCheckStatus");

                    b.Property<string>("content");

                    b.Property<DateTime>("createTime");

                    b.Property<DateTime>("endTime");

                    b.Property<bool>("grabStatus");

                    b.Property<string>("informationCategoryId");

                    b.Property<int>("isTop");

                    b.Property<string>("noHtmlContent");

                    b.Property<int>("redCount");

                    b.Property<bool>("removed");

                    b.Property<int>("sort");

                    b.Property<string>("source");

                    b.Property<DateTime>("startTime");

                    b.Property<string>("title");

                    b.Property<int>("type");

                    b.Property<DateTime>("updateTime");

                    b.HasKey("id");

                    b.ToTable("WhyNews");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.WHY.WhyActivity", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("_operator");

                    b.Property<int>("accessNumber");

                    b.Property<DateTime>("actSessionSTime");

                    b.Property<string>("activityCategoryId");

                    b.Property<string>("ageTagId");

                    b.Property<string>("area");

                    b.Property<int>("areaCheckStatus");

                    b.Property<string>("areaId");

                    b.Property<int>("back");

                    b.Property<string>("cashType");

                    b.Property<int>("cityCheckStatus");

                    b.Property<int>("commentScope");

                    b.Property<int>("commentStatus");

                    b.Property<string>("content");

                    b.Property<DateTime>("createTime");

                    b.Property<string>("fPoster");

                    b.Property<bool>("grabStatus");

                    b.Property<int>("grade");

                    b.Property<int>("gradeNum");

                    b.Property<string>("hPoster");

                    b.Property<bool>("hasSession");

                    b.Property<int>("isTop");

                    b.Property<string>("keywords");

                    b.Property<int>("limit");

                    b.Property<int>("maxCount");

                    b.Property<string>("name");

                    b.Property<string>("organizationId");

                    b.Property<string>("organizationtypeId");

                    b.Property<int>("previewNumber");

                    b.Property<int>("price");

                    b.Property<int>("rate");

                    b.Property<DateTime>("recentHoldEndTime");

                    b.Property<DateTime>("recentHoldStartTime");

                    b.Property<bool>("removed");

                    b.Property<int>("reportNum");

                    b.Property<int>("reservationMode");

                    b.Property<int>("sort");

                    b.Property<int>("status");

                    b.Property<string>("summary");

                    b.Property<int>("ticketNumber");

                    b.Property<int>("type");

                    b.Property<DateTime>("updateTime");

                    b.HasKey("id");

                    b.ToTable("WhyActivities");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.WHY.WhyModel", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<int>("RapiId");

                    b.Property<string>("Version");

                    b.Property<string>("addressInfo");

                    b.Property<string>("contact");

                    b.Property<string>("name");

                    b.Property<string>("summary");

                    b.Property<string>("website");

                    b.HasKey("id");

                    b.ToTable("WHYDetailOrganizations");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<DateTime>("pubtime");

                    b.Property<string>("title");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.ToTable("ZiBoWechatNews");
                });

            modelBuilder.Entity("TourInfo.Domain.EWQYPlaceTypeEntity", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Fingerprint");

                    b.Property<int>("PlaceType");

                    b.Property<string>("Version");

                    b.HasKey("id");

                    b.ToTable("EWQYPlaceTypeEntities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EWQYPlaceTypeEntity");
                });

            modelBuilder.Entity("TourInfo.Domain.ZBTA.ZbtaNews", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("back1");

                    b.Property<string>("checkState");

                    b.Property<string>("createUser");

                    b.Property<string>("created");

                    b.Property<string>("releaseTime");

                    b.Property<string>("titles");

                    b.HasKey("id");

                    b.ToTable("ZbtaNews");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.EWQY.CompanyVenueType", b =>
                {
                    b.HasBaseType("TourInfo.Domain.EWQYPlaceTypeEntity");

                    b.Property<string>("name")
                        .HasColumnName("CompanyVenueType_name");

                    b.HasDiscriminator().HasValue("CompanyVenueType");
                });

            modelBuilder.Entity("TourInfo.Domain.EWQYEntity", b =>
                {
                    b.HasBaseType("TourInfo.Domain.EWQYPlaceTypeEntity");

                    b.HasDiscriminator().HasValue("EWQYEntity");
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

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data", b =>
                {
                    b.OwnsOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Category", "category", b1 =>
                        {
                            b1.Property<string>("Dataid");

                            b1.Property<string>("created_at");

                            b1.Property<string>("description");

                            b1.Property<int>("featured");

                            b1.Property<string>("icon");

                            b1.Property<int>("id");

                            b1.Property<int>("is_default");

                            b1.Property<string>("name");

                            b1.Property<int>("order");

                            b1.Property<int>("parent_id");

                            b1.Property<string>("slug");

                            b1.Property<int>("status");

                            b1.Property<string>("updated_at");

                            b1.Property<int>("user_id");

                            b1.HasKey("Dataid");

                            b1.ToTable("SDTACityGuideDetailCategory");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data")
                                .WithOne("category")
                                .HasForeignKey("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Category", "Dataid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Pics", "pics", b1 =>
                        {
                            b1.Property<string>("Dataid");

                            b1.Property<int>("content_id");

                            b1.Property<string>("created_at");

                            b1.Property<string>("deleted_at");

                            b1.Property<int>("id");

                            b1.Property<string>("reference");

                            b1.Property<string>("updated_at");

                            b1.HasKey("Dataid");

                            b1.ToTable("SDTACityGuideDetailPics");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data")
                                .WithOne("pics")
                                .HasForeignKey("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Pics", "Dataid")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsMany("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Pics+Image", "images", b2 =>
                                {
                                    b2.Property<string>("GuideId");

                                    b2.Property<string>("description");

                                    b2.HasKey("GuideId", "description");

                                    b2.ToTable("SDTACityGuideDetailPicImage");

                                    b2.HasOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Pics")
                                        .WithMany("images")
                                        .HasForeignKey("GuideId")
                                        .OnDelete(DeleteBehavior.Cascade);

                                    b2.OwnsOne("TourInfo.Domain.Base.ImageUrl", "img", b3 =>
                                        {
                                            b3.Property<string>("ImageGuideId");

                                            b3.Property<string>("Imagedescription");

                                            b3.Property<string>("LocalizedUrl");

                                            b3.Property<string>("OriginalUrl");

                                            b3.HasKey("ImageGuideId", "Imagedescription");

                                            b3.ToTable("SDTACityGuideDetailPicImage");

                                            b3.HasOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data+Pics+Image")
                                                .WithOne("img")
                                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "ImageGuideId", "Imagedescription")
                                                .OnDelete(DeleteBehavior.Cascade);
                                        });
                                });
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "image", b1 =>
                        {
                            b1.Property<string>("Dataid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("Dataid");

                            b1.ToTable("SDTACityGuideDetail");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.CityGuideDetail+Data")
                                .WithOne("image")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "Dataid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.LineDetail", b =>
                {
                    b.OwnsMany("TourInfo.Domain.DomainModel.SDTA.LineDetail+Day", "days", b1 =>
                        {
                            b1.Property<string>("LineId");

                            b1.Property<string>("name");

                            b1.Property<string>("desc");

                            b1.Property<string>("foodDesc");

                            b1.Property<string>("hotelDesc");

                            b1.HasKey("LineId", "name");

                            b1.ToTable("SDTALineDetailDay");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.LineDetail")
                                .WithMany("days")
                                .HasForeignKey("LineId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsMany("TourInfo.Domain.DomainModel.SDTA.LineDetail+Day+Place", "place", b2 =>
                                {
                                    b2.Property<string>("LineId");

                                    b2.Property<string>("name");

                                    b2.Property<string>("id");

                                    b2.Property<string>("tag");

                                    b2.Property<string>("time");

                                    b2.Property<string>("type");

                                    b2.HasKey("LineId", "name", "id");

                                    b2.ToTable("SDTALineDetailDayPlace");

                                    b2.HasOne("TourInfo.Domain.DomainModel.SDTA.LineDetail+Day")
                                        .WithMany("place")
                                        .HasForeignKey("LineId", "name")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "thumb", b1 =>
                        {
                            b1.Property<string>("LineDetailid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("LineDetailid");

                            b1.ToTable("SDTALineDetail");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.LineDetail")
                                .WithOne("thumb")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "LineDetailid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.LineDetailScenic+Doc+Source", b =>
                {
                    b.OwnsMany("TourInfo.Domain.DomainModel.SDTA.LineDetailScenic+Doc+Source+Eletype", "eletype", b1 =>
                        {
                            b1.Property<string>("sourceid");

                            b1.Property<string>("id");

                            b1.Property<string>("ancestors");

                            b1.Property<int>("level");

                            b1.Property<string>("value");

                            b1.HasKey("sourceid", "id");

                            b1.ToTable("SDTALineDetailScenicDocSourceEletype");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.LineDetailScenic+Doc+Source")
                                .WithMany("eletype")
                                .HasForeignKey("sourceid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "default_photo", b1 =>
                        {
                            b1.Property<string>("Sourceid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("Sourceid");

                            b1.ToTable("SDTALineDetailScenicDocSource");

                            b1.HasOne("TourInfo.Domain.DomainModel.SDTA.LineDetailScenic+Doc+Source")
                                .WithOne("default_photo")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "Sourceid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.WHY.WHYNews", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "imagepath", b1 =>
                        {
                            b1.Property<string>("WHYNewsid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("WHYNewsid");

                            b1.ToTable("WhyNews");

                            b1.HasOne("TourInfo.Domain.DomainModel.WHY.WHYNews")
                                .WithOne("imagepath")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "WHYNewsid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.WHY.WhyModel", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "hposter", b1 =>
                        {
                            b1.Property<string>("WhyModelid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("WhyModelid");

                            b1.ToTable("WHYDetailOrganizations");

                            b1.HasOne("TourInfo.Domain.DomainModel.WHY.WhyModel")
                                .WithOne("hposter")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "WhyModelid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "location", b1 =>
                        {
                            b1.Property<string>("WhyModelid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("WhyModelid");

                            b1.ToTable("WHYDetailOrganizations");

                            b1.HasOne("TourInfo.Domain.DomainModel.WHY.WhyModel")
                                .WithOne("location")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "WhyModelid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "img", b1 =>
                        {
                            b1.Property<string>("ZiBoWechatNewsid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("ZiBoWechatNewsid");

                            b1.ToTable("ZiBoWechatNews");

                            b1.HasOne("TourInfo.Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews")
                                .WithOne("img")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "ZiBoWechatNewsid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrlsInText", "content", b1 =>
                        {
                            b1.Property<string>("ZiBoWechatNewsid");

                            b1.Property<string>("ImageBaseUrl");

                            b1.Property<string>("ImageLocalizedText");

                            b1.Property<string>("OriginaText");

                            b1.HasKey("ZiBoWechatNewsid");

                            b1.ToTable("ZiBoWechatNews");

                            b1.HasOne("TourInfo.Domain.DomainModel.ZiBoWechatNews.ZiBoWechatNews")
                                .WithOne("content")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrlsInText", "ZiBoWechatNewsid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.ZBTA.ZbtaNews", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "image", b1 =>
                        {
                            b1.Property<string>("ZbtaNewsid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("ZbtaNewsid");

                            b1.ToTable("ZbtaNews");

                            b1.HasOne("TourInfo.Domain.ZBTA.ZbtaNews")
                                .WithOne("image")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "ZbtaNewsid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrlsInText", "details", b1 =>
                        {
                            b1.Property<string>("ZbtaNewsid");

                            b1.Property<string>("ImageBaseUrl");

                            b1.Property<string>("ImageLocalizedText");

                            b1.Property<string>("OriginaText");

                            b1.HasKey("ZbtaNewsid");

                            b1.ToTable("ZbtaNews");

                            b1.HasOne("TourInfo.Domain.ZBTA.ZbtaNews")
                                .WithOne("details")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrlsInText", "ZbtaNewsid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.EWQYEntity", b =>
                {
                    b.OwnsMany("TourInfo.Domain.Base.ImageUrl", "pictureKeys", b1 =>
                        {
                            b1.Property<string>("OriginalUrl");

                            b1.Property<string>("id");

                            b1.Property<string>("LocalizedUrl");

                            b1.HasKey("OriginalUrl", "id");

                            b1.HasIndex("id");

                            b1.ToTable("EWQYPlaceTypeEntities_pictureKeys");

                            b1.HasOne("TourInfo.Domain.EWQYEntity")
                                .WithMany("pictureKeys")
                                .HasForeignKey("id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "thumbnailKey", b1 =>
                        {
                            b1.Property<string>("EWQYEntityid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("EWQYEntityid");

                            b1.ToTable("EWQYPlaceTypeEntities");

                            b1.HasOne("TourInfo.Domain.EWQYEntity")
                                .WithOne("thumbnailKey")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "EWQYEntityid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.CompanyVenue", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.Location", "location", b1 =>
                        {
                            b1.Property<string>("CompanyVenueid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("CompanyVenueid");

                            b1.ToTable("CompanyVanueLocations");

                            b1.HasOne("TourInfo.Domain.CompanyVenue")
                                .WithOne("location")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "CompanyVenueid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
