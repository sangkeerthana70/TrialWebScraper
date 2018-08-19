﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrialWebScraper.Models;

namespace TrialWebScraper.Migrations
{
    [DbContext(typeof(TrialWebScraperContext))]
    [Migration("20180715184836_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrialWebScraper.Models.SnapShot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("SnapShotTime");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.ToTable("SnapShot");
                });

            modelBuilder.Entity("TrialWebScraper.Models.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Change");

                    b.Property<string>("Currency");

                    b.Property<decimal>("LastPrice");

                    b.Property<decimal>("MarketCap");

                    b.Property<decimal>("PercentChg");

                    b.Property<int?>("SnapShotID");

                    b.Property<string>("Symbol");

                    b.Property<decimal>("Volume");

                    b.HasKey("ID");

                    b.HasIndex("SnapShotID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("TrialWebScraper.Models.Stock", b =>
                {
                    b.HasOne("TrialWebScraper.Models.SnapShot")
                        .WithMany("Stocks")
                        .HasForeignKey("SnapShotID");
                });
#pragma warning restore 612, 618
        }
    }
}
