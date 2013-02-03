﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace A_ust.Models
{
    public class AustContext : DbContext
    {
        public AustContext()
            : base("DefaultConnection")
        {
        }
        public AustContext(string connection)
            : base(connection)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Assumptions> Assumptions { get; set; }
        public DbSet<UserStories> UserStories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}