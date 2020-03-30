﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourInfo.Infrastracture.Repository.EFCore;

namespace TourInfo.Infrastracture.Migrations
{
    [DbContext(typeof(TourInfoDbContext))]
    partial class TourInfoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Projectinfo", b =>
                {
                    b.Property<int>("pid");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("appid");

                    b.Property<string>("areacode");

                    b.Property<DateTime>("crtdate");

                    b.Property<string>("defaultlogo");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("desc");

                    b.Property<string>("detailfoot");

                    b.Property<string>("detailhead");

                    b.Property<string>("homeurl");

                    b.Property<int>("id");

                    b.Property<bool>("iscomment");

                    b.Property<string>("pname");

                    b.Property<int>("subpid");

                    b.Property<string>("topjumpurl");

                    b.Property<string>("toppicurl");

                    b.Property<string>("topresourceurl");

                    b.Property<string>("topvideourl");

                    b.Property<DateTime>("updatetime");

                    b.Property<string>("wapbgimg");

                    b.HasKey("pid");

                    b.ToTable("Projectinfo");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubinfounit", b =>
                {
                    b.Property<int>("unitid");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("address");

                    b.Property<string>("areacode");

                    b.Property<string>("areaname");

                    b.Property<int>("bedcount");

                    b.Property<string>("booktel");

                    b.Property<int>("boxcount");

                    b.Property<string>("businesslicense");

                    b.Property<string>("businesstime");

                    b.Property<int>("commentnum");

                    b.Property<string>("complainttel");

                    b.Property<DateTime>("crtdate");

                    b.Property<string>("decorationtime");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("desc");

                    b.Property<string>("detailurl");

                    b.Property<string>("environmentrating");

                    b.Property<string>("facilityrating");

                    b.Property<string>("favouredpolicy");

                    b.Property<string>("fax");

                    b.Property<string>("hygienerating");

                    b.Property<int>("id");

                    b.Property<int>("id5a");

                    b.Property<int>("imgnum");

                    b.Property<string>("infotel");

                    b.Property<string>("innertrafic");

                    b.Property<int>("level");

                    b.Property<string>("licenseno");

                    b.Property<string>("logopic");

                    b.Property<string>("mainline");

                    b.Property<string>("manager");

                    b.Property<string>("managertel");

                    b.Property<int>("maxcapacity");

                    b.Property<string>("memo");

                    b.Property<string>("name5a");

                    b.Property<string>("opentime");

                    b.Property<float>("orderno");

                    b.Property<string>("overallrating");

                    b.Property<float>("personprice");

                    b.Property<int>("pid");

                    b.Property<string>("poitypename");

                    b.Property<string>("poitypetag");

                    b.Property<string>("postcode");

                    b.Property<string>("pricedesc");

                    b.Property<string>("publictrafic");

                    b.Property<string>("reservefield1");

                    b.Property<string>("reservefield2");

                    b.Property<string>("reservefield3");

                    b.Property<string>("reservefield4");

                    b.Property<string>("reservefield5");

                    b.Property<string>("reservefield6");

                    b.Property<string>("reservefield7");

                    b.Property<string>("reservefield8");

                    b.Property<string>("reservefield9");

                    b.Property<int>("roomcount");

                    b.Property<float>("roomprice");

                    b.Property<int>("seatcount");

                    b.Property<string>("servicerating");

                    b.Property<string>("shortname");

                    b.Property<int>("sourcefrom");

                    b.Property<int>("state");

                    b.Property<string>("telephone");

                    b.Property<float>("ticketprice");

                    b.Property<string>("tips");

                    b.Property<int>("typeid");

                    b.Property<string>("unitname");

                    b.Property<DateTime>("updatetime");

                    b.Property<string>("url");

                    b.Property<string>("url360");

                    b.Property<string>("zonecode");

                    b.HasKey("unitid");

                    b.ToTable("Pubinfounit");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubinfounitchild", b =>
                {
                    b.Property<int>("childid");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<string>("childname");

                    b.Property<DateTime>("crtdate");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("desc");

                    b.Property<string>("guidetext");

                    b.Property<string>("guidevoice");

                    b.Property<int>("id");

                    b.Property<bool>("isshow");

                    b.Property<string>("memo");

                    b.Property<float>("orderno");

                    b.Property<int>("pid");

                    b.Property<string>("price");

                    b.Property<int>("unitid");

                    b.Property<DateTime>("updatetime");

                    b.HasKey("childid");

                    b.HasIndex("childid");

                    b.ToTable("Pubinfounitchild");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubmediainfo", b =>
                {
                    b.Property<int>("mediaid");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<DateTime>("crtdate");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("desc");

                    b.Property<int>("id");

                    b.Property<bool>("isshow");

                    b.Property<string>("medianame");

                    b.Property<int>("mediatypeid");

                    b.Property<string>("memo");

                    b.Property<float>("orderno");

                    b.Property<int>("pid");

                    b.Property<bool>("topshow");

                    b.Property<int>("typepicid");

                    b.Property<int>("unitid");

                    b.Property<DateTime>("updatetime");

                    b.Property<string>("videourl");

                    b.HasKey("mediaid");

                    b.ToTable("Pubmediainfo");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubunittag", b =>
                {
                    b.Property<int>("unittagid");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<int>("id");

                    b.Property<int>("pid");

                    b.Property<int>("tagid");

                    b.Property<string>("tagvalue");

                    b.Property<int>("unitid");

                    b.HasKey("unittagid");

                    b.ToTable("Pubunittag");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Typefield", b =>
                {
                    b.Property<int>("id");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<DateTime>("crtdate");

                    b.Property<string>("customname");

                    b.Property<bool>("deleteflag");

                    b.Property<int>("displayorder");

                    b.Property<string>("fieldname");

                    b.Property<string>("fieldtype");

                    b.Property<string>("groupname");

                    b.Property<bool>("isdisplay");

                    b.Property<bool>("isedit");

                    b.Property<float>("orderno");

                    b.Property<int>("pid");

                    b.Property<int>("typeid");

                    b.Property<DateTime>("updatetime");

                    b.HasKey("id");

                    b.ToTable("Typefield");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Typeinfo", b =>
                {
                    b.Property<int>("typeid");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<DateTime>("crtdate");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("editurl");

                    b.Property<bool>("existschild");

                    b.Property<bool>("existsroom");

                    b.Property<bool>("existsscenic");

                    b.Property<int>("id");

                    b.Property<bool>("isshow");

                    b.Property<string>("mobilememo");

                    b.Property<float>("orderno");

                    b.Property<int>("pid");

                    b.Property<int>("ptypeid");

                    b.Property<string>("showurl");

                    b.Property<string>("typename");

                    b.Property<DateTime>("updatetime");

                    b.HasKey("typeid");

                    b.ToTable("Typeinfo");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Typepic", b =>
                {
                    b.Property<int>("id");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<DateTime>("crtdate");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("groupname");

                    b.Property<int>("mediatypeid");

                    b.Property<string>("mediatypename");

                    b.Property<float>("orderno");

                    b.Property<int>("pid");

                    b.Property<int>("typeid");

                    b.Property<DateTime>("updatetime");

                    b.HasKey("id");

                    b.ToTable("Typepic");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Typetag", b =>
                {
                    b.Property<int>("id");

                    b.Property<string>("Fingerprint");

                    b.Property<string>("Version");

                    b.Property<DateTime>("crtdate");

                    b.Property<bool>("deleteflag");

                    b.Property<string>("groupname");

                    b.Property<float>("orderno");

                    b.Property<int>("pid");

                    b.Property<string>("tagname");

                    b.Property<int>("typeid");

                    b.Property<DateTime>("updatetime");

                    b.HasKey("id");

                    b.ToTable("Typetag");
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.SDTA.LineDetail", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bestSeason");

                    b.Property<string>("city");

                    b.Property<string>("name");

                    b.Property<string>("tags");

                    b.Property<string>("thumb");

                    b.HasKey("id");

                    b.ToTable("SDTALineDetail");
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

                    b.Property<string>("img");

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

            modelBuilder.Entity("TourInfo.Domain.TourNews.ZbtaNews", b =>
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

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubinfounit", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "flagpic", b1 =>
                        {
                            b1.Property<int?>("Pubinfounitid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("Pubinfounitid");

                            b1.ToTable("Pubinfounit");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounit")
                                .WithOne("flagpic")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "Pubinfounitid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "gps", b1 =>
                        {
                            b1.Property<int>("Pubinfounitunitid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("Pubinfounitunitid");

                            b1.ToTable("Pubinfounit");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounit")
                                .WithOne("gps")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "Pubinfounitunitid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "gpsbd", b1 =>
                        {
                            b1.Property<int>("Pubinfounitunitid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("Pubinfounitunitid");

                            b1.ToTable("Pubinfounit");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounit")
                                .WithOne("gpsbd")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "Pubinfounitunitid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "gpsgd", b1 =>
                        {
                            b1.Property<int>("Pubinfounitunitid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("Pubinfounitunitid");

                            b1.ToTable("Pubinfounit");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounit")
                                .WithOne("gpsgd")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "Pubinfounitunitid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubinfounitchild", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "flagurl", b1 =>
                        {
                            b1.Property<int>("Pubinfounitchildchildid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("Pubinfounitchildchildid");

                            b1.ToTable("Pubinfounitchild");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounitchild")
                                .WithOne("flagurl")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "Pubinfounitchildchildid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "gps", b1 =>
                        {
                            b1.Property<int>("Pubinfounitchildchildid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("Pubinfounitchildchildid");

                            b1.ToTable("Pubinfounitchild");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounitchild")
                                .WithOne("gps")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "Pubinfounitchildchildid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "gpsbd", b1 =>
                        {
                            b1.Property<int>("Pubinfounitchildchildid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("Pubinfounitchildchildid");

                            b1.ToTable("Pubinfounitchild");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounitchild")
                                .WithOne("gpsbd")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "Pubinfounitchildchildid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.Location", "gpsgd", b1 =>
                        {
                            b1.Property<int>("Pubinfounitchildchildid");

                            b1.Property<double>("Latitude");

                            b1.Property<double>("Longitude");

                            b1.HasKey("Pubinfounitchildchildid");

                            b1.ToTable("Pubinfounitchild");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubinfounitchild")
                                .WithOne("gpsgd")
                                .HasForeignKey("TourInfo.Domain.Base.Location", "Pubinfounitchildchildid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Pubmediainfo", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "mediaurl", b1 =>
                        {
                            b1.Property<int?>("Pubmediainfoid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("Pubmediainfoid");

                            b1.ToTable("Pubmediainfo");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Pubmediainfo")
                                .WithOne("mediaurl")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "Pubmediainfoid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TourInfo.Domain.DomainModel.Rapi.Typeinfo", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "wapshowimg", b1 =>
                        {
                            b1.Property<int?>("Typeinfoid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("Typeinfoid");

                            b1.ToTable("Typeinfo");

                            b1.HasOne("TourInfo.Domain.DomainModel.Rapi.Typeinfo")
                                .WithOne("wapshowimg")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "Typeinfoid")
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

            modelBuilder.Entity("TourInfo.Domain.TourNews.ZbtaNews", b =>
                {
                    b.OwnsOne("TourInfo.Domain.Base.ImageUrlsInText", "details", b1 =>
                        {
                            b1.Property<string>("ZbtaNewsid");

                            b1.Property<string>("ImageBaseUrl");

                            b1.Property<string>("ImageLocalizedText");

                            b1.Property<string>("OriginaText");

                            b1.HasKey("ZbtaNewsid");

                            b1.ToTable("ZbtaNews");

                            b1.HasOne("TourInfo.Domain.TourNews.ZbtaNews")
                                .WithOne("details")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrlsInText", "ZbtaNewsid")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("TourInfo.Domain.Base.ImageUrl", "image", b1 =>
                        {
                            b1.Property<string>("ZbtaNewsid");

                            b1.Property<string>("LocalizedUrl");

                            b1.Property<string>("OriginalUrl");

                            b1.HasKey("ZbtaNewsid");

                            b1.ToTable("ZbtaNews");

                            b1.HasOne("TourInfo.Domain.TourNews.ZbtaNews")
                                .WithOne("image")
                                .HasForeignKey("TourInfo.Domain.Base.ImageUrl", "ZbtaNewsid")
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
