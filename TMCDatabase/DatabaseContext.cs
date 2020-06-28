using TMCDatabase.Model;
using TMCDatabase.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TMCDatabase.Tools;

namespace TMCDatabase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Scenegroup> Scenegroups { get; set; }
        public DbSet<C_Scenegroup_Composer> C_Scenegroup_Composers{ get; set; }
        public DbSet<Tracker> Trackers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new Configurator("Private.config");
            optionsBuilder.UseMySQL(config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Set Unique keys
            modelBuilder.Entity<Style>().HasIndex(x => x.Style_id).IsUnique();
            modelBuilder.Entity<Composer>().HasIndex(x => x.Composer_id).IsUnique();
            modelBuilder.Entity<Scenegroup>().HasIndex(x => x.Scenegroup_id).IsUnique();
            modelBuilder.Entity<C_Scenegroup_Composer>().HasIndex(x => x.Scenegroup_composer_id).IsUnique();
            modelBuilder.Entity<Tracker>().HasIndex(x => x.Tracker_id).IsUnique();

            //Set default values
            modelBuilder.Entity<Track>().Property(x => x.Date_created).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Track>().Property(x => x.Date_modified).HasDefaultValue(DateTime.Now);
        }
    }
}
