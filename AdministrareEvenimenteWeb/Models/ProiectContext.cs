using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdministrareEvenimenteWeb.Models
{
    public partial class ProiectContext : DbContext
    {
        public ProiectContext()
        {
        }

        public ProiectContext(DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administreaza> Administreazas { get; set; } = null!;
        public virtual DbSet<Angajat> Angajats { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Eveniment> Eveniments { get; set; } = null!;
        public virtual DbSet<Gestionare> Gestionares { get; set; } = null!;
        public virtual DbSet<LocatieEveniment> LocatieEveniments { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Sediu> Sedius { get; set; } = null!;
        public virtual DbSet<Servicii> Serviciis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PGCSFV3; Database=Proiect; User ID=test; Password=test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administreaza>(entity =>
            {
                entity.HasKey(e => e.IdAdministreaza)
                    .HasName("PK__ADMINIST__8F82101E001D1E0B");

                entity.ToTable("ADMINISTREAZA");

                entity.Property(e => e.IdAdministreaza).HasColumnName("idAdministreaza");

                entity.Property(e => e.IdModel).HasColumnName("idModel");

                entity.Property(e => e.IdServicii).HasColumnName("idServicii");

                entity.HasOne(d => d.IdModelNavigation)
                    .WithMany(p => p.Administreazas)
                    .HasForeignKey(d => d.IdModel)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__ADMINISTR__idMod__571DF1D5");

                entity.HasOne(d => d.IdServiciiNavigation)
                    .WithMany(p => p.Administreazas)
                    .HasForeignKey(d => d.IdServicii)
                    .HasConstraintName("FK__ADMINISTR__idSer__5629CD9C");
            });

            modelBuilder.Entity<Angajat>(entity =>
            {
                entity.HasKey(e => e.IdAngajat)
                    .HasName("PK__ANGAJAT__E09DCAF41A8F2753");

                entity.ToTable("ANGAJAT");

                entity.HasIndex(e => e.Telefon, "UQ__ANGAJAT__237247E203D2C444")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__ANGAJAT__AB6E6164B5268994")
                    .IsUnique();

                entity.Property(e => e.IdAngajat).HasColumnName("idAngajat");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdSediu).HasColumnName("idSediu");

                entity.Property(e => e.IdServicii).HasColumnName("idServicii");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nume");

                entity.Property(e => e.Prenume)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prenume");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telefon");

                entity.HasOne(d => d.IdSediuNavigation)
                    .WithMany(p => p.Angajats)
                    .HasForeignKey(d => d.IdSediu)
                    .HasConstraintName("FK__ANGAJAT__idSediu__5070F446");

                entity.HasOne(d => d.IdServiciiNavigation)
                    .WithMany(p => p.Angajats)
                    .HasForeignKey(d => d.IdServicii)
                    .HasConstraintName("FK__ANGAJAT__idServi__5165187F");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__CLIENT__A6A610D439B9A404");

                entity.ToTable("CLIENT");

                entity.HasIndex(e => e.Telefon, "UQ__CLIENT__237247E287DD4EB5")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__CLIENT__AB6E6164C46ECDF9")
                    .IsUnique();

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nume)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nume");

                entity.Property(e => e.Prenume)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prenume");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telefon");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("PK__CONTRACT__9145BAA3AB05675E");

                entity.ToTable("CONTRACT");

                entity.Property(e => e.IdContract).HasColumnName("idContract");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.IdServicii).HasColumnName("idServicii");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__CONTRACT__idClie__5DCAEF64");

                entity.HasOne(d => d.IdServiciiNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdServicii)
                    .HasConstraintName("FK__CONTRACT__idServ__5EBF139D");
            });

            modelBuilder.Entity<Eveniment>(entity =>
            {
                entity.HasKey(e => e.IdEveniment)
                    .HasName("PK__EVENIMEN__943E913F0CBA4236");

                entity.ToTable("EVENIMENT");

                entity.Property(e => e.IdEveniment).HasColumnName("idEveniment");

                entity.Property(e => e.DataOraInceperii)
                    .HasColumnType("datetime")
                    .HasColumnName("dataOraInceperii");

                entity.Property(e => e.DataOraIncheierii)
                    .HasColumnType("datetime")
                    .HasColumnName("dataOraIncheierii");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.NumeEveniment)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numeEveniment");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Eveniments)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK__EVENIMENT__idCli__619B8048");
            });

            modelBuilder.Entity<Gestionare>(entity =>
            {
                entity.HasKey(e => e.IdGestionare)
                    .HasName("PK__GESTIONA__D2270187648F8012");

                entity.ToTable("GESTIONARE");

                entity.Property(e => e.IdGestionare).HasColumnName("idGestionare");

                entity.Property(e => e.IdEveniment).HasColumnName("idEveniment");

                entity.Property(e => e.IdLocatieEveniment).HasColumnName("idLocatieEveniment");

                entity.HasOne(d => d.IdEvenimentNavigation)
                    .WithMany(p => p.Gestionares)
                    .HasForeignKey(d => d.IdEveniment)
                    .HasConstraintName("FK__GESTIONAR__idEve__66603565");

                entity.HasOne(d => d.IdLocatieEvenimentNavigation)
                    .WithMany(p => p.Gestionares)
                    .HasForeignKey(d => d.IdLocatieEveniment)
                    .HasConstraintName("FK__GESTIONAR__idLoc__6754599E");
            });

            modelBuilder.Entity<LocatieEveniment>(entity =>
            {
                entity.HasKey(e => e.IdLocatieEveniment)
                    .HasName("PK__LOCATIE___8FAB04350A68D801");

                entity.ToTable("LOCATIE_EVENIMENT");

                entity.Property(e => e.IdLocatieEveniment).HasColumnName("idLocatieEveniment");

                entity.Property(e => e.Judet)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("judet");

                entity.Property(e => e.Localitate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("localitate");

                entity.Property(e => e.Numar)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("numar");

                entity.Property(e => e.NumeLocatie)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numeLocatie");

                entity.Property(e => e.Strada)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strada");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.IdModel)
                    .HasName("PK__MODEL__144F1E55B630DF5D");

                entity.ToTable("MODEL");

                entity.Property(e => e.IdModel).HasColumnName("idModel");

                entity.Property(e => e.Culoare)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("culoare");

                entity.Property(e => e.Model1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("model");
            });

            modelBuilder.Entity<Sediu>(entity =>
            {
                entity.HasKey(e => e.IdSediu)
                    .HasName("PK__SEDIU__A7D99FDEAFB92425");

                entity.ToTable("SEDIU");

                entity.Property(e => e.IdSediu).HasColumnName("idSediu");

                entity.Property(e => e.Judet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("judet");

                entity.Property(e => e.Localitate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("localitate");

                entity.Property(e => e.Numar).HasColumnName("numar");

                entity.Property(e => e.Strada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strada");
            });

            modelBuilder.Entity<Servicii>(entity =>
            {
                entity.HasKey(e => e.IdServicii)
                    .HasName("PK__SERVICII__CEB9811FFB7141F9");

                entity.ToTable("SERVICII");

                entity.HasIndex(e => e.NumeServiciu, "UQ__SERVICII__6E39CFFB9F301136")
                    .IsUnique();

                entity.Property(e => e.IdServicii).HasColumnName("idServicii");

                entity.Property(e => e.NumeServiciu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeServiciu");

                entity.Property(e => e.PretServiciu).HasColumnName("pretServiciu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
