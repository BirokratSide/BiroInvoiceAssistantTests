using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

using Common.utils;

namespace Tests.Models1
{
    public partial class birosideContext : DbContext
    {

        IConfiguration Configuration;
        string ConnectionString;

        public birosideContext()
        {
            LoadFromSettings();
        }

        public birosideContext(DbContextOptions<birosideContext> options)
            : base(options)
        {
            LoadFromSettings();
        }

        public void LoadFromSettings()
        {
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

        public virtual DbSet<BufferHistoryLog> BufferHistoryLog { get; set; }
        public virtual DbSet<InvoiceBuffer> InvoiceBuffer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BufferHistoryLog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditionalParams)
                    .HasColumnName("additional_params")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasColumnName("company_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyYearId)
                    .IsRequired()
                    .HasColumnName("company_year_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVnosa)
                    .IsRequired()
                    .HasColumnName("datum_vnosa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedBy).HasColumnName("finished_by");

                entity.Property(e => e.FinishedGross)
                    .HasColumnName("finished_gross")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedGross0)
                    .HasColumnName("finished_gross_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedGrossM)
                    .HasColumnName("finished_gross_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedGrossV)
                    .HasColumnName("finished_gross_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedInvDate)
                    .HasColumnName("finished_inv_date")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedInvNum)
                    .HasColumnName("finished_inv_num")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNet)
                    .HasColumnName("finished_net")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNet0)
                    .HasColumnName("finished_net_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNetM)
                    .HasColumnName("finished_net_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNetV)
                    .HasColumnName("finished_net_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedPayUntil)
                    .HasColumnName("finished_pay_until")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedReference)
                    .HasColumnName("finished_reference")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedTime)
                    .HasColumnName("finished_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinishedVat)
                    .HasColumnName("finished_vat")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVat0)
                    .HasColumnName("finished_vat_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatIdBuyer)
                    .HasColumnName("finished_vat_id_buyer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatIdPublished)
                    .HasColumnName("finished_vat_id_published")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatM)
                    .HasColumnName("finished_vat_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatV)
                    .HasColumnName("finished_vat_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LockedBy).HasColumnName("locked_by");

                entity.Property(e => e.LockedTime)
                    .HasColumnName("locked_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Oznaka)
                    .IsRequired()
                    .HasColumnName("oznaka")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedTime)
                    .HasColumnName("processed_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecNo)
                    .IsRequired()
                    .HasColumnName("rec_no")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RihGross)
                    .HasColumnName("rih_gross")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihGross0)
                    .HasColumnName("rih_gross_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihGrossM)
                    .HasColumnName("rih_gross_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihGrossV)
                    .HasColumnName("rih_gross_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihInvDate)
                    .HasColumnName("rih_inv_date")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihInvNum)
                    .HasColumnName("rih_inv_num")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihNet)
                    .HasColumnName("rih_net")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihNet0)
                    .HasColumnName("rih_net_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihNetM)
                    .HasColumnName("rih_net_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihNetV)
                    .HasColumnName("rih_net_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihPayUntil)
                    .HasColumnName("rih_pay_until")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihReference)
                    .HasColumnName("rih_reference")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihVat)
                    .HasColumnName("rih_vat")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihVat0)
                    .HasColumnName("rih_vat_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatIdBuyer)
                    .HasColumnName("rih_vat_id_buyer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatIdPublisher)
                    .HasColumnName("rih_vat_id_publisher")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatM)
                    .HasColumnName("rih_vat_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatV)
                    .HasColumnName("rih_vat_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Vrsta)
                    .IsRequired()
                    .HasColumnName("vrsta")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InvoiceBuffer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditionalParams)
                    .HasColumnName("additional_params")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasColumnName("company_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyYearId)
                    .IsRequired()
                    .HasColumnName("company_year_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DatumVnosa)
                    .IsRequired()
                    .HasColumnName("datum_vnosa")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedBy).HasColumnName("finished_by");

                entity.Property(e => e.FinishedGross)
                    .HasColumnName("finished_gross")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedGross0)
                    .HasColumnName("finished_gross_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedGrossM)
                    .HasColumnName("finished_gross_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedGrossV)
                    .HasColumnName("finished_gross_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedInvDate)
                    .HasColumnName("finished_inv_date")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedInvNum)
                    .HasColumnName("finished_inv_num")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNet)
                    .HasColumnName("finished_net")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNet0)
                    .HasColumnName("finished_net_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNetM)
                    .HasColumnName("finished_net_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedNetV)
                    .HasColumnName("finished_net_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedPayUntil)
                    .HasColumnName("finished_pay_until")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedReference)
                    .HasColumnName("finished_reference")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedTime)
                    .HasColumnName("finished_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinishedVat)
                    .HasColumnName("finished_vat")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVat0)
                    .HasColumnName("finished_vat_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatIdBuyer)
                    .HasColumnName("finished_vat_id_buyer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatIdPublished)
                    .HasColumnName("finished_vat_id_published")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatM)
                    .HasColumnName("finished_vat_M")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedVatV)
                    .HasColumnName("finished_vat_V")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LockedBy).HasColumnName("locked_by");

                entity.Property(e => e.LockedTime)
                    .HasColumnName("locked_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Oznaka)
                    .IsRequired()
                    .HasColumnName("oznaka")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedTime)
                    .HasColumnName("processed_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecNo)
                    .IsRequired()
                    .HasColumnName("rec_no")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RihGross)
                    .HasColumnName("rih_gross")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihGross0)
                    .HasColumnName("rih_gross_0")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihGrossM)
                    .HasColumnName("rih_gross_M")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihGrossV)
                    .HasColumnName("rih_gross_V")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihInvDate)
                    .HasColumnName("rih_inv_date")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihInvNum)
                    .HasColumnName("rih_inv_num")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihNet)
                    .HasColumnName("rih_net")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihNet0)
                    .HasColumnName("rih_net_0")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihNetM)
                    .HasColumnName("rih_net_M")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihNetV)
                    .HasColumnName("rih_net_V")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihPayUntil)
                    .HasColumnName("rih_pay_until")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihReference)
                    .HasColumnName("rih_reference")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihVat)
                    .HasColumnName("rih_vat")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihVat0)
                    .HasColumnName("rih_vat_0")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatIdBuyer)
                    .HasColumnName("rih_vat_id_buyer")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatIdPublisher)
                    .HasColumnName("rih_vat_id_publisher")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatM)
                    .HasColumnName("rih_vat_M")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RihVatV)
                    .HasColumnName("rih_vat_V")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Vrsta)
                    .IsRequired()
                    .HasColumnName("vrsta")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
