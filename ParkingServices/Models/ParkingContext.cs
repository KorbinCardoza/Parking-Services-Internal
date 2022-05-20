using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ParkingServices.Models
{
    public partial class ParkingContext : DbContext
    {
        public ParkingContext()
        {
        }

        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<ComplaintType> ComplaintTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.Property(e => e.State).IsFixedLength(true);

                entity.Property(e => e.Zip).IsFixedLength(true);

                entity.HasOne(d => d.ComplaintTypeNavigation)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.ComplaintType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplaintType");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Complaints)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Staff");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
