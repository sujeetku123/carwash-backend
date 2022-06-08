using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Myproject.Models
{
    public partial class MyDataBaseContext : DbContext
    {
        public MyDataBaseContext()
        {
        }

        public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<CarDetail> CarDetails { get; set; } = null!;
        public virtual DbSet<CarserviceFeedback> CarserviceFeedbacks { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<ServiceLogin> ServiceLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-9NIG3NRQ;Database=MyDataBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<CarDetail>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__CarDetai__87355E7297B3B789");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CarModel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carModel");

                entity.Property(e => e.CarType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carType");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contactNumber");

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PreferredTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("preferredTime");

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serviceType");

                entity.Property(e => e.Subscription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subscription");
            });

            modelBuilder.Entity<CarserviceFeedback>(entity =>
            {
                entity.HasKey(e => e.FeedbackId)
                    .HasName("PK__Carservi__7A6B2B8CCE4E6D06");

                entity.ToTable("Carservice_Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.FeedbackComments)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("feedback_comments");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.RatingValue)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("Rating_Value");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__Customer__87355E72420DD002");

                entity.ToTable("Customer");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<ServiceLogin>(entity =>
            {
                entity.ToTable("ServiceLogin");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailId");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
