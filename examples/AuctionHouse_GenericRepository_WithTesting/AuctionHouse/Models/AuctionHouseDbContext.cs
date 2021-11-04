﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AuctionHouse.Models
{
    public partial class AuctionHouseDbContext : DbContext
    {
        public AuctionHouseDbContext()
        {
        }

        public AuctionHouseDbContext(DbContextOptions<AuctionHouseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AuctionHouseConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("Bid_Fk_Buyer");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("Bid_Fk_Item");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("Item_Fk_Seller");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
