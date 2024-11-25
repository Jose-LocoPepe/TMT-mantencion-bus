using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace TMT_mantencion.Models;

public partial class TransporteContext : DbContext
{
    public TransporteContext()
    {
    }

    public TransporteContext(DbContextOptions<TransporteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bus> Buses { get; set; }

    public virtual DbSet<Chofer> Choferes { get; set; }

    public virtual DbSet<Tramo> Tramos { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Load environment variables from .env file
        DotNetEnv.Env.Load();

        // Get the connection string from environment variables
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DB_CONNECTION_STRING environment variable is not set.");
        }

        optionsBuilder.UseMySQL(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bus");

            entity.HasIndex(e => e.Patente, "patente").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.Kilometros).HasColumnName("kilometros");
            entity.Property(e => e.Patente)
                .HasMaxLength(50)
                .HasColumnName("patente");
        });

        modelBuilder.Entity<Chofer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chofer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");
            entity.Property(e => e.Kilometros).HasColumnName("kilometros");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tramo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tramo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Distancia).HasColumnName("distancia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("viaje");

            entity.HasIndex(e => e.IdBus, "id_bus");

            entity.HasIndex(e => e.IdChofer, "id_chofer");

            entity.HasIndex(e => e.IdTramo, "id_tramo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdBus).HasColumnName("id_bus");
            entity.Property(e => e.IdChofer).HasColumnName("id_chofer");
            entity.Property(e => e.IdTramo).HasColumnName("id_tramo");

            entity.HasOne(d => d.IdBusNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdBus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viaje_ibfk_1");

            entity.HasOne(d => d.IdChoferNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdChofer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viaje_ibfk_2");

            entity.HasOne(d => d.IdTramoNavigation).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.IdTramo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("viaje_ibfk_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
