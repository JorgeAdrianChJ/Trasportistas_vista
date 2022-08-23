using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trasportistas_vista.Models
{
    public partial class BD_TRASPORTISTASContext : DbContext
    {
        public BD_TRASPORTISTASContext()
        {
        }

        public BD_TRASPORTISTASContext(DbContextOptions<BD_TRASPORTISTASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArticuloCustodium> ArticuloCustodia { get; set; } = null!;
        public virtual DbSet<ArticuloRetirado> ArticuloRetirados { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Trasportistum> Trasportista { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BD_TRASPORTISTAS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloCustodium>(entity =>
            {
                entity.ToTable("articuloCustodia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteCodigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("clienteCodigo")
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.Peso)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("peso");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.TrakingId)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("trakingId");

                entity.Property(e => e.TrasportistaCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("trasportistaCodigo")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArticuloRetirado>(entity =>
            {
                entity.ToTable("articuloRetirado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteCodigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("clienteCodigo")
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaRetiro)
                    .HasColumnType("date")
                    .HasColumnName("fechaRetiro");

                entity.Property(e => e.TrakingId)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("trakingId");

                entity.Property(e => e.TrasportistaCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("trasportistaCodigo")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo")
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fechaNacimiento");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("identificacion")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Trasportistum>(entity =>
            {
                entity.ToTable("trasportista");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("codigo")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
