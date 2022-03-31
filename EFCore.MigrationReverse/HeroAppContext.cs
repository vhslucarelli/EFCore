using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.MigrationReverse
{
    public partial class HeroAppContext : DbContext
    {
        public HeroAppContext()
        {
        }

        public HeroAppContext(DbContextOptions<HeroAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armas> Armas { get; set; }
        public virtual DbSet<Batalhas> Batalhas { get; set; }
        public virtual DbSet<Herois> Herois { get; set; }
        public virtual DbSet<HeroisBatalhas> HeroisBatalhas { get; set; }
        public virtual DbSet<IdentidadiesSecretas> IdentidadiesSecretas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroApp;Data Source=I5M520");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Armas>(entity =>
            {
                entity.HasIndex(e => e.HeroiId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.Armas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<HeroisBatalhas>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });

                entity.HasIndex(e => new { e.HeroiBatalhaBatalhaId, e.HeroiBatalhaHeroiId });

                entity.HasOne(d => d.Batalha)
                    .WithMany(p => p.HeroisBatalhas)
                    .HasForeignKey(d => d.BatalhaId);

                entity.HasOne(d => d.HeroiBatalha)
                    .WithMany(p => p.InverseHeroiBatalha)
                    .HasForeignKey(d => new { d.HeroiBatalhaBatalhaId, d.HeroiBatalhaHeroiId });
            });

            modelBuilder.Entity<IdentidadiesSecretas>(entity =>
            {
                entity.HasIndex(e => e.HeroiId)
                    .IsUnique();

                entity.HasOne(d => d.Heroi)
                    .WithOne(p => p.IdentidadiesSecretas)
                    .HasForeignKey<IdentidadiesSecretas>(d => d.HeroiId);
            });
        }
    }
}
