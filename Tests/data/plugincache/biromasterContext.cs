using System;
using System.IO;
using Common.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Tests.data.plugincache
{
    public partial class biromasterContext : DbContext
    {

        

        public biromasterContext()
        {
        }

        public biromasterContext(DbContextOptions<biromasterContext> options)
            : base(options)
        {
        }

        IConfiguration Configuration;
        string ConnectionString;
        public virtual DbSet<PluginCache> PluginCache { get; set; }

        public void LoadFromSettings()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();
            
            if (!Configuration.GetValue<bool>("Database:IntegratedSecurity"))
            {
                ConnectionString = String.Format("Server={0};Database={1};Trusted_Connection=false;User={2};Password={3}",
                                                 Configuration.GetValue<string>("Database:Address"),
                                                 "biromaster",
                                                 Configuration.GetValue<string>("Database:Username"),
                                                 Configuration.GetValue<string>("Database:Password"));
            }
            else
            {
                ConnectionString = String.Format("Server={0};Database={1};Trusted_Connection=true",
                                                 Configuration.GetValue<string>("Database:Address"),
                                                 "biromaster");
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PluginCache>(entity =>
            {
                entity.ToTable("plugin_cache");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companyyear)
                    .IsRequired()
                    .HasColumnName("companyyear")
                    .HasMaxLength(10);

                entity.Property(e => e.Datumvnosa)
                    .HasColumnName("datumvnosa")
                    .HasMaxLength(250);

                entity.Property(e => e.Davcnastevilka)
                    .IsRequired()
                    .HasColumnName("davcnastevilka")
                    .HasMaxLength(25);

                entity.Property(e => e.Oznaka)
                    .HasColumnName("oznaka")
                    .HasMaxLength(250);

                entity.Property(e => e.Processed).HasColumnName("processed");

                entity.Property(e => e.Recno)
                    .HasColumnName("recno")
                    .HasMaxLength(50);

                entity.Property(e => e.Toprocess)
                    .IsRequired()
                    .HasColumnName("toprocess")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });
        }
    }
}
