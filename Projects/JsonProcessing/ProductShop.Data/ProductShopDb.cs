using System.Configuration;
using ProductShop.Models;
using Shop.Data;


namespace ProductShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class ProductShopDb : DbContext
    {
        
        public ProductShopDb()
            : base("name=ProductShopDb")
        {
            Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends).WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer)
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold)
                .WithRequired(p => p.Seller)
                .Map(m =>
                {
                    m.MapKey("SellerId");
                });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }
   
    }

}