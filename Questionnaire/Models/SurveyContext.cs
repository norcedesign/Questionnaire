using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Questionnaire.Models
{
    public partial class SurveyContext : DbContext
    {
        public SurveyContext()
        {
        }

        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Entite> Entite { get; set; }
        public virtual DbSet<Formulaire> Formulaire { get; set; }
        public virtual DbSet<Localizations> Localizations { get; set; }
        //public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionFormulaire> QuestionFormulaire { get; set; }
        public virtual DbSet<Reponse> Reponse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"data source=Omega;initial catalog=Survey;user id=WebUser;password=WebUser;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Entite>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DateCompletion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Formulaire>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");

                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Localizations>(entity =>
            {
                entity.HasKey(e => e.Pk);

                entity.Property(e => e.Pk).HasColumnName("pk");

                entity.Property(e => e.Comment).HasMaxLength(512);

                entity.Property(e => e.Filename)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LocaleId)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ResourceId)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.ResourceSet)
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .HasMaxLength(512)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Value).HasDefaultValueSql("('')");

                entity.Property(e => e.ValueType).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Label).HasMaxLength(500);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Option_Question");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Label).HasMaxLength(500);

                entity.Property(e => e.Type).HasMaxLength(10);
            });

            modelBuilder.Entity<QuestionFormulaire>(entity =>
            {
                entity.HasOne(d => d.Form)
                    .WithMany(p => p.QuestionFormulaire)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionFormulaire_Formulaire");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionFormulaire)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionFormulaire_Question");
            });

            modelBuilder.Entity<Reponse>(entity =>
            {
                entity.HasOne(d => d.Entite)
                    .WithMany(p => p.Reponse)
                    .HasForeignKey(d => d.EntiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reponse_Entite");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Reponse)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reponse_Formulaire");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Reponse)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reponse_Option");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.Reponse)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reponse_Question");
            });
        }
    }
}
