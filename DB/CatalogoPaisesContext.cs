using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CatalogoPaises.DB;

public partial class CatalogoPaisesContext : DbContext
{
    public CatalogoPaisesContext()
    {
    }

    public CatalogoPaisesContext(DbContextOptions<CatalogoPaisesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotele> Hoteles { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Restaurante> Restaurantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotele>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoteles__3214EC2747D66A9B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreHotel).HasMaxLength(100);
            entity.Property(e => e.PaisId).HasColumnName("PaisID");

            entity.HasOne(d => d.Pais).WithMany(p => p.Hoteles)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK_Hoteles_Paises");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paises__3214EC27390FB2B7");

            entity.HasIndex(e => e.NombrePais, "IX_NombrePais");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoIso)
                .HasMaxLength(5)
                .HasColumnName("CodigoISO");
            entity.Property(e => e.NombrePais).HasMaxLength(100);
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Restaura__3214EC276C8D2E27");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreRestaurante).HasMaxLength(100);
            entity.Property(e => e.PaisId).HasColumnName("PaisID");

            entity.HasOne(d => d.Pais).WithMany(p => p.Restaurantes)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK_Restaurantes_Paises");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
