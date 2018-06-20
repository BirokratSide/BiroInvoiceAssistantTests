using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

using Common.utils;

namespace Tests.Models
{
    public partial class biro16010264Context : DbContext
    {
        IConfiguration Configuration;
        string ConnectionString;

        public biro16010264Context()
        {
            LoadFromSettings();
        }

        public biro16010264Context(DbContextOptions<biro16010264Context> options)
            : base(options)
        {
            LoadFromSettings();
        }

        public void LoadFromSettings() {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            // Database init
            SBAzureSettings config = new SBAzureSettings(
                Configuration.GetValue<string>("Database:Username"),
                Configuration.GetValue<string>("Database:Password"),
                Configuration.GetValue<string>("Database:Address"),
                Configuration.GetValue<string>("Database:InitialCatalog"),
                Configuration.GetValue<bool>("Database:IntegratedSecurity"),
                Configuration.GetValue<string>("Database:Database"));

            if (!Configuration.GetValue<bool>("Database:IntegratedSecurity"))
            {
                ConnectionString = String.Format("Server={0};Database={1};Trusted_Connection=false;User={2};Password={3}",
                                                 Configuration.GetValue<string>("Database:Address"),
                                                 Configuration.GetValue<string>("Database:Database"),
                                                 Configuration.GetValue<string>("Database:Username"),
                                                 Configuration.GetValue<string>("Database:Password"));
            }
            else
            {
                ConnectionString = String.Format("Server={0};Database={1};Trusted_Connection=true",
                                                 Configuration.GetValue<string>("Database:Address"),
                                                 Configuration.GetValue<string>("Database:Database"));
            }
        }

        public virtual DbSet<PostnaKnjiga> PostnaKnjiga { get; set; }
        public virtual DbSet<Slike> Slike { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostnaKnjiga>(entity =>
            {
                entity.HasKey(e => e.SyncId);

                entity.HasIndex(e => e.SyncId)
                    .HasName("ix_PostnaKnjiga_sync")
                    .IsUnique();

                entity.Property(e => e.SyncId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Datum1).HasColumnType("datetime");

                entity.Property(e => e.Datum2).HasColumnType("datetime");

                entity.Property(e => e.DatumPotrditve).HasColumnType("datetime");

                entity.Property(e => e.DatumVnosa).HasMaxLength(12);

                entity.Property(e => e.ESlogguid)
                    .HasColumnName("eSLOGGUID")
                    .HasMaxLength(36);

                entity.Property(e => e.ImePartnerja).HasMaxLength(60);

                entity.Property(e => e.InternaStevilka).HasMaxLength(25);

                entity.Property(e => e.Komentar).HasMaxLength(255);

                entity.Property(e => e.Likvidacija).HasMaxLength(100);

                entity.Property(e => e.Mpo)
                    .HasColumnName("MPO")
                    .HasMaxLength(5);

                entity.Property(e => e.Pe)
                    .HasColumnName("PE")
                    .HasMaxLength(25);

                entity.Property(e => e.RecNo).ValueGeneratedOnAdd();

                entity.Property(e => e.SifraPartnerja).HasMaxLength(10);

                entity.Property(e => e.SlikeOznaka).HasMaxLength(20);

                entity.Property(e => e.SlikeVrsta).HasMaxLength(20);

                entity.Property(e => e.Sporocilo).HasMaxLength(50);

                entity.Property(e => e.Tip).HasMaxLength(10);

                entity.Property(e => e.TipPoste).HasMaxLength(35);

                entity.Property(e => e.Vnasalec).HasMaxLength(50);

                entity.Property(e => e.VrstaPoste).HasMaxLength(40);

                entity.Property(e => e.YearCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Zadeva).HasMaxLength(150);

                entity.Property(e => e.Zaposlen).HasMaxLength(50);

                entity.Property(e => e.Zzi)
                    .HasColumnName("ZZI")
                    .HasMaxLength(50);

                entity.Property(e => e.Zzi1).HasColumnName("ZZI1");

                entity.Property(e => e.Zzi2).HasColumnName("ZZI2");
            });

            modelBuilder.Entity<Slike>(entity =>
            {
                entity.HasKey(e => e.SyncId);

                entity.HasIndex(e => e.SyncId)
                    .HasName("ix_Slike_sync")
                    .IsUnique();

                entity.Property(e => e.SyncId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DatumVnosa).HasMaxLength(12);

                entity.Property(e => e.Komentar).HasColumnType("ntext");

                entity.Property(e => e.Oznaka).HasMaxLength(50);

                entity.Property(e => e.RecNo).ValueGeneratedOnAdd();

                entity.Property(e => e.Vnasalec).HasMaxLength(50);

                entity.Property(e => e.Vrsta).HasMaxLength(50);

                entity.Property(e => e.Vsebina).HasColumnType("ntext");

                entity.Property(e => e.YearCode)
                    .IsRequired()
                    .HasMaxLength(5);
            });
        }
    }
}
