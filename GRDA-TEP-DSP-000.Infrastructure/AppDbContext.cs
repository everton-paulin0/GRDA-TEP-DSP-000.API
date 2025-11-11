using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using GRDA_TEP_DSP_000.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GRDA_TEP_DSP_000.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Palestra> Palestra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Palestra>()
                .Property(p => p.SessionTime)
                .HasConversion<string>(); // Salva como texto

            base.OnModelCreating(modelBuilder);
        }
    }
}
