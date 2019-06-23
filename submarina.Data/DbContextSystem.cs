using Microsoft.EntityFrameworkCore;
using submarina.Data.Mapping;
using submarina.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace submarina.Data
{
    public class DbContextSystem : DbContext
    {
        public DbSet<Detector> Detectores { get; set; }

        public DbContextSystem(DbContextOptions<DbContextSystem> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DetectorMap());
        }
    }
}
