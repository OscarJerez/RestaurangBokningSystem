using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestaurangBokningSystem.Models;

public partial class RestaurangBokningSystemContext : DbContext
{
    public RestaurangBokningSystemContext()
    {
    }

    public RestaurangBokningSystemContext(DbContextOptions<RestaurangBokningSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MariaRachosPC\\SQLEXPRESS;Database=RestaurangBokningSystem;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestsId).HasName("PK__Guests__839947E1702BD5A3");

            entity.Property(e => e.GuestsId)
                .ValueGeneratedNever()
                .HasColumnName("GuestsID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefonnummer)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF15335A99");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F04DC55D2B4");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Reservati__Table__3C69FB99");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Tables__7D5F018E9CBE59BD");

            entity.HasIndex(e => e.TableNumber, "UQ__Tables__E8E0DB52924B243D").IsUnique();

            entity.Property(e => e.TableId).HasColumnName("TableID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
