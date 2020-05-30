﻿
using AbstractStoreDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractStoreDatabaseImplement
{
    public class AbstractStoreDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AIVAGGI\SQLEXPRESS;Initial Catalog=AbstractShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Jewerly> Jewerlies { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductJewerly> ProductJewerlies { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
