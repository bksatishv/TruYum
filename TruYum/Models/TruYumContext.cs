﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TruYum.Models
{
    public class TruYumContext:DbContext
    {
        public TruYumContext():base("TruYumContext")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }
    }
}