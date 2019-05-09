using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseIdContent> MySongs { get; set; }
        public DbSet<DatabaseIdContent> MyAlbums { get; set; }
        public DbSet<DatabaseIdContent> MyArtists { get; set; }

        private string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
