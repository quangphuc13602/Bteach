using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EDuBee.Models
{
    public partial class EDUBEE1Context : DbContext
    {
        public EDUBEE1Context()
        {
        }

        public EDUBEE1Context(DbContextOptions<EDUBEE1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=EDUBEE1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasKey(e => e.Idattribute)
                    .HasName("PK__Attribut__3F710007DB601909");

                entity.Property(e => e.Idattribute).HasColumnName("IDAttribute");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Value).HasMaxLength(255);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory)
                    .HasName("PK__Category__1AA1EC6672AD009C");

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Idclass)
                    .HasName("PK__Class__778C6D9B71A01F5B");

                entity.Property(e => e.Idclass).HasColumnName("IDClass");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.Idschool)
                    .HasConstraintName("FK__Class__IDSchool__2DE6D218");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Iddistrict)
                    .HasName("PK__District__D21CA39967BD2235");

                entity.Property(e => e.Iddistrict)
                    .HasColumnName("IDDistrict")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idprovince).HasColumnName("IDProvince");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.Iddocument)
                    .HasName("PK__Document__42F9550FD3054E08");

                entity.Property(e => e.Iddocument).HasColumnName("IDDocument");

                entity.Property(e => e.Contents).HasColumnType("text");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.File)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idattribute)
                    .HasColumnName("IDAttribute")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Summary).HasColumnType("text");

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.Idcategory)
                    .HasConstraintName("FK__Document__IDCate__37703C52");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Idprovince)
                    .HasName("PK__Province__5A186F033133ED47");

                entity.Property(e => e.Idprovince)
                    .HasColumnName("IDProvince")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Idrole)
                    .HasName("PK__Role__A1BA16C4A0E110A2");

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Summary)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Idschool)
                    .HasName("PK__School__41E8DACC23232C0F");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Iddistrict).HasColumnName("IDDistrict");

                entity.Property(e => e.Idprovince).HasColumnName("IDProvince");

                entity.Property(e => e.Idward).HasColumnName("IDWard");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.IduserAccount)
                    .HasName("PK__UserAcco__44D40C86C3DFCD81");

                entity.Property(e => e.IduserAccount).HasColumnName("IDUserAccount");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.Idrole)
                    .HasConstraintName("FK__UserAccou__IDRol__31B762FC");

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.Idschool)
                    .HasConstraintName("FK__UserAccou__IDSch__30C33EC3");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.HasKey(e => e.Idward)
                    .HasName("PK__Ward__62E45365998F47C8");

                entity.Property(e => e.Idward)
                    .HasColumnName("IDWard")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iddistrict).HasColumnName("IDDistrict");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
