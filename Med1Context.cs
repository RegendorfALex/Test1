using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API;

public partial class Med1Context : DbContext
{
    public Med1Context()
    {
    }

    public Med1Context(DbContextOptions<Med1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Daigno> Daignos { get; set; }

    public virtual DbSet<Gospitalisation> Gospitalisations { get; set; }

    public virtual DbSet<MedCard> MedCards { get; set; }

    public virtual DbSet<Pacient> Pacients { get; set; }

    public virtual DbSet<Procedur> Procedurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = HOME-PC; Initial Catalog = Med_1; Integrated Security = true; encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Daigno>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiagnosName).HasMaxLength(50);
        });

        modelBuilder.Entity<Gospitalisation>(entity =>
        {
            entity.ToTable("Gospitalisation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateEnd).HasColumnType("smalldatetime");
            entity.Property(e => e.DateGospitalisation).HasColumnType("smalldatetime");
            entity.Property(e => e.DateStart).HasColumnType("smalldatetime");
            entity.Property(e => e.IdPacient).HasColumnName("idPacient");
            entity.Property(e => e.Job)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NameDiagnos)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Otdelenie)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PolisCompany).HasColumnType("smalldatetime");
            entity.Property(e => e.PolisEnd).HasColumnType("smalldatetime");
            entity.Property(e => e.PolisNumber)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PolisStart).HasColumnType("smalldatetime");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdPacientNavigation).WithMany(p => p.Gospitalisations)
                .HasForeignKey(d => d.IdPacient)
                .HasConstraintName("FK_Gospitalisation_Pacients");
        });

        modelBuilder.Entity<MedCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Obrashenie");

            entity.ToTable("MedCard");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatePolis).HasColumnType("smalldatetime");
            entity.Property(e => e.DateFuture).HasColumnType("smalldatetime");
            entity.Property(e => e.DateLast).HasColumnType("smalldatetime");
            entity.Property(e => e.EndPolis).HasColumnType("smalldatetime");
            entity.Property(e => e.IdPacient).HasColumnName("idPacient");
            entity.Property(e => e.PolisCompany)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdPacientNavigation).WithMany(p => p.MedCards)
                .HasForeignKey(d => d.IdPacient)
                .HasConstraintName("FK_MedCard_Pacients");
        });

        modelBuilder.Entity<Pacient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pacienti");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Born).HasColumnType("smalldatetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.F).HasMaxLength(50);
            entity.Property(e => e.I).HasMaxLength(50);
            entity.Property(e => e.IdMedCard).HasColumnName("idMedCard");
            entity.Property(e => e.O).HasMaxLength(50);
            entity.Property(e => e.PasportAdres).HasMaxLength(50);
            entity.Property(e => e.PasportSeria).HasMaxLength(50);
            entity.Property(e => e.Photo)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Rabota)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdMedCardNavigation).WithMany(p => p.Pacients)
                .HasForeignKey(d => d.IdMedCard)
                .HasConstraintName("FK_Pacients_MedCard");
        });

        modelBuilder.Entity<Procedur>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.IdDiagnos).HasColumnName("idDiagnos");
            entity.Property(e => e.IdMedCard).HasColumnName("idMedCard");
            entity.Property(e => e.IdPacient).HasColumnName("idPacient");
            entity.Property(e => e.ProcedurName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Recomendation)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Result)
                .HasMaxLength(500)
                .IsFixedLength();

            entity.HasOne(d => d.IdDiagnosNavigation).WithMany(p => p.Procedurs)
                .HasForeignKey(d => d.IdDiagnos)
                .HasConstraintName("FK_Procedurs_Daignos");

            entity.HasOne(d => d.IdPacientNavigation).WithMany(p => p.Procedurs)
                .HasForeignKey(d => d.IdPacient)
                .HasConstraintName("FK_Procedurs_Pacients");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
