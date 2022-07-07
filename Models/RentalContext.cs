using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class RentalContext : IdentityDbContext
    {
        public RentalContext()
        {
        }

        public RentalContext(DbContextOptions<RentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarMake> CarMakes { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<RentalReturn> RentalReturns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("body_type");

                entity.Property(e => e.BodyTypeId).HasColumnName("body_type_id");

                entity.Property(e => e.BodyDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("body_description");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.Property(e => e.CarId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("car_id");

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("available");

                entity.Property(e => e.BodyTypeId).HasColumnName("body_type_id");

                entity.Property(e => e.KilometersTraveled).HasColumnName("kilometers_traveled");

                entity.Property(e => e.MakeId).HasColumnName("make_id");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.ServiceKilometers).HasColumnName("service_kilometers");

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarBodyType");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarMake");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarModel");
            });

            modelBuilder.Entity<CarMake>(entity =>
            {
                entity.HasKey(e => e.MakeId)
                    .HasName("PK__car_make__335C91D8E2A4472D");

                entity.ToTable("car_make");

                entity.Property(e => e.MakeId).HasColumnName("make_id");

                entity.Property(e => e.MakeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("make_description");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK__car_mode__DC39CAF4243C344F");

                entity.ToTable("car_model");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.ModelDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model_description");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.DriverId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("driver_id");

                entity.Property(e => e.DriverAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("driver_address");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("driver_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobile_number");
            });

            modelBuilder.Entity<Inspector>(entity =>
            {
                entity.ToTable("inspector");

                entity.Property(e => e.InspectorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("inspector_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.InspectorName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("inspector_name");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobile_number");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("rental");

                entity.Property(e => e.RentalId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("rental_id");

                entity.Property(e => e.CarId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("car_id");

                entity.Property(e => e.DriverId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("driver_id");

                entity.Property(e => e.InspectorId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("inspector_id");

                entity.Property(e => e.RentalEndDate)
                    .HasColumnType("date")
                    .HasColumnName("rental_end_date");

                entity.Property(e => e.RentalFee)
                    .HasColumnType("money")
                    .HasColumnName("rental_fee");

                entity.Property(e => e.RentalStartDate)
                    .HasColumnType("date")
                    .HasColumnName("rental_start_date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalCar");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalDriver");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.InspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentalInspector");
            });

            modelBuilder.Entity<RentalReturn>(entity =>
            {
                entity.HasKey(e => e.ReturnId)
                    .HasName("PK__rental_r__35C2347375427712");

                entity.ToTable("rental_returns");

                entity.Property(e => e.ReturnId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("return_id");

                entity.Property(e => e.DailyFine)
                    .HasColumnType("money")
                    .HasColumnName("daily_fine");

                entity.Property(e => e.InspectorId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("inspector_id");

                entity.Property(e => e.RentalId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("rental_id");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("return_date");

                entity.HasOne(d => d.Inspector)
                    .WithMany(p => p.RentalReturns)
                    .HasForeignKey(d => d.InspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReturnInspector");

                entity.HasOne(d => d.Rental)
                    .WithMany(p => p.RentalReturns)
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReturnRental");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
