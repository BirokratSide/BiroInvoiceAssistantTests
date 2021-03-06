﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;

using Common.utils;
using Microsoft.Extensions.Configuration;

namespace Tests.birotest
{
    public partial class BiroInvoiceAssistantTestingOnlyContext : DbContext
    {
        IConfiguration Configuration;
        string ConnectionString;

        public BiroInvoiceAssistantTestingOnlyContext()
        {
            LoadFromSettings();
        }

        public BiroInvoiceAssistantTestingOnlyContext(DbContextOptions<BiroInvoiceAssistantTestingOnlyContext> options)
            : base(options)
        {
            LoadFromSettings();
        }
        public void LoadFromSettings()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            // Database init
            SBAzureSettings config = new SBAzureSettings(
                Configuration.GetValue<string>("DatabaseConnection:Username"),
                Configuration.GetValue<string>("DatabaseConnection:Password"),
                Configuration.GetValue<string>("DatabaseConnection:Address"),
                Configuration.GetValue<string>("DatabaseConnection:InitialCatalog"),
                Configuration.GetValue<bool>("DatabaseConnection:IntegratedSecurity"),
                Configuration.GetValue<string>("DatabaseConnection:Database"));

            if (!Configuration.GetValue<bool>("DatabaseConnection:IntegratedSecurity"))
            {
                ConnectionString = String.Format("Server={0};Database={1};Trusted_Connection=false;User={2};Password={3}",
                                                 Configuration.GetValue<string>("DatabaseConnection:Address"),
                                                 "BiroInvoiceAssistantTestingOnly",
                                                 Configuration.GetValue<string>("DatabaseConnection:Username"),
                                                 Configuration.GetValue<string>("DatabaseConnection:Password"));
            }
            else
            {
                ConnectionString = String.Format("Server={0};Database={1};Trusted_Connection=true",
                                                 Configuration.GetValue<string>("DatabaseConnection:Address"),
                                                 "BiroInvoiceAssistantTestingOnly");
            }
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public virtual DbSet<CrmstrankeOpcije> CrmstrankeOpcije { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmstrankeOpcije>(entity =>
            {
                entity.ToTable("CRMStrankeOpcije");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aplikacija)
                    .IsRequired()
                    .HasColumnName("aplikacija")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Opcija)
                    .IsRequired()
                    .HasColumnName("opcija")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasColumnName("sifra")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Vrednost)
                    .IsRequired()
                    .HasColumnName("vrednost")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DavcnaStevilka)
                    .IsRequired()
                    .HasColumnName("davcnaStevilka")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasColumnName("sifra")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
