using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaBiblioteca.AppWebMVC.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autores { get; set; }

    public virtual DbSet<Editorial> Editoriales { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Autores__3214EC074DE2887F");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Editoria__3214EC072B09D482");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Generos__3214EC07F4DBC434");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libros__3214EC077793AFCC");

            entity.Property(e => e.AutorId).HasColumnName("AutorID");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("FK__Libros__AutorID__4F7CD00D");

            entity.HasOne(d => d.Editorial).WithMany(p => p.Libros)
                .HasForeignKey(d => d.EditorialId)
                .HasConstraintName("FK__Libros__Editoria__5070F446");

            entity.HasMany(d => d.Generos).WithMany(p => p.Libros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibrosGenero",
                    r => r.HasOne<Genero>().WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Libros_Ge__Gener__5441852A"),
                    l => l.HasOne<Libro>().WithMany()
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Libros_Ge__Libro__534D60F1"),
                    j =>
                    {
                        j.HasKey("LibroId", "GeneroId").HasName("PK__Libros_G__AF383CC9BCC3CDD0");
                        j.ToTable("Libros_Generos");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC0780B087E3");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053431A6E3F4").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estatus).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UltimoInicioSesion).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
