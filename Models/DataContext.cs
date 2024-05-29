using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GProyectosEmpleados.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competencia> Competencias { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competencia>(entity =>
        {
            entity.HasKey(e => e.IdCompetencia).HasName("PK__Competen__DA802ADDC664056F");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation).WithMany(p => p.Competencia)
                .HasForeignKey(d => d.EmpleadoIdEmpleado)
                .HasConstraintName("FK__Competenc__Emple__4222D4EF");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DA2182D60");

            entity.ToTable("Departamento");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E57BA1C96");

            entity.ToTable("Empleado");

            entity.Property(e => e.Cargo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DptoIdDptoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DptoIdDpto)
                .HasConstraintName("FK__Empleado__DptoId__398D8EEE");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__F4888673112FB2F7");

            entity.ToTable("Proyecto");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.DptoIdDptoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.DptoIdDpto)
                .HasConstraintName("FK__Proyecto__DptoId__3C69FB99");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CA70904A7");

            entity.ToTable("Rol");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation).WithMany(p => p.Rols)
                .HasForeignKey(d => d.EmpleadoIdEmpleado)
                .HasConstraintName("FK__Rol__EmpleadoIdE__3F466844");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE90985E4204B2");

            entity.ToTable("Tarea");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.EmpleadoIdEmpleadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.EmpleadoIdEmpleado)
                .HasConstraintName("FK__Tarea__EmpleadoI__44FF419A");

            entity.HasOne(d => d.ProyectoIdProyectoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ProyectoIdProyecto)
                .HasConstraintName("FK__Tarea__ProyectoI__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
