﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SeaBreeze.Domain;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230512062948_UpdateRealState")]
    partial class UpdateRealState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FeatureRealEstate", b =>
                {
                    b.Property<int>("RealEstateFeaturesId")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstatesId")
                        .HasColumnType("integer");

                    b.HasKey("RealEstateFeaturesId", "RealEstatesId");

                    b.HasIndex("RealEstatesId");

                    b.ToTable("FeatureRealEstate");
                });

            modelBuilder.Entity("HotelEssentialsRealEstate", b =>
                {
                    b.Property<int>("EssentialsId")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstatesId")
                        .HasColumnType("integer");

                    b.HasKey("EssentialsId", "RealEstatesId");

                    b.HasIndex("RealEstatesId");

                    b.ToTable("HotelEssentialsRealEstate");
                });

            modelBuilder.Entity("HotelHotelEssentials", b =>
                {
                    b.Property<int>("EssentialsId")
                        .HasColumnType("integer");

                    b.Property<int>("HotelsId")
                        .HasColumnType("integer");

                    b.HasKey("EssentialsId", "HotelsId");

                    b.HasIndex("HotelsId");

                    b.ToTable("HotelHotelEssentials");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelEssentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HotelEssentials");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelEssentialTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelEssentialsId")
                        .HasColumnType("integer");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelEssentialsId");

                    b.ToTable("HotelEssentialTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelImages");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelReservation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("BuyTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("HotelReservations");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Desciription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RealEstateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.ToTable("RealEstateDetails");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.FeatureTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FeatureTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RealEstateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.ToTable("RealEstateGalleries");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.RealEstateTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Desciription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RealEstateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateId");

                    b.ToTable("RealEstateTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Settings.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Stories.Stories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BannerImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("End")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("IticketUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Stories.StoriesTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LangCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StoriesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StoriesId");

                    b.ToTable("StoriesTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Tickets.BeachClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Banner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BeachClubInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EnsuranceInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PremiumTicketInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BeachClubs");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Tickets.BeachClubOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("BeachClubOrders");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Tickets.BeachClubTicket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BeachClubOrderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FIN")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsInsured")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRoseBar")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UsedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BeachClubOrderId");

                    b.ToTable("BeachClubTickets");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Users.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FIN")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsResident")
                        .HasColumnType("boolean");

                    b.Property<string>("Lang")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Users.ResidentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HouseNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RealEstate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ResidentInfos");
                });

            modelBuilder.Entity("FeatureRealEstate", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.RealEsstates.Feature", null)
                        .WithMany()
                        .HasForeignKey("RealEstateFeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", null)
                        .WithMany()
                        .HasForeignKey("RealEstatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelEssentialsRealEstate", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.HotelEssentials", null)
                        .WithMany()
                        .HasForeignKey("EssentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", null)
                        .WithMany()
                        .HasForeignKey("RealEstatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelHotelEssentials", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.HotelEssentials", null)
                        .WithMany()
                        .HasForeignKey("EssentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaBreeze.Domain.Entity.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Users.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelEssentialTranslate", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.HotelEssentials", null)
                        .WithMany("Transaltes")
                        .HasForeignKey("HotelEssentialsId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelImages", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.Hotel", null)
                        .WithMany("HotelImages")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelReservation", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaBreeze.Domain.Entity.Users.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelTranslate", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Hotels.Hotel", null)
                        .WithMany("HotelTranslates")
                        .HasForeignKey("HotelId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.Detail", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", null)
                        .WithMany("RealEstateDetails")
                        .HasForeignKey("RealEstateId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.Gallery", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", null)
                        .WithMany("Galleries")
                        .HasForeignKey("RealEstateId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.RealEstateTranslate", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", null)
                        .WithMany("RealEstateTranslates")
                        .HasForeignKey("RealEstateId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Stories.StoriesTranslate", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Stories.Stories", null)
                        .WithMany("StoriesTranslates")
                        .HasForeignKey("StoriesId");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Tickets.BeachClubOrder", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Users.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Tickets.BeachClubTicket", b =>
                {
                    b.HasOne("SeaBreeze.Domain.Entity.Tickets.BeachClubOrder", "BeachClubOrder")
                        .WithMany("Tickets")
                        .HasForeignKey("BeachClubOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeachClubOrder");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.Hotel", b =>
                {
                    b.Navigation("HotelImages");

                    b.Navigation("HotelTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Hotels.HotelEssentials", b =>
                {
                    b.Navigation("Transaltes");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.RealEsstates.RealEstate", b =>
                {
                    b.Navigation("Galleries");

                    b.Navigation("RealEstateDetails");

                    b.Navigation("RealEstateTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Stories.Stories", b =>
                {
                    b.Navigation("StoriesTranslates");
                });

            modelBuilder.Entity("SeaBreeze.Domain.Entity.Tickets.BeachClubOrder", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
